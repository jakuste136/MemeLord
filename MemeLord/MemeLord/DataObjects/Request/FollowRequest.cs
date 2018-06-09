using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MemeLord.DataObjects.Request
{
    public class FollowRequest
    {
        public string AuthorName { get; set; }
        public bool Follow { get; set; }
    }
}