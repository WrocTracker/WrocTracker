using System;
using WrocTracker;

namespace WrocTrackerClient
{
    public class WrocTrackerClient
    {
        static void Main()
        {
            ITrackable tracker = new Tracker();

            while (Console.ReadKey().Key != ConsoleKey.Escape)
            {
                var vehicles = tracker.GetPositions("16","2", "E", "4", "245", "246", "A", "10", "1", "112");

                foreach (var vehicle in vehicles)
                {
                    Console.WriteLine("Vehicle: {0}, type: {1}, position: ({2}, {3})", vehicle.Name, vehicle.VehicleType,
                        vehicle.Position.Latitude, vehicle.Position.Longitude);
                }

                Console.WriteLine(String.Join(", ", tracker.NotFoundVehicles));
            }
        }
    }
}

