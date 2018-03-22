using System;

namespace MemeLord.DataObjects.Dto
{
    public class PostDto
    {
        public string Username { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public DateTime CreationDate { get; set; }
        public int Rating { get; set; }
        public DateTime? DeletionDate { get; set; }
    }
}