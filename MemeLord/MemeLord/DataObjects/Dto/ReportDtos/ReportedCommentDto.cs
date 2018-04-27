using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MemeLord.DataObjects.Dto.ReportDtos
{
    public class ReportedCommentDto
    {
        public string Username { get; set; }
        public string Text { get; set; }
        public DateTime CreationDate { get; set; }
        public string Description { get; set; }
        public int CommentId { get; set; }
    }
}