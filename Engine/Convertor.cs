using Engine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    internal static class Convertor
    {
        internal static Trending ConvertToEngine(this Service.Dto.GiphyTredingResponse response)
        {
            return (response == null || response.Data == null) ?
                null :
                new Trending
                {
                    Images = response.Data.ConvertAll(i => i.ConvertToEngine()),
                    Pagination = response.Pagination.ConvertToEngine()
                };
        }

        internal static Pagination ConvertToEngine(this Service.Dto.Pagination pagination)
        {
            return pagination == null ?
                null :
                new Pagination
                {
                    TotalCount = pagination.Total_Count,
                    Count = pagination.Count,
                    Offset = pagination.Offset
                };
        }

        internal static Image ConvertToEngine(this Service.Dto.Gif gif)
        {
            return gif == null ?
                null :
                new Image
                {
                    Id = gif.Id,
                    Url = gif.Images?.Original?.Url
                };
        }

        internal static Search ConvertToEngine(this Service.Dto.SearchResponse response)
        {
            return (response == null || response.Data == null) ?
                null :
                new Search
                {
                    Image = response.Data.ConvertToEngine()
                };
        }
    }
}
