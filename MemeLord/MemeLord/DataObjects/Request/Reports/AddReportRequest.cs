using System;

namespace MemeLord.DataObjects.Request.Reports
{
    public class AddReportRequest
    {
        public int? PostId { get; set; }
        public int? CommentId { get; set; }
        public int ReporterId { get; set; }
        public DateTime ReportDate { get; set; }
        public int ReportTypeId { get; set; }
    }
}