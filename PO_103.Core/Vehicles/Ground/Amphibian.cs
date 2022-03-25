using PO_103.Core.Mediums;
using PO_103.Core.Units;
using PO_103.Core.Utils;
using PO_103.Core.Vehicles.Interfaces;

namespace PO_103.Core.Vehicles.Ground;

public class Amphibian : IAmphibian, IMotorVehicle
{
    public Amphibian(IEngine engine, int buoyancy, int wheelsCount)
    {
        Engine = engine;
        Displacement = buoyancy;
        WheelsCount = wheelsCount;
    }

    IVehicle.State IVehicle.CurrentState { get; set; }
    
    public IEngine Engine { get; set; }


    public void Accelerate(IUnit value)
    {
        ((IAmphibian) this).AccelerateAmphibian(value);
    }

    public int Displacement { get; }

    public int WheelsCount { get; }

    public void Start()
    {
        ((IMaritimeVehicle) this).StartMaritime();
        ((IGroundVehicle) this).StartGround();
        ((IMotorVehicle) this).StartEngine();
    }

    public void Stop()
    {
        ((IMaritimeVehicle) this).StopMaritime();
        ((IGroundVehicle) this).StopGround();
        ((IMotorVehicle) this).StopEngine();
    }

    double IVehicle.Velocity { get; set; }

    MediumBase IVehicle.Medium { get; set; } = Mediums.Ground.Instance.Value;

    public IUnit GetSpeed() => ((IAmphibian) this).IsInWater 
        ? new Knots(((IVehicle) this).Velocity)
        : new KilometersPerHour(((IVehicle) this).Velocity);

    public override string ToString()
    {
        return $"{this.GetVehicleInfo()}{this.GetEngineInfo()}{this.GetGroundVehicleInfo()}{this.GetMaritimeVehicleInfo()}";

    }
}