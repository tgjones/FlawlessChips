using static FlawlessChips.Flawless2A03.NodeIds;

namespace FlawlessChips;

public sealed partial class Flawless2A03 : ChipSimulator
{
    public Flawless2A03()
        : base("_2A03", gnd, pwr)
    {
    }

    public void Startup()
    {
        SetNode(clk_in, NodeValue.PulledLow);
        for (var i = 0; i < 6; i++)
        {
            SetNode(clk_in, NodeValue.PulledHigh);
            SetNode(clk_in, NodeValue.PulledLow);
        }

        // Assert RESET and initialize other inputs
        SetNode(res, NodeValue.PulledLow);
        SetNode(so, NodeValue.PulledLow);
        SetNode(irq, NodeValue.PulledHigh);
        SetNode(nmi, NodeValue.PulledHigh);

        // Recalculate all nodes until the chip stabilizes
        StabilizeChip();

        // Run for 8 6502 cycles so that RESET fully takes effect
        for (var i = 0; i < 8 * 12; i++)
        {
            SetNode(clk_in, NodeValue.PulledHigh);
            SetNode(clk_in, NodeValue.PulledLow);
        }

        // Deassert RESET so the chip can continue running normally
        SetNode(res, NodeValue.PulledHigh);
    }

    public ushort GetPC() => (ushort)((GetBus(pch) << 8) | GetBus(pcl));
}
