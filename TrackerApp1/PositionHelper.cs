using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;

namespace TrackerApp1
{
    public static class PositionHelper
    {
        public static double CalculateDistance(Point firstCoordinate, Point secondCoordinate)
        {
            double R = 6371.0; // km
            double lon1 = DegToRad(firstCoordinate.X);
            double lat1 = DegToRad(firstCoordinate.Y);

            double lon2 = DegToRad(secondCoordinate.X);
            double lat2 = DegToRad(secondCoordinate.Y);

            double dLat = lat2 - lat1;
            double dLon = lon2 - lon1;

            double a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) + Math.Sin(dLon / 2) * Math.Sin(dLon / 2) * Math.Cos(lat1) * Math.Cos(lat2);
            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
           
            return R * c * 1000;
        }

        private static double DegToRad(double degrees)
        {
            return degrees * (Math.PI / 180);
        }

        public static double CalculateAngle(Point firstCoordinate, Point secondCoordinate)
        {
            return 0;
        }

        public static double CalculateSmallDistance()
        {
            return 0;

        }
    }
}
