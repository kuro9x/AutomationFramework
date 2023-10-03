using System.Text.Json.Nodes;
using RestSharp;
using Newtonsoft;
using RestSharp.Serializers.NewtonsoftJson;
using RestSharp.Authenticators;
using RestSharp.Authenticators.OAuth2;
using Newtonsoft.Json;

namespace ProjectCore.API
{
<<<<<<<< HEAD:AutomationFramework/AutomationFramework/API/APISendRequest.cs
    public class APISendRequest
========
    public class APIClient
>>>>>>>> c38fdee9c3c12185cc910f3c84bb1c1d593e5bfa:AutomationFramework/AutomationFramework/API/APIClient.cs
    {
        private readonly RestClient _client;

        public RestRequest Request;

        private RestClientOptions? requestOption;

<<<<<<<< HEAD:AutomationFramework/AutomationFramework/API/APISendRequest.cs
        public APISendRequest(RestClient client, RestClientOptions requestOption)
========
        public APIClient(RestClient client)
>>>>>>>> c38fdee9c3c12185cc910f3c84bb1c1d593e5bfa:AutomationFramework/AutomationFramework/API/APIClient.cs
        {
            _client = client;
            Request = new RestRequest();
        }

<<<<<<<< HEAD:AutomationFramework/AutomationFramework/API/APISendRequest.cs
        public APISendRequest(string url, RestClientOptions requestOption)
========
        public APIClient(string url)
>>>>>>>> c38fdee9c3c12185cc910f3c84bb1c1d593e5bfa:AutomationFramework/AutomationFramework/API/APIClient.cs
        {
            RestClientOptions options = new RestClientOptions(url);
            _client = new RestClient(options, configureSerialization: s => s.UseNewtonsoftJson());
            Request = new RestRequest();
        }

<<<<<<<< HEAD:AutomationFramework/AutomationFramework/API/APISendRequest.cs
        public APISendRequest(RestClientOptions options, RestClientOptions requestOption)
========
        public APIClient(RestClientOptions options)
>>>>>>>> c38fdee9c3c12185cc910f3c84bb1c1d593e5bfa:AutomationFramework/AutomationFramework/API/APIClient.cs
        {
            _client = new RestClient(options, configureSerialization: s => s.UseNewtonsoftJson());
            Request = new RestRequest();
        }

<<<<<<<< HEAD:AutomationFramework/AutomationFramework/API/APISendRequest.cs
        public APISendRequest SetBasicAuthentication(string username, string password)
========
        public APIClient SetBasicAuthentication(string username, string password)
>>>>>>>> c38fdee9c3c12185cc910f3c84bb1c1d593e5bfa:AutomationFramework/AutomationFramework/API/APIClient.cs
        {
            if (requestOption == null)
            {
                requestOption = new RestClientOptions();
            }
            requestOption.Authenticator = new HttpBasicAuthenticator(username, password);
<<<<<<<< HEAD:AutomationFramework/AutomationFramework/API/APISendRequest.cs
            return new APISendRequest(requestOption, requestOption);
        }

        public APISendRequest SetAccessTokenAuthentication(string consumerKey, string consumerSecret, string oauthToken, string oauthtokenSecret)
========
            return new APIClient(requestOption);
        }

        public APIClient SetAccessTokenAuthentication(string consumerKey, string consumerSecret, string oauthToken, string oauthtokenSecret)
>>>>>>>> c38fdee9c3c12185cc910f3c84bb1c1d593e5bfa:AutomationFramework/AutomationFramework/API/APIClient.cs
        {
            if (requestOption == null)
            {
                requestOption = new RestClientOptions();
            }
            requestOption.Authenticator = OAuth1Authenticator.ForAccessToken(consumerKey, consumerSecret, oauthToken, oauthtokenSecret);
<<<<<<<< HEAD:AutomationFramework/AutomationFramework/API/APISendRequest.cs
            return new APISendRequest(requestOption, requestOption);
        }

        public APISendRequest SetRequestHeaderAuthentication(string token, string authType = "Bearer")
========
            return new APIClient(requestOption);
        }

        public APIClient SetRequestHeaderAuthentication(string token, string authType = "Bearer")
