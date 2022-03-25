using static PO_103.Core.ConsoleHelpers;

namespace PO_103.Core.Features.Engines;

public sealed class GasTurbineEngine : BaseEngine
{
    public Architectures.GasTurbine Architecture { get; }
    
    private GasTurbineEngine(Architectures.GasTurbine type, Fuel fuel)
    {
        Architecture = type;
        Fuel = fuel;
    }

    public static class Factory
    {
        public static GasTurbineEngine NewTurboFanEngine(Fuel fuel) => new(Architectures.GasTurbine.Turbofan, fuel);
        public static GasTurbineEngine NewTurboJetEngine(Fuel fuel) => new(Architectures.GasTurbine.Turbojet, fuel);
    }
    
    public override void MakeStartNoise()
    {
        switch (Architecture)
        {
            case Architectures.GasTurbine.Turbofan:
                WriteLine("*Turbofan noises*", EngineColor);
                break;
            case Architectures.GasTurbine.Turbojet:
                WriteLine("*Turbojet noises*", EngineColor);
                break;
        }
    }

    public override string ToString()
    {
        return $"{base.ToString()} {Architecture}";
    }
}