using LocalStore.Domain;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace LocalStore.Service.Helper
{
    public static class HelperClass
    {
        #region Fields
        static readonly Dictionary<string, string> prefixCodes = new Dictionary<string, string>
        {
            { nameof(Warehouse), "KH" },
            { nameof(User), "US" },
            { nameof(Role), "RL" }
        };
        #endregion

        #region HashPassword
        public static string HashPassword(string plainPassword)
        {
            StringBuilder password = new StringBuilder();
            MD5CryptoServiceProvider md5Provider = new MD5CryptoServiceProvider();
            byte[] bytes = md5Provider.ComputeHash(new UTF8Encoding().GetBytes(plainPassword));

            for (int i = 0; i < bytes.Length; i++)
            {
                password.Append(bytes[i].ToString("x2"));
            }

            return password.ToString();
        }
        #endregion

        #region GenCode
        public static string GenCode(string type)
        {
            int minRange = 10000, maxRange = 100000;
            Random rd = new Random();
            int postfixCode = rd.Next(minRange, maxRange);

            bool hasType = prefixCodes.ContainsKey(type);
            if (!hasType)
            {
                return null;
            }
            else
            {
                string prefixCode = prefixCodes[type];
                return prefixCode + postfixCode;
            }
        }
        #endregion
    }
}
