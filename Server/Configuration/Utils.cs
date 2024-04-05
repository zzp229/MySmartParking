using IConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Configuration
{
    public class Utils : IUtils
    {
        // MD5加密
        public string GetMD5Str(string inputStr)
        {
            if (string.IsNullOrEmpty(inputStr)) return "";

            byte[] result = Encoding.Default.GetBytes(inputStr);    //tbPass为输入密码的文本框
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] output = md5.ComputeHash(result);
            return BitConverter.ToString(output).Replace("-", "");  //tbMd5pass为输出加密文本的文本框
        }
    }
}
