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
                var vehicles = tracker.GetPositions("A", "C", "6", "2", "7", "11", "10", "4", "C", "D", "1", "245");

                foreach (var vehicle in vehicles)
                {
                    Console.WriteLine("Vehicle: {0}, type: {1}, position: ({2}, {3})", vehicle.Name, vehicle.VehicleType,
                        vehicle.Position.Latitude, vehicle.Position.Longitude);
                }
            }
        }
    }
}

