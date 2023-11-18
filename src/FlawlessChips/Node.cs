using System.Collections.Generic;

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

    public List<Transistor> Gates;
    public List<Transistor> C1C2s;
    public int Area;
}

public enum NodeValue
{
    PulledHigh,
    PulledLow,
    Floating,
}