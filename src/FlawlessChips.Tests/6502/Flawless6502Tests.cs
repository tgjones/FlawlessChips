using System;
using NUnit.Framework;

using static FlawlessChips.Flawless6502.NodeIds;

namespace FlawlessChips.Tests
{
    public class Flawless6502Tests
    {
        [Test]
        public void TestStartupStateMatchesVisual6502()
        {
            var chip = new Flawless6502();

            Assert.AreEqual(
                "llllllllllllllllllllllllllllllxlllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllxllllllllllllllllllllllllllllxllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllxllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllxlllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllxllllllllllllllllllllllllllllllllllllllllllllxlllllllllllllllgllllxlllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllvlllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllxllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllxllllllxlllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllxlllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllxxllllllllllllllllllllllllllllllllllllllllllllllllllllxlllllllllllllllllllllllllllllllllllllllllllllllllllllllxlllllllllllllllllllllllllllllllllllllllllllxlxlllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllxlllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllxlllllllllllllllllllllllllllllllllllllxlllllllllllllllllllllll",
                chip.GetState());

            var memory = new byte[ushort.MaxValue];

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

            void HandleMemory()
            {
                if (chip.GetNode(rw) == NodeValue.PulledHigh)
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
                }
            }

            var clk = false;

            void HalfStep()
            {
                clk = !clk;

                chip.SetNode(clk0, clk ? NodeValue.PulledHigh : NodeValue.PulledLow);

                if (!clk)
                {
                    HandleMemory();
                }

                Console.WriteLine($"PC {chip.GetBus(pch):X2}{chip.GetBus(pcl):X2}   AB {chip.GetBus(ab):X4}   DB {chip.GetBus(db):X2}  {(chip.GetNode(rw) == NodeValue.PulledHigh ? 'R' : 'W')}");
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
        }
    }
}