using HighFlyerCompanion.Data.DTO;
using HighFlyerCompanion.Data.ServerClient;
using Newtonsoft.Json;
using System.ComponentModel;

namespace HighFlyerCompanion.Data.Service;

public enum MissionStatus
{
    [Description("Sucess")]
    SUCESS,

    [Description("Charging")]
    CHARGING,

    [Description("In progress")]
    INPROGRESS,

    [Description("Error occured")]
    ERROR,
}

/// <summary>
/// Service for manage drone when is on mission
/// </summary>
public class DroneOnMissionService
{
    private DroneServerClient droneServerClient;

    public DroneOnMissionService()
    {
        droneServerClient = new DroneServerClient();
    }

    /// <summary>
    /// Get mission status
    /// </summary>
    /// <returns></returns>
    public async Task<MissionStatus> GetStatus()
    {
        int status = await droneServerClient.GetStatus();
        switch (status)
        {
            case 1: return MissionStatus.SUCESS;
            case 2: return MissionStatus.CHARGING;
            case 3: return MissionStatus.INPROGRESS;
            default:
                return MissionStatus.ERROR;
        }
    }

    /// <summary>
    /// Launch mission
    /// </summary>
    /// <returns></returns>
    public async Task LaunchMission()
    {
        await droneServerClient.LaunchMission();
    }

    /// <summary>
    /// Get final images after a mission
    /// </summary>
    /// <returns></returns>
    public async Task<MissionDTOGet> GetImages()
    {
        return await droneServerClient.GetImages();
    }
}