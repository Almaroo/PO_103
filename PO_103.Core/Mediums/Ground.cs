namespace PO_103.Core.Mediums;

internal sealed class Ground : MediumBase
{
    public override int MaxVelocity => 350;
    public override int MinVelocity => 1;

    private Ground() { }

    public static Lazy<Ground> Instance => new(() => new Ground());
}