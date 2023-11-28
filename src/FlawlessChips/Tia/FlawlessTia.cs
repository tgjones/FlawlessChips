using static FlawlessChips.FlawlessTia.NodeIds;

namespace FlawlessChips;

public sealed partial class FlawlessTia : ChipSimulator
{
    public FlawlessTia()
        : base("Tia", VSS, VCC)
    {
    }

    public void Startup()
    {
        SetHigh(CS3);
        SetHigh(CS0);

        StabilizeChip();
    }
}
