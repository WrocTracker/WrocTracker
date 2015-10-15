﻿using System;
using System.Collections.Generic;
using System.Linq;
using WrocTracker.Helpers;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WrocTracker
{
    public class Tracker : ITrackable
    {
        public TimeSpan RefreshTime { get; set; }
        private const int DefaultRefreshtime = 10;
        private const string Uri = "http://pasazer.mpk.wroc.pl/position.php";
        const string DataOpener = "busList%5B";
        const string DataPart2 = "%5D%5B%5D=";

        public Tracker(int refreshTimeInSeconds = DefaultRefreshtime)
        {
            RefreshTime = new TimeSpan(0, 0, 0, refreshTimeInSeconds);
        }

        public async Task<List<Vehicle>> GetPositionsAsync(params string[] vehicles)
        {
            if (vehicles == null)
            {
                throw new Exception("Vehicles list could not be empty.");
            }

            var postData = CreatePostData(vehicles);
            return await GetVehicles(postData);
        }

        public List<Vehicle> GetPositions(params string[] vehicles)
        {
            if (vehicles == null)
            {
                throw new Exception("Vehicles list could not be empty.");
            }

            var postData = CreatePostData(vehicles);
            return Task.Run(async () => await GetVehicles(postData)).Result;
        }

        private string CreatePostData(string[] names)
        {
            var sb = new StringBuilder();

            foreach (var name in names)
            {
                var type = VehicleHelper.GetVehicleType(name);
                sb.Append(DataOpener + type + DataPart2 + name);
                sb.Append("&");
            }

            return sb.ToString();
        }

        private async Task<List<Vehicle>> GetVehicles(string postData)
        {
            var postResult = await PostAsync(postData);
            var mpkObjects = JsonConvert.DeserializeObject<List<MpkObject>>(postResult);
            var vehicles = mpkObjects.Select(mpkObject => new Vehicle(mpkObject))
                    .OrderBy(v => v.VehicleType)
                    .ThenBy(v => v.Name)
                    .ToList();

            return vehicles;
        }

        private async Task<string> PostAsync(string postData)
        {
            using (var httpClient = new HttpClient())
            {
                var uri = new Uri(Uri);
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                httpClient.DefaultRequestHeaders.Host = uri.Host;
                var content = new StringContent(postData, Encoding.UTF8, "application/x-www-form-urlencoded");
                var response = await httpClient.PostAsync(uri, content);
                return await response.Content.ReadAsStringAsync();
            }
        }
    }
}
