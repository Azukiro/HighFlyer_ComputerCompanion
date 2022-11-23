using HighFlyerCompanion.Data.ServerClient;

namespace HighFlyerCompanion.Data.Service
{
    public enum DroneState
    {
        Off,
        Charging,
        Waiting,
        InFlight
    }

    /// <summary>
    /// Service for manage health data of the drone
    /// </summary>
    public class DroneHealthService
    {
        public DroneState DroneState { get; set; } = DroneState.Off;
        private DroneServerClient droneServerClient;

        public DroneHealthService()
        {
            droneServerClient = new DroneServerClient();
        }

        /// <summary>
        /// Get battery level of the drone
        /// </summary>
        /// <returns></returns>
        public async Task<int> GetBattery()
        {
            return await droneServerClient.GetBattery();
        }

        /// <summary>
        /// Get altitude of the drone
        /// </summary>
        /// <returns></returns>
        public async Task<float> GetAltitude()
        {
            return await droneServerClient.GetAltitude();
        }
    }
}