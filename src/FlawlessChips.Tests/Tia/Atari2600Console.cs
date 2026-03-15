namespace FlawlessChips.Tests;

/// <summary>
/// Based on https://github.com/tgjones/sim2600-cs/blob/b4bc0f5e3366cbf1b51095b74f2e50ccd616908d/src/Sim2600/Sim2600Console.cs
/// </summary>
internal sealed class Atari2600Console
{
    public readonly Flawless6502 Sim6507 = new();
    public readonly FlawlessTia SimTIA = new();
    public readonly EmulatedPia EmuPIA = new();

    public int HalfClkCount { get; private set; }

    private byte[] _rom = new byte[4096];
    public int BankSwitchROMOffset;
    private int _programLen;

    public Atari2600Console(byte[] romBytes)
    {
        LoadProgram(romBytes);

        Sim6507.Startup();
        SimTIA.Startup();

        // The 6507's IRQ and NMI are connected to the supply voltage
        // Setting them to 'pulled high' will keep them high.
        Sim6507.SetHigh(Flawless6502.NodeIds.irq);
        Sim6507.SetHigh(Flawless6502.NodeIds.nmi);

        // TIA CS1 is always high. !CS2 is always grounded
        SimTIA.SetHigh(FlawlessTia.NodeIds.CS1);
        SimTIA.SetLow(FlawlessTia.NodeIds.CS2);

        // We're running an Atari 2600 program, so set memory locations
        // for the console's switches and joystick state.
        // Console switches:
        // d3 set to 1 for color (vs B&W), 
        // d1 select set to 1 for 'switch not pressed'
        // d0 set to 1 switch 
        WriteMemory(0x0282, 0x0B, true);

        // No joystick motion
        // joystick trigger buttons read on bit 7 of INPT4 and INPT5 of TIA
        WriteMemory(0x0280, 0xFF, true);
    }

    /// <summary>
    /// Memory is mapped as follows:
    /// 0x00 - 0x2C  write to TIA
    /// 0x30 - 0x3D  read from TIA
    /// 0x80 - 0xFF  PIA RAM (128 bytes), also mapped to 0x0180 - 0x01FF for the stack
    /// 0280 - 0297  PIA i/o ports and timer
    /// F000 - FFFF  Cartridge memory, 4kb
    /// We handle 2k, 4k, and 8k cartridges, but only handle the bank switching
    /// operations used by Asteroids:  write to 0xFFF8 or 0xFFF9
    /// </summary>
    private byte ReadMemory(ushort addr)
    {
        if (addr > 0x02FF && addr < 0x8000)
        {
            Console.WriteLine($"ERROR: 6507 ROM reading addr from 0x1000 to 0x1FFF: 0x{addr:X4}");
            return 0;
        }

        byte data = 0;
        if ((addr >= 0x80 && addr <= 0xFF) || (addr >= 0x180 && addr <= 0x1FF))
        {
            data = EmuPIA.Ram[(addr & 0xFF) - 0x80];
        }
        else if (addr >= 0x0280 && addr <= 0x0297)
        {
            data = EmuPIA.Iot[addr - 0x0280];
        }
        else if (addr >= 0xF000 || (addr >= 0xD000 && addr <= 0xDFFF && _programLen == 8192))
        {
            data = _rom[(addr & 0x0FFF) + BankSwitchROMOffset];
        }
        else if (addr >= 0x30 && addr <= 0x3D)
        {
            // This is a read from the TIA where the value is
            // controlled by the TIA data bus bits 6 and 7 drive-low
            // and drive-high gates: DB6_drvLo, DB6_drvHi, etc.
            // This is handled below, so no need for anything here
        }
        else if (addr <= 0x2C || (addr >= 0x100 && addr <= 0x12C))
        {
            // This happens all the time, usually at startup when
            // setting data at all writeable addresses to 0.
            //Console.WriteLine($"CURIOUS: Attempt to read from TIA write-only address 0x{addr:X4}");
        }
        else
        {
            // This can happen when the 6507 is coming out of RESET.
            // It sets the first byte of the address bus, issues a read,
            // then sets the second byte, and issues another read to get
            // the correct reset vector.
            Console.WriteLine($"WARNING: Unhandled address in readMemory: 0x{addr:X4}");
        }

        var cpu = Sim6507;
        var tia = SimTIA;

        if (cpu.IsHigh(Flawless6502.NodeIds.sync))
        {
            foreach (var wireIndex in FlawlessTia.NodeIds.DBDrivers.NodeIds)
            {
                if (tia.IsHigh(wireIndex))
                {
                    Console.WriteLine($"ERROR: TIA driving DB when 6502 fetching instruction at addr 0x{addr:X4}");
                }
            }
        }
        else
        {
            if (tia.IsHigh(FlawlessTia.NodeIds.DB6_drvLo))
            {
                data &= (0xFF ^ (1 << 6));
            }
            if (tia.IsHigh(FlawlessTia.NodeIds.DB6_drvHi))
            {
                data |= (1 << 6);
            }
            if (tia.IsHigh(FlawlessTia.NodeIds.DB7_drvLo))
            {
                data &= (0xFF ^ (1 << 7));
            }
            if (tia.IsHigh(FlawlessTia.NodeIds.DB7_drvHi))
            {
                data |= (1 << 7);
            }
        }

        cpu.SetBus(Flawless6502.NodeIds.db, data);

        return data;
    }

