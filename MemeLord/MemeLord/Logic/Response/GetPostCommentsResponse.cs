using MemeLord.Logic.Dto;
using System.Collections.Generic;

namespace MemeLord.Logic.Response
{
    public class GetPostCommentsResponse
    {
        public int Number { get; set; }
        public IEnumerable<CommentDto> CommentsList { get; set; }
    }
}