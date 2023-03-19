﻿using System.Security.Cryptography;
using System.Text;

namespace backendnet.Utils
{
    public static class Encriptar
    {
        public static string EncriptarPassword(string input)
        {
            MD5 md5Hash = MD5.Create();
            //Convert The input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }

    }
}
