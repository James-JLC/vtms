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
using VTMS.Model.Entities;
namespace VTMS
{
    public partial class MainForm : Office2007RibbonForm
    {
        private Type[] types = Assembly.Load("VTMS").GetTypes();

        private static Dictionary<RibbonBar, Dictionary<string, string>> buttons = new Dictionary<RibbonBar, Dictionary<string, string>>();

        public MainForm()
        {
            InitializeComponent();

            InitialWindowsInfo();

            load_PreferSetting();

            InitialButtons();

            SetPrivilege();
        }

        /// <summary>
        /// 初始化状态栏等控件信息
        /// </summary>
        private void InitialWindowsInfo()
        {
            //初始化主题菜单选项
            foreach (string name in Enum.GetNames(typeof(eStyle)))
            {
                if (name != "Metro")
                {
                    ButtonItem button = new ButtonItem(name, name);
                    button.Click += new EventHandler(theme_Changed);
                    this.theme.SubItems.Add(button);
                }
            }
            
            //初始化登录信息
            this.loginUser.Text = "登录用户："+LoginForm.user.UsersName;
            this.loginServer.Text = "服务器地址：" + LoginForm.user.LoginServer;
            this.loginDate.Text = "服务器日期：" + DateTime.ParseExact(LoginForm.user.LoginDate, "yyyyMMdd", System.Globalization.CultureInfo.CurrentCulture).ToString("yyyy年MM月dd日");
        }

        private void SetPrivilege()
        {
            if (LoginForm.user.UsersId.Equals("admin"))
            {
                return;
            }
            List<Control> list = findControl(this.RibbonControl, typeof(RibbonBar));
            List<ButtonItem> component = new List<ButtonItem>();
            foreach (Control parent in list)
            {
                RibbonBar ribbonBar = (RibbonBar)parent;


                foreach (ButtonItem button in ribbonBar.Items)
                {
                    button.Enabled = false;
                }
                foreach (Privilege privilege in LoginForm.user.Privileges)
                {
                    if(ribbonBar.Name.Equals(privilege.ParentName)){
                        try
                        {
                            ribbonBar.Items[privilege.Itmename].Enabled = privilege.Isactive;
                        }
                        catch { }
                    }
                }
            }
        }

        /// <summary>
        /// 改变主题风格
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void theme_Changed(object sender, EventArgs e)
        {
            foreach (ButtonItem bi in this.theme.SubItems)
            {
                bi.Checked = false;
            }
            ButtonItem source = sender as ButtonItem;

            this.styleManager.ManagerStyle = (eStyle)Enum.Parse(typeof(eStyle), source.Name);

            source.Checked = true;

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

            foreach (Form form in this.MdiChildren)
            {
                if (form.Name.Equals(tabName))
                {
                    isOpened = true;
                    foreach (TabItem tab in tabStrip1.Tabs)
                    {
                        if (tab.Text.Equals(form.Text))
                        {
                            tabStrip1.SelectedTab = tab;
                            break;
                        }
                    }
                    break;
                }
            }

            return isOpened;
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
            string formName = (sender as ButtonItem).Name + "Form";
            if (!IsOpenTab(formName))
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
        /// <summary>
        /// 查找特定控件
        /// </summary>
        /// <param name="control"></param>
        /// <param name="controlName"></param>
        /// <returns></returns>
        private List<Control> findControl(System.Windows.Forms.Control control, Type t)
        {
            List<Control> list = new List<Control>();
            foreach (Control c in control.Controls)
            {
                if (c.GetType() == t)
                {
                    list.Add(c);
                }
                else if (c.Controls.Count > 0)
                {
                    List<Control> l = findControl(c, t);
                    foreach (Control cc in l)
                    {
                        list.Add(cc);
                    }
                }
            }
            return list;
        }

        private void InitialButtons()
        {
            List<Control> list = findControl(this.RibbonControl, typeof(RibbonBar));
            foreach (Control parent in list)
            {
                Dictionary<string, string> controls = new Dictionary<string, string>();

                RibbonBar ribbonBar = (RibbonBar)parent;
                foreach (ButtonItem button in ribbonBar.Items)
                {
                    controls.Add(button.Name, button.Text);
                }
                buttons.Add(ribbonBar, controls);
            }
        }
        public static Dictionary<RibbonBar, Dictionary<string, string>> GetControls()
        {
            return buttons;
        }

        private void Password_Click(object sender, EventArgs e)
        {
            new VTMS.SystemManagement.PasswordForm().ShowDialog();
        }

        private void Company_Click(object sender, EventArgs e)
        {
            new VTMS.SystemManagement.CompanyForm().ShowDialog();
        }

        private void VehicleType_Click(object sender, EventArgs e)
        {
            new VTMS.SystemManagement.VehicleTypeForm().ShowDialog();
        }
    }
}
