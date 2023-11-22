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
        SetLow(clk_in);
        for (var i = 0; i < 6; i++)
        {
            SetHigh(clk_in);
            SetLow(clk_in);
        }

        // Assert RESET and initialize other inputs
        SetLow(res);
        SetLow(so);
        SetHigh(irq);
        SetHigh(nmi);

        // Recalculate all nodes until the chip stabilizes
        StabilizeChip();

        // Run for 8 6502 cycles so that RESET fully takes effect
        for (var i = 0; i < 8 * 12; i++)
        {
            SetHigh(clk_in);
            SetLow(clk_in);
        }

        // Deassert RESET so the chip can continue running normally
        SetHigh(res);
    }

    public ushort GetPC() => (ushort)((GetBus(pch) << 8) | GetBus(pcl));
}
