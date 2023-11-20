using static FlawlessChips.Flawless6502.NodeIds;

namespace FlawlessChips;

public sealed partial class Flawless6502 : ChipSimulator
{
    public Flawless6502()
        : base("FlawlessChips._6502.SegmentDefinitions.txt",
               "FlawlessChips._6502.TransistorDefinitions.txt",
               vss,
               vcc)
    {
    }

    public void Startup()
    {
        // Recalculate all nodes until the chip stabilizes
        StabilizeChip();

        // Assert RESET and initialize other inputs
        SetNode(res, NodeValue.PulledLow);
        SetNode(clk0, NodeValue.PulledLow);
        SetNode(rdy, NodeValue.PulledHigh);
        SetNode(so, NodeValue.PulledLow);
        SetNode(irq, NodeValue.PulledHigh);
        SetNode(nmi, NodeValue.PulledHigh);

        // Run for 8 cycles so that RESET fully takes effect
        for (var i = 0; i < 8; i++)
        {
            SetNode(clk0, NodeValue.PulledHigh);
            SetNode(clk0, NodeValue.PulledLow);
        }

        // Deassert RESET so the chip can continue running normally
        SetNode(res, NodeValue.PulledHigh);
    }
}
