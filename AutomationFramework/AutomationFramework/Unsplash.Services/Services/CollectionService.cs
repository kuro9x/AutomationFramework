using ProjectCore.API;
using ProjectCore.Unsplash.Services.Constants;
using ProjectCore.Unsplash.Services.Model;
using RestSharp;

namespace ProjectCore.Unsplash.Services.Services
{
    public class CollectionService
    {
        private readonly APIClient _client;

        public CollectionService() { }

        public CollectionService(APIClient apiClient)
        {
            _client = apiClient;
        }
        public async Task<RestResponse<AddCollectionDto>> CreateANewCollection(string bearerToken, string title, string isPrivate, string description)
        {
            return await _client.CreateRequest(APIConstant.GetCollectionEndPoint)
                                .AddAuthorizationHeader(bearerToken)
                                .AddParameter("private", isPrivate)
                                .AddParameter("title", title)
                                .AddParameter("description", description)
                                .ExecutePostAsync<AddCollectionDto>();
        }

        public async Task<RestResponse> DeleteACollection(string bearerToken, string collectionId)
        {
            return await _client.CreateRequest(APIConstant.GetCollectionEndPoint + collectionId)
                                .AddAuthorizationHeader(bearerToken)
                                .ExecuteDeleteAsync();
        }
    }
}
