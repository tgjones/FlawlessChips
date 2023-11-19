using System.Numerics;

namespace FlawlessChips;

public readonly struct NodeBus<T>(NodeId[] nodeIds)
    where T : INumberBase<T>
{
    public readonly NodeId[] NodeIds = nodeIds;
}
