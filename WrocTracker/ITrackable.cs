using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WrocTracker
{
    public interface ITrackable
    {
        Task<List<Vehicle>> GetPositionsAsync(params string[] vehicles);
        List<Vehicle> GetPositions(params string[] vehicles);
        TimeSpan RefreshTime { get; set; }
    }
}
