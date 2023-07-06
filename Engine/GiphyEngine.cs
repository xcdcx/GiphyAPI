using Service;
using Engine.Models;

namespace Engine
{
    public class GiphyEngine : IGiphyEngine
    {
        private readonly IGiphyService _giphyService;
        public GiphyEngine()
        {
            _giphyService = new GiphyService();
        }

        public async Task<Trending> GetTrendingAsync(int offset)
        {
            try
            {
                Trending result = (await _giphyService.GetTrendingAsync(offset)).ConvertToEngine();
                return result;
            }
            catch(Exception ex)
            {
                //TODO write to logger
                throw;
            }
        }

        public async Task<Search> GetByIdAsync(string id)
        {
            try
            {
                var result = (await _giphyService.GetByIdAsync(id)).ConvertToEngine();
                return result;
            }
            catch(Exception ex)
            {
                //TODO write to logger
                throw;
            }
        }
    }
}