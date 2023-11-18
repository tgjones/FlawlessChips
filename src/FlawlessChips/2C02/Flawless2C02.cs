namespace FlawlessChips;

public sealed partial class Flawless2C02 : ChipSimulator
{
    public Flawless2C02()
        : base("FlawlessChips._2C02.SegmentDefinitions.txt",
               "FlawlessChips._2C02.TransistorDefinitions.txt",
               NodeIds.gnd,
               NodeIds.pwr)
    {

    }

    public void Startup()
    {
        // Assert RESET and initialize other inputs
        SetNode(NodeIds.res, NodeValue.PulledLow);
        SetNode(NodeIds.clk0, NodeValue.PulledLow);
        SetNode(NodeIds.io_ce, NodeValue.PulledHigh);
        SetNode(NodeIds.@int, NodeValue.PulledHigh);

        // Recalculate all nodes until the chip stabilizes
        StabilizeChip();

        // Run for 4 cycles so that RESET fully takes effect
        for (var i = 0; i < 4; i++)
        {
            SetNode(NodeIds.clk0, NodeValue.PulledHigh);
            SetNode(NodeIds.clk0, NodeValue.PulledLow);
        }

        // Deassert RESET so the chip can continue running normally
        SetNode(NodeIds.res, NodeValue.PulledHigh);
    }

    public void Step()
    {
        var clk = IsNodeHigh(NodeIds.clk0);

        SetNode(NodeIds.clk0, clk ? NodeValue.PulledLow : NodeValue.PulledHigh);
    }

    public bool GetPinALE() => IsNodeHigh(NodeIds.ale);

    public bool GetPinRD() => IsNodeHigh(NodeIds.rd);

    public bool GetPinWR() => IsNodeHigh(NodeIds.wr);

    public ushort GetPinsAB() => GetNodeGroup<ushort>(NodeIds.ab);

    public void SetPinsAB(ushort value) => SetNodeGroup(NodeIds.ab, value);

    public byte GetPinsDB() => GetNodeGroup<byte>(NodeIds.db);

    public void SetPinsDB(byte value) => SetNodeGroup(NodeIds.db, value);

    public void SetPinIO_CE(NodeValue value) => SetNode(NodeIds.io_ce, value);

    public void SetPinIO_RW(NodeValue value) => SetNode(NodeIds.io_rw, value);

    public byte GetPinsIO_AB() => GetNodeGroup<byte>(NodeIds.io_ab);

    public void SetPinsIO_AB(byte value) => SetNodeGroup(NodeIds.io_ab, value);

    public byte GetPinsIO_DB() => GetNodeGroup<byte>(NodeIds.io_db);

    public void SetPinsIO_DB(byte value) => SetNodeGroup(NodeIds.io_db, value);

    public ushort GetHPos() => GetNodeGroup<ushort>(NodeIds.hpos);

    public ushort GetVPos() => GetNodeGroup<ushort>(NodeIds.vpos);

    public void PaletteWrite(byte address, byte value)
    {
        for (var i = 0; i < 6; i++)
        {
            var n0 = NodeIds.PaletteNodes[address][i][0];
            var n1 = NodeIds.PaletteNodes[address][i][1];

            if ((value & (1 << i)) != 0)
            {
                SetBit(n1, n0);
            }
            else
            {
                SetBit(n0, n1);
            }
        }
    }
}