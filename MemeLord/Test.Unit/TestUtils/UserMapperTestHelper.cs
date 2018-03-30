using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MemeLord.Logic.Authentication;

namespace Test.Unit.TestUtils
{
    internal class UserMapperTestHelper
    {
        public static string GetSaltFromHash(string hash)
        {
            var hashStrings = HashManager.StripHashedPassword(result.Hash);
            var hashBytes = Convert.FromBase64String(hashStrings[3]);
            var salt = HashManager.GetSaltFromHashBytes(hashBytes);
        }
    }
}
