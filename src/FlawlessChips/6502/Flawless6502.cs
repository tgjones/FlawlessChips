using static FlawlessChips.Flawless6502.NodeIds;

namespace FlawlessChips;

public sealed partial class Flawless6502 : ChipSimulator
{
    public Flawless6502()
        : base("_6502", vss, vcc)
    {
    }

    public void Startup()
    {
        // Recalculate all nodes until the chip stabilizes
        StabilizeChip();

        // Assert RESET and initialize other inputs
        SetLow(res);
        SetLow(clk0);
        SetHigh(rdy);
        SetLow(so);
        SetHigh(irq);
        SetHigh(nmi);

        // Run for 8 cycles so that RESET fully takes effect
        for (var i = 0; i < 8; i++)
        {
            SetHigh(clk0);
            SetLow(clk0);
        }

        // Deassert RESET so the chip can continue running normally
        SetHigh(res);
    }

    public ushort GetPC() => (ushort)((GetBus(pch) << 8) | GetBus(pcl));
}
