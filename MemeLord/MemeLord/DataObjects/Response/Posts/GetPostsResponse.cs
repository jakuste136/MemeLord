using System.Collections.Generic;
using MemeLord.DataObjects.Dto;

namespace MemeLord.DataObjects.Response.Posts
{
    public class GetPostsResponse
    {
        public int LastId { get; set; }
        public IEnumerable<PostDto> PostsList { get; set; }
    }
}