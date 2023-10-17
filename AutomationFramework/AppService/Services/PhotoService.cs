using AppService.Models;
using Newtonsoft.Json;
using ProjectCore.Helpper;
using ProjectCore.Service;
using RestSharp;

namespace AppService.Services
{
    public class PhotoService
    {
        private readonly ApiClient _apiClient;
        private string baseUrl = ApplicationHelper.GetApiBaseUrl();

        public PhotoService(ApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<List<(bool, RestResponse)>> LikePhotos(List<string> photoIds, string accessToken)
        {
            var response = new List<(bool, RestResponse)> { };

            if (photoIds == null || photoIds.Count == 0)
            {
                return response;
            }

            foreach (var photoId in photoIds)
            {
                var isSuccess = true;
                var restResponse = new RestResponse();
                try
                {
                    var pathUrl = $"{baseUrl}photos/{photoId}/like";
                    restResponse = await _apiClient.CreateRequest(pathUrl)
                               .AddAuthorizationHeader(accessToken)
                               .ExecutePostAsync();
                }
                catch (Exception ex)
                {
                    isSuccess = false;
                    Console.WriteLine(ex.Message);
                }
                response.Add((isSuccess, restResponse));
            }

            return response;
        }

        public async Task<List<(bool, RestResponse)>> UnLikePhotos(List<string> photoIds, string accessToken)
        {
            var response = new List<(bool, RestResponse)> { };

            if (photoIds == null || photoIds.Count == 0)
            {
                return response;
            }

            foreach (var photoId in photoIds)
            {
                var isSuccess = true;
                var restResponse = new RestResponse();
                try
                {
                    var pathUrl = $"{baseUrl}photos/{photoId}/like";
                    restResponse = await _apiClient.CreateRequest(pathUrl)
                               .AddAuthorizationHeader(accessToken)
                               .ExecuteDeleteAsync();
                }
                catch (Exception ex)
                {
                    isSuccess = false;
                    Console.WriteLine(ex.Message);
                }
                response.Add((isSuccess, restResponse));
            }

            return response;
        }

        public async Task<List<PhotoResponseModel>> GetPhotosLatest(int page = 1, int per_page = 10, string order_by = "latest", string accessToken = "")
        {
            try
            {
                var pathUrl = $"{baseUrl}photos?page={page}&per_page={per_page}&order_by={order_by}";
                var restResponse = await _apiClient.CreateRequest(pathUrl)
                           .AddAuthorizationHeader(accessToken)
                           .ExecuteGetAsync();
                if (restResponse.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return JsonConvert.DeserializeObject<List<PhotoResponseModel>>(restResponse.Content);
                }

                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
