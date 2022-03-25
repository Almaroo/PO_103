using static PO_103.Core.ConsoleHelpers;

namespace PO_103.Core.Vehicles.Interfaces;

public interface IMotorVehicle : IVehicle
{
    public IEngine Engine { get; }

    void IVehicle.Start() => StartEngine();
    
    void StartEngine()
    {
        Engine.MakeStartNoise();
        CurrentState = State.Moving;
    }

    void IVehicle.Stop() => StopEngine();
    
    void StopEngine()
    {
        WriteLine("Engine is turning off", EngineColor);
        CurrentState = State.Stationary;
        Velocity = 0;
    }
}