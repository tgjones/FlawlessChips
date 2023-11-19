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
        // Assert RESET and initialize other inputs
        SetNode(res, NodeValue.PulledLow);
        SetNode(clk0, NodeValue.PulledLow);
        SetNode(rdy, NodeValue.PulledHigh);
        SetNode(so, NodeValue.PulledLow);
        SetNode(irq, NodeValue.PulledHigh);
        SetNode(nmi, NodeValue.PulledHigh);

        // Recalculate all nodes until the chip stabilizes
        StabilizeChip();

        // Run for 4 cycles so that RESET fully takes effect
        for (var i = 0; i < 4; i++)
        {
            SetNode(clk0, NodeValue.PulledHigh);
            SetNode(clk0, NodeValue.PulledLow);
        }

        // Deassert RESET so the chip can continue running normally
        SetNode(res, NodeValue.PulledHigh);

        // Run for 18 cycles so that chip is... definitely ready for user code?
        for (var i = 0; i < 18; i++)
        {
            SetNode(clk0, NodeValue.PulledHigh);
            SetNode(clk0, NodeValue.PulledLow);
        }
    }
}
