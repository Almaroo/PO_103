namespace PO_103.Core.Units;

public sealed class MetersPerSecond : IUnit
{
    public double Value { get; }
    public static string Unit => "m/s";

    public MetersPerSecond(double value)
    {
        Value = Math.Round(value, 3);
    }

    public override string ToString()
    {
        return $"{Value}{Unit}";
    }
    
    public static implicit operator MetersPerSecond(double value) => new (value);
    public static implicit operator double(MetersPerSecond value) => value.Value;

    public static explicit operator MetersPerSecond(Knots value) => new (value.Value * 1.944);
    public static explicit operator MetersPerSecond(KilometersPerHour value) => new (value.Value / 3.6);

    public static bool operator <(MetersPerSecond value1, MetersPerSecond value2) => value1.Value < value2.Value;
    public static bool operator >(MetersPerSecond value1, MetersPerSecond value2)  => value1.Value > value2.Value;
    public static bool operator <=(MetersPerSecond value1, MetersPerSecond value2) => value1.Value <= value2.Value;
    public static bool operator >=(MetersPerSecond value1, MetersPerSecond value2)  => value1.Value >= value2.Value;
    
    #region IComparable implementations

    private int CompareTo(MetersPerSecond? other)
    {
        if (ReferenceEquals(this, other)) return 0;
        if (ReferenceEquals(null, other)) return 1;
        return Value.CompareTo(other.Value);
    }
    
    public int CompareTo(IUnit? other)
    {
        // cast to dynamic is required to make use of explicit cast operators
        // otherwise InvalidCastException is thrown
        
        return ReferenceEquals(other, null) ? 0 : CompareTo((MetersPerSecond)(dynamic)other);
    }

    #endregion
}