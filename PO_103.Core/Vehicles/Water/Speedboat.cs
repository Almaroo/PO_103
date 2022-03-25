using PO_103.Core.Features.Engines;
using PO_103.Core.Mediums;
using PO_103.Core.Utils;
using PO_103.Core.Vehicles.Interfaces;

namespace PO_103.Core.Vehicles.Water;

public class Speedboat : IMaritimeVehicle, IMotorVehicle
{
    public IEngine Engine { get; }
    public int Displacement { get; }
    
    public Speedboat(StrokeEngine engine, int buoyancy)
    {
        Engine = engine;
        Displacement = buoyancy;
    }

    IVehicle.State IVehicle.CurrentState { get; set; }

    public void Start()
    {
        ((IMaritimeVehicle) this).StartMaritime();
        ((IMotorVehicle) this).StartEngine();
    }

    public void Stop()
    {
        ((IMaritimeVehicle) this).StopMaritime();
        ((IMotorVehicle) this).StopEngine();
    }

    double IVehicle.Velocity { get; set; }

    MediumBase IVehicle.Medium { get; set; } = Mediums.Water.Instance.Value;

    public override string ToString()
    {
        return $"{this.GetVehicleInfo()}{this.GetEngineInfo()}{this.GetMaritimeVehicleInfo()}";
    }
}