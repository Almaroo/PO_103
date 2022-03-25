using PO_103.Core.Mediums;
using PO_103.Core.Utils;
using PO_103.Core.Vehicles.Interfaces;

namespace PO_103.Core.Vehicles.Ground;

public class Bike : IGroundVehicle
{
    IVehicle.State IVehicle.CurrentState { get; set; }

    double IVehicle.Velocity { get; set; }

    MediumBase IVehicle.Medium { get; set; } = Mediums.Ground.Instance.Value;

    public int WheelsCount => 2;

    public override string ToString()
    {
        return $"{this.GetVehicleInfo()}{this.GetGroundVehicleInfo()}";

    }
}