using System.Web.UI;

namespace MemeLord.Models
{
    public class Following
    {
        public User Follower { get; set; }
        public User Followed { get; set; }
    }
}