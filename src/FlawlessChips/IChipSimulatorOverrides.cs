using System.Collections.Generic;

namespace FlawlessChips;

/// <summary>
/// Allows each chip to customize some aspects of the chip simulator.
/// For performance reasons, this is done via static dispatch, using
/// this interface with static interface methods and generics.
/// </summary>
public interface IChipSimulatorOverrides
{
    static abstract void OverrideGroupState(ref GroupState groupState, List<NodeId> group);
}
