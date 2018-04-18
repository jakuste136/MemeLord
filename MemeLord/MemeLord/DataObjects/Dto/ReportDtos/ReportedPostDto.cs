using System;

namespace MemeLord.DataObjects.Dto.ReportDtos
{
    public class ReportedPostDto
    {
        public string Username { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public DateTime CreationDate { get; set; }
        public string Description { get; set; }
        public int PostId { get; set; }
    }
}