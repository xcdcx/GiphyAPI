using Engine;
using GiphyAPI.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System.Net;

namespace GiphyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GiphyController : ControllerBase
    {
        private readonly IGiphyEngine _giphyEngine;
        private readonly IMemoryCache _cache;
        public GiphyController(IGiphyEngine giphyEngine, IMemoryCache cache)
        {
            _giphyEngine = giphyEngine;
            _cache = cache;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GifDto>>> GetTrending(int offset)
        {
            try
            {
                var result = await _giphyEngine.GetTrendingAsync(offset);
                var response = result.ToDto();

                foreach(Image image in response.Images)
                {
                    _cache.Set(image.Id, image.Url, TimeSpan.FromDays(1));
                }
                return Ok(response);
            }
            catch(Exception ex)
            {
                //TODO write to logger
                throw;
            }
        }


        [HttpGet("id")]
        public async Task<ActionResult<string>> GetById(string id)
        {
            try
            {
                string response = null;
                response = _cache.Get<string>(id);
                if(response is null)
                {
                    var result = await _giphyEngine.GetByIdAsync(id);
                    if (result is null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        _cache.Set(result.Image.Id, result.Image.Url, TimeSpan.FromDays(1));
                        response = result.Image.Url;
                    }
                }

                return Ok(response);
            }
            catch(Exception ex)
            {
                //TODO write to logger
                throw;
            }
        }


    }
}
