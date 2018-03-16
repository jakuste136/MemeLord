using System;
using MemeLord.Models.Utils;

namespace MemeLord.Models
{
    public class Like : BaseEntity
    {
        public Users Users { get; set; }
        public DateTime CreationDate { get; set; }
        public Post Post { get; set; }
        public Comment Comment { get; set; }
        public int Value { get; set; }
    }
}