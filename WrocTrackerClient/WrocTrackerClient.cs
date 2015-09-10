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
                string[] vehiclesToQuery = {"A", "C", "6"};

                var vehicles = tracker.GetPositions(vehiclesToQuery).Result;

                foreach (var vehicle in vehicles)
                {
                    Console.WriteLine("Vehicle: {0}, type: {1}, position: ({2}, {3})", vehicle.Name, vehicle.VehicleType,
                        vehicle.Position.Latitude, vehicle.Position.Longitude);
                }
            }
        }
    }
}

