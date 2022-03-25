using PO_103.Core.Mediums;
using PO_103.Core.Units;

namespace PO_103.Core.Vehicles.Interfaces;

public interface IVehicle
{
    enum State
    {
        Stationary,
        Moving
    }
    
    State CurrentState { get; protected set; }

    virtual void Accelerate(IUnit value) => Velocity += value.Value;

    public void Start()
    {
        CurrentState = State.Moving;
    }

    public void Stop()
    {
        CurrentState = State.Stationary;
        Velocity = 0;
    }

    double Velocity { get; protected set; }
    MediumBase Medium { get; protected set; }
    public IUnit GetSpeed();
}