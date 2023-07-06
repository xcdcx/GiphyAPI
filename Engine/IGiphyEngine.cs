using Engine.Models;

namespace Engine
{
    public interface IGiphyEngine
    {
        public Task<Trending> GetTrendingAsync(int offset);
        public Task<Search> GetByIdAsync(string id);
    }
}
