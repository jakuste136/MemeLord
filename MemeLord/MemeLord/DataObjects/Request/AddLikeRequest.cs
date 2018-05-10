using MemeLord.Models;

namespace MemeLord.DataObjects.Request
{
    public class AddLikeRequest
    {
        public int Value { get; set; }
        public int PostId { get; set; }
        public int CommentId { get; set; }
    }
}