using static FlawlessChips.FlawlessTia.NodeIds;

namespace FlawlessChips;

public sealed partial class FlawlessTia : ChipSimulator
{
    public FlawlessTia()
        : base("Tia", typeof(NodeIds), VSS, VCC)
    {
    }

    protected override bool AllowUnsettledNodesOnFirstRecalc => true;

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
        SetHigh(CS3);
        SetHigh(CS0);

        StabilizeChip();
    }
}