    private void WriteMemory(ushort address, byte byteValue, bool setup = false)
    {
        var cpu = Sim6507;
        var tia = SimTIA;
        var pia = EmuPIA;

        if (!cpu.IsHigh(Flawless6502.NodeIds.res) && !setup)
        {
            Console.WriteLine($"Skipping 6507 write during reset.  addr: 0x{address:X4}");
            return;
        }

        if (address >= 0xF000 && !setup)
        {
            if (_programLen == 8192)
            {
                if (address == 0xFFF9)
                {
                    // Switch to bank 1 which starts at 0xD0000
                    BankSwitchROMOffset = 0x1000;
                }
                else if (address == 0xFFF8)
                {
                    BankSwitchROMOffset = 0x0000;
                }
            }
            else
            {
                var msg = $"6502 writing to ROM space addr 0x{address:X4} data 0x{byteValue:X2}";
                if (address >= 0xFFF4 && address <= 0xFFFB)
                {
                    msg += "  This is likely a bank switch strobe we have not implemented";
                }
                else if (address >= 0xF000 && address <= 0xF07F)
                {
                    msg += "  This is likely a cartridge RAM write we have not implemented";
                }
                throw new InvalidOperationException(msg);
            }
        }

        // 6502 shouldn't write to where we keep the console switches
        if ((address == 0x282 || address == 0x280) && !setup)
        {
            Console.WriteLine($"ERROR: 6507 writing to console or joystick switches addr 0x{address:X4}  data 0x{byteValue:X2}");
            return;
        }

        if (address < 0x280)
        {
            //Console.WriteLine($"6507 WRITE to [0x{address:X4}]: 0x{byteValue:X2}  at 6507 halfclock {cpu.HalfClkCount}");
        }

        if ((address >= 0x80 && address <= 0xFF) || (address >= 0x180 && address <= 0x1FF))
        {
            pia.Ram[(address & 0xFF) - 0x80] = byteValue;
        }
        else if (address >= 0x0280 && address <= 0x0297)
        {
            pia.Iot[address - 0x0280] = byteValue;

            int? period = address switch
            {
                0x294 => 1,
                0x295 => 8,
                0x296 => 64,
                0x297 => 1024,
                _ => null,
            };

            if (period != null)
            {
                pia.TimerPeriod = period.Value;
                // initial value for timer read from data bus
                pia.TimerValue = cpu.GetBus(Flawless6502.NodeIds.db);
                pia.TimerClockCount = 0;
                pia.TimerFinished = false;
            }
        }
        else if (address <= 0x2C)
        {
            //    # Remember what we wrote to the TIA write-only address
            //    # This is only for bookeeping and debugging and is not
            //    # used for simulation.
            // self.simTIA.lastControlValue[addr] = byteValue
        }
    }

