using System;
using System.Security.Cryptography;
using MemeLord.Configuration;

namespace MemeLord.Logic.Authentication
{
    /*
     *     HASH MANAGER - generating password hashes since 2018.    
     *  WARNING -- PLEASE DO NOT FUCKING TOUCH ANY CONSTS -- WARNING
     */
    public sealed class HashManager
    {
        /* Size of salt part of hash in bytes. */
        private readonly int _saltSize = 16;

        /* Size of proper hash part of hash in bytes. */
        private const int HashSize = 20;

        /* Iterations used to generate hash. */
        private const int Iterations = 53238;

        /* Hash identification prefix. */
        private const string HashPrefix = "MMLRD$V1$";

        public HashManager()
        {
            _saltSize = PasswordConfig.Salt;
        }

        /*
         * Get hash from given string.
         */
        public static string Hash(string password)
        {
            var salt = new byte[_saltSize];
            new RNGCryptoServiceProvider().GetBytes(salt);

            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, Iterations);
            var hash = pbkdf2.GetBytes(HashSize);

            var hashBytes = new byte[_saltSize + HashSize];
            Array.Copy(salt, 0, hashBytes, 0, _saltSize);
            Array.Copy(hash, 0, hashBytes, _saltSize, HashSize);

            var base64Hash = Convert.ToBase64String(hashBytes);
            return string.Format($"{HashPrefix}{Iterations}${base64Hash}");
        }

        /*
         * Cheks if hash is supported in its verion.
         */
        public static bool IsHashSupported(string hashString)
        {
            return hashString.Contains(HashPrefix);
        }

        /*
         * Verify if given hash matches given password, proper hash auhorisation method.
         */
        public static bool Verify(string password, string hashedPassword)
        {
            if (!IsHashSupported(hashedPassword))
            {
                throw new NotSupportedException("The hashtype is not supported");
            }

            var splittedHashString = hashedPassword.Replace(HashPrefix, "").Split('$');
            var iterations = int.Parse(splittedHashString[0]);
            var base64Hash = splittedHashString[1];

            var hashBytes = Convert.FromBase64String(base64Hash);

            var salt = new byte[_saltSize];
            Array.Copy(hashBytes, 0, salt, 0, _saltSize);

            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations);
            var hash = pbkdf2.GetBytes(HashSize);

            for (var i = 0; i < HashSize; i++)
            {
                if (hashBytes[i + _saltSize] != hash[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}