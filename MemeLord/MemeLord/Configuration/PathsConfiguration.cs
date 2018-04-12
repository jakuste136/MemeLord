using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MemeLord.Configuration.Settings;

namespace MemeLord.Configuration
{
    public class PathsConfiguration
    {
        public string MemeFolderName => PathsSettings.Default.MemeFolderName;
    }
}