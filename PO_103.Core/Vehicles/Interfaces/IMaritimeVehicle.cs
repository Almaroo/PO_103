using PO_103.Core.Units;
using static PO_103.Core.ConsoleHelpers;
using static PO_103.Core.Mediums.Water;

namespace PO_103.Core.Vehicles.Interfaces;

public interface IMaritimeVehicle : IVehicle
{
    public int Displacement { get; }

    void IVehicle.Start() => StartMaritime();
    void StartMaritime()
    {
        WriteLine("Set sails!", MaritimeColor);
        CurrentState = State.Moving;
        Velocity = Instance.Value.MinVelocity;
    }

    void IVehicle.Stop() => StopMaritime();
    void StopMaritime()
    {
        WriteLine("Back in harbour", MaritimeColor);
        CurrentState = State.Stationary;
        Velocity = 0;
    }

    void IVehicle.Accelerate(IUnit value)
    {
        AccelerateMaritime(value);
    }

    void AccelerateMaritime(IUnit value)
    {
        if (CurrentState == State.Stationary)
            return;
        
        if (value is not Knots)
        {
            WriteLine("Wrong value. Kn expected", ErrorColor);
            return;
        }
        
        if (value.Value + Velocity <= Instance.Value.MaxVelocity && value.Value + Velocity >= Instance.Value.MinVelocity)
        {
            Velocity += value.Value;
            WriteLine($"Speed changed by {value.Value}{Knots.Unit}. Current speed {GetSpeed()}", AirColor);
            return;
        }
        
        WriteLine($"Acceleration result is not in range of {Instance.Value.MinVelocity}-{Instance.Value.MaxVelocity}{Knots.Unit}", ErrorColor);
    }

    new IUnit GetSpeed() => new Knots(Velocity);

    IUnit IVehicle.GetSpeed() => GetSpeed();
}