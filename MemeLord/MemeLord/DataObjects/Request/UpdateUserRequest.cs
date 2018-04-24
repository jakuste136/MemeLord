using System;
using MemeLord.Models;

namespace MemeLord.DataObjects.Request
{
    public class UpdateUserRequest
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Avatar { get; set; }
        public Sex Sex { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Description { get; set; }
    }
}