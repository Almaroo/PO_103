using PO_103.Core.Units;
using static PO_103.Core.ConsoleHelpers;

namespace PO_103.Core.Vehicles.Interfaces;

public interface IAmphibian : IMaritimeVehicle, IGroundVehicle
{
    public bool IsInWater => Medium is Mediums.Water;

    public void GoIntoWater()
    {
        WriteLine($"Amphibian leaving land at {((IGroundVehicle) this).GetSpeed()}", GroundVehicleColor);
        Medium = Mediums.Water.Instance.Value;
        RecalculateVelocity();
        WriteLine($"Amphibian continuing in water at {((IMaritimeVehicle) this).GetSpeed()}", MaritimeColor);
    }

    public void GoOnLand()
    {
        WriteLine($"Amphibian leaving water at {((IMaritimeVehicle) this).GetSpeed()}", MaritimeColor);
        Medium = Mediums.Ground.Instance.Value;
        RecalculateVelocity();
        WriteLine($"Amphibian continuing on land at {((IGroundVehicle) this).GetSpeed()}", GroundVehicleColor);
    }

    private void RecalculateVelocity()
    {
        if (Medium is Mediums.Water)
            Velocity = (Knots) new KilometersPerHour(Velocity);
        else
            Velocity = Math.Min((KilometersPerHour) new Knots(Velocity), Mediums.Water.Instance.Value.MaxVelocity);
    }
    
    void IVehicle.Accelerate(IUnit value)
    {
        AccelerateAmphibian(value);
    }

    void AccelerateAmphibian(IUnit value)
    {
        switch (IsInWater, value)
        {
            case (false, KilometersPerHour kmh): 
                AccelerateGround(kmh);
                break;
            case (true, Knots kn):
                AccelerateMaritime(kn);
                break;
            case (false, _):
                WriteLine("Wrong unit. Proper unit when on ground is km/h.", ErrorColor);
                break;
            case (true, _):
                WriteLine("Wrong unit. Proper unit when in water is kn.", ErrorColor);
                break;
        }
    }
}