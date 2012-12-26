using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Configuration;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Rendering;
using VTMS.Common;
namespace VTMS
{
    public partial class MainForm : Office2007RibbonForm
    {
        private Type[] types = Assembly.Load("VTMS").GetTypes();

        public MainForm()
        {
            InitializeComponent();

            InitialWindowsInfo();

            load_PreferSetting();
        }

        /// <summary>
        /// 初始化状态栏等控件信息
        /// </summary>
        private void InitialWindowsInfo()
        {
            //初始化主题菜单选项
            foreach (string name in Enum.GetNames(typeof(eStyle)))
            {
                ButtonItem button = new ButtonItem(name, name);
                button.AutoCheckOnClick = true;
                button.Click += new EventHandler(theme_Changed);
                this.theme.SubItems.Add(button);
            }
            //初始化登录信息
            this.loginUser.Text = "登录用户："+LoginForm.user.Name;
            this.loginServer.Text = "服务器地址：" + LoginForm.loginServer;
            this.loginDate.Text = "服务器日期：" + DateTime.ParseExact(LoginForm.user.loginDate, "yyyyMMdd", System.Globalization.CultureInfo.CurrentCulture).ToString("yyyy年MM月dd日");
        }

        /// <summary>
        /// 改变主题风格
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void theme_Changed(object sender, EventArgs e)
        {
            ButtonItem source = sender as ButtonItem;

            this.styleManager.ManagerStyle = (eStyle)Enum.Parse(typeof(eStyle), source.Name);

            this.Invalidate();
        }

        /// <summary>
        /// 防止打开多个同样的子窗体,检查是否已打开某个子窗体,如果打开了就返回true,否则返回false
        /// </summary>
        /// <param name="tabName">子窗体的窗体名称</param>
        /// <returns></returns>
        private bool IsOpenTab(string tabName)
        {
            bool isOpened = false;
            Control.ControlCollection controls = tabStrip1.Controls;
            foreach (TabItem tab in tabStrip1.Tabs)
            {
                if (tab.Text.Trim() == tabName)
                {
                    isOpened = true;
                    tabStrip1.SelectedTab = tab;
                    break;
                }
            }

            return isOpened;
        }

        private void infoInput_Click(object sender, EventArgs e)
        {
            string tabName = (sender as ButtonItem).Text;
            if (!IsOpenTab(tabName))
            {
                InfoInputForm doc = new InfoInputForm();
                doc.MdiParent = this;
                doc.WindowState = FormWindowState.Maximized;
                doc.Show();
                doc.Update();
            }
        }

        /// <summary>
        /// 窗体关闭时保存主题风格和偏好设置，并关闭子窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {

            Utilities.SaveConfig("theme", this.styleManager.ManagerStyle.ToString());

            Utilities.SaveConfig("function", this.ribbonControl1.SelectedRibbonTabItem.Name);

            foreach (Form child in this.MdiChildren)
            {
                child.Close();
            }
        }

        /// <summary>
        /// 选择某一功能菜单，加载子页面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormBtn_Click(object sender, EventArgs e)
        {
            string tabName = (sender as ButtonItem).Text;
            string formName = (sender as ButtonItem).Name + "Form";
            if (!IsOpenTab(tabName))
            {
                foreach (Type type in types)
                {
                    if (type.Name.Equals(formName))
                    {
                        Form child = Activator.CreateInstance(type) as Form;
                        child.MdiParent = this;
                        child.WindowState = FormWindowState.Maximized;
                        child.Show();
                        child.Update();
                    }
                }
            }
        }

        /// <summary>
        /// 加载主题风格和偏好设置
        /// </summary>
        private void load_PreferSetting()
        {
            if (Utilities.GetConfigValue("theme") != null)
            {
                this.styleManager.ManagerStyle = (eStyle)Enum.Parse(typeof(eStyle), Utilities.GetConfigValue("theme"));

                (this.theme.SubItems[this.styleManager.ManagerStyle.ToString()] as ButtonItem).Checked = true;

                this.Invalidate();
            }

            if (Utilities.GetConfigValue("function") != null)
            {
                RibbonTabItem tabItem = this.ribbonControl1.Items[Utilities.GetConfigValue("function")] as RibbonTabItem;
                tabItem.Checked = true;
            }
        }
    }
}
