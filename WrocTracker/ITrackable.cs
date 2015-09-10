using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WrocTracker
{
    public interface ITrackable
    {
        Task<List<Vehicle>> GetPositions(string vehicle);
        Task<List<Vehicle>> GetPositions(string[] vehicles);
        TimeSpan RefreshTime { get; set; }
    }
}
