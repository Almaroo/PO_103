namespace PO_103.Core.Mediums;

internal sealed class Air : MediumBase
{
    public override int MaxVelocity => 200;
    public override int MinVelocity => 20;

    private Air() { }

    public static Lazy<Air> Instance => new(() => new Air());
}