>>>>>>>> c38fdee9c3c12185cc910f3c84bb1c1d593e5bfa:AutomationFramework/AutomationFramework/API/APIClient.cs
        {
            if (requestOption == null)
            {
                requestOption = new RestClientOptions();
            }
            requestOption.Authenticator = new OAuth2AuthorizationRequestHeaderAuthenticator(token, authType);
<<<<<<<< HEAD:AutomationFramework/AutomationFramework/API/APISendRequest.cs
            return new APISendRequest(requestOption, requestOption);
        }

        public APISendRequest SetJwtAuthenticator(string token)
========
            return new APIClient(requestOption);
        }

        public APIClient SetJwtAuthenticator(string token)
>>>>>>>> c38fdee9c3c12185cc910f3c84bb1c1d593e5bfa:AutomationFramework/AutomationFramework/API/APIClient.cs
        {
            if (requestOption == null)
            {
                requestOption = new RestClientOptions();
            }
            requestOption.Authenticator = new JwtAuthenticator(token);
<<<<<<<< HEAD:AutomationFramework/AutomationFramework/API/APISendRequest.cs
            return new APISendRequest(requestOption, requestOption);
        }

        public APISendRequest ClearAuthenticator()
========
            return new APIClient(requestOption);
        }

        public APIClient ClearAuthenticator()
>>>>>>>> c38fdee9c3c12185cc910f3c84bb1c1d593e5bfa:AutomationFramework/AutomationFramework/API/APIClient.cs
        {
            if (requestOption == null)
            {
                requestOption = new RestClientOptions();
            }
            requestOption.Authenticator = null;
<<<<<<<< HEAD:AutomationFramework/AutomationFramework/API/APISendRequest.cs
            return new APISendRequest(requestOption, requestOption);
        }

        public APISendRequest AddDefaultHeaders(Dictionary<string, string> headers)
========
            return new APIClient(requestOption);
        }

        public APIClient AddDefaultHeaders(Dictionary<string, string> headers)
>>>>>>>> c38fdee9c3c12185cc910f3c84bb1c1d593e5bfa:AutomationFramework/AutomationFramework/API/APIClient.cs
        {
            _client.AddDefaultHeaders(headers);
            return this;
        }

<<<<<<<< HEAD:AutomationFramework/AutomationFramework/API/APISendRequest.cs
        public APISendRequest CreateRequest(string source = "")
========
        public APIClient CreateRequest(string source = "")
>>>>>>>> c38fdee9c3c12185cc910f3c84bb1c1d593e5bfa:AutomationFramework/AutomationFramework/API/APIClient.cs
        {
            Request = new RestRequest(source);
            return this;
        }

<<<<<<<< HEAD:AutomationFramework/AutomationFramework/API/APISendRequest.cs
        public APISendRequest AddHeader(string name, string value)
========
        public APIClient AddHeader(string name, string value)
>>>>>>>> c38fdee9c3c12185cc910f3c84bb1c1d593e5bfa:AutomationFramework/AutomationFramework/API/APIClient.cs
        {
            Request.AddHeader(name, value);
            return this;
        }

<<<<<<<< HEAD:AutomationFramework/AutomationFramework/API/APISendRequest.cs
        public APISendRequest AddAuthorizationHeader(string value)
========
        public APIClient AddAuthorizationHeader(string value)
>>>>>>>> c38fdee9c3c12185cc910f3c84bb1c1d593e5bfa:AutomationFramework/AutomationFramework/API/APIClient.cs
        {
            return AddHeader("Authorization", value);
        }

<<<<<<<< HEAD:AutomationFramework/AutomationFramework/API/APISendRequest.cs
        public APISendRequest AddParameter(string name, string value)
========
        public APIClient AddParameter(string name, string value)
>>>>>>>> c38fdee9c3c12185cc910f3c84bb1c1d593e5bfa:AutomationFramework/AutomationFramework/API/APIClient.cs
        {
            Request.AddParameter(name, value);
            return this;
        }

<<<<<<<< HEAD:AutomationFramework/AutomationFramework/API/APISendRequest.cs
        public APISendRequest AddBody(object obj, string? contentType = null)
========
        public APIClient AddBody(object obj, string? contentType = null)
>>>>>>>> c38fdee9c3c12185cc910f3c84bb1c1d593e5bfa:AutomationFramework/AutomationFramework/API/APIClient.cs
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
