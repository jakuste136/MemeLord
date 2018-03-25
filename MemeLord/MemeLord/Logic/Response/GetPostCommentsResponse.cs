using MemeLord.Logic.Dto;
using System.Collections.Generic;

namespace MemeLord.Logic.Response
{
    public class GetPostCommentsResponse
    {
        public int LastId { get; set; }
        public IEnumerable<CommentDto> CommentsList { get; set; }
    }
}