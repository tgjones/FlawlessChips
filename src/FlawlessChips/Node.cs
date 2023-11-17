using System.Collections.Generic;

namespace FlawlessChips;

public struct Node
{
    public NodeId NodeId;
    public bool Pullup;
    public bool Pulldown;
    public bool State;
    public List<Transistor> Gates;
    public List<Transistor> C1C2s;
    public int Area;
}