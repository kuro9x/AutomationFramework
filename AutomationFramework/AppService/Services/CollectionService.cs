using AppService.Models;
using Newtonsoft.Json;

namespace AppService.Services
{
    public class CollectionService
    {
        private readonly ApiClient _apiClient;

        public CollectionService(ApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<CollectionResponseModel> AddCollection(CollectionRequestModel collectionRequest)
        {
            try
            {
                var pathUrl = $"https://api.unsplash.com/collections?title={collectionRequest.Title}&description={collectionRequest.Description}&private={collectionRequest.Private}";
                var restResponse = await _apiClient.CreateRequest(pathUrl)
                           .AddAuthorizationHeader("Bearer pB8vEyYLumcMNIkuMXf4tfH6GUJo5PmzF1nax7YTAn4")
                           .ExecutePostAsync();

                if (restResponse.StatusCode == System.Net.HttpStatusCode.Created)
                {
                    return JsonConvert.DeserializeObject<CollectionResponseModel>(restResponse.Content);
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
