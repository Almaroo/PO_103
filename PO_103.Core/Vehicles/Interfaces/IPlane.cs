using PO_103.Core.Units;
using static PO_103.Core.ConsoleHelpers;

namespace PO_103.Core.Vehicles.Interfaces;

public interface IPlane : IGroundVehicle, IAerialVehicle
{
    void IAerialVehicle.TakeOff() => TakeOffPlane();

    void IAerialVehicle.Land() => LandPlane();

    public void TakeOffPlane()
    {
        if (IsInAir)
        {
            WriteLine("Cannot take off. Vehicle is already in air", ErrorColor);
            return;
        }

        if (new KilometersPerHour(Velocity) <= (KilometersPerHour)new MetersPerSecond(Mediums.Air.Instance.Value.MinVelocity))
        {
            WriteLine("Cannot take off. Velocity to small.", ErrorColor);
            return;
        }
        
        WriteLine($"Plane is taking off at {((IVehicle) this).GetSpeed()}", GroundVehicleColor);
        Medium = Mediums.Air.Instance.Value;
        RecalculateVelocity();
        WriteLine($"Plane took off and is flying at speed of {((IVehicle) this).GetSpeed()}", AirColor);
    }

    public void LandPlane()
    {
        if (!IsInAir)
        {
            WriteLine("Cannot land. Vehicle is already on ground", ErrorColor);
            return;
        }

        if (Velocity > new MetersPerSecond(Mediums.Air.Instance.Value.MinVelocity))
        {
            WriteLine("Cannot land. Vehicle is moving to fast", ErrorColor);
            return;
        }
        
        WriteLine($"Plane is landing at {((IVehicle) this).GetSpeed()}", AirColor);
        Medium = Mediums.Ground.Instance.Value;
        RecalculateVelocity();
        WriteLine($"Plane landed and is driving runway at speed of {((IVehicle) this).GetSpeed()}", GroundVehicleColor);
    }

    void IVehicle.Accelerate(IUnit value) => AcceleratePlane(value);
    
    void AcceleratePlane(IUnit value)
    {
        switch (IsInAir, value)
        {
            case (false, KilometersPerHour kmh): 
                AccelerateGround(kmh);
                break;
            case (true, MetersPerSecond mps):
                AccelerateAerial(mps);
                break;
            case (false, _):
                WriteLine("Wrong unit. Proper unit when on ground is km/h.", ErrorColor);
                break;
            case (true, _):
                WriteLine("Wrong unit. Proper unit when in air is mps.", ErrorColor);
                break;
        }
    }
    
    private void RecalculateVelocity()
    {
        if (Medium is Mediums.Air)
            Velocity = (MetersPerSecond) new KilometersPerHour(Velocity);
        else
            Velocity = Math.Min((KilometersPerHour) new MetersPerSecond(Velocity), Mediums.Ground.Instance.Value.MaxVelocity);
    }
}