using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Security.Cryptography;
using System.Configuration;
using System.Runtime.Serialization.Formatters.Binary;
namespace VTMS.Common
{
    public class Utilities
    {
        private static Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

        public static byte[] ConvertImage2Bytes(Image image)
        {
            if (image == null)
            {
                return null;
            }
            MemoryStream ms = new MemoryStream();
            byte[] imagedata = null;
            image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            imagedata = ms.GetBuffer();
            return imagedata;

        }

        public static Image ConvertBytes2Image(byte[] bytes)
        {
            if (bytes == null)
            {
                return null;
            }
            MemoryStream ms = new MemoryStream(bytes);
            Image img = Image.FromStream(ms);
            return img;
        }

        public static bool IsNullOrEmpty(string str)
        {
            if (str == null || str.Trim().Length == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static string Md5Encrypt(string password)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] result = md5.ComputeHash(System.Text.Encoding.Default.GetBytes(password));
            return System.Text.Encoding.Default.GetString(result);
        }

        public static string Base64Dencrypt(string password)
        {
            byte[] output = Convert.FromBase64String(password);
            return Encoding.Default.GetString(output);
        }

        public static string Base64Encrypt(string password)
        {
            byte[] bytes = Encoding.Default.GetBytes(password);
            return Convert.ToBase64String(bytes);
        }

        /// <summary>
        /// 保存配置信息
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public static void SaveConfig(string key, string value)
        {
            if (config.AppSettings.Settings[key] == null)
            {
                config.AppSettings.Settings.Add(key, value);
            }
            else
            {
                config.AppSettings.Settings[key].Value = value;
            }
        }

        public static string GetConfigValue(string key)
        {
            if (config.AppSettings.Settings[key] != null)
                return config.AppSettings.Settings[key].Value;
            else
                return null;
        }
        public static void RemoveConfigValue(string key)
        {
            config.AppSettings.Settings.Remove(key);
        }

        public static void Close()
        {
            config.Save(ConfigurationSaveMode.Modified);
        }
    }
}
