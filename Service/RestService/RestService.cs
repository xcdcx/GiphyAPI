using RestSharp;

namespace Service.RestService
{
    internal static class RestService
    {
        internal async static Task<TResponse> GetAsync<TResponse>(string url, string resource, Dictionary<string, string> headers)
            where TResponse : class
        {
            TResponse? response = null;
            try
            {
                IRestClient client = new RestClient(url);
                RestRequest request = new RestRequest(resource).AddHeaders(headers);
                response = await client.GetAsync<TResponse>(request);
            }
            catch (Exception ex)
            {
                //TODO print to log Logger.WriteException(MessageLevel.Error, typeof(RestService).FullName, $"Error in {nameof(GetAsync)}", ex);
            }
            return response;
        }

        internal async static Task<TResponse> PostAsync<TResponse, TRequest>(string url, string resource, Dictionary<string, string> headers, TRequest request)
            where TRequest: class
            where TResponse: class
        {
            TResponse? response = null;
            try
            {
                IRestClient client = new RestClient(url);
                RestRequest restRequest = new RestRequest(resource, Method.Post).AddHeaders(headers).AddBody(request);
                response = await client.PostAsync<TResponse>(restRequest);
            }
            catch(Exception ex)
            {
                //TODO print to log Logger.WriteException(MessageLevel.Error, typeof(RestService).FullName, $"Error in {nameof(PostAsync)}", ex);
            }
            return response;
        }
    }
}
