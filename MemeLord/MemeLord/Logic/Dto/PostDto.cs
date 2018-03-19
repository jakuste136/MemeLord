using System;
using MemeLord.Models;

namespace MemeLord.Logic.Dto
{
    public class PostDto
    {
        public User Op { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public DateTime CreationDate { get; set; }
        public int Rating { get; set; }
        public DateTime? DeletionDate { get; set; }
    }
}