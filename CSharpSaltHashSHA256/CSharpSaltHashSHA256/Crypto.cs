﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSaltHashSHA256
{
    public static class Crypto
    {
        private static String ByteArrayToHexString(byte[] ba)
        {
            StringBuilder hex = new StringBuilder(ba.Length * 2);
            foreach (byte b in ba)
                hex.AppendFormat("{0:x2}", b);

            return hex.ToString();
        }

        //Create a Salt, it is recommended to set this Value to Unique in your Database
        public static String CreateSalt(int length)
        {
            var rng = new System.Security.Cryptography.RNGCryptoServiceProvider();
            var buff = new byte[length];
            rng.GetBytes(buff);

            return Convert.ToBase64String(buff);
        }

        //This Hash can be used few Times, it isn´t bad if this Value is more then one time in your Database
        public static String HashToSHA256(string password, string salt)
        {
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(password + salt);
            System.Security.Cryptography.SHA256Managed sha256hashstring = new System.Security.Cryptography.SHA256Managed();

            byte[] hash = sha256hashstring.ComputeHash(bytes);

            return ByteArrayToHexString(hash);
        }
    }
}
