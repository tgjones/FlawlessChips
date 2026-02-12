namespace FlawlessChips;

public struct Node
{
    public NodeId NodeId;

    /// <summary>
    /// Stores whether this node is pulled high or low, or neither (floating).
    /// </summary>
    public NodeValue Pulled;

    /// <summary>
    /// Stores the current state of this node as the simulation progresses.
    /// </summary>
    public NodeValue State;

    /// <summary>
    /// All the transistors for which this node is the gate.
    /// </summary>
    public List<Transistor> Gates;

    /// <summary>
    /// All the transistors for which this node is C1 or C2.
    /// </summary>
    public List<Transistor> C1C2s;

    public int Area;
}

public enum NodeValue
{
    PulledHigh,
    PulledLow,
    Floating,
}