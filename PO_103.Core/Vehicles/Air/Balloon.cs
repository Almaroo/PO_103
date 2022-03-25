using PO_103.Core.Mediums;
using PO_103.Core.Vehicles.Interfaces;

namespace PO_103.Core.Vehicles.Air;

public class Balloon : IAerialVehicle
{
    IVehicle.State IVehicle.CurrentState { get; set; }

    double IVehicle.Velocity { get; set; }

    MediumBase IVehicle.Medium { get; set; } = Mediums.Ground.Instance.Value;

    public bool IsInAir { get; init; }
}