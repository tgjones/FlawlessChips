namespace FlawlessChips;

/// <summary>
/// Represents a contiguous electrically-connected area on the chip.
/// </summary>
public struct Node
{
    public NodeId NodeId { get; init; }

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
    public List<Transistor> Gates { get; init; }

    /// <summary>
    /// All the transistors for which this node is C1 or C2.
    /// </summary>
    public List<Transistor> C1C2s { get; init; }

    /// <summary>
    /// Used to disambiguate which node "wins" if there is a tie.
    /// Only used for specific chips like the 2C02.
    /// </summary>
    public int Area;
}

public enum NodeValue
{
    Floating,
    PulledHigh,
    PulledLow,
}