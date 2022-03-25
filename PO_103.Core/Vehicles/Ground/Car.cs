using PO_103.Core.Features.Engines;
using PO_103.Core.Mediums;
using PO_103.Core.Units;
using PO_103.Core.Utils;
using PO_103.Core.Vehicles.Interfaces;

namespace PO_103.Core.Vehicles.Ground;

public class Car : IGroundVehicle, IMotorVehicle
{
    public IEngine Engine { get; }
    public int WheelsCount { get; }

    
    public Car(StrokeEngine engine, int wheelsCount)
    {
        Engine = engine;
        WheelsCount = wheelsCount;
    }

    IVehicle.State IVehicle.CurrentState { get; set; }
    
    public void Start()
    {
        ((IGroundVehicle) this).StartGround();
        ((IMotorVehicle) this).StartEngine();
    }

    public void Stop()
    {
        ((IGroundVehicle) this).StopGround();
        ((IMotorVehicle) this).StopEngine();
    }

    double IVehicle.Velocity { get; set; }

    MediumBase IVehicle.Medium { get; set; } = Mediums.Ground.Instance.Value;

    public void Accelerate(KilometersPerHour value)
    {
        ((IGroundVehicle) this).AccelerateGround(value);
    }

    public override string ToString()
    {
        return $"{this.GetVehicleInfo()}{this.GetEngineInfo()}{this.GetGroundVehicleInfo()}";

    }
}   