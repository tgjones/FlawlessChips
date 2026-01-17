using static FlawlessChips.Flawless6502.NodeIds;

namespace FlawlessChips.Tests;

public class Flawless6502Tests
{
    [Test]
    public async Task TestStartupStateMatchesVisual6502()
    {
        var chip = new Flawless6502();

        // This state was retrieved from Visual 6502 by running the equivalent simulation,
        // and then calling the JavaScript stateString() function to get the state.
        await Assert.That(chip.GetState()).IsEqualTo(
            "llllllllllllllllllllllllllllllxlllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllxllllllllllllllllllllllllllllxllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllxllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllxlllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllxllllllllllllllllllllllllllllllllllllllllllllxlllllllllllllllgllllxlllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllvlllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllxllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllxllllllxlllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllxlllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllxxllllllllllllllllllllllllllllllllllllllllllllllllllllxlllllllllllllllllllllllllllllllllllllllllllllllllllllllxlllllllllllllllllllllllllllllllllllllllllllxlxlllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllxlllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllxlllllllllllllllllllllllllllllllllllllxlllllllllllllllllllllll");

        var memory = new byte[ushort.MaxValue + 1];

        var testProgram = new byte[]
        {
            0xa9, 0x00,              // LDA #$00
            0x20, 0x10, 0x00,        // JSR $0010
            0x4c, 0x02, 0x00,        // JMP $0002
            
            0x00, 0x00, 0x00, 0x00,
            0x00, 0x00, 0x00, 0x40,
            
            0xe8,                    // INX
            0x88,                    // DEY
            0xe6, 0x0F,              // INC $0F
            0x38,                    // SEC
            0x69, 0x02,              // ADC #$02
            0x60                     // RTS
        };

        Array.Copy(testProgram, memory, testProgram.Length);

        chip.Startup();

        var output = "";

        void HandleMemoryAccess()
        {
            if (chip.IsHigh(rw))
            {
                var address = chip.GetBus(ab);
                var data = memory[address];
                chip.SetBus(db, data);
            }
            else
            {
                var address = chip.GetBus(ab);
                var data = chip.GetBus(db);
                memory[address] = data;

                if (address == 0x000F)
                {
                    output += (char)data;
                }
            }
        }

        var clk = false;

        void HalfStep()
        {
            clk = !clk;

            chip.SetNode(clk0, clk ? NodeValue.PulledHigh : NodeValue.PulledLow);

            if (chip.IsHigh(clk2out))
            {
                HandleMemoryAccess();
            }

            // Uncomment this line to see chip state at each step.
            //Console.WriteLine(
            //    "Φ2 {0}   PC {1:X4}   X {2:X2}   Y {3:X2}   A {4:X2}   SP {5:X2}   AB {6:X4}   DB {7:X2}   RW {8}   SYNC {9}",
            //    chip.IsHigh(clk2out) ? '1' : '0',
            //    chip.GetPC(),
            //    chip.GetBus(x),
            //    chip.GetBus(y),
            //    chip.GetBus(a),
            //    chip.GetBus(s),
            //    chip.GetBus(ab),
            //    chip.GetBus(db),
            //    chip.IsHigh(rw) ? '1' : '0',
            //    chip.IsHigh(sync) ? '1' : '0');
        }

        for (var i = 0; i < 217; i++)
        {
            HalfStep();
        }

        await Assert.That(output).IsEqualTo("@AABBCC");
    }

    // Based on https://github.com/mist64/perfect6502/blob/268d16647c6b9cb0c6859cae230fd55ad98ff689/apple1basic/apple1basic.c
    [Test]
    public async Task TestApple1Basic()
    {
        var apple1BasicBin = File.ReadAllBytes("6502/apple1basic.bin");
        byte[] memory = new byte[ushort.MaxValue + 1];
        Array.Copy(apple1BasicBin, 0, memory, 0xE000, apple1BasicBin.Length);

        memory[0xFFFC] = 0x00;
        memory[0xFFFD] = 0xE0;

        var chip = new Flawless6502();
        chip.Startup();

        const string stringToPrint = "Hello World";
        var stringIndex = 0;

        var output = "";

        void HandleMemoryAccess()
        {
            if (chip.IsHigh(rw))
            {
                var address = chip.GetBus(ab);

                // 0xD010: Keyboard input register
                // 0xD011: Keyboard control register
                // 0xD012: Display register

                var register = address & 0xFF1F;

                byte data;

                switch (register)
                {
                    case 0xD010:
                        data = (byte)stringToPrint[stringIndex];
                        data |= 0x80;
                        stringIndex++;
                        break;

                    case 0xD011:
                        // If we're still printing the string, then tell CPU we have a character available.
                        data = stringIndex < stringToPrint.Length ? (byte)0x80 : (byte)0;
                        break;

                    case 0xD012:
                        // Tell CPU we're ready to receive a character to the display register.
                        data = 0;
                        break;

                    default:
                        data = memory[address];
                        break;
                }

                chip.SetBus(db, data);
            }
            else
            {
                var address = chip.GetBus(ab);
                var data = chip.GetBus(db);

                var register = address & 0xFF1F;

                switch (register)
                {
                    case 0xD012:
                        var character = (char)(data & 0x7F);
                        output += character;
                        break;

                    default:
                        memory[address] = data;
                        break;
                }
            }
        }

        var clk = false;

        void HalfStep()
        {
            clk = !clk;

            chip.SetNode(clk0, clk ? NodeValue.PulledHigh : NodeValue.PulledLow);

            if (chip.IsHigh(clk2out))
            {
                HandleMemoryAccess();
            }
        }

        for (var i = 0; i < 3000; i++)
        {
            HalfStep();
        }

        await Assert.That(output).IsEqualTo("\r>Hello World");
    }
}