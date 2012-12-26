using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using VTMS.ControlLib;
using VTMS.Model;
using VTMS.Access;
using VTMS.Common;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Rendering;

namespace VTMS
{
    public partial class LoginForm : Office2007Form
    {

        public static User user = new User();

        public static string loginServer;

        public LoginForm()
        {
            InitializeComponent();

            LoadConfig();
        }

        /// <summary>
        /// 加载配置信息
        /// </summary>
        private void LoadConfig()
        {
            if (Utilities.GetConfigValue("userName") != null)
            {
                userName.Text = Utilities.GetConfigValue("userName");
                if (Utilities.GetConfigValue("password") != null)
                {
                    password.Text = Utilities.Base64Dencrypt(Utilities.GetConfigValue("password"));
                }
            }
            if (Utilities.GetConfigValue("server") != null)
            {
                string ip = Utilities.GetConfigValue("server");
                try
                {
                    server.IPAddress = System.Net.IPAddress.Parse(ip);
                }
                catch
                {
                }
            }
            if (Utilities.GetConfigValue("pwdCBox") != null)
            {
                pwdCBox.Checked = bool.Parse(Utilities.GetConfigValue("pwdCBox"));
            }
            if (Utilities.GetConfigValue("userNameCBox") != null)
            {
                userNameCBox.Checked = bool.Parse(Utilities.GetConfigValue("userNameCBox"));
            }

            if (Utilities.GetConfigValue("theme") != null)
            {
                this.styleManager.ManagerStyle = (eStyle)Enum.Parse(typeof(eStyle), Utilities.GetConfigValue("theme"));

                this.Invalidate();
            }
            else
            {
                this.styleManager.ManagerStyle = eStyle.Office2007Blue;
            }
        }

        /// <summary>
        /// 检查用户名密码,取得用户信息
        /// </summary>
        /// <returns></returns>
        private bool CheckPrivilege()
        {
            if(userName.Equals("jilichao") && password.Equals("admin"))
                return true;
            else
                return false;
        }

        /// <summary>
        /// 登录按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void loginBtn_Click(object sender, EventArgs e)
        {
            
            if (userName.Text.Equals("jilichao") && password.Text.Equals("admin"))
            {
                user.Id = "jilichao";
                user.Name = "纪立超";
                user.loginDate = DateTime.Now.ToString("yyyyMMdd");
                loginServer = server.Text;

                SaveLoginInfo();

                MainForm mainForm = new MainForm();
                this.Hide();
                if (mainForm.ShowDialog() != DialogResult.OK)
                    this.Close();
            }
        }

        /// <summary>
        /// 保存登录信息
        /// </summary>
        private void SaveLoginInfo()
        {
            if (userNameCBox.Checked)
            {
                Utilities.SaveConfig("userName", userName.Text);

                Utilities.SaveConfig("userNameCBox", userNameCBox.Checked.ToString());
            }
            else
            {
                Utilities.RemoveConfigValue("userName");
                Utilities.RemoveConfigValue("userNameCBox");
            }
            if (pwdCBox.Checked)
            {
                Utilities.SaveConfig("pwdCBox", pwdCBox.Checked.ToString());

                Utilities.SaveConfig("userName", userName.Text);

                //保存密码
                Utilities.SaveConfig("password", Utilities.Base64Encrypt(password.Text));
            }
            else
            {
                Utilities.RemoveConfigValue("password");
                Utilities.RemoveConfigValue("pwdCBox");
            }
            //保存服务器地址
            Utilities.SaveConfig("server", server.Text);
        }
        
        /// <summary>
        /// 取消关闭窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 记住密码点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pwdCBox_CheckedChanged(object sender, EventArgs e)
        {
            if (pwdCBox.Checked)
            {
                this.userNameCBox.Enabled = false;
            }
            else
            {
                this.userNameCBox.Enabled = true;
            }
        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utilities.Close();
        }
    }
}
