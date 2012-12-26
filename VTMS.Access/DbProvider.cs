using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace VTMS.Access
{
    public class DbProvider
    {
        private static System.Collections.Specialized.NameValueCollection sets = ConfigurationManager.AppSettings;
        /// <summary>
        /// 数据库的连接字符串
        /// </summary>
        /// 
        public readonly static string dbconnstring = string.Format("server={0};user id={1};password={2};database={3}",
            new string[]{VTMS.Common.Utilities.GetConfigValue("server"),
                        sets["DBUser"].ToString(), VTMS.Common.Utilities.Base64Dencrypt(sets["DBPassword"].ToString()), sets["database"].ToString()});

        /// <summary>
        /// 数据库中字符串的NULL值转换
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string DBNullCheck(object str)
        {
            try
            {
                if (str == DBNull.Value)
                {
                    return "";
                }
                else
                {
                    return str.ToString().Trim();
                }
            }
            catch
            {
                return "";
            }
        }

        /// <summary>
        /// 数据库中图片的NULL值转换
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static byte[] PicNullCheck(object pic)
        {
            if (pic == DBNull.Value)
            {
                return null;
            }
            else
            {
                return (byte[])pic;
            }
        }
    }
}
