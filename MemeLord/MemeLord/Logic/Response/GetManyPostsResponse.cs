using MemeLord.Logic.Dto;
using System.Collections.Generic;

namespace MemeLord.Logic.Response
{
    public class GetManyPostsResponse
    {
        public int LastId { get; set; }
        public IEnumerable<PostDto> PostsList { get; set; }
    }
}