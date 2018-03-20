using System;

namespace MemeLord.Logic.Dto
{
    public class PostDto
    {
        public string Title { get; set; }
        public string Image { get; set; }
        public DateTime CreationDate { get; set; }
        public int Rating { get; set; }
        public DateTime? DeletionDate { get; set; }
    }
}