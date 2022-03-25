using PO_103.Core.Vehicles.Interfaces;

namespace PO_103.Core.Features.Engines;

public abstract class BaseEngine : IEngine
{
    
    public static class Architectures
    {
        public enum GasTurbine
        {
            Turbojet,
            Turbofan
        }
        
        public enum Stroke
        {
            TwoStroke,
            FourStroke,
            SixStroke
        }
    }
    
    public Fuel Fuel { get; protected init; }
    
    public abstract void MakeStartNoise();
    public int Power { get; protected init; } = 1000;

    public override string ToString()
    {
        return GetType().Name;
    }
}