using System.Collections.Generic;
using MemeLord.DataObjects.Dto;

namespace MemeLord.DataObjects.Response
{
    public class GetBestCommentsResponse
    {
        public int Count { get; set; }
        public IEnumerable<CommentDto> CommentsList { get; set; }
    }
}