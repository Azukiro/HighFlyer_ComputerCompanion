using HighFlyerCompanion.Data.DTO;
using HighFlyerCompanion.Data.ServerClient;
using System.Text;
using System.Text.Json;

namespace HighFlyerCompanion.Data.Service;

/// <summary>
/// Service for manage mission and the history
/// </summary>
public class MissionService
{
    private readonly MissionMapperService _missionMapperService;

    public MissionService(MissionMapperService missionMapperService)
    {
        _missionMapperService = missionMapperService;
    }

    private static string filename = "history.json";

    private static readonly string[] BuildingNames = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private static readonly string[] Commentaries = new[]
    {
        "The weather was really cold", "Drone autonomy was really bad (5min)", "Nothing"
    };

    /// <summary>
    ///Get Missions history
    /// </summary>
    /// <returns></returns>
    public async Task<List<Mission>> GetMissionsAsync()
    {
        string mainDir = FileSystem.Current.AppDataDirectory;
        string path = Path.Combine(mainDir, filename);
        if (!File.Exists(path))
            return null;
        List<Mission> missions;
        using (FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read))
        {
            missions = await JsonSerializer.DeserializeAsync<List<Mission>>(fileStream)!;
        }
        return missions;
    }

    /// <summary>
    /// Save and add a mission to the history
    /// </summary>
    /// <param name="missions"></param>
    private void SaveMissions(List<Mission> missions)
    {
        string mainDir = FileSystem.Current.AppDataDirectory;
        string path = Path.Combine(mainDir, filename);

        string jsonString = JsonSerializer.Serialize(missions);
        using (FileStream outputFileStream = new FileStream(path, FileMode.OpenOrCreate))
        {
            byte[] str = new UTF8Encoding(true).GetBytes(jsonString);
            outputFileStream.Write(str, 0, str.Length);
        }
    }

    /// <summary>
    /// Publish a mission to the backend and save it locally
    /// </summary>
    /// <param name="missionSubmit"></param>
    /// <param name="timeTaken"></param>
    /// <param name="missionImageData"></param>
    /// <returns></returns>
    public async Task PublishMission(MissionSubmit missionSubmit, double timeTaken, MissionDTOGet missionImageData)
    {
        //Create mission
        Mission mission = new Mission()
        {
            BuildingName = missionSubmit.BuildingName,
            Face = missionSubmit.Face,
            TimeTaken = timeTaken,
            Commentary = missionSubmit.Commentary,
            Date = DateTime.Now,
        };

        //Map mission with data from drone
        _missionMapperService.MapMissionFromGet(ref mission, missionImageData);

        //Send data to backend
        BackEndServerClient backEndServerClient = new BackEndServerClient();
        MissionDTOPost missionDTOPost = _missionMapperService.MapMissionToPost(mission);
        string url = await backEndServerClient.UploadMission(missionDTOPost);

        //Save data for history
        mission.Link = url;

        string mainDir = FileSystem.Current.AppDataDirectory;
        string path = Path.Combine(mainDir, filename);
        if (!File.Exists(path))
        {
            SaveMissions(new List<Mission>());
        }

        List<Mission> missions = await GetMissionsAsync();
        missions.Add(mission);

        SaveMissions(missions);
    }

    /// <summary>
    /// Generate a random list of mission for testing
    /// </summary>
    /// <param name="startDate"></param>
    public void GenerateAsync(DateTime startDate)
    {
        Array faceOrientations = Enum.GetValues(typeof(FaceOrientation));
        var mission = Enumerable.Range(1, 5).Select(index => new Mission
        {
            Date = startDate.AddDays(index),
            TimeTaken = Random.Shared.Next(10, 200),
            Commentary = Commentaries[Random.Shared.Next(Commentaries.Length)],
            BuildingName = BuildingNames[Random.Shared.Next(BuildingNames.Length)],
            Face = (FaceOrientation)faceOrientations.GetValue(Random.Shared.Next(faceOrientations.Length)),
            Link = "https://www.google.com"
        }).ToList();

        SaveMissions(mission);
    }
}