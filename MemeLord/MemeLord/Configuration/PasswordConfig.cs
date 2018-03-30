using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MemeLord.Configuration
{
    public static class PasswordConfig
    {
        public static int Salt => Properties.Settings.Default.Salt;
    }
}