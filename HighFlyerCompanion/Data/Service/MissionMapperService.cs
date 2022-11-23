using HighFlyerCompanion.Data.DTO;

namespace HighFlyerCompanion.Data.Service
{
    /// <summary>
    /// Service for reproduce a Mapper beacause on function CreateMauiApp builder.Services.AddAutoMapper() don't exist
    /// </summary>
    public class MissionMapperService
    {
        /// <summary>
        /// Merge data from DTOGet to Mission variable
        /// </summary>
        /// <param name="mission"></param>
        /// <param name="missionDTOGet"></param>
        public void MapMissionFromGet(ref Mission mission, MissionDTOGet missionDTOGet)
        {
            mission.MissionImageData = missionDTOGet.Images;
        }

        /// <summary>
        /// Transform a mission into a mission DTO Post
        /// </summary>
        /// <param name="mission"></param>
        /// <returns></returns>
        public MissionDTOPost MapMissionToPost(Mission mission)
        {
            MissionDTOPost missionDTOPost = new MissionDTOPost()
            {
                Date = mission.Date,
                TimeTaken = mission.TimeTaken,
                Face = mission.Face,
                Commentary = mission.Commentary,
                BuildingName = mission.BuildingName,
                Images = mission.MissionImageData
            };

            return missionDTOPost;
        }
    }
}