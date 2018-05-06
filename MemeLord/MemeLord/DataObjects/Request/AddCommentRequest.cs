using System;

namespace MemeLord.DataObjects.Request
{ 
    public class AddCommentRequest
    {
        public int PostId { get; set; }
        public int? MasterCommentId { get; set; }
        public int UserId { get; set; }
        public int Rating { get; set; }
        public string Text { get; set; }
    }
}