namespace PO_103.Core;

public static class ConsoleHelpers
{
    public static readonly ConsoleColor ErrorColor = ConsoleColor.Red;
    public static readonly ConsoleColor GroundVehicleColor = ConsoleColor.DarkGreen;
    public static readonly ConsoleColor EngineColor = ConsoleColor.Yellow;
    public static readonly ConsoleColor MaritimeColor = ConsoleColor.Cyan;
    public static readonly ConsoleColor AirColor = ConsoleColor.DarkMagenta;

    public static void WriteLine(string message, ConsoleColor consoleColor)
    {
        Console.ForegroundColor = consoleColor;
        Console.WriteLine(message);
        Console.ResetColor();
    }
}