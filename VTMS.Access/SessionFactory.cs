using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using VTMS.Model;
using VTMS.Common;
namespace VTMS.Access
{
    public static class SessionFactory
    {
        private static ISessionFactory sessionFactory;

        public static ISession OpenSession()
        {
            if (sessionFactory == null)
            {
                System.Collections.Specialized.NameValueCollection sets = System.Configuration.ConfigurationManager.AppSettings;

                //获取连接字符串
                string server = Utilities.GetConfigValue("server");
                string pwd = VTMS.Common.Utilities.Base64Dencrypt(Utilities.GetConfigValue("DBPassword"));
                string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
                connectionString = string.Format(connectionString, server, pwd);




                try
                {
                    Configuration cfg = new Configuration().Configure();
                    cfg.Proxy(p => p.ProxyFactoryFactory<NHibernate.Bytecode.DefaultProxyFactoryFactory>());
                    cfg.DataBaseIntegration(db =>
                    {
                        db.ConnectionString = connectionString;
                    });

                    sessionFactory = cfg.BuildSessionFactory();
                }
                catch (Exception e)
                {
                    VTMS.Common.MessageUtil.ShowError("无法登陆服务器，请检查服务器IP设置是否正确，错误信息为：" + e.Message);
                }
            }
            return sessionFactory.OpenSession();
        }
    }
}
