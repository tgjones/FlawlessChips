using System.Collections.Generic;

using static FlawlessChips.Flawless2C02.NodeIds;

namespace FlawlessChips;

public sealed partial class Flawless2C02 : ChipSimulator<Flawless2C02>, IChipSimulatorOverrides
{
    public Flawless2C02()
        : base("FlawlessChips._2C02.SegmentDefinitions.txt",
               "FlawlessChips._2C02.TransistorDefinitions.txt",
               gnd,
               pwr)
    {
    }

    static void IChipSimulatorOverrides.OverrideGroupState(ref GroupState groupState, List<NodeId> group)
    {
        if ((groupState & GroupState.ContainsGnd) != 0 && (groupState & GroupState.ContainsPwr) != 0)
        {
            // spr_d0 thru spr_d7 sometimes get conflicts,
            // so suppress them here
            if (group.Contains(359) ||
                group.Contains(566) ||
                group.Contains(691) ||
                group.Contains(871) ||
                group.Contains(870) ||
                group.Contains(864) ||
                group.Contains(856) ||
                group.Contains(818))
            {
                groupState &= ~GroupState.ContainsGnd;
                groupState &= ~GroupState.ContainsPwr;
            }
        }
    }

    public void Startup()
    {
        // Assert RESET and initialize other inputs
        SetNode(res, NodeValue.PulledLow);
        SetNode(clk0, NodeValue.PulledLow);
        SetNode(io_ce, NodeValue.PulledHigh);
        SetNode(@int, NodeValue.PulledHigh);

        // Recalculate all nodes until the chip stabilizes
        StabilizeChip();

        // Run for 4 cycles so that RESET fully takes effect
        for (var i = 0; i < 4; i++)
        {
            SetNode(clk0, NodeValue.PulledHigh);
            SetNode(clk0, NodeValue.PulledLow);
        }

        // Deassert RESET so the chip can continue running normally
        SetNode(res, NodeValue.PulledHigh);
    }

    public void PaletteWrite(byte address, byte value)
    {
        for (var i = 0; i < 6; i++)
        {
            var n0 = PaletteNodes[address][i][0];
            var n1 = PaletteNodes[address][i][1];

            if ((value & (1 << i)) != 0)
            {
                SetBit(n1, n0);
            }
            else
            {
                SetBit(n0, n1);
            }
        }
    }
}