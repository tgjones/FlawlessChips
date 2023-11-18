using static FlawlessChips.Flawless2C02.NodeIds;

namespace FlawlessChips;

public sealed partial class Flawless2C02
{
    public readonly ChipSimulator ChipSimulator;

    public Flawless2C02()
    {
        ChipSimulator = new ChipSimulator(
            "FlawlessChips._2C02.SegmentDefinitions.txt",
            "FlawlessChips._2C02.TransistorDefinitions.txt",
            gnd,
            pwr);
    }

    public void Startup()
    {
        // Assert RESET and initialize other inputs
        ChipSimulator.SetNode(res, NodeValue.PulledLow);
        ChipSimulator.SetNode(clk0, NodeValue.PulledLow);
        ChipSimulator.SetNode(io_ce, NodeValue.PulledHigh);
        ChipSimulator.SetNode(@int, NodeValue.PulledHigh);

        // Recalculate all nodes until the chip stabilizes
        ChipSimulator.StabilizeChip();

        // Run for 4 cycles so that RESET fully takes effect
        for (var i = 0; i < 4; i++)
        {
            ChipSimulator.SetNode(clk0, NodeValue.PulledHigh);
            ChipSimulator.SetNode(clk0, NodeValue.PulledLow);
        }

        // Deassert RESET so the chip can continue running normally
        ChipSimulator.SetNode(res, NodeValue.PulledHigh);
    }

    public void Step()
    {
        var clk = ChipSimulator.IsNodeHigh(clk0);

        ChipSimulator.SetNode(clk0, clk ? NodeValue.PulledLow : NodeValue.PulledHigh);
    }

    public bool GetPinALE() => ChipSimulator.IsNodeHigh(ale);

    public bool GetPinRD() => ChipSimulator.IsNodeHigh(rd);

    public bool GetPinWR() => ChipSimulator.IsNodeHigh(wr);

    public ushort GetPinsAB() => ChipSimulator.GetNodeGroup<ushort>(ab);

    public void SetPinsAB(ushort value) => ChipSimulator.SetNodeGroup(ab, value);

    public byte GetPinsDB() => ChipSimulator.GetNodeGroup<byte>(db);

    public void SetPinsDB(byte value) => ChipSimulator.SetNodeGroup(db, value);

    public void SetPinIO_CE(NodeValue value) => ChipSimulator.SetNode(io_ce, value);

    public void SetPinIO_RW(NodeValue value) => ChipSimulator.SetNode(io_rw, value);

    public byte GetPinsIO_AB() => ChipSimulator.GetNodeGroup<byte>(io_ab);

    public void SetPinsIO_AB(byte value) => ChipSimulator.SetNodeGroup(io_ab, value);

    public byte GetPinsIO_DB() => ChipSimulator.GetNodeGroup<byte>(io_db);

    public void SetPinsIO_DB(byte value) => ChipSimulator.SetNodeGroup(io_db, value);

    public ushort GetHPos() => ChipSimulator.GetNodeGroup<ushort>(hpos);

    public ushort GetVPos() => ChipSimulator.GetNodeGroup<ushort>(vpos);

    public void PaletteWrite(byte address, byte value)
    {
        for (var i = 0; i < 6; i++)
        {
            var n0 = PaletteNodes[address][i][0];
            var n1 = PaletteNodes[address][i][1];

            if ((value & (1 << i)) != 0)
            {
                ChipSimulator.SetBit(n1, n0);
            }
            else
            {
                ChipSimulator.SetBit(n0, n1);
            }
        }
    }
}