using System;
using NUnit.Framework;

using static FlawlessChips.Flawless6502.NodeIds;

namespace FlawlessChips.Tests;

public class Flawless6502Tests
{
    [Test]
    public void TestStartupStateMatchesVisual6502()
    {
        var chip = new Flawless6502();

        Assert.AreEqual(
            "llllllllllllllllllllllllllllllxlllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllxllllllllllllllllllllllllllllxllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllxllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllxlllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllxllllllllllllllllllllllllllllllllllllllllllllxlllllllllllllllgllllxlllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllvlllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllxllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllxllllllxlllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllxlllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllxxllllllllllllllllllllllllllllllllllllllllllllllllllllxlllllllllllllllllllllllllllllllllllllllllllllllllllllllxlllllllllllllllllllllllllllllllllllllllllllxlxlllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllxlllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllxlllllllllllllllllllllllllllllllllllllxlllllllllllllllllllllll",
            chip.GetState());

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

        void HandleBusRead()
        {
            if (chip.GetNode(rw) == NodeValue.PulledHigh)
            {
                var address = chip.GetBus(ab);
                var data = memory[address];
                chip.SetBus(db, data);
            }
        }

        void HandleBusWrite()
        {
            if (chip.GetNode(rw) != NodeValue.PulledHigh)
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

            if (clk)
            {
                HandleBusWrite();
            }
            else
            {
                HandleBusRead();
            }

            //Console.WriteLine($"PC {chip.GetBus(pch):X2}{chip.GetBus(pcl):X2}   X {chip.GetBus(x):X2}   Y {chip.GetBus(y):X2}   A {chip.GetBus(a):X2}   SP {chip.GetBus(s):X2}   AB {chip.GetBus(ab):X4}   DB {chip.GetBus(db):X2}  {(chip.GetNode(rw) == NodeValue.PulledHigh ? 'R' : 'W')}");
        }

        // Run for 18 half-cycles so that chip has _just_ finished RESET sequence
        // and has read the first byte of user code.
        for (var i = 0; i < 18; i++)
        {
            HalfStep();
        }

        Assert.AreEqual(
            "lllhlhllllhhllllhhhllhllhlhlhhxhlhlhhllhlhllhlhhhllhllhhhhlllllllhhlhlllllhhlllhhhllllhllhhlhlhhlllhlhhhhllhhhhhlhhlhhhhllhhhllllllllllhllhhllllxllllhhllhllllhhhlhlllhlhlhhhxhhllllllllhllllllllhhlhlhhllllllhlllhlhhlhllllhhhlllhhlllhhllllhhllhlhllhllhllhlhhhllllhhhhlhlllhlllllhlhhhlhlhllllhxllhlllhllhlllllllllhllllllhlhlllhlllhlhllhlllhlhhhllhhhlhllhhlhlllhhhlhlhhhhlhhllhlhllllllhlhhlhlllhlllhllhhlllllllllhhlxhlhhhhlhhllhlhlhhhlllllllllllhhhllllllhllhlllhhhhlhhllllhlhlhllllhhllhllhhllhlhhllhhlxhhllllhlhllhlhhhhlhllhlhlhhlhhlhhllllhhlhhlhxlhllllhlhlhlhhhghlhhxlhhllhlhllllhhllllhhllllllhhhhlhllhlllhlhhllhhlllhllhhhhhhllhlhhlhllhllhhlhhhhhlhhllllhlllhllvlhlhhlhlllhhlhlhhlhllhhhlhlllllhhllhlhlhhhllhhlhlhllhhlllllhlllhlhhhhlhhhlllllllhhllllhllhlxlhlhllhhhlhhlhllllhllhhhhllllhhllhlhlllhhlhllllhlhhlhhlhlhllllhhlhllhhhhlhhhlhlhlhllhhhhhlhhhlhhlllhhhlhhlllhhlhhhhllllhlllhllhlhlhlhhllllhhhllhhhlhlllhlhlhhhxhlllhhxllhhhhlhlhlhhhhllhlhlhlhlllllllllhlhhllhhllhlhlllllllhlhllhlhlllhhlllllhllhllhhhllhhlhlhlhlhlhhlhllhhhhllhlllhhhhlllllhhlhlhlllllhhhhhlhlhhlllhlllhhhhllllhllhlhlhllhllhlhlllhhhlhhlllhhhlllhlhhlllllhlllhhhhhhhhhlxhllhlhhlllhllhhllhllllhllhllhhlllhlhlhlhllhlhlhlhlhlhlhhhlllhhllhlhhhlhhhhlhlhlxxlllhlhlllhhhllhhhlllhhhllhlhlhllhllhhllhhllllhhhllllxhllhhhlllhllhhlhlhhllhhllhhhhllllllhhlhllhlllhhhlllhlhlxhhhlhhllhhllllhllhhllllhlhllhllhllhhllhhhlhxlxllhllllllllhhhhhlllhllhllhlhllhhlhlhhhhhhhhhhllhlhllhlhllhlhlhlhlllhllhhllhhhlhlhllhlhlhllhhlhhllxhlhllhllllhlhhlhllllllhhllllhlllhllllhhllllhhhlhlhlhhlhlhhlhhhlllhlhllhhllhhllllhllllhhlhlhhhhlhhlhhlhllhhhllhlhlllhlllhlllhhlllhlhllhllhlhlhllhhllhllllhllllhhhlllllhhllhlllhhlhlhhlhlllllhhllhhhhhllhllxlllhhhlllllhhhllhllhhlhhhlhllhlllllllxhhlhllhllhllhlhhhllllll",
            chip.GetState());

        for (var i = 0; i < 200; i++)
        {
            HalfStep();
        }

        Assert.AreEqual("@AABBCC", output);
    }
}