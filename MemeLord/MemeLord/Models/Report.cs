using System;
using MemeLord.Models.Utils;

namespace MemeLord.Models
{
    public class Report : BaseEntity
    {
        public Post Post { get; set; }
        public Comment Comment { get; set; }
        public User Reporter { get; set; }
        public DateTime ReportDate { get; set; }
        public ReportType ReportType { get; set; }
    }
}