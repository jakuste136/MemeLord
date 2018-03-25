using System;
using System.Security.Cryptography;
using MemeLord.Configuration;

namespace MemeLord.Logic.Authentication
{
    public static class HashManager
    {
        private static readonly int saltSize = HashManagerConfiguration.SaltSize;  //16

        private static readonly int hashSize = HashManagerConfiguration.HashSize; //20

        private static readonly int iterations = HashManagerConfiguration.Iterations; //53238

        private static readonly string hashPrefix = HashManagerConfiguration.HashPrefix; //MMLRD$V1$

        public static string Hash(string password)
        {
            var salt = new byte[saltSize];
            new RNGCryptoServiceProvider().GetBytes(salt);

            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations);
            var hash = pbkdf2.GetBytes(hashSize);

            var hashBytes = new byte[saltSize + hashSize];
            Array.Copy(salt, 0, hashBytes, 0, saltSize);
            Array.Copy(hash, 0, hashBytes, saltSize, hashSize);

            var base64Hash = Convert.ToBase64String(hashBytes);
            return string.Format($"{hashPrefix}{iterations}${base64Hash}");
        }

        public static bool IsHashSupported(string hashString)
        {
            return hashString.Contains(hashPrefix);
        }

        public static bool Verify(string password, string hashedPassword)
        {
            if (!IsHashSupported(hashedPassword))
            {
                throw new NotSupportedException("The hashtype is not supported");
            }

            var splittedHashString = hashedPassword.Replace(hashPrefix, "").Split('$');
            var guessedIterations = int.Parse(splittedHashString[0]);
            var base64Hash = splittedHashString[1];

            var hashBytes = Convert.FromBase64String(base64Hash);

            var salt = new byte[saltSize];
            Array.Copy(hashBytes, 0, salt, 0, saltSize);

            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, guessedIterations);
            var hash = pbkdf2.GetBytes(hashSize);

            for (var i = 0; i < hashSize; i++)
            {
                if (hashBytes[i + saltSize] != hash[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}