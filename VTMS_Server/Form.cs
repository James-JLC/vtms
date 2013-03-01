using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using System.Diagnostics;

namespace VTMS_Server
{
    public partial class Form : Office2007Form
    {
        System.Timers.Timer timer = new System.Timers.Timer(ONE_HOUR);

        string homePath = new System.IO.DirectoryInfo(".").FullName;

        const int ONE_MINUTE = 1000 * 60;
        const int FIVE_MINUTES = 5 * ONE_MINUTE;
        const int TEN_MINUTES = 10 * ONE_MINUTE;
        const int THIRTY_MINUTES = 30 * ONE_MINUTE;
        const int ONE_HOUR = 60 * ONE_MINUTE;
        const int ONE_DAY = 24 * ONE_HOUR;

        public Form()
        {
            InitializeComponent();
            //this.timeSetup.DataSource = new string[]{"每5分钟","每10分钟","每30分钟","每1小时"};
            //this.timeSetup.Text = "每1小时";

            timer.Elapsed += new System.Timers.ElapsedEventHandler(timeOut);
            timer.AutoReset = true;
            timer.Enabled = true;
        }

        private void Form_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                this.notifyIcon.Visible = true;
                this.notifyIcon.ShowBalloonTip(3500, "提示", "双击恢复窗口", ToolTipIcon.Info); 
                this.ShowInTaskbar = false; 
            }
        }

        /// <summary>
        /// 托盘中图标的双击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void notifyIcon_DoubleClick(object sender, EventArgs e)
        {
            this.notifyIcon.Visible = false;
            this.Show();
            WindowState = FormWindowState.Normal;
            this.Focus();
        }

        /// <summary>
        /// 执行Cmd命令
        /// </summary>
        /// <param name="workingDirectory">要启动的进程的目录</param>
        /// <param name="command">要执行的命令</param>
        public static void StartCmd(String workingDirectory, String command)
        {
            try
            {
                Process p = new Process();
                p.StartInfo.FileName = "cmd.exe";
                p.StartInfo.WorkingDirectory = workingDirectory;
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardInput = true;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.RedirectStandardError = true;
                p.StartInfo.CreateNoWindow = true;
                p.Start();
                p.StandardInput.WriteLine(command);
                p.StandardInput.WriteLine("exit");
            }
            catch (Exception ex)
            {
                MessageBox.Show("执行操作出错，错误信息为：" + ex.Message);
            }
        }

        /// <summary>
        /// 点击关闭按钮时的操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        /// <summary>
        /// 点击恢复按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void restoreBtn_Click(object sender, EventArgs e)
        {
            if (this.restorePath.Text.Length > 0)
            {
                string command = @"mysql -uroot -pjilichao < " + this.restorePath.Text;

                StartCmd(homePath, command);
            }
        }

        /// <summary>
        /// 选择恢复文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void restorePath_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDlg = new OpenFileDialog();
            fileDlg.Filter = "备份文件|*.sql";
            if (fileDlg.ShowDialog() == DialogResult.OK)
            {
                this.restorePath.Text = fileDlg.FileName;
            }
        }

        /// <summary>
        /// 选择备份目录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backupPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDlg = new FolderBrowserDialog();
            if (folderDlg.ShowDialog() == DialogResult.OK)
            {
                this.backupPath.Text = folderDlg.SelectedPath;
            }
        }

        /// <summary>
        /// 设置备份频率
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void confirmBtn_Click(object sender, EventArgs e)
        {
            //if (this.timeSetup.Text == "每5分钟")
            //{
            //    timer.Interval = FIVE_MINUTES;
            //}
            //else if (this.timeSetup.Text == "每10分钟")
            //{
            //    timer.Interval = TEN_MINUTES;
            //} if (this.timeSetup.Text == "每30分钟")
            //{
            //    timer.Interval = THIRTY_MINUTES;
            //} if (this.timeSetup.Text == "每1小时")
            //{
            //    timer.Interval = ONE_HOUR;
            //} 
        }
        public void timeOut(object source, System.Timers.ElapsedEventArgs e)
        {
            if (this.backupPath.Text.Length > 0)
            {
                string command = "mysqldump -uroot -pjilichao --default-character-set=utf8 --opt --extended-insert=false --quick --triggers -R --hex-blob vtms > \"" + this.backupPath.Text + "\"\\vtms.sql";

                StartCmd(homePath, command);
            }
        }
        /// <summary>
        /// 备份按钮点击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backupBtn_Click(object sender, EventArgs e)
        {
            if (this.backupPath.Text.Length > 0)
            {
                string command = "mysqldump -uroot -pjilichao --default-character-set=utf8 --opt --extended-insert=false --quick --triggers -R --hex-blob vtms > \"" + this.backupPath.Text + "\"\\vtms.sql";

                StartCmd(homePath, command);
            }
        }
    }
}
