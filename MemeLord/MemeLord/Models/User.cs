using System;
using MemeLord.Models.Utils;

namespace MemeLord.Models
{
    public class User : BaseEntity
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Hash { get; set; }
        public string Avatar { get; set; }
        public Sex Sex { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Description { get; set; }
    }

    public enum Sex
    {
        Male,
        Female,
        Undefined
    }
}