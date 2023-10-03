using System.Text.Json.Nodes;
using RestSharp;
using Newtonsoft;
using RestSharp.Serializers.NewtonsoftJson;
using RestSharp.Authenticators;
using RestSharp.Authenticators.OAuth2;
using Newtonsoft.Json;

namespace ProjectCore.API
{
    public class APISendRequest
    {
        private readonly RestClient _client;

        public RestRequest Request;

        private RestClientOptions requestOption;

        public APISendRequest(RestClient client, RestClientOptions requestOption)
        {
            _client = client;
            Request = new RestRequest();
            this.requestOption = requestOption;
        }

        public APISendRequest(string url, RestClientOptions requestOption)
        {
            RestClientOptions options = new RestClientOptions(url);
            _client = new RestClient(options, configureSerialization: s => s.UseNewtonsoftJson());
            Request = new RestRequest();
            this.requestOption = requestOption;
        }

        public APISendRequest(RestClientOptions options, RestClientOptions requestOption)
        {
            _client = new RestClient(options, configureSerialization: s => s.UseNewtonsoftJson());
            Request = new RestRequest();
            this.requestOption = requestOption;
        }

        public APISendRequest SetBasicAuthentication(string username, string password)
        {
            requestOption.Authenticator = new HttpBasicAuthenticator(username, password);
            return new APISendRequest(requestOption, requestOption);
        }

        public APISendRequest SetAccessTokenAuthentication(string consumerKey, string consumerSecret, string oauthToken, string oauthtokenSecret)
        {
            requestOption.Authenticator = OAuth1Authenticator.ForAccessToken(consumerKey, consumerSecret, oauthToken, oauthtokenSecret);
            return new APISendRequest(requestOption, requestOption);
        }

        public APISendRequest SetRequestHeaderAuthentication(string token, string authType = "Bearer")
        {
            requestOption.Authenticator = new OAuth2AuthorizationRequestHeaderAuthenticator(token, authType);
            return new APISendRequest(requestOption, requestOption);
        }

        public APISendRequest SetJwtAuthenticator(string token)
        {
            requestOption.Authenticator = new JwtAuthenticator(token);
            return new APISendRequest(requestOption, requestOption);
        }

        public APISendRequest ClearAuthenticator()
        {
            requestOption.Authenticator = null;
            return new APISendRequest(requestOption, requestOption);
        }

        public APISendRequest AddDefaultHeaders(Dictionary<string, string> headers)
        {
            _client.AddDefaultHeaders(headers);
            return this;
        }

        public APISendRequest CreateRequest(string source = "")
        {
            Request = new RestRequest(source);
            return this;
        }

        public APISendRequest AddHeader(string name, string value)
        {
            Request.AddHeader(name, value);
            return this;
        }

        public APISendRequest AddAuthorizationHeader(string value)
        {
            return AddHeader("Authorization", value);
        }

        public APISendRequest AddParameter(string name, string value)
        {
            Request.AddParameter(name, value);
            return this;
        }

        public APISendRequest AddBody(object obj, string? contentType = null)
        {
            string json = JsonConvert.SerializeObject(obj);
            Request.AddStringBody(json, contentType ?? ContentType.Json);
            return this;
        }

        public async Task<RestResponse> ExecuteGetAsync()
        {
            return await _client.ExecuteGetAsync(Request);
        }

        public async Task<RestResponse<T>> ExecuteGetAsync<T>()
        {
            return await _client.ExecuteGetAsync<T>(Request);
        }

        public async Task<RestResponse> ExecutePostAsync()
        {
            return await _client.ExecutePostAsync(Request);
        }

        public async Task<RestResponse<T>> ExecutePostAsync<T>()
        {
            return await _client.ExecutePostAsync<T>(Request);
        }

        public async Task<RestResponse> ExecuteDeleteAsync()
        {
            Request.Method = Method.Delete;
            return await _client.ExecuteAsync(Request);
        }

        public async Task<RestResponse<T>> ExecuteDeleteAsync<T>()
        {
            Request.Method = Method.Delete;
            return await _client.ExecuteAsync<T>(Request);
        }

        public async Task<RestResponse> ExecutePutAsync()
        {
            return await _client.ExecutePutAsync(Request);
        }

        public async Task<RestResponse<T>> ExecutePutAsync<T>()
        {
            return await _client.ExecutePutAsync<T>(Request);
        }

    }
}
