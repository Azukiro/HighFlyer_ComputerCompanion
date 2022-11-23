using HighFlyerCompanion.Data.DTO;
using Newtonsoft.Json;
using RestSharp;
using System.Net;

namespace HighFlyerCompanion.Data.ServerClient
{
    /// <summary>
    /// Client for manage api communication with backend server
    /// </summary>
    public class BackEndServerClient
    {
        private readonly RestClient _client;

        public BackEndServerClient()
        {
            _client = new RestClient("http://127.0.0.1:5000");
        }

        /// <summary>
        /// Upload mission data to the backend server
        /// </summary>
        /// <param name="mission"></param>
        /// <returns></returns>
        public async Task<string> UploadMission(MissionDTOPost mission)
        {
            //"/api/upload"
            var request = new RestRequest("/api/upload", Method.Post);

            // Json to post.
            string jsonToSend = JsonConvert.SerializeObject(mission);

            request.AddParameter("application/json; charset=utf-8", jsonToSend, ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;

            try
            {
                RestResponse response = await _client.ExecuteAsync(request);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    return response.Content;
                }
            }
            catch (Exception error)
            {
            }

            return null;
        }
    }
}