    private void LoadProgramBytes(byte[] progByteList, ushort baseAddr, bool setResetVector)
    {
        var pch = (byte)(baseAddr >> 8);
        var pcl = (byte)(baseAddr & 0xFF);
        Console.WriteLine($"LoadProgramBytes base addr ${pch:X2}{pcl:X2}");

        var romDuplicate = 1;
        var programLen = progByteList.Length;
        _programLen = programLen;
        if (programLen != 2048 && programLen != 4096 && programLen != 8192)
        {
            throw new InvalidOperationException($"No support for program byte list of length {programLen}");
        }

        if (programLen == 2048)
        {
            // Duplicate ROM contents so it fills all of 0xF000 - 0xFFFF
            romDuplicate = 2;
        }
        else if (programLen == 8192)
        {
            BankSwitchROMOffset = 0x1000;
        }

        _rom = new byte[progByteList.Length * romDuplicate];
        for (var i = 0; i < romDuplicate; i++)
        {
            Array.Copy(progByteList, 0, _rom, progByteList.Length * i, progByteList.Length);
        }

        if (setResetVector)
        {
            Console.WriteLine("Setting program's reset vector to program's base address");
            WriteMemory(0xFFFC, pcl, true);
            WriteMemory(0xFFFD, pch, true);
        }
        else
        {
            pcl = ReadMemory(0xFFFA);
            pch = ReadMemory(0xFFFB);
            Console.WriteLine($"NMI vector:     {pch:X2} {pcl:X2}");
            pcl = ReadMemory(0xFFFC);
            pch = ReadMemory(0xFFFD);
            Console.WriteLine($"Reset vector:   {pch:X2} {pcl:X2}");
            pcl = ReadMemory(0xFFFE);
            pch = ReadMemory(0xFFFF);
            Console.WriteLine($"IRQ/BRK vector: {pch:X2} {pcl:X2}");
        }
    }

    private void LoadProgram(byte[] bytes)
    {
        ushort baseAddr = 0xF000;
        if (bytes.Length == 8192)
        {
            Console.WriteLine($"Loading 8kb ROM starting from 0x{baseAddr:X4}");
        }
        else if (bytes.Length == 2048)
        {
            baseAddr = 0xF800;
            Console.WriteLine($"Loading 2kb ROM starting from 0x{baseAddr:X4}");
        }

        LoadProgramBytes(bytes, baseAddr, false);
    }

    private void UpdateDataBus()
    {
        var cpu = Sim6507;
        var tia = SimTIA;

        // transfer 6507 data bus to TIA
        // TIA DB0-DB5 are pure inputs
        // TIA DB6 and DB7 can be driven high or low by the TIA
        // TIA CS3 or CS0 high inhibits tia from driving db6 and db7

        tia.SetBus(FlawlessTia.NodeIds.DB, cpu.GetBus(Flawless6502.NodeIds.db));

        var hidrv = false;
        foreach (var wireInd in FlawlessTia.NodeIds.DBDrivers.NodeIds)
        {
            if (tia.IsHigh(wireInd))
            {
                hidrv = true;
                break;
            }
        }

        if (hidrv)
        {
            // 6502 SYNC is HIGH when its fetching instruction, so make sure
            // our DB is not being written to by the TIA at this time
            if (cpu.IsHigh(Flawless6502.NodeIds.sync))
            {
                Console.WriteLine("ERROR: TIA driving DB when 6502 fetching instruction");
            }
        }
    }

