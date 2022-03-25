using PO_103.Core.Features.Engines;
using PO_103.Core.Mediums;
using PO_103.Core.Units;
using PO_103.Core.Utils;
using PO_103.Core.Vehicles.Interfaces;
using static PO_103.Core.ConsoleHelpers;

namespace PO_103.Core.Vehicles.Air;

public class Jet : IPlane, IMotorVehicle
{
    public IEngine Engine { get; }
    public int WheelsCount => 4;

    public Jet(GasTurbineEngine engine)
    {
        Engine = engine;
    }

    IVehicle.State IVehicle.CurrentState { get; set; }

    public void Accelerate(IUnit value) => ((IPlane) this).AcceleratePlane(value);

    public void Start()
    {
        ((IAerialVehicle) this).StartAerial();
        ((IGroundVehicle) this).StartGround();
        ((IMotorVehicle) this).StartEngine();
    }

    public void Stop()
    {
        try
        {
            ((IAerialVehicle) this).StopAerial();
            ((IGroundVehicle) this).StopGround();
            ((IMotorVehicle) this).StopEngine();
        }
        catch (Exception e)
        {
            WriteLine(e.Message, ErrorColor);
        }
    }

    double IVehicle.Velocity { get; set; }

    MediumBase IVehicle.Medium { get; set; } = Mediums.Ground.Instance.Value;

    public IUnit GetSpeed() => ((IAerialVehicle) this).IsInAir 
        ? new MetersPerSecond(((IVehicle) this).Velocity)
        : new KilometersPerHour(((IVehicle) this).Velocity);

    public override string ToString()
    {
        return $"{this.GetVehicleInfo()}{this.GetEngineInfo()}{this.GetGroundVehicleInfo()}";
    }
}