using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;

namespace FlawlessChips;

public class ChipSimulator
{
    private const NodeId NullNodeId = NodeId.MaxValue;

    private readonly Node[] _nodes;
    private readonly Transistor[] _transistors;

    private readonly NodeId _nodeGnd;
    private readonly NodeId _nodePwr;

    private readonly BitArray _recalcListOutBitmap;

    private List<NodeId> _recalcListIn;
    private List<NodeId> _recalcListOut;

    private readonly List<NodeId> _group;

    [Flags]
    protected enum GroupState
    {
        ContainsNothing = 0,
        ContainsHi = 1 << 0,
        ContainsPulldown = 1 << 1,
        ContainsPullup = 1 << 2,
        ContainsPwr = 1 << 3,
        ContainsGnd = 1 << 4,
    }

    private GroupState _groupState;

    public ChipSimulator(
        string chipResourceName,
        NodeId gnd,
        NodeId pwr)
    {
        _nodeGnd = gnd;
        _nodePwr = pwr;

        var segmentDefinitions = ReadSegmentDefinitions($"FlawlessChips.{chipResourceName}.SegmentDefinitions.txt");

        // Check maximum node ID.
        var maximumId = 0;
        foreach (var segmentDefinition in segmentDefinitions)
        {
            maximumId = Math.Max(maximumId, segmentDefinition.NodeId);
        }

        _nodes = new Node[maximumId + 1];
        for (var i = 0; i < _nodes.Length; i++)
        {
            _nodes[i].NodeId = NullNodeId;
        }

        var transistorDefinitions = ReadTransistorDefinitions($"FlawlessChips.{chipResourceName}.TransistorDefinitions.txt");

        _transistors = new Transistor[transistorDefinitions.Count];

        SetupNodes(segmentDefinitions);
        SetupTransistors(transistorDefinitions);

        InitializeNodesAndTransistors();

        _recalcListOutBitmap = new BitArray(_nodes.Length);

        _recalcListIn = [];
        _recalcListOut = [];

        _group = [];
    }

    private static List<SegmentDefinition> ReadSegmentDefinitions(string segmentDefinitionsResourceName)
    {
        using var stream = typeof(ChipSimulator).Assembly.GetManifestResourceStream(segmentDefinitionsResourceName)!;
        using var streamReader = new StreamReader(stream);

        var result = new List<SegmentDefinition>();

        const int maxCoordinates = 7000;
        var coordinates = new float[maxCoordinates];

        string? rawLine;
        while ((rawLine = streamReader.ReadLine()) != null)
        {
            if (rawLine == "" || rawLine.StartsWith("//", StringComparison.InvariantCultureIgnoreCase))
            {
                continue;
            }

            var line = rawLine.Split(',');

            var numCoordinates = line.Length - 3;
            if (numCoordinates > maxCoordinates)
            {
                throw new InvalidOperationException($"Node {line[0]}, numCoordinates {numCoordinates} is more than maxCoordinates {maxCoordinates}");
            }

            for (var j = 0; j < numCoordinates; j++)
            {
                coordinates[j] = float.Parse(line[j + 3]);
            }

            var area = coordinates[numCoordinates - 2] * coordinates[1] - coordinates[0] * coordinates[numCoordinates - 1];
            for (var j = 0; j < numCoordinates - 2; j += 2)
            {
                area += coordinates[j] * coordinates[j + 3] - coordinates[j + 2] * coordinates[j + 1];
            }

            if (area < 0)
            {
                area = -area;
            }

            var segmentDefinition = new SegmentDefinition(
                ushort.Parse(line[0]),
                line[1] == "+",
                byte.Parse(line[2]),
                (int)area);

            result.Add(segmentDefinition);
        }

        return result;
    }

    private List<TransistorDefinition> ReadTransistorDefinitions(string transistorDefinitionsResourceName)
    {
        using var stream = typeof(ChipSimulator).Assembly.GetManifestResourceStream(transistorDefinitionsResourceName)!;
        using var streamReader = new StreamReader(stream);

        var result = new List<TransistorDefinition>();

        string? line;
        while ((line = streamReader.ReadLine()) != null)
        {
            if (line == "" || line.StartsWith("//", StringComparison.InvariantCultureIgnoreCase))
            {
                continue;
            }

            if (ShouldSkipTransistorDefinition(line))
            {
                continue;
            }

            var splitLine = line.Split(',');

            var transistorDefinition = new TransistorDefinition(
                ushort.Parse(splitLine[1]),
                ushort.Parse(splitLine[2]),
                ushort.Parse(splitLine[3]));

            result.Add(transistorDefinition);
        }

        return result;
    }

    protected virtual bool ShouldSkipTransistorDefinition(string line) => false;

    private void SetupNodes(List<SegmentDefinition> segmentDefinitions)
    {
        foreach (var segmentDefinition in segmentDefinitions)
        {
            var nodeId = segmentDefinition.NodeId;
            ref var node = ref _nodes[nodeId];
            if (node.NodeId == NullNodeId)
            {
                node = new Node
                {
                    NodeId = nodeId,
                    Pulled = segmentDefinition.Pullup
                        ? NodeValue.PulledHigh
                        : NodeValue.Floating,
                    State = NodeValue.Floating,
                    Area = 0,
                    Gates = [],
                    C1C2s = []
                };
            }

            if (nodeId == _nodeGnd) continue;
            if (nodeId == _nodePwr) continue;

            node.Area += segmentDefinition.Area;
        }
    }

    private void SetupTransistors(List<TransistorDefinition> transistorDefinitions)
    {
        for (var i = 0; i < transistorDefinitions.Count; i++)
        {
            var transistorDefinition = transistorDefinitions[i];

            var gate = transistorDefinition.Gate;
            var c1 = transistorDefinition.C1;
            var c2 = transistorDefinition.C2;

            if (c1 == _nodeGnd) { c1 = c2; c2 = _nodeGnd; }
            if (c1 == _nodePwr) { c1 = c2; c2 = _nodePwr; }

            var transistor = new Transistor
            {
                On = false,
                Gate = gate,
                C1 = c1,
                C2 = c2,
            };

            _nodes[gate].Gates.Add(transistor);
            _nodes[c1].C1C2s.Add(transistor);
            _nodes[c2].C1C2s.Add(transistor);
            _transistors[i] = transistor;
        }
    }

    private void InitializeNodesAndTransistors()
    {
        // set all nodes to be floating
        for (var i = 0; i < _nodes.Length; i++)
        {
            ref var node = ref _nodes[i];
            node.State = NodeValue.Floating;
        }

        // set GND and PWR to be driven high/low
        _nodes[_nodeGnd].State = NodeValue.PulledLow;
        _nodes[_nodePwr].State = NodeValue.PulledHigh;

        // Turn on all transistors connected to VCC, and turn off the rest
        foreach (var transistor in _transistors)
        {
            transistor.On = transistor.Gate == _nodePwr;
        }
    }

    public void RecalcNodeList()
    {
        for (var j = 0; j < 100; j++) // Prevent infinite loops
        {
            (_recalcListOut, _recalcListIn) = (_recalcListIn, _recalcListOut);

            _recalcListOut.Clear();
            _recalcListOutBitmap.SetAll(false);

            if (_recalcListIn.Count == 0)
            {
                return;
            }

            foreach (var item in _recalcListIn)
            {
                RecalcNode(item);
            }
        }

        throw new Exception("Encountered loop while updating");
    }

    private void RecalcNode(NodeId nodeId)
    {
        GetNodeGroup(nodeId);

        var newState = GetNodeValue();

        foreach (var i in _group)
        {
            ref var n = ref _nodes[i];

            if (n.State == newState)
            {
                continue;
            }

            n.State = newState;

            foreach (var t in n.Gates)
            {
                if (n.State == NodeValue.PulledHigh)
                {
                    TurnTransistorOn(t);
                }
                else
                {
                    TurnTransistorOff(t);
                }
            }
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void TurnTransistorOn(Transistor t)
    {
        if (t.On)
        {
            return;
        }

        t.On = true;

        AddRecalcNode(t.C1);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void TurnTransistorOff(Transistor t)
    {
        if (!t.On)
        {
            return;
        }

        t.On = false;

        AddRecalcNode(t.C1);
        AddRecalcNode(t.C2);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void AddRecalcNode(NodeId nodeId)
    {
        if (nodeId == _nodeGnd) return;
        if (nodeId == _nodePwr) return;

        if (_recalcListOutBitmap[nodeId])
        {
            return;
        }

        _recalcListOut.Add(nodeId);
        _recalcListOutBitmap[nodeId] = true;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void GetNodeGroup(NodeId nodeId)
    {
        _group.Clear();
        _groupState = GroupState.ContainsNothing;
        AddNodeToGroup(nodeId);
    }

    private void AddNodeToGroup(NodeId nodeId)
    {
        if (nodeId == _nodeGnd)
        {
            _groupState |= GroupState.ContainsGnd;
            return;
        }

        if (nodeId == _nodePwr)
        {
            _groupState |= GroupState.ContainsPwr;
            return;
        }

        if (_group.Contains(nodeId))
        {
            return;
        }

        _group.Add(nodeId);

        ref readonly var node = ref _nodes[nodeId];

        if (node.Pulled == NodeValue.PulledHigh)
        {
            _groupState |= GroupState.ContainsPullup;
        }

        if (node.Pulled == NodeValue.PulledLow)
        {
            _groupState |= GroupState.ContainsPulldown;
        }

        if (node.State == NodeValue.PulledHigh)
        {
            _groupState |= GroupState.ContainsHi;
        }

        foreach (var t in node.C1C2s)
        {
            if (!t.On)
            {
                continue;
            }

            NodeId other;
            if (t.C1 == nodeId) other = t.C2;
            else if (t.C2 == nodeId) other = t.C1;
            else throw new InvalidOperationException();
            AddNodeToGroup(other);
        }
    }

    protected virtual void OverrideGroupState(ref GroupState groupState, List<NodeId> group) { }

    private NodeValue GetNodeValue()
    {
        OverrideGroupState(ref _groupState, _group);

        if ((_groupState & GroupState.ContainsGnd) != 0)
        {
            return NodeValue.PulledLow;
        }

        if ((_groupState & GroupState.ContainsPwr) != 0)
        {
            return NodeValue.PulledHigh;
        }

        if ((_groupState & GroupState.ContainsPulldown) != 0)
        {
            return NodeValue.PulledLow;
        }

        if ((_groupState & GroupState.ContainsPullup) != 0)
        {
            return NodeValue.PulledHigh;
        }

        if ((_groupState & GroupState.ContainsHi) != 0)
        {
            return GetNodeValueForAmbiguousGroup(_group, _nodes);
        }

        return NodeValue.Floating;
    }

    protected virtual NodeValue GetNodeValueForAmbiguousGroup(List<NodeId> group, Node[] nodes) => NodeValue.PulledHigh;

    public void StabilizeChip()
    {
        for (NodeId nodeId = 0; nodeId < _nodes.Length; nodeId++)
        {
            if (nodeId == _nodeGnd || nodeId == _nodePwr)
            {
                continue;
            }

            if (_nodes[nodeId].NodeId == NullNodeId)
            {
                continue;
            }

            _recalcListOut.Add(nodeId);
        }
        RecalcNodeList();
    }

    public void SetState(string str)
    {
        for (var i = 0; i < str.Length; i++)
        {
            var c = str[i];

            if (c == 'x')
            {
                continue;
            }

            ref var node = ref _nodes[i];

            if (node.NodeId == NullNodeId)
            {
                continue;
            }

            var state = c switch
            {
                'g' => NodeValue.PulledLow,
                'h' => NodeValue.PulledHigh,
                'v' => NodeValue.PulledHigh,
                'l' => NodeValue.PulledLow,
                _ => throw new InvalidOperationException(),
            };

            node.State = state;

            foreach (var gate in node.Gates)
            {
                gate.On = state == NodeValue.PulledHigh;
            }
        }
    }

    public string GetState()
    {
        var result = new StringBuilder(_nodes.Length);

        for (var i = 0; i < _nodes.Length; i++)
        {
            ref readonly var node = ref _nodes[i];

            if (node.NodeId == NullNodeId)
            {
                result.Append('x');
            }
            else if (i == _nodeGnd)
            {
                result.Append('g');
            }
            else if (i == _nodePwr)
            {
                result.Append('v');
            }
            else
            {
                result.Append(node.State == NodeValue.PulledHigh ? 'h' : 'l');
            }
        }

        return result.ToString();
    }

    public void SetNode(NodeId nodeId, NodeValue value)
    {
        Span<NodeId> nodeIds = stackalloc NodeId[1];
        Span<NodeValue> values = stackalloc NodeValue[1];

        nodeIds[0] = nodeId;
        values[0] = value;

        SetNodes(nodeIds, values);
    }

    public void SetHigh(NodeId nodeId) => SetNode(nodeId, NodeValue.PulledHigh);
    public void SetLow(NodeId nodeId) => SetNode(nodeId, NodeValue.PulledLow);

    private void SetNodes(Span<NodeId> nodeIds, Span<NodeValue> values)
    {
        for (var i = 0; i < nodeIds.Length; i++)
        {
            var nodeId = nodeIds[i];

            if (nodeId == NodeId.MaxValue)
            {
                continue;
            }

            ref var node = ref _nodes[nodeId];

            node.Pulled = values[i];

            _recalcListOut.Add(nodeId);
        }

        RecalcNodeList();
    }

    public NodeValue GetNode(NodeId nodeId) => _nodes[nodeId].State;

    public bool IsHigh(NodeId nodeId) => GetNode(nodeId) == NodeValue.PulledHigh;

    public T GetBus<T>(NodeBus<T> bus)
        where T : IUnsignedNumber<T>, IShiftOperators<T, int, T>, IModulusOperators<T, T, T>
    {
        var result = T.Zero;
        for (var i = 0; i < bus.NodeIds.Length; i++)
        {
            var nodeId = bus.NodeIds[i];

            if (nodeId == NodeId.MaxValue)
            {
                continue;
            }

            var isHigh = IsHigh(nodeId);

            result += (isHigh ? T.One : T.Zero) << i;
        }
        return result;
    }

    public void SetBus<T>(NodeBus<T> bus, T value)
        where T : IUnsignedNumber<T>, IModulusOperators<T, T, T>
    {
        Span<NodeValue> values = stackalloc NodeValue[bus.NodeIds.Length];

        var two = T.CreateChecked(2);

        for (var i = 0; i < bus.NodeIds.Length; i++)
        {
            values[i] = (value % two) != T.Zero
                ? NodeValue.PulledHigh
                : NodeValue.PulledLow;
            value /= two;
        }

        SetNodes(bus.NodeIds, values);
    }

    public void SetBusFloating<T>(NodeBus<T> bus)
        where T : IUnsignedNumber<T>, IShiftOperators<T, int, T>
    {
        Span<NodeValue> values = stackalloc NodeValue[bus.NodeIds.Length];

        for (var i = 0; i < bus.NodeIds.Length; i++)
        {
            values[i] = NodeValue.Floating;
        }

        SetNodes(bus.NodeIds, values);
    }

    // TODO: Check whether this can be done via SetNode. Is it important that we don't
    // change the pullup / pulldown values for these "memory" nodes?
    public void SetBit(NodeId n0, NodeId n1)
    {
        foreach (var transistor in _nodes[n0].Gates)
        {
            transistor.On = true;
        }

        foreach (var transistor in _nodes[n1].Gates)
        {
            transistor.On = false;
        }

        _nodes[n0].State = NodeValue.PulledHigh;
        _nodes[n1].State = NodeValue.PulledLow;

        _recalcListOut.Add(n0);
        _recalcListOut.Add(n1);

        RecalcNodeList();
    }
}