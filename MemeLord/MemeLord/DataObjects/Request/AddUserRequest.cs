using System;
using MemeLord.Models;

namespace MemeLord.DataObjects.Request
{
    public class AddUserRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public Sex Sex { get; set; }
    }
}