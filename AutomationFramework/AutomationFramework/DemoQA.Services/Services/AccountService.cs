using ProjectCore.API;
using RestSharp;
using TestScript;

namespace ProjectCore.DemoQA.Services.Services
{
    public class AccountService
    {
        private readonly APIClient _client;
        public AccountService(APIClient apiClient)
        {
            _client = apiClient;
        }

        public async Task<RestResponse<TokenObject>> GenerateToken(string username, string password)
        {
            BodyObject.BodyToken body = new(username, password);
            return await _client.CreateRequest(APIConstant.accountEndpoint + "/GenerateToken")
                                .AddHeader("accept", "application/json")
                                .AddHeader("Content-Type", "application/json")
                                .AddBody(body)
                                .ExecutePostAsync<TokenObject>();
        }

        public async Task<RestResponse<TokenObject>> GenerateToken(BodyObject.BodyToken body)
        {
            return await _client.CreateRequest(APIConstant.accountEndpoint + "/GenerateToken")
                                .AddHeader("accept", "application/json")
                                .AddHeader("Content-Type", "application/json")
                                .AddBody(body)
                                .ExecutePostAsync<TokenObject>();
        }

        public async Task<RestResponse<UserObject.UserInfo>> GetUserInfoByCreadentials(string username, string password)
        {
            BodyObject.BodyToken body = new(username, password);
            return await _client.CreateRequest(APIConstant.accountEndpoint + "/User")
                                .AddHeader("accept", "application/json")
                                .AddHeader("Content-Type", "application/json")
                                .AddBody(body)
                                .ExecutePostAsync<UserObject.UserInfo>();
        }

        public async Task<RestResponse<UserObject.UserInfo>> GetUserInfoByCreadentials(BodyObject.BodyToken body)
        {
            return await _client.CreateRequest(APIConstant.accountEndpoint + "/User")
                                .AddHeader("accept", "application/json")
                                .AddHeader("Content-Type", "application/json")
                                .AddBody(body)
                                .ExecutePostAsync<UserObject.UserInfo>();
        }

        public async Task<RestResponse<UserObject.UserInfo>> GetUserInfoByToken(string userId, string bearerToken)
        {
            return await _client.CreateRequest(APIConstant.userEndpoint + $"/{userId}")
                                .AddAuthorizationHeader(bearerToken)
                                .AddHeader("accept", "application/json")
                                .ExecuteGetAsync<UserObject.UserInfo>();
        }

        public async Task<RestResponse> DeleteAnUser(string userId, string bearerToken)
        {
            return await _client.CreateRequest(APIConstant.userEndpoint + $"/{userId}")
                                .AddAuthorizationHeader(bearerToken)
                                .AddHeader("accept", "application/json")
                                .ExecuteDeleteAsync();
        }

    }
}