using AppService.Models;
using Newtonsoft.Json;
using RestSharp;

namespace AppService.Services
{
    public class PhotoService
    {
        private readonly ApiClient _apiClient;

        public PhotoService(ApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<List<(bool, RestResponse)>> LikePhotos(List<string> photoIds)
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
                    var pathUrl = $"https://api.unsplash.com/photos/{photoId}/like";
                    restResponse = await _apiClient.CreateRequest(pathUrl)
                               .AddAuthorizationHeader("Bearer pB8vEyYLumcMNIkuMXf4tfH6GUJo5PmzF1nax7YTAn4")
                               .ExecutePostAsync();
                }
                catch (Exception ex)
                {
                    isSuccess = false;
                    Console.WriteLine(ex.Message);
                }
                var s = restResponse.StatusCode;
                response.Add((isSuccess, restResponse));
            }

            return response;
        }


        public async Task<List<PhotoResponseModel>> GetPhotosLatest(int page = 1, int per_page = 10, string order_by = "latest")
        {
            try
            {
                var pathUrl = $"https://api.unsplash.com/photos?page={page}&per_page={per_page}&order_by={order_by}";
                var restResponse = await _apiClient.CreateRequest(pathUrl)
                           .AddAuthorizationHeader("Bearer pB8vEyYLumcMNIkuMXf4tfH6GUJo5PmzF1nax7YTAn4")
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
