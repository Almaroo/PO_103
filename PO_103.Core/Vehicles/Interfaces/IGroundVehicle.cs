using PO_103.Core.Units;

using static PO_103.Core.ConsoleHelpers;
using static PO_103.Core.Mediums.Ground;

namespace PO_103.Core.Vehicles.Interfaces;

public interface IGroundVehicle : IVehicle
{
    public int WheelsCount { get; }
    
    void IVehicle.Start() => StartGround();
    void StartGround()
    {
        WriteLine("Hit the road Jack", GroundVehicleColor);
        CurrentState = State.Moving;
        Velocity = Instance.Value.MinVelocity;
    }
    void IVehicle.Stop() => StopGround();
    
    void StopGround()
    {
        WriteLine("It is time to stop", GroundVehicleColor);
        CurrentState = State.Stationary;
        Velocity = 0;
    }

    void IVehicle.Accelerate(IUnit value)
    {
        AccelerateGround(value);
    }

    void AccelerateGround(IUnit value)
    {
        if (CurrentState == State.Stationary)
            return;

        if (value is not KilometersPerHour)
        {
            WriteLine("Wrong value. Kmh expected", ErrorColor);
            return;
        }
        
        if (value.Value + Velocity <= Instance.Value.MaxVelocity && value.Value + Velocity >= Instance.Value.MinVelocity)
        {
            Velocity += value.Value;
            WriteLine(
                $"Speed changed by {value.Value}{KilometersPerHour.Unit}. Current speed {GetSpeed()}",
                GroundVehicleColor);
            return;
        }
        
        WriteLine($"Acceleration result is not in range of {Instance.Value.MinVelocity}-{Instance.Value.MaxVelocity}{KilometersPerHour.Unit}", ErrorColor);
    }

    IUnit IVehicle.GetSpeed() => GetSpeed();
    new IUnit GetSpeed() => new KilometersPerHour(Velocity);
}