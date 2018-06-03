using MemeLord.DataObjects.Dto;
using System.Collections.Generic;

namespace MemeLord.DataObjects.Response.UserResponses
{
    public class GetUserActivityResponse
    {
        public GetUserResponse User { get; set; }
        public IEnumerable<PostDto> PostList { get; set; }
    }
}