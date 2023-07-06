using GiphyAPI.Dto;

namespace GiphyAPI
{
    internal static  class Convertor
    {
        internal static GifDto ToDto(this Engine.Models.Trending trending)
        {
            return trending == null ?
                null :
                new GifDto
                {
                    Images = trending.Images.ConvertAll(i => i.ToDto()),
                    Pagination = trending.Pagination.ToDto()
                };
        }

        internal static Pagination ToDto(this Engine.Models.Pagination pagination)
        {
            return pagination == null ?
                null :
                new Pagination
                {
                    TotalCount = pagination.TotalCount,
                    Count = pagination.Count,
                    Offset = pagination.Offset
                };
        }

        internal static Image ToDto(this Engine.Models.Image image)
        {
            return image == null ?
                null :
                new Image
                {
                    Id = image.Id,
                    Url = image.Url
                };
        }
    }
}
