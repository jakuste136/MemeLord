using System;
using MemeLord.Models.Utils;

namespace MemeLord.Models
{
    public class Post : BaseEntity, ISoftDeletable
    {
        public Users Op { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public DateTime CreationDate { get; set; }
        public int Rating { get; set; }
        public DateTime? DeletionDate { get; set; }
    }
}