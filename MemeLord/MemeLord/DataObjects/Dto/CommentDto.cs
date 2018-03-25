using System;
using System.Collections.Generic;

namespace MemeLord.DataObjects.Dto
{
    public class CommentDto
    {
        public string Username { get; set; }
        public int Rating { get; set; }
        public IEnumerable<CommentDto> Answers { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? DeletionDate { get; set; }
        public string Description { get; set; }
        public int Id { get; set; }
    }
}