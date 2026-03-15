namespace FlawlessChips.Tests;

internal sealed class EmulatedPia
{
    public int TimerPeriod;
    public byte TimerValue;
    public int TimerClockCount;
    public bool TimerFinished;

    // 128 bytes of RAM
    public readonly byte[] Ram = new byte[128];

    // I/O and timer registers
    public readonly byte[] Iot = new byte[0x297 - 0x280 + 1];
}