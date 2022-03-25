namespace PO_103.Core.Units;

public sealed class KilometersPerHour : IUnit
{
    public double Value { get; }
    public static string Unit => "km/h";

    public KilometersPerHour(double value)
    {
        Value = Math.Round(value, 3);
    }

    public override string ToString()
    {
        return $"{Value}{Unit}";
    }
    
    public static implicit operator KilometersPerHour(double value) => new (value);
    public static implicit operator double(KilometersPerHour value) => value.Value;

    public static explicit operator KilometersPerHour(MetersPerSecond value) => new (value.Value * 3.6);
    public static explicit operator KilometersPerHour(Knots value) => new (value.Value * 1.852);

    public static bool operator <(KilometersPerHour value1, KilometersPerHour value2) => value1.Value < value2.Value;
    public static bool operator >(KilometersPerHour value1, KilometersPerHour value2)  => value1.Value > value2.Value;
    public static bool operator <=(KilometersPerHour value1, KilometersPerHour value2) => value1.Value <= value2.Value;
    public static bool operator >=(KilometersPerHour value1, KilometersPerHour value2)  => value1.Value >= value2.Value;

    #region IComparable implementations

    public int CompareTo(IUnit? other)
    {
        // cast to dynamic is required to make use of explicit cast operators
        // otherwise InvalidCastException is thrown
        
        return ReferenceEquals(other, null) ? 0 : CompareTo((KilometersPerHour)(dynamic)other);
    }

    private int CompareTo(KilometersPerHour? other)
    {
        if (ReferenceEquals(this, other)) return 0;
        if (ReferenceEquals(null, other)) return 1;
        return Value.CompareTo(other.Value);
    }
    #endregion
}