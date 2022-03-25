using PO_103.Core.Mediums;
using PO_103.Core.Utils;
using PO_103.Core.Vehicles.Interfaces;

namespace PO_103.Core.Vehicles.Water;
 
public class Kayak : IMaritimeVehicle
{
    public Kayak(int buoyancy)
    {
        Displacement = buoyancy;
    }

    IVehicle.State IVehicle.CurrentState { get; set; }

    double IVehicle.Velocity { get; set; }

    MediumBase IVehicle.Medium { get; set; } = Mediums.Water.Instance.Value;

    public int Displacement { get; }

    public override string ToString()
    {
        return $"{this.GetVehicleInfo()}{this.GetMaritimeVehicleInfo()}";
    }
}