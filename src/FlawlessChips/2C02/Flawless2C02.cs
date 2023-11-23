using System.Collections.Generic;

using static FlawlessChips.Flawless2C02.NodeIds;

namespace FlawlessChips;

public sealed partial class Flawless2C02 : ChipSimulator
{
    public Flawless2C02()
        : base("_2C02", gnd, pwr)
    {
    }

    protected override NodeValue GetNodeValueForAmbiguousGroup(List<NodeId> group, Node[] nodes)
    {
        var areaHi = 0;
        var areaLo = 0;

        foreach (var nn in group)
        {
            ref readonly var n = ref nodes[nn];

            // If we get here, we know that none of the nodes
            // in the group are gnd, pwr, pullup, or pulldown.
            switch (n.State)
            {
                case NodeValue.PulledHigh:
                    areaHi += n.Area;
                    break;

                case NodeValue.PulledLow:
                case NodeValue.Floating: // Not quite right.
                    areaLo += n.Area;
                    break;
            }
        }

        return areaHi > areaLo
            ? NodeValue.PulledHigh
            : NodeValue.PulledLow;
    }

    protected override void OverrideGroupState(ref GroupState groupState, List<NodeId> group)
    {
        if ((groupState & GroupState.ContainsGnd) != 0 && (groupState & GroupState.ContainsPwr) != 0)
        {
            // spr_d0 thru spr_d7 sometimes get conflicts,
            // so suppress them here
            foreach (var nodeId in group)
            {
                switch (nodeId)
                {
                    case spr_d7:
                    case spr_d6:
                    case spr_d5:
                    case spr_d4:
                    case spr_d3:
                    case spr_d2:
                    case spr_d1:
                    case spr_d0:
                        groupState &= ~GroupState.ContainsGnd;
                        groupState &= ~GroupState.ContainsPwr;
                        return;
                }
            }
        }
    }

    public void Startup()
    {
        // Assert RESET and initialize other inputs
        SetLow(res);
        SetLow(clk0);
        SetHigh(io_ce);
        SetHigh(@int);

        // Recalculate all nodes until the chip stabilizes
        StabilizeChip();

        // Run for 4 cycles so that RESET fully takes effect
        for (var i = 0; i < 4; i++)
        {
            SetHigh(clk0);
            SetLow(clk0);
        }

        // Deassert RESET so the chip can continue running normally
        SetHigh(res);
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