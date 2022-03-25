using PO_103.Core.Features.Engines;
using PO_103.Core.Units;
using PO_103.Core.Utils;
using PO_103.Core.Vehicles.Air;
using PO_103.Core.Vehicles.Ground;
using PO_103.Core.Vehicles.Interfaces;
using PO_103.Core.Vehicles.Water;
using static PO_103.Core.Features.Engines.BaseEngine.Architectures;

var mazdarx7 = new Car(StrokeEngine.Factory.NewPetroleumEngine(Stroke.FourStroke, 200), 4);

Console.WriteLine("--- BEGIN CAR ---");
mazdarx7.Start();
mazdarx7.Accelerate(new KilometersPerHour(20));
mazdarx7.Accelerate(new KilometersPerHour(400));
mazdarx7.Stop();
Console.WriteLine("--- END CAR ---");
Console.WriteLine();

var boeing737 = new Jet(GasTurbineEngine.Factory.NewTurboJetEngine(Fuel.Petroleum));

Console.WriteLine("--- BEGIN JET ---");
boeing737.Start();
boeing737.Accelerate(new MetersPerSecond(40));
boeing737.Accelerate(new KilometersPerHour(72));
boeing737.Stop();

boeing737.Start();
boeing737.Accelerate(new MetersPerSecond(40));
boeing737.Accelerate(new KilometersPerHour(40));
((IAerialVehicle) boeing737).TakeOff();
boeing737.Accelerate(new KilometersPerHour(40));
((IAerialVehicle) boeing737).TakeOff();
boeing737.Accelerate(new KilometersPerHour(40));
boeing737.Accelerate(new MetersPerSecond(40));
boeing737.Accelerate(new MetersPerSecond(100));
// acceleration will fail due to passing higher limit
boeing737.Accelerate(new MetersPerSecond(100));
boeing737.Accelerate(new MetersPerSecond(-100));

((IAerialVehicle) boeing737).TakeOff();

// should display info that turning off engine when in air is forbidded
boeing737.Stop();

// should display info that moving too fast
((IAerialVehicle) boeing737).Land();
boeing737.Accelerate(new MetersPerSecond(-42.5));

// after landing we should be able to turn off the engine
((IAerialVehicle) boeing737).Land();
((IVehicle) boeing737).Stop();

Console.WriteLine("--- END JET ---");
Console.WriteLine();

var pershingx9 = new Speedboat(StrokeEngine.Factory.NewDieselEngine(Stroke.SixStroke, 600), 1200);

Console.WriteLine("--- BEGIN SPEEDBOAT ---");
((IVehicle)pershingx9).Start();
((IVehicle)pershingx9).Accelerate(new Knots(10));
((IVehicle)pershingx9).Accelerate(new Knots(10));
((IVehicle)pershingx9).Accelerate(new Knots(50));
((IVehicle)pershingx9).Stop();
Console.WriteLine("--- END SPEEDBOAT ---");
Console.WriteLine();

var balloon = new Balloon();

Console.WriteLine("--- BEGIN BALLOON ---");

((IAerialVehicle) balloon).Start();
((IAerialVehicle) balloon).TakeOff();
((IAerialVehicle) balloon).Accelerate(new MetersPerSecond(5));
((IAerialVehicle) balloon).Land();
((IAerialVehicle) balloon).Stop();

Console.WriteLine("--- END BALLOON ---");
Console.WriteLine();

var amphibian = new Amphibian(StrokeEngine.Factory.NewDieselEngine(Stroke.FourStroke, 1200), 12600, 4);

Console.WriteLine("--- BEGIN AMPHIBIAN ---");

amphibian.Start();
amphibian.Accelerate(new KilometersPerHour(30));
amphibian.Accelerate(new Knots(10));
((IAmphibian) amphibian).GoIntoWater();
amphibian.Accelerate(new KilometersPerHour(30));
amphibian.Accelerate(new Knots(30));
((IAmphibian) amphibian).GoOnLand();
amphibian.Accelerate(new KilometersPerHour(30));
amphibian.Accelerate(new Knots(30));
amphibian.Stop();

Console.WriteLine("--- END AMPHIBIAN ---");
Console.WriteLine();

IVehicle romet = new Bike();

Console.WriteLine("--- BEGIN BIKE ---");
romet.Start();
romet.Accelerate(new KilometersPerHour(10));
romet.Accelerate(new MetersPerSecond(2));
romet.Accelerate(new KilometersPerHour(10));
romet.Stop();

Console.WriteLine("--- END BIKE ---");
Console.WriteLine();

Console.WriteLine("--- BEGIN KAYAK ---");
IVehicle kayak = new Kayak(200);
kayak.Start();
kayak.Accelerate(new Knots(2));
kayak.Accelerate(new Knots(3));
kayak.Accelerate(new Knots(4));
kayak.Stop();
Console.WriteLine("--- END KAYAK ---");
Console.WriteLine();


var vehicles = new List<IVehicle>
{
    mazdarx7,
    boeing737,
    pershingx9,
    amphibian,
    romet
};

Console.WriteLine("--- BEGIN TEST ToString ---");

amphibian.Start();
((IAmphibian) amphibian).GoIntoWater();
Console.WriteLine(amphibian.GetVehicleInfo());
((IAmphibian) amphibian).GoOnLand();
Console.WriteLine(amphibian.GetVehicleInfo());

Console.WriteLine(amphibian.GetEngineInfo());
Console.WriteLine("--- END TEST ToString ---");
Console.WriteLine();

Console.WriteLine("--- BEGIN ALL VEHICLES ---");
vehicles.PrintAllVehicles();
Console.WriteLine("--- END ALL VEHICLES ---");
Console.WriteLine();

Console.WriteLine("--- BEGIN ONLY GROUND VEHICLES ---");
vehicles.PrintAllGroundVehicles();
Console.WriteLine("--- END ONLY GROUND VEHICLES ---");
Console.WriteLine();

// Lets start boeing and accelerate it to 72km/h = 20m/s

boeing737.Start();
boeing737.Accelerate(new KilometersPerHour(72));

// Boeing takes off
((IAerialVehicle) boeing737).TakeOff();

// Accelerate amphibian to 22km/h
amphibian.Accelerate(new KilometersPerHour(21));


// We expect to see boeing first as 20m/s > 22km/h

Console.WriteLine("--- BEGIN SORTED BY SPEED ---");
vehicles.PrintAllVehiclesSortedByVelocity();
Console.WriteLine("--- END SORTED BY SPEED ---");
Console.WriteLine();


// We expect to see amphibian first since boeing has took off and is no longer on ground

Console.WriteLine("--- BEGIN ONLY ON GROUND VEHICLES SORTED BY SPEED ---");
vehicles.PrintAllVehiclesCurrentlyOnLandSortedByVelocity();
Console.WriteLine("--- END ONLY ON GROUND VEHICLES SORTED BY SPEED ---");
Console.WriteLine();
