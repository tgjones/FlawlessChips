namespace FlawlessChips;

internal sealed record SegmentDefinition(
    NodeId Node,
    bool Pullup,
    byte Unknown,
    int Area);