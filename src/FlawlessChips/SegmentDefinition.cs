namespace FlawlessChips;

internal sealed record SegmentDefinition(
    NodeId NodeId,
    bool Pullup,
    byte Unknown,
    int Area);