namespace PO_103.Core.Units;

public interface IUnit : IComparable<IUnit>
{
    double Value { get; }
}