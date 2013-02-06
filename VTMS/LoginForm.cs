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
using VTMS.Model.Entities;
using VTMS.Access;
using VTMS.Common;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Rendering;

namespace VTMS
{
    public partial class LoginForm : Office2007Form
    {

        public static Users user;

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
                server.Text = Utilities.GetConfigValue("server");
            }
            if (Utilities.GetConfigValue("pwdCBox") != null)
            {
                pwdCBox.Checked = bool.Parse(Utilities.GetConfigValue("pwdCBox"));
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
            Users user = null;
            try
            {
                user = UsersDao.GetById(this.userName.Text);
            }
            catch
            {
                return false;
            }
            string pwd = Utilities.Md5Encrypt(this.password.Text);
            if (user != null && user.UsersIsactive && user.Password.Equals(Utilities.Md5Encrypt(this.password.Text)))
            {
                LoginForm.user = user;
                LoginForm.user.Privileges = PrivilegeDao.GetByUserId(user.UsersId);
                LoginForm.user.LoginDate = VehicleDao.GetCurrentDate();
                LoginForm.user.LoginServer = server.Text;
                return true;
            }
            return false;
        }

        /// <summary>
        /// 登录按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void loginBtn_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren(ValidationConstraints.Enabled & ValidationConstraints.TabStop & ValidationConstraints.Selectable))
            {
                MessageBox.Show("控件内容不合法");
                return;
            }
            SaveLoginInfo();
            if (CheckPrivilege())
            {
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
            Utilities.SaveConfig("userName", userName.Text);

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

            Utilities.Save();
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

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utilities.Save();
        }
    }
}
