using PO_103.Core.Features.Engines;

namespace PO_103.Core.Vehicles.Interfaces;

public interface IEngine
{
    void MakeStartNoise();
    public int Power { get; }
    public Fuel Fuel { get; }
}