using System;
using MemeLord.Models;

namespace MemeLord.DataObjects.Dto
{
    public class UserDto
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Sex Sex { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}