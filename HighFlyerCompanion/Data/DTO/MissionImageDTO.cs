using Newtonsoft.Json;

namespace HighFlyerCompanion.Data.DTO
{
    /// <summary>
    /// DTO class for Get api method
    /// </summary>
    public class MissionDTOGet
    {
        public List<MissionImageData> Images { get; set; }
    }

    /// <summary>
    /// DTO class for Post api method
    /// </summary>
    public class MissionDTOPost
    {
        [JsonProperty("date")]
        public DateTime Date { get; set; }

        [JsonProperty("time_taken")]
        public double TimeTaken { get; set; }

        [JsonProperty("face")]
        public FaceOrientation Face { get; set; }

        [JsonProperty("commentary")]
        public string Commentary { get; set; }

        [JsonProperty("building_name")]
        public string BuildingName { get; set; }

        [JsonProperty("images")]
        public List<MissionImageData> Images { get; set; }
    }
}