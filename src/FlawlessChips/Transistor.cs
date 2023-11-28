namespace FlawlessChips;

public sealed class Transistor(ushort gate, ushort c1, ushort c2)
{
    public readonly NodeId Gate = gate;
    public readonly NodeId C1 = c1;
    public readonly NodeId C2 = c2;

    public bool On;
}
