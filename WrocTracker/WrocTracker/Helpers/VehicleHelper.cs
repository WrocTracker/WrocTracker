using System;
using System.Globalization;
using System.IO;

namespace WrocTracker.Helpers
{
    public static class VehicleHelper
    {
        public static string GetVehicleType(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new InvalidDataException("Invalid MPK vehicle name");
            }

            if (Char.IsLetter(name[0]))
            {
                return "bus";
            }

            if (name.ToUpper() == "0P" || name.ToUpper() == "0L")
            {
                return "tram";
            }

            int number;
            if (int.TryParse(name, NumberStyles.Integer, CultureInfo.InvariantCulture, out number))
            {
                if (number < 100)
                {
                    return "tram";
                }

                if (number >= 100)
                {
                    return "bus";
                }
            }

            throw new InvalidDataException("Invalid MPK vehicle name");
        }
    }
}
