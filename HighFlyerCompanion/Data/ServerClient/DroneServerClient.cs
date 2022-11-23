using HighFlyerCompanion.Data.DTO;
using HighFlyerCompanion.Data.Service;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighFlyerCompanion.Data.ServerClient
{
    /// <summary>
    /// Client class for api communication with the drone
    /// </summary>
    public class DroneServerClient
    {
        private readonly RestClient _client;

        public DroneServerClient()
        {
            _client = new RestClient("http://127.0.0.1:5000");
        }

        /// <summary>
        /// Get Battery level of the drone
        /// </summary>
        /// <returns></returns>
        public Task<int> GetBattery()
            => _client.GetJsonAsync<int>("battery");

        /// <summary>
        /// Get Altitude of the drone
        /// </summary>
        /// <returns></returns>
        public Task<float> GetAltitude()
            => _client.GetJsonAsync<float>("altitude");

        /// <summary>
        /// Launch mission on the drone
        /// </summary>
        /// <returns></returns>
        public Task LaunchMission()
          => _client.GetAsync(new RestRequest("launch-mission"));

        /// <summary>
        /// Get mission status of the drone
        /// </summary>
        /// <returns></returns>
        public Task<int> GetStatus()
           => _client.GetJsonAsync<int>("mission-status");

        /// <summary>
        /// Get drone's images at the end of a mission
        /// </summary>
        /// <returns></returns>
        public Task<MissionDTOGet> GetImages()
         => _client.GetJsonAsync<MissionDTOGet>("send-pictures");
    }
}