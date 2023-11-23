using System;
using System.Collections.Generic;

using static FlawlessChips.FlawlessZ80.NodeIds;

namespace FlawlessChips;

public sealed partial class FlawlessZ80 : ChipSimulator
{
    public FlawlessZ80()
        : base("Z80", vss, vcc)
    {
    }

    protected override bool ShouldSkipTransistorDefinition(string line)
    {
        return line.EndsWith("true,]", StringComparison.InvariantCulture);
    }

    protected override NodeValue GetNodeValueForAmbiguousGroup(List<NodeId> group, Node[] nodes)
    {
        var maxState = NodeValue.PulledLow;
        var maxConnections = 0;

        foreach (var nodeId in group)
        {
            ref readonly var node = ref nodes[nodeId];

            var connections = node.Gates.Count + node.C1C2s.Count;
            if (connections > maxConnections)
            {
                maxConnections = connections;
                maxState = node.State == NodeValue.PulledHigh
                    ? NodeValue.PulledHigh
                    : NodeValue.PulledLow;
            }
        }

        return maxState;
    }

    public void Startup()
    {
        SetLow(_reset);
        SetHigh(clk);
        SetHigh(_busrq);
        SetHigh(_int);
        SetHigh(_nmi);
        SetHigh(_wait);

        StabilizeChip();

        for (var i = 0; i < 31; i++)
        {
            var clkIsHigh = IsHigh(clk);

            SetNode(clk, clkIsHigh ? NodeValue.PulledLow : NodeValue.PulledHigh);
        }

        SetHigh(_reset);
    }
}
