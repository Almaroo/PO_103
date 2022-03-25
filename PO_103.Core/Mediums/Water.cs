namespace PO_103.Core.Mediums;

internal sealed class Water : MediumBase
{
    public override int MaxVelocity => 40;
    public override int MinVelocity => 1;

    private Water() { }

    public static Lazy<Water> Instance => new(() => new Water());
}