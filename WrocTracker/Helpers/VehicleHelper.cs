using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using WrocTracker.Models;

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

        public static List<Vehicle> SortVehicles(IEnumerable<Vehicle> vehicles)
        {
            int notImportatnInteger;
            var vehicles1 = vehicles.Where(k => Int32.TryParse(k.Name, out notImportatnInteger)).OrderBy(e => Int32.Parse(e.Name));
            var vehicles2 = vehicles.Where(k => !Int32.TryParse(k.Name, out notImportatnInteger)).OrderBy(e => e.Name);

            var result = new List<Vehicle>();
            result.AddRange(vehicles1);
            result.AddRange(vehicles2);

            return result;
        }
    }
}
