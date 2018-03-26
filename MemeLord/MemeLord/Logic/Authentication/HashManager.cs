using System;
using System.Security.Cryptography;
using MemeLord.Configuration;

namespace MemeLord.Logic.Authentication
{
    public class HashManager
    {
        private readonly AuthenticationConfiguration _authenticationConfiguration;

        public HashManager(AuthenticationConfiguration authenticationConfiguration)
        {
            _authenticationConfiguration = authenticationConfiguration;
        }

        public string Hash(string password)
        {
            var salt = new byte[_authenticationConfiguration.SaltSize];
            new RNGCryptoServiceProvider().GetBytes(salt);
            return Hash(password, salt);
        }

        public string Hash(string password, byte[] salt)
        {
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, _authenticationConfiguration.Iterations);
            var hash = pbkdf2.GetBytes(_authenticationConfiguration.HashSize);

            var hashBytes = new byte[_authenticationConfiguration.SaltSize + _authenticationConfiguration.HashSize];
            Array.Copy(salt, 0, hashBytes, 0, _authenticationConfiguration.SaltSize);
            Array.Copy(hash, 0, hashBytes, _authenticationConfiguration.SaltSize, _authenticationConfiguration.HashSize);

            var base64Hash = Convert.ToBase64String(hashBytes);
            return string.Format($"{_authenticationConfiguration.HashPrefix}${_authenticationConfiguration.HashVersion}${_authenticationConfiguration.Iterations}${base64Hash}");
        }

        public string[] StripHashedPassword(string hashedPassword)
        {
             return hashedPassword.Split('$');
        }

        public byte[] GetSaltFromHashBytes(byte[] hashBytes)
        {
            var salt = new byte[_authenticationConfiguration.SaltSize];
            Array.Copy(hashBytes, 0, salt, 0, _authenticationConfiguration.SaltSize);
            return salt;
        }

        public bool Verify(string password, string hashedPassword)
        {
            var splittedHashString = StripHashedPassword(hashedPassword);
            if (!string.Equals(splittedHashString[0], _authenticationConfiguration.HashPrefix) || !string.Equals(splittedHashString[1], _authenticationConfiguration.HashVersion))
            {
                throw new NotSupportedException("The hashtype is not supported");
            }

            var guessedIterations = int.Parse(splittedHashString[2]);
            var base64Hash = splittedHashString[3];

            var hashBytes = Convert.FromBase64String(base64Hash);

            var salt = GetSaltFromHashBytes(hashBytes);

            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, guessedIterations);
            var hash = pbkdf2.GetBytes(_authenticationConfiguration.HashSize);

            for (var i = 0; i < _authenticationConfiguration.HashSize; i++)
            {
                if (hashBytes[i + _authenticationConfiguration.SaltSize] != hash[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}