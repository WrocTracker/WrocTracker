using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TrackerForWindowsPhoneClassLibrary.Models;

namespace TrackerForWindowsPhoneClassLibrary
{
    public interface ITrackable
    {
        Task<List<Vehicle>> GetPositionsAsync(params string[] vehicles);
        List<Vehicle> GetPositions(params string[] vehicles);
        TimeSpan RefreshTime { get; set; }
        string[] NotFoundVehicles { get; set; }
    }
}
