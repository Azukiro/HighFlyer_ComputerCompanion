using HighFlyerCompanion.Data.DTO;
using HighFlyerCompanion.Data.Service;
using Newtonsoft.Json;
using System.ComponentModel;

namespace HighFlyerCompanion.Data;

/// <summary>
/// Orientation of a building face
/// </summary>
public enum FaceOrientation
{
    [Description("North")]
    NORTH,

    [Description("East")]
    EAST,

    [Description("South")]
    SOUTH,

    [Description("West")]
    WEST
}

/// <summary>
/// Data format for manage image from the drone
/// </summary>
public class MissionImageData
{
    [JsonProperty("thermal_array")]
    public double[] ThermalArray { get; set; }

    [JsonProperty("normal_array")]
    public double[][] NormalArray { get; set; }

    [JsonProperty("col")]
    public int Col { get; set; }

    [JsonProperty("row")]
    public int Row { get; set; }
}

/// <summary>
/// Data for a mission
/// </summary>
public class Mission
{
    public DateTime Date { get; set; }

    public double TimeTaken { get; set; }

    public FaceOrientation Face { get; set; }

    public string Commentary { get; set; }

    public string BuildingName { get; set; }

    public string Link { get; set; }

    public List<MissionImageData> MissionImageData { get; set; }
}