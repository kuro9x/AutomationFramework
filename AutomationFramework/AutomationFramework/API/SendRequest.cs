using RestSharp;

namespace ProjectCore.API
{
    public class SendRequest
    {
        public async Task<RestResponse?> SendRestRequest(string url, Dictionary<string, string> headers, RestRequest request)
        {
            var options = new RestClientOptions(url)
            {
            };

            foreach(var item in headers)
            {
                request.AddHeader(item.Key, item.Value);
            }

            var client = new RestClient(options);

            RestResponse? response = null;

            switch (request.Method)
            {
                case Method.Post:
                    response = await client.PostAsync(request);
                    break;
                case Method.Get:
                    response = await client.GetAsync(request);
                    break;
            }

            return response;
        }

    }
}
