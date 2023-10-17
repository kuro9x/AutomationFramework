using AppService.Models;
using Newtonsoft.Json;
using ProjectCore.Helpper;
using ProjectCore.Service;
using RestSharp;

namespace AppService.Services
{
    public class CollectionService
    {
        private readonly ApiClient _apiClient;
        private string baseUrl = ApplicationHelper.GetApiBaseUrl();

        public CollectionService(ApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<CollectionResponseModel> AddCollection(CollectionRequestModel collectionRequest, string accessToken)
        {
            try
            {
                var pathUrl = $"{baseUrl}collections?title={collectionRequest.Title}&description={collectionRequest.Description}&private={collectionRequest.Private}";
                var restResponse = await _apiClient.CreateRequest(pathUrl)
                           .AddAuthorizationHeader(accessToken)
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

        public async Task<List<(bool, RestResponse)>> DeleteCollections(List<string> collectionIds, string accessToken)
        {

            var response = new List<(bool, RestResponse)> { };

            if (collectionIds == null || collectionIds.Count == 0) return response;

            foreach (var collectionId in collectionIds)
            {
                var isSuccess = true;
                var restResponse = new RestResponse();
                try
                {
                    var pathUrl = $"{baseUrl}collections/{collectionId}";
                    restResponse = await _apiClient.CreateRequest(pathUrl)
                               .AddAuthorizationHeader(accessToken)
                               .ExecuteDeleteAsync();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                response.Add((isSuccess, restResponse));
            }

            return response;
        }
    }
}
