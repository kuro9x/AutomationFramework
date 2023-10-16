using RestSharp;
using RestSharp.Serializers.NewtonsoftJson;
using RestSharp.Authenticators;
using RestSharp.Authenticators.OAuth2;
using Newtonsoft.Json;

namespace AppService.Services
{
    public class ApiClient
    {
        protected readonly RestClient _client;
        protected RestRequest Request;
        protected RestClientOptions? requestOption;

        public ApiClient(RestClient client)
        {
            _client = client;
            Request = new RestRequest();
        }

        public ApiClient(string url)
        {
            RestClientOptions options = new RestClientOptions(url);
            _client = new RestClient(options, configureSerialization: s => s.UseNewtonsoftJson());
            Request = new RestRequest();
        }

        public ApiClient(RestClientOptions options)
        {
            _client = new RestClient(options, configureSerialization: s => s.UseNewtonsoftJson());
            Request = new RestRequest();
        }

        public ApiClient SetBasicAuthentication(string username, string password)
        {
            if (requestOption == null)
            {
                requestOption = new RestClientOptions();
            }
            requestOption.Authenticator = new HttpBasicAuthenticator(username, password);
            return new ApiClient(requestOption);
        }

        public ApiClient SetAccessTokenAuthentication(string consumerKey, string consumerSecret, string oauthToken, string oauthtokenSecret)
        {
            if (requestOption == null)
            {
                requestOption = new RestClientOptions();
            }
            requestOption.Authenticator = OAuth1Authenticator.ForAccessToken(consumerKey, consumerSecret, oauthToken, oauthtokenSecret);
            return new ApiClient(requestOption);
        }

        public ApiClient SetRequestHeaderAuthentication(string token, string authType = "Bearer")
        {
            if (requestOption == null)
            {
                requestOption = new RestClientOptions();
            }
            requestOption.Authenticator = new OAuth2AuthorizationRequestHeaderAuthenticator(token, authType);
            return new ApiClient(requestOption);
        }

        public ApiClient SetJwtAuthenticator(string token)
        {
            if (requestOption == null)
            {
                requestOption = new RestClientOptions();
            }
            requestOption.Authenticator = new JwtAuthenticator(token);
            return new ApiClient(requestOption);
        }

        public ApiClient ClearAuthenticator()
        {
            if (requestOption == null)
            {
                requestOption = new RestClientOptions();
            }
            requestOption.Authenticator = null;
            return new ApiClient(requestOption);
        }

        public ApiClient AddDefaultHeaders(Dictionary<string, string> headers)
        {
            _client.AddDefaultHeaders(headers);
            return this;
        }

        public ApiClient CreateRequest(string source = "")
        {
            Request = new RestRequest(source);
            return this;
        }

        public ApiClient AddHeader(string name, string value)
        {
            Request.AddHeader(name, value);
            return this;
        }

        public ApiClient AddAuthorizationHeader(string value)
        {
            return AddHeader("Authorization", value);
        }

        public ApiClient AddParameter(string name, string value)
        {
            Request.AddParameter(name, value);
            return this;
        }

        public ApiClient AddBody(object obj, string? contentType = null)
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
