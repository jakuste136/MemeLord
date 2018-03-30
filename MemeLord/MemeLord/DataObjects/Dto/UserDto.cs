using System;
using MemeLord.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MemeLord.DataObjects.Dto
{
    [Obsolete]
    public class UserDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public Sex Sex { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}