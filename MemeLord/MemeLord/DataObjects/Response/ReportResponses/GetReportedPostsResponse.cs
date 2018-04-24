using System.Collections.Generic;
using MemeLord.DataObjects.Dto.ReportDtos;

namespace MemeLord.DataObjects.Response.ReportResponses
{
    public class GetReportedPostsResponse
    {
        public int LastId { get; set; }
        public IEnumerable<ReportedPostDto> ReportedPosts { get; set; }
    }
}