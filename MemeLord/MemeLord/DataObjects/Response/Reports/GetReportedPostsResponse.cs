using System.Collections.Generic;
using MemeLord.DataObjects.Dto.ReportDtos;

namespace MemeLord.DataObjects.Response.Reports
{
    public class GetReportedPostsResponse
    {
        public int LastId { get; set; }
        public IEnumerable<ReportedPostDto> ReportedPosts { get; set; }
    }
}