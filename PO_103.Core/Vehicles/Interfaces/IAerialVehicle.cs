using PO_103.Core.Units;
using static PO_103.Core.ConsoleHelpers;

namespace PO_103.Core.Vehicles.Interfaces;

public interface IAerialVehicle : IVehicle
{
    public bool IsInAir => Medium is Mediums.Air;

    void TakeOff() => Medium = Mediums.Air.Instance.Value;
    void Land() => Medium = Mediums.Ground.Instance.Value;

    void IVehicle.Accelerate(IUnit value) => AccelerateAerial(value);

    void AccelerateAerial(IUnit value)
    {
        if (CurrentState == State.Stationary)
            return;
        
        if (value is not MetersPerSecond)
        {
            WriteLine("Wrong value. Mps expected", ErrorColor);
            return;
        }
        
        if (value.Value + Velocity <= Mediums.Air.Instance.Value.MaxVelocity && value.Value + Velocity >= Mediums.Air.Instance.Value.MinVelocity)
        {
            Velocity += value.Value;
            WriteLine(
                $"Speed changed by {value.Value}{MetersPerSecond.Unit}. Current speed {GetSpeed()}",
                AirColor);
            return;
        }
        
        WriteLine($"Acceleration result is not in range of {Mediums.Air.Instance.Value.MinVelocity}-{Mediums.Air.Instance.Value.MaxVelocity}{MetersPerSecond.Unit}", ErrorColor);
    }

    IUnit IVehicle.GetSpeed() => GetSpeed();
    new IUnit GetSpeed() => new MetersPerSecond(Velocity);
    

    void IVehicle.Start() => StartAerial();

    public void StartAerial()
    {
        WriteLine("Cleared for takeoff runway zero-one", AirColor);
        CurrentState = State.Moving;
        TakeOff();
        Velocity = Mediums.Air.Instance.Value.MinVelocity;
    }
    
    void IVehicle.Stop() => StopAerial();
    void StopAerial()
    {
        if (IsInAir)
            throw new InvalidOperationException("Cannot stop aircraft when in air");

        WriteLine("Thank you for flying Ryanair", AirColor);
        CurrentState = State.Stationary;
        Velocity = 0;
    }
}