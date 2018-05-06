using MemeLord.Models;

namespace MemeLord.DataObjects.Request
{
    public class AddLikeRequest
    {
        public Like Like { get; set; }
        public User User { get; set; }
        public int PostId { get; set; }
    }
}