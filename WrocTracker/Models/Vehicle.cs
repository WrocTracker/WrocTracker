using System;
using WrocTracker.Enums;

namespace WrocTracker.Models
{
    public struct Vehicle
    {
        public string Name;
        public Position Position;
        public VehicleType VehicleType;

        public Vehicle(MpkObject mpkObject)
        {
            Name = mpkObject.Name.ToUpper();
            VehicleType = GetVehicleTypeFromString(mpkObject.Type);
            
            Position = new Position
            {
                Latitude = mpkObject.X,
                Longitude = mpkObject.Y,
            };
        }

        private static VehicleType GetVehicleTypeFromString(string type)
        {
            switch (type)
            {
                case "bus":
                    return VehicleType.Bus;
                case "tram":
                    return VehicleType.Tram;
                default:
                    throw new ArgumentOutOfRangeException("type");
            }
        }
    }
}
