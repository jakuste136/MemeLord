using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using Microsoft.Owin;

namespace MemeLord.Logic.Extensions
{
    public static class OwinContextExtentions
    {
        public static string GetUserUsername(this IOwinContext context)
        {
            var result = "-1";
            var claim = context.Authentication.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name);
            if (claim != null)
            {
                result = claim.Value;
            }
            return result;
        }
    }
}