    public void AdvanceOneHalfClock()
    {
        var cpu = Sim6507;
        var tia = SimTIA;
        var pia = EmuPIA;

        // Set all TIA inputs to be pulled high.  These aren't updated to
        // reflect any joystick or console switch inputs, but they could be.
        // To give the sim those inputs, you could check the sim halfClkCount,
        // and when it hits a certain value or range of values, set whatever
        // ins you like to low or high.
        // Here, we make an arbitrary choice to set the pads to be pulled
        // high for 10 half clocks.  After this, they should remain pulled
        // high, so choosing 10 half clocks or N > 0 half clocks makes no
        // difference.
        if (HalfClkCount < 10)
        {
            tia.SetBus(FlawlessTia.NodeIds.I, NodeValue.PulledHigh);
        }

        tia.SetHigh(FlawlessTia.NodeIds.del);

        // TIA 6x45 control ROM will change when R/W goes HI to LOW only if
        // the TIA CLK2 is LOW, so update R/W first, then CLK2.
        // R/W is high when 6502 is reading, low when 6502 is writing

        tia.SetNode(FlawlessTia.NodeIds.R_W, cpu.IsHigh(Flawless6502.NodeIds.rw) ? NodeValue.PulledHigh : NodeValue.PulledLow);

        var addr = cpu.GetBus(Flawless6502.NodeIds.ab);

        // Transfer the state of the 6507 simulation's address bus
        // to the corresponding address inputs of the TIA simulation
        // We lop off the high bits of the 6507 address bus and just set the low 7 bits to the TIA AB inputs.
        tia.SetBus(FlawlessTia.NodeIds.AB, (byte)cpu.GetBus(Flawless6502.NodeIds.ab));

        // 6507 AB7 goes to TIA CS3 and PIA CS1
        // 6507 AB12 goes to TIA CS0 and PIA CS0, but which 6502 AB line is it?
        // 6507 AB12, AB11, AB10 are not connected externally, so 6507 AB12 is
        // 6502 AB15
        //
        // TODO: return changed/unchanged from setHigh, setLow to decide to recalc
        NodeValue tiaCsShouldBeHigh;
        if (addr > 0x7F)



        {
            // It's not a TIA address, so set TIA CS3 high
            // Either CS3 high or CS0 high should disable TIA from writing
            tiaCsShouldBeHigh = NodeValue.PulledHigh;
        }
        else
        {
            // It is a TIA addr from 0x00 to 0x7F, so set CS3 and CS0 low
            tiaCsShouldBeHigh = NodeValue.PulledLow;
        }
        tia.SetBus(FlawlessTia.NodeIds.CS0CS3, tiaCsShouldBeHigh);

        UpdateDataBus();

        // Advance the TIA 2nd input clock that is controlled
        // by the 6507's clock generator.
        tia.SetNode(FlawlessTia.NodeIds.CLK2, cpu.IsHigh(Flawless6502.NodeIds.clk1out) ? NodeValue.PulledHigh : NodeValue.PulledLow);

        // Advance TIA 'CLK0' by one half clock
        tia.SetNode(FlawlessTia.NodeIds.CLK0, tia.IsHigh(FlawlessTia.NodeIds.CLK0) ? NodeValue.PulledLow : NodeValue.PulledHigh);

        // This is a good place to record the TIA and 6507 (6502)
        // state if you want to capture something like a logic
        // analyzer trace.

        // Transfer bits from TIA pads to 6507 pads
        // TIA RDY and 6507 RDY are pulled high through external resistor, so pull
        // the pad low if the TIA RDY_lowCtrl is on.
        cpu.SetNode(Flawless6502.NodeIds.rdy, !tia.IsHigh(FlawlessTia.NodeIds.RDY_lowCtrl) ? NodeValue.PulledHigh : NodeValue.PulledLow);

        // TIA sends a clock to the 6507.  Propagate this clock from the
        // TIA simulation to the 6507 simulation.
        var clkTo6502IsHigh = tia.IsHigh(FlawlessTia.NodeIds.PH0);

        if (clkTo6502IsHigh != cpu.IsHigh(Flawless6502.NodeIds.clk0))
        {
            // Emulate the PIA timer
            // Here at Visual6502.org, we're building a gate-level model
            // of the PIA, but it's not ready yet. 

            if (clkTo6502IsHigh)
            {
                // When its reached its end, it counts down from 0xFF every clock
                // (every time the input clock is high, it advances)
                if (pia.TimerFinished)
                {
                    if (pia.TimerValue > 0)
                    {
                        // Assume it doesn't wrap around. When it reaches 0 it just stays there.
                        pia.TimerValue--;
                    }
                }
                else
                {
                    pia.TimerClockCount++;
                    if (pia.TimerClockCount >= pia.TimerPeriod)
                    {
                        // decrement interval counter
                        if (pia.TimerValue > 0)
                        {
                            pia.TimerValue--;
                        }
                        else
                        {
                            pia.TimerFinished = true;
                            pia.TimerValue = 0xFF;
                        }
                        pia.TimerClockCount = 0;
                    }
                }
            }

            // Advance the 6502 simulation 1 half clock cycle
            if (clkTo6502IsHigh)
            {
                cpu.SetHigh(Flawless6502.NodeIds.clk0);
            }
            else
            {
                cpu.SetLow(Flawless6502.NodeIds.clk0);

                // Put PIA count value into memory so 6507 can read it
                // like a regular memory read.
                WriteMemory(0x284, pia.TimerValue);
            }

            // TODO(Tim): Don't need to retrieve it again?
            addr = cpu.GetBus(Flawless6502.NodeIds.ab);

            if (cpu.IsHigh(Flawless6502.NodeIds.clk0))
            {
                if (!cpu.IsHigh(Flawless6502.NodeIds.rw))
                {
                    var data = cpu.GetBus(Flawless6502.NodeIds.db);
                    WriteMemory(addr, data);
                }
            }
            else
            {
                // 6507's CLK0 is low
                if (cpu.IsHigh(Flawless6502.NodeIds.rw))
                {
                    ReadMemory(addr);
                }
            }
        }

        HalfClkCount++;
    }
}