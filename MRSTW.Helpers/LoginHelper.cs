using System;
using System.Security.Cryptography;
using System.Text;

namespace MRSTW.Helpers
{
    public static class AuthHelper
    {
        private static string PASSWORD_SALT = "helloworld123";

        public static string GeneratePasswordHash(string password)
        {
            var md5 = new MD5CryptoServiceProvider();
            var originalBytes = Encoding.Default.GetBytes(password + PASSWORD_SALT);
            var encodingBytes = md5.ComputeHash(originalBytes);

            return BitConverter.ToString(encodingBytes).Replace("-", "").ToLower();
        }
    }
}
