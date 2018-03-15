using System;
using MemeLord.Models.Utils;

namespace MemeLord.Models
{
    public class Users : BaseEntity
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Avatar { get; set; }
        // todo: [kuba] sprawdzic czy salt tez ma tu byc
        public Sex Sex { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Description { get; set; }
    }

    public enum Sex
    {
        Male = 0,
        Female = 1,
        Undefined = 2
    }
}