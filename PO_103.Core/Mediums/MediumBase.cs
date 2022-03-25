namespace PO_103.Core.Mediums;

public abstract class MediumBase
{
    public virtual int MaxVelocity { get; }
    public virtual int MinVelocity { get; }

    public override string ToString()
    {
        return $"{GetType().Name} [{MinVelocity}-{MaxVelocity}]";
    }
}