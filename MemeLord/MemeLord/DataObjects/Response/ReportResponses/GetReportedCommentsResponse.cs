using System.Collections.Generic;
using MemeLord.DataObjects.Dto.ReportDtos;

namespace MemeLord.DataObjects.Response.ReportResponses
{
    public class GetReportedCommentsResponse
    {
        public int LastId { get; set; }
        public IEnumerable<ReportedCommentDto> ReportedComments { get; set; }
    }
}