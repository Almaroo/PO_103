namespace PO_103.Core.Units;

public sealed class Knots : IUnit
{
    public double Value { get; }
    public static string Unit => "kn";

    public Knots(double value)
    {
        Value = Math.Round(value, 3);
    }
    
    public override string ToString()
    {
        return $"{Value}{Unit}";
    }
    
    public static implicit operator Knots(double value) => new (value);
    public static implicit operator double(Knots value) => value.Value;

    public static explicit operator Knots(MetersPerSecond value) => new (value.Value / 1.944);
    public static explicit operator Knots(KilometersPerHour value) => new (value.Value / 1.852);

    public static bool operator <(Knots value1, Knots value2) => value1.Value < value2.Value;
    public static bool operator >(Knots value1, Knots value2)  => value1.Value > value2.Value;
    public static bool operator <=(Knots value1, Knots value2) => value1.Value <= value2.Value;
    public static bool operator >=(Knots value1, Knots value2)  => value1.Value >= value2.Value;
    
    #region IComparable implementations

    private int CompareTo(Knots? other)
    {
        if (ReferenceEquals(this, other)) return 0;
        if (ReferenceEquals(null, other)) return 1;
        return Value.CompareTo(other.Value);
    }
    
    public int CompareTo(IUnit? other)
    {
        // cast to dynamic is required to make use of explicit cast operators
        // otherwise InvalidCastException is thrown
        
        return ReferenceEquals(other, null) ? 0 : CompareTo((Knots)(dynamic)other);
    }
    
    #endregion
}