# FlawlessChips [![Build Status](https://github.com/tgjones/FlawlessChips/actions/workflows/ci.yml/badge.svg?branch=main)](https://github.com/tgjones/FlawlessChips/actions)  [![NuGet](https://img.shields.io/nuget/v/FlawlessChips.svg)](https://www.nuget.org/packages/FlawlessChips/)

<img align="right" width="150px" height="150px" src="img/logo.png">

FlawlessChips is a C# library that provides gate-level simulation of various 8-bit chips.

FlawlessChips is (with a nod and wink to [perfect6502](https://github.com/mist64/perfect6502)'s description):

* *Flawless* - it is a simulation of the original transistors, not an emulation. (Of course, there might be bugs...)
* *Slow* - like, *really slow*. This implementation is faster than the JavaScript implementations on which it's based, but it's still way slower than the original chips.

FlawlessChips's intended audience is emulator authors who want to run their emulations and compare e.g. output pins with this half-cycle exact simulation.

## Simulated chips

* [MOS Technology 6502](https://en.wikipedia.org/wiki/MOS_Technology_6502) - `FlawlessChips.Flawless6502`
* [Ricoh 2A03](https://www.nesdev.org/wiki/CPU) - `FlawlessChips.Flawless2A03`
* [Ricoh 2C02](https://www.nesdev.org/wiki/PPU) - `FlawlessChips.Flawless2C02`
* [Zilog Z80](https://en.wikipedia.org/wiki/Zilog_Z80) - `FlawlessChips.FlawlessZ80`
* [Atari 2600 TIA](https://en.wikipedia.org/wiki/Television_Interface_Adaptor) - `FlawlessChips.FlawlessTia`

## Install

FlawlessChips is available as a [NuGet Package](https://www.nuget.org/packages/FlawlessChips/).

## Usage

This example shows the `Flawless6502` chip simulator. Other chips are similar.

``` c#
var chip = new Flawless6502();

// Assert reset pin, initialize other pins, deassert reset pin.
// Calling this method is optional; you can perform this setup
// in your own code.
chip.Startup();

// Create 64K of memory for the chip to work with.
var memory = new byte[ushort.MaxValue + 1];

// Loop a few times.
for (var i = 0; i < 100; i++)
{
    var newClk = !chip.IsHigh(clk0);

    // Pulse clock pin. Any transistors connected to this pin will be re-evaluated, recursively,
    // until the chip "settles" in its new state.
    chip.SetNode(clk0, newClk ? NodeValue.PulledHigh : NodeValue.PulledLow);

    // Memory accesses should only occur when the 6502's phi2 output pin is high.
    if (chip.IsHigh(clk2out))
    {
        // Does the 6502 want to read?
        if (chip.IsHigh(rw))
        {
            // You can access individual pin values via chip.IsHigh(ab0), chip.IsHigh(ab1), etc.
            // But for simplicity there's GetBus and SetBus to set the whole bus value at once.
            var address = chip.GetBus(ab);
            var data = memory[address];
            chip.SetBus(db, data);
        }
        else // Otherwise the 6502 wants to write.
        {
            var address = chip.GetBus(ab);
            var data = chip.GetBus(db);
            memory[address] = data;
        }
    }

    // Print out a few interesting bits of chip state. There are also hundreds of other node names
    // available in the FlawlessChips.Flawless6502.NodeIds class.
    Console.WriteLine(
        "Φ2 {0}   PC {1:X4}   X {2:X2}   Y {3:X2}   A {4:X2}   SP {5:X2}   AB {6:X4}   DB {7:X2}   RW {8}",
        chip.IsHigh(clk2out) ? '1' : '0',
        chip.GetPC(),
        chip.GetBus(x),
        chip.GetBus(y),
        chip.GetBus(a),
        chip.GetBus(s),
        chip.GetBus(ab),
        chip.GetBus(db),
        chip.IsHigh(rw) ? '1' : '0');
}
```

## License

This software is released under the [BSD-Clause 2 license](https://opensource.org/licenses/BSD-2-Clause). 

## Credits

This project is essentially a C# port of the following projects. The authors of these projects deserve huge credit
for their efforts in photographing chips, analyzing circuits, and writing the simulators.

* [Visual 6502](http://www.visual6502.org/JSSim/index.html) by Greg James, Brian Silverman, and Barry Silverman
  * with optimization ideas from [perfect6502](https://github.com/mist64/perfect6502) by [Michael Steil](http://www.pagetable.com/).

* [Visual 2A03](https://www.qmtpro.com/~nes/chipimages/visual2a03/) by [quietust](https://www.qmtpro.com/)
  * with additional inspiration from [VisualNES](https://github.com/SourMesen/VisualNes) by [SourMesen](https://github.com/SourMesen)

* [Visual 2C02](https://www.qmtpro.com/~nes/chipimages/visual2c02/) by [quietust](https://www.qmtpro.com/)
  * with additional inspiration from [VisualNES](https://github.com/SourMesen/VisualNes) by [SourMesen](https://github.com/SourMesen)

* [Visual Z80](http://www.visual6502.org/JSSim/expert-z80.html), authorship unknown, perhaps Greg James, Brian Silverman, and Barry Silverman

* [Sim2600](https://github.com/gregjames/Sim2600) by [Greg James](https://github.com/gregjames)

The logo is a modified version of the [chips](https://thenounproject.com/icon/chips-4719557/) icon by [pictranoosa](https://thenounproject.com/ihsannugroho/), and the [perfect](https://thenounproject.com/icon/perfect-1221120/) icon by [Paffi](https://thenounproject.com/paffi/).

## Author

Tim Jones