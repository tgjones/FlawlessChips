using System.Collections;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using FlawlessChips.Utility;

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

    private readonly Type _nodeIdsType;
    private ChipLogger? _logger;

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
        Type nodeIdsType,
        NodeId gnd,
        NodeId pwr)
    {
        _nodeGnd = gnd;
        _nodePwr = pwr;

        _nodeIdsType = nodeIdsType;

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
            _nodes[i] = new Node
            {
                NodeId = NullNodeId
            };
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

            var area = 0.0f;
            if (numCoordinates > 0)
            {
                area = coordinates[numCoordinates - 2] * coordinates[1] - coordinates[0] * coordinates[numCoordinates - 1];
                for (var j = 0; j < numCoordinates - 2; j += 2)
                {
                    area += coordinates[j] * coordinates[j + 3] - coordinates[j + 2] * coordinates[j + 1];
                }

                if (area < 0)
                {
                    area = -area;
                }
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
        var existingTransistors = new HashSet<TransistorDefinition>();

        string? line;
        while ((line = streamReader.ReadLine()) != null)
        {
            if (line == "" || line.StartsWith("//", StringComparison.InvariantCultureIgnoreCase) || line.StartsWith("#", StringComparison.InvariantCultureIgnoreCase))
            {
                continue;
            }

            if (ShouldSkipTransistorDefinition(line))
            {
                continue;
            }

            var splitLine = line.Split(',');

            var c1 = ushort.Parse(splitLine[2]);
            var c2 = ushort.Parse(splitLine[3]);

            if (c1 == _nodeGnd) { c1 = c2; c2 = _nodeGnd; }
            else if (c1 == _nodePwr) { c1 = c2; c2 = _nodePwr; }

            var transistorDefinition = new TransistorDefinition(
                ushort.Parse(splitLine[1]),
                c1, c2);

            if (existingTransistors.Add(transistorDefinition))
            {
                result.Add(transistorDefinition);
            }
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

            var transistor = new Transistor(gate, c1, c2);

            _nodes[gate].Gates.Add(transistor);
            _nodes[c1].C1C2s.Add(transistor);
            _nodes[c2].C1C2s.Add(transistor);
            _transistors[i] = transistor;
        }
    }

    private void InitializeNodesAndTransistors()
    {
        // set GND and PWR to be driven high/low
        _nodes[_nodeGnd].State = NodeValue.PulledLow;
        _nodes[_nodePwr].State = NodeValue.PulledHigh;

        // Turn on all transistors connected to VCC.
        foreach (var transistor in _nodes[_nodePwr].Gates)
        {
            transistor.On = true;
        }
    }

    private bool _firstTime = true;

    public void RecalcNodeList()
    {
        _logger?.Begin();

        for (var j = 0; j < 400; j++) // Prevent infinite loops
        {
            (_recalcListOut, _recalcListIn) = (_recalcListIn, _recalcListOut);

            _recalcListOut.Clear();
            _recalcListOutBitmap.SetAll(false);

            if (_recalcListIn.Count == 0)
            {
                _logger?.End();
                return;
            }

            _logger?.BeginIteration(j);

            foreach (var item in _recalcListIn)
            {
                RecalcNode(item);
            }

            _logger?.EndIteration();
        }

        _logger?.End();

        if (_firstTime)
        {
            // Allow chip not to settle on first time. This is necessary for the TIA chip,
            // because it has some nodes that appear to be in a cycle and never settle.
            // TODO: Figure out if this is what it should actually be doing :)
            _firstTime = false;
        }
        else
        {
            throw new Exception("Encountered loop while updating");
        }
    }

    private void RecalcNode(NodeId nodeId)
    {
        _logger?.BeginRecalcNode(nodeId);

        GetNodeGroup(nodeId);

        var newState = GetNodeValue();

        _logger?.SetGroupState(_groupState, newState);

        foreach (var i in _group)
        {
            ref var n = ref _nodes[i];

            if (n.State == newState)
            {
                continue;
            }

            n.State = newState;

            // Loop through all the transistors that this node is the gate for.
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

        _logger?.EndRecalcNode();
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void TurnTransistorOn(Transistor t)
    {
        if (t.On)
        {
            _logger?.AddUnaffectedTransistor(t);
            return;
        }

        _logger?.AddAffectedTransistor(t, true);

        t.On = true;

        AddRecalcNode(t.C1);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void TurnTransistorOff(Transistor t)
    {
        if (!t.On)
        {
            _logger?.AddUnaffectedTransistor(t);
            return;
        }

        _logger?.AddAffectedTransistor(t, false);

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

        _logger?.SetNextNodeTransistorGate(null);

        AddNodeToGroup(nodeId);
    }

    private void AddNodeToGroup(NodeId nodeId)
    {
        _logger?.AddNodeToGroup(nodeId, _nodes[nodeId].State);

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
        else if (node.Pulled == NodeValue.PulledLow)
        {
            _groupState |= GroupState.ContainsPulldown;
        }
        else if (node.State == NodeValue.PulledHigh)
        {
            _groupState |= GroupState.ContainsHi;
        }

        // Loop through all the transistors that this node is connected to as C1 or C2.
        foreach (var t in node.C1C2s)
        {
            // If the transistor is off, it doesn't connect nodes,
            // so this node's change of state has no effect on nodes
            // that are the other side of a transistor gate.
            if (!t.On)
            {
                continue;
            }

            _logger?.SetNextNodeTransistorGate(t.Gate);

            // Figure out which is the "other" side of the transistor.
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

    public void SetNode(NodeId nodeId, NodeValue value, bool recalculate = true)
    {
        Span<NodeId> nodeIds = stackalloc NodeId[1];
        Span<NodeValue> values = stackalloc NodeValue[1];

        nodeIds[0] = nodeId;
        values[0] = value;

        SetNodes(nodeIds, values, recalculate);
    }

    public void SetHigh(NodeId nodeId, bool recalculate = true) => SetNode(nodeId, NodeValue.PulledHigh, recalculate);
    public void SetLow(NodeId nodeId) => SetNode(nodeId, NodeValue.PulledLow);

    private void SetNodes(ReadOnlySpan<NodeId> nodeIds, ReadOnlySpan<NodeValue> values, bool recalculate = true)
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

            if (recalculate)
            {
                _recalcListOut.Add(nodeId);
            }
        }

        if (recalculate)
        {
            RecalcNodeList();
        }
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

    public void SetBus<T>(NodeBus<T> bus, NodeValue value)
        where T : IUnsignedNumber<T>, IShiftOperators<T, int, T>
    {
        Span<NodeValue> values = stackalloc NodeValue[bus.NodeIds.Length];

        for (var i = 0; i < bus.NodeIds.Length; i++)
        {
            values[i] = value;
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

    public IDisposable BeginLogging(string filePath, NodeId? nodeToTrace = null)
    {
        if (_logger != null)
        {
            throw new InvalidOperationException("Logging is already enabled.");
        }

        return new ChipLogger(this, filePath, nodeToTrace);
    }

    private sealed class ChipLogger : IDisposable
    {
        private readonly ChipSimulator _chipSimulator;
        private readonly StreamWriter _streamWriter;
        private readonly NodeId? _nodeToTrace;

        private readonly List<NodeId> _nodes = new();
        private readonly List<RecalcNodesIteration> _iterations = new();
        private RecalcNodesIteration? _currentIteration;
        private RecalcNode? _currentRecalcNode;
        private NodeId? _nextNodeTransistorGate;

        private int _indentLevel;

        public ChipLogger(ChipSimulator chipSimulator, string filePath, NodeId? nodeToTrace)
        {
            _chipSimulator = chipSimulator;
            _streamWriter = new StreamWriter(filePath);
            _nodeToTrace = nodeToTrace;

            chipSimulator._logger = this;
        }

        public void Begin() { }

        public void BeginIteration(int iteration)
        {
            _currentIteration = new RecalcNodesIteration(iteration);
        }

        public void BeginRecalcNode(NodeId nodeId)
        {
            _currentRecalcNode = new RecalcNode(nodeId);
        }

        public void AddNodeToGroup(NodeId nodeId, NodeValue currentValue)
        {
            if (!_currentRecalcNode!.Group.Any(x => x.Item1 == nodeId))
            {
                _currentRecalcNode!.Group.Add((nodeId, _nextNodeTransistorGate, currentValue));
            }
        }

        public void SetNextNodeTransistorGate(NodeId? gate)
        {
            _nextNodeTransistorGate = gate;
        }

        public void SetGroupState(GroupState currentGroupState, NodeValue newGroupState)
        {
            _currentRecalcNode!.CurrentGroupState = currentGroupState;
            _currentRecalcNode!.NewGroupState = newGroupState;
        }

        public void AddAffectedTransistor(Transistor transistor, bool turnedOn)
        {
            _currentRecalcNode!.AffectedTransistors.Add((transistor, turnedOn));
        }

        public void AddUnaffectedTransistor(Transistor transistor)
        {
            //_currentRecalcNode!.UnaffectedTransistors.Add(transistor);
        }

        public void EndRecalcNode()
        {
            _currentIteration!.RecalcNodes.Add(_currentRecalcNode!);
            _currentRecalcNode = null;
        }

        public void EndIteration()
        {
            _iterations.Add(_currentIteration!);
            _currentIteration = null;
        }

        public void End()
        {
            // Search backwards through iterations for everything that affected _nodeToTrace

            List<RecalcNodesIteration> filteredIterations;
            if (_nodeToTrace != null)
            {
                var interestingNodeIds = new HashSet<NodeId>
                {
                    _nodeToTrace.Value
                };

                filteredIterations = new List<RecalcNodesIteration>();

                for (var i = _iterations.Count - 1; i >= 0; i--)
                {
                    var iteration = _iterations[i];

                    var filteredRecalcNodes = new List<RecalcNode>();

                    for (var j = iteration.RecalcNodes.Count - 1; j >= 0; j--)
                    {
                        var recalcNode = iteration.RecalcNodes[j];

                        // Did this recalcNode turn on or off an interesting node?
                        var affectedInterestingTransistors = recalcNode
                            .AffectedTransistors
                            .Any(x => interestingNodeIds.Contains(x.Item1.C1) || interestingNodeIds.Contains(x.Item1.C2));

                        if (interestingNodeIds.Contains(recalcNode.NodeId) || affectedInterestingTransistors)
                        {
                            interestingNodeIds.Add(recalcNode.NodeId);
                            filteredRecalcNodes.Insert(0, recalcNode);
                        }
                    }

                    if (filteredRecalcNodes.Count > 0)
                    {
                        var filteredIteration = new RecalcNodesIteration(iteration.Iteration);
                        filteredIteration.RecalcNodes.AddRange(filteredRecalcNodes);
                        filteredIterations.Insert(0, filteredIteration);
                    }
                }
            }
            else
            {
                filteredIterations = _iterations;
            }

            // Write it to log.

            foreach (var iteration in filteredIterations)
            {
                WriteLine($"Iteration {iteration.Iteration}");
                PushIndentLevel();
                foreach (var recalcNode in iteration.RecalcNodes)
                {
                    WriteLine($"Recalc Node {GetNodeName(recalcNode.NodeId)}:");
                    PushIndentLevel();

                    WriteLine($"Group Nodes:");
                    PushIndentLevel();
                    foreach (var (groupNodeId, viaGateId, groupNodeValue) in recalcNode.Group)
                    {
                        //var transistorGateSuffix = viaGateId != null ? $" (via transistor gate {GetNodeName(viaGateId.Value)})" : "";
                        var transistorGateSuffix = "";
                        WriteLine($"- {GetNodeName(groupNodeId)}: {groupNodeValue}{transistorGateSuffix}");
                    }
                    PopIndentLevel();

                    WriteLine($"Current Group State: {recalcNode.CurrentGroupState}");
                    WriteLine($"New Group State:     {recalcNode.NewGroupState}");

                    WriteLine("Unaffected Transistors:");
                    PushIndentLevel();
                    foreach (var transistor in recalcNode.UnaffectedTransistors)
                    {
                        WriteLine($"- Transistor: {transistor.ToDisplayString(_chipSimulator._nodeIdsType)}");
                    }
                    PopIndentLevel();

                    WriteLine("Affected Transistors:");
                    PushIndentLevel();
                    foreach (var affectedTransistor in recalcNode.AffectedTransistors)
                    {
                        var (transistor, turnedOn) = affectedTransistor;
                        WriteLine($"- Transistor {(turnedOn ? "On" : "Off")}: {transistor.ToDisplayString(_chipSimulator._nodeIdsType)}");
                    }
                    PopIndentLevel();

                    PopIndentLevel();
                }
                PopIndentLevel();
            }

            WriteLine("****************");

            _iterations.Clear();
            _nodes.Clear();
        }

        private string GetNodeName(NodeId nodeId)
        {
            return LoggingUtility.GetNodeName(nodeId, _chipSimulator._nodeIdsType);
        }

        private void WriteLine(string line)
        {
            _streamWriter.WriteLine(new string(' ', _indentLevel * 4) + line);
        }

        private void PushIndentLevel() => _indentLevel++;

        private void PopIndentLevel() => _indentLevel--;

        public void Dispose()
        {
            _streamWriter.Flush();
            _streamWriter.Dispose();
            _chipSimulator._logger = null;
        }

        private sealed class RecalcNodesIteration(int iteration)
        {
            public List<RecalcNode> RecalcNodes = [];

            public int Iteration => iteration;
        }

        private sealed class RecalcNode(NodeId nodeId)
        {
            public NodeId NodeId => nodeId;
            public List<(NodeId, NodeId?, NodeValue)> Group { get; } = [];
            public GroupState CurrentGroupState { get; set; }
            public NodeValue NewGroupState { get; set; }
            public List<(Transistor, bool)> AffectedTransistors { get; } = [];
            public List<Transistor> UnaffectedTransistors { get; } = [];
        }
    }
}