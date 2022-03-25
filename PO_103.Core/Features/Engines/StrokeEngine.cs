using static PO_103.Core.ConsoleHelpers;

namespace PO_103.Core.Features.Engines;

public sealed class StrokeEngine : BaseEngine
{
    public Architectures.Stroke Architecture { get; }
    
    private StrokeEngine(Architectures.Stroke type, Fuel fuel, int power)
    {
        Architecture = type;
        Fuel = fuel;
        Power = power;
    }
    
    public static class Factory
    {
        public static StrokeEngine NewDieselEngine(Architectures.Stroke architecture, int power) => new(architecture, Fuel.Diesel, power);
        public static StrokeEngine NewPetroleumEngine(Architectures.Stroke architecture, int power) => new(architecture, Fuel.Petroleum, power);
    }

    public override void MakeStartNoise()
    {
        switch (Architecture)
        {
            case Architectures.Stroke.TwoStroke:
                WriteLine("*TwoStroke engine noises*", EngineColor);
                break;
            case Architectures.Stroke.FourStroke:
                WriteLine("*FourStroke engine noises*", EngineColor);
                break;
            case Architectures.Stroke.SixStroke:
                WriteLine("*SixStroke engine noises*", EngineColor);
                break;
            default:
                WriteLine("Unknown architecture", ErrorColor);
                break;
        }
    }

    public override string ToString()
    {
        return $"{base.ToString()} {Architecture}";
    }
}