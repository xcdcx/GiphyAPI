using Service.Dto;
using Service.ServiceHelpers;
using System.Collections.Generic;

namespace Service
{
    public class GiphyService : IGiphyService
    {
        private const string GIPHYAPIKEY = "mNUbQrcilHaHIbhK3VGXB3N1C0CR48Gi";
        private const string GIPHYURL = "https://api.giphy.com";
        private const int PAGESIZE = 50;
        public async Task<GiphyTredingResponse> GetTrendingAsync(int offset)
        {
            GiphyTredingResponse response = null;
            try
            {
                Dictionary<string, string> queryStringParams = new Dictionary<string, string>
                {
                    {"api_key", GIPHYAPIKEY},
                    {"limit", PAGESIZE.ToString()},
                    {"offset", offset.ToString()},
                    //{"rating", "g" },
                    {"bundle", "messaging_non_clips"}

                };
                response = await RestService.RestService.GetAsync<GiphyTredingResponse>(GIPHYURL, RosourceBuilder.BuildResource("/v1/gifs", "trending", queryStringParams), new Dictionary<string, string>());
            }
            catch
            {
                //TODO print to log Logger.WriteException(MessageLevel.Error, typeof(GiphyService).FullName, $"Error in {nameof(GetTrendingAsync)}", ex);
                throw;
            }
            return response;
        }

        public async Task<SearchResponse> GetByIdAsync(string id)
        {
            SearchResponse response = null;
            try
            {
                Dictionary<string, string> queryStringParams = new Dictionary<string, string>
                {
                    {"api_key", GIPHYAPIKEY}
                };
                response = await RestService.RestService.GetAsync<SearchResponse>(GIPHYURL, RosourceBuilder.BuildResource("/v1/gifs", id, queryStringParams), new Dictionary<string, string>());
            }
            catch(Exception ex)
            {
                //TODO write to logger Logger.WriteException(MessageLevel.Error, typeof(GiphyService).FullName, $"Error in {nameof(GetByIdAsync)}", ex);
                throw;
            }
            return response;
        }
    }
}