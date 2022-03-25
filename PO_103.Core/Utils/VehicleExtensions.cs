using System.Text;
using PO_103.Core.Vehicles.Interfaces;

namespace PO_103.Core.Utils;

public static class VehicleExtensions
{
    // methods below are added as replacement for base methods in abstract classes
    
    public static string GetVehicleInfo(this IVehicle vehicle)
    {
        var infoBuilder = new StringBuilder("Vehicle info:\n");
        var vehicleType = vehicle.GetType();
        var interfaces = vehicle.GetType().GetInterfaces();

        infoBuilder.AppendLine($"Type: {vehicleType.Name}");

        infoBuilder.Append("Traits: ");
        foreach (var @interface in interfaces)
        {
            infoBuilder.Append(' ');
            switch (@interface.Name)
            {
                case nameof(IAerialVehicle):
                    infoBuilder.Append("Aerial");
                    break;
                case nameof(IGroundVehicle):
                    infoBuilder.Append("Ground");
                    break;
                case nameof(IMaritimeVehicle):
                    infoBuilder.Append("Maritime");
                    break;
                case nameof(IMotorVehicle):
                    infoBuilder.Append("Motor");
                    break;
                case nameof(IAmphibian):
                    infoBuilder.Append("Amphibian");
                    break;
            }
        }
        infoBuilder.AppendLine();
        
        infoBuilder.AppendLine($"Current state: {vehicle.CurrentState.ToString()}");
        infoBuilder.AppendLine($"Current medium: {vehicle.Medium}");
        infoBuilder.AppendLine($"Speed: {vehicle.GetSpeed()}");
        
        return infoBuilder.ToString();
    }

    public static string GetEngineInfo(this IMotorVehicle motorVehicle)
    {
        var infoBuilder = new StringBuilder("Engine info:\n");

        // Code below could avoid repeating having same ToString methods in GasTurbineEngine and StrokeEngine
        
        /*var engineType = motorVehicle.Engine.GetType();
        var architectureType =
            engineType
                .GetProperty("Architecture")?.GetAccessors()
                .FirstOrDefault(x => x.ReturnType != typeof(void))
                ?.Invoke(motorVehicle.Engine, new object[] { });*/
        
        
        infoBuilder.AppendLine($"Type: {motorVehicle.Engine}");
        infoBuilder.AppendLine($"Fuel: {motorVehicle.Engine.Fuel}");

        return infoBuilder.ToString();
    }

    public static string GetGroundVehicleInfo(this IGroundVehicle groundVehicle)
    {
        var infoBuilder = new StringBuilder("Ground vehicle info:\n");

        infoBuilder.AppendLine($"No wheels: {groundVehicle.WheelsCount}");
        
        return infoBuilder.ToString();
    }

    public static string GetMaritimeVehicleInfo(this IMaritimeVehicle maritimeVehicle)
    {
        var infoBuilder = new StringBuilder("Engine info:\n");

        infoBuilder.AppendLine("Maritime vehicle info:");
        infoBuilder.AppendLine($"Displacement: {maritimeVehicle.Displacement}");
        
        return infoBuilder.ToString();
    }

    // methods below are added to avoid unnecessary code in Program.cs
    public static void PrintAllVehicles(this IEnumerable<IVehicle> vehicles)
    {
        foreach (var vehicle in vehicles)
        {
            Console.WriteLine(vehicle);
        }
    }

    public static void PrintAllGroundVehicles(this IEnumerable<IVehicle> vehicles)
    {
        foreach (var vehicle in vehicles.Where(x => x is IGroundVehicle))
        {
            Console.WriteLine(vehicle);
        }
    }

    public static void PrintAllVehiclesSortedByVelocity(this IEnumerable<IVehicle> vehicles)
    {
        foreach (var vehicle in vehicles.OrderBy(x => x.GetSpeed()).Reverse())
        {
            Console.WriteLine(vehicle);
        }
    }

    public static void PrintAllVehiclesCurrentlyOnLandSortedByVelocity(this IEnumerable<IVehicle> vehicles)
    {
        foreach (var vehicle in vehicles.Where(x => x.Medium is Mediums.Ground).OrderBy(x => x.GetSpeed()).Reverse())
        {
            Console.WriteLine(vehicle);
        }
    }
}