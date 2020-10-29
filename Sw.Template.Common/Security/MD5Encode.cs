using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Sw.Template.Common.Security
{
    public class MD5Encode
    {
        public static string MD5Encrypt(string pwd)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            return BitConverter.ToString(md5.ComputeHash(Encoding.Default.GetBytes(pwd))).Replace("-", "").ToUpper();
        }
    }
}
