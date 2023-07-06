using Service.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IGiphyService
    {
        public Task<GiphyTredingResponse> GetTrendingAsync(int offset);
        public Task<SearchResponse> GetByIdAsync(string id);
    }
}
