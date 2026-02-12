using static FlawlessChips.FlawlessTia.NodeIds;

namespace FlawlessChips;

internal sealed partial class FlawlessTia : ChipSimulator
{
    public FlawlessTia()
        : base("Tia", typeof(NodeIds), VSS, VCC)
    {
    }

    public void Startup()
    {
        SetHigh(CS3);
        SetHigh(CS0);

        StabilizeChip();
    }
}
