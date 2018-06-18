using System;

namespace MemeLord.DataObjects.Response.UserResponses
{
    public class SingleUserReportResponse
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Sex { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int PostsCount { get; set; }
        public int PostRating { get; set; }
    }
}