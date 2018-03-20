using MemeLord.Models.Utils;

namespace MemeLord.Models
{
    public class Notification : BaseEntity
    {
        public NotificationType NotificationType { get; set; }
        public User User { get; set; }
        public Post Post { get; set; }
        public bool WasDisplayed { get; set; }
    }
}