namespace FlawlessChips;

/// <summary>
/// 
/// </summary>
/// <param name="Gate">Gate node</param>
/// <param name="C1">Source node</param>
/// <param name="C2">Drain node</param>
public sealed record TransistorDefinition(
    NodeId Gate,
    NodeId C1,
    NodeId C2);