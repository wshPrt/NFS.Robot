using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NFS.Commons.MD5Poxy
{
    /// <summary>
    /// 加密／解密工具
    /// </summary>
    public class CEncoder
    {
        const string key = "a3f3bc6d43e7f10d";

        /// <summary>
        /// 字符串加密.由DESCryptoServiceProvider对象加密
        /// </summary>
        public static string Encode(string str)
        {
            try
            {
                DESCryptoServiceProvider provider = new DESCryptoServiceProvider();
                provider.Key = Encoding.ASCII.GetBytes(key.Substring(0, 8));
                provider.IV = Encoding.ASCII.GetBytes(key.Substring(0, 8));
                byte[] bytes = Encoding.Default.GetBytes(str);
                MemoryStream stream = new MemoryStream();
                CryptoStream stream2 = new CryptoStream(stream, provider.CreateEncryptor(), CryptoStreamMode.Write);
                stream2.Write(bytes, 0, bytes.Length);
                stream2.FlushFinalBlock();
                StringBuilder builder = new StringBuilder();
                foreach (byte num in stream.ToArray())
                {
                    builder.AppendFormat("{0:X2}", num);
                }
                stream.Close();
                return builder.ToString();
            }
            catch
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// 字符串解密.由DESCryptoServiceProvider对象解密
        /// </summary>
        public static string Decode(string str)
        {
            try
            {
                DESCryptoServiceProvider provider = new DESCryptoServiceProvider();
                provider.Key = Encoding.ASCII.GetBytes(key.Substring(0, 8));
                provider.IV = Encoding.ASCII.GetBytes(key.Substring(0, 8));
                byte[] buffer = new byte[str.Length / 2];
                for (int i = 0; i < (str.Length / 2); i++)
                {
                    int num2 = Convert.ToInt32(str.Substring(i * 2, 2), 0x10);
                    buffer[i] = (byte)num2;
                }
                MemoryStream stream = new MemoryStream();
                CryptoStream stream2 = new CryptoStream(stream, provider.CreateDecryptor(), CryptoStreamMode.Write);
                stream2.Write(buffer, 0, buffer.Length);
                stream2.FlushFinalBlock();
                stream.Close();
                return Encoding.Default.GetString(stream.ToArray());
            }
            catch
            {
                return string.Empty;
            }
        }

        private static int PREFIX_LEN = 6;

        /// <summary>
        /// RETURN [PREFIX]+STRING
        /// </summary>
        public static string Encode(string source, bool genPrefix)
        {
            if (source == string.Empty) return "";

            if (genPrefix)
                return GetPrefix(PREFIX_LEN) + CEncoder.Encode(source);
            else
                return CEncoder.Encode(source);
        }

        /// <summary>
        /// [PREFIX]STRING-->STRING
        /// </summary>
        public static string Decode(string source, bool hasPrefix)
        {
            if (source == string.Empty) return "";

            if (source.Length <= PREFIX_LEN || !hasPrefix)
                return Decode(source);
            else if (hasPrefix)
                return Decode(source.Substring(PREFIX_LEN, source.Length - PREFIX_LEN));
            else
                return Decode(source);
        }

        /// <summary>
        /// MD5加密，Use object MD5,返回16字符串
        /// </summary>
        public static string encryptMD5(string content)
        {
            string retContent = "";

            MD5 md5 = MD5.Create();
            // 加密后是一个字节类型的数组 
            byte[] s = md5.ComputeHash(Encoding.Unicode.GetBytes(content));

            // 通过使用循环，将字节类型的数组转换为字符串，此字符串是常规字符格式化所得 
            for (int i = 0; i < s.Length; i++)
            {
                // 将得到的字符串使用十六进制类型格式。格式后的字符是小写的字母，
                //如果使用大写（X）则格式后的字符是大写字符 
                retContent = retContent + s[i].ToString("X");
            }
            return retContent;
        }

        /// <summary>
        /// MD5不可逆加密.use MD5CryptoServiceProvider
        /// </summary>
        public static string GenerateMD5Hash(string input)
        {
            MD5CryptoServiceProvider md5Hasher = new MD5CryptoServiceProvider();

            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input));

            StringBuilder sBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }

        /// <summary>
        /// 密码头
        /// </summary>
        public static string GetPrefix(int bit)
        {
            //A-Z 0-9
            string chars = "0A1D30A4B5C006D72C8E92030F506E7E02F1A0D023B3B40C5E180D6F4D5E6F";
            string ret = "";
            if (bit < 1) bit = PREFIX_LEN;
            for (int i = 1; i <= bit; i++)
            {
                int n = GetRandomNum(chars.Length - 2);
                ret = ret + chars.Substring(n, 1);
            }
            return ret;
        }

        /// <summary>
        /// 取随机数
        /// </summary>
        /// <param name="maxValue">最大数</param>
        /// <returns></returns>
        public static int GetRandomNum(int maxValue)
        {
            Random seed = new Random();
            Random randomNum = new Random();
            Thread.Sleep(20);
            return randomNum.Next(1, maxValue);
        }

    }
}
