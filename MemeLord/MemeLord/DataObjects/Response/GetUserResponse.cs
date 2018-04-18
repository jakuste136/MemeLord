using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MemeLord.Models;

namespace MemeLord.DataObjects.Response
{
    public class GetUserResponse
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public Sex Sex { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Description { get; set; }
        public string Avatar { get; set; }
    }
}