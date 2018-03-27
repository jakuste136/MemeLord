using System;
using System.Collections.Generic;

namespace MemeLord.DataObjects.Dto
{
    public class CommentDto
    {
        public string Username { get; set; }
        public int Rating { get; set; }
        public IList<CommentDto> Answers { get; set; }
        public DateTime CreationDate { get; set; }
        public string Text { get; set; }
    }
}