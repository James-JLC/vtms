namespace VTMS
{
    partial class LoginForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.loginBtn = new DevComponents.DotNetBar.ButtonX();
            this.pwdCBox = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.cancelBtn = new DevComponents.DotNetBar.ButtonX();
            this.styleManager = new DevComponents.DotNetBar.StyleManager(this.components);
            this.userName = new VTMS.ControlLib.TextBoxExt();
            this.password = new VTMS.ControlLib.TextBoxExt();
            this.server = new VTMS.ControlLib.TextBoxExt();
            this.SuspendLayout();
            // 
            // labelX1
            // 
            this.labelX1.AutoSize = true;
            this.labelX1.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.Class = "";
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX1.Location = new System.Drawing.Point(55, 52);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(74, 26);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "用户名：";
            // 
            // labelX2
            // 
            this.labelX2.AutoSize = true;
            this.labelX2.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.Class = "";
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX2.Location = new System.Drawing.Point(55, 88);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(57, 26);
            this.labelX2.TabIndex = 2;
            this.labelX2.Text = "密码：";
            // 
            // labelX3
            // 
            this.labelX3.AutoSize = true;
            this.labelX3.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.Class = "";
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX3.Location = new System.Drawing.Point(55, 124);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(90, 26);
            this.labelX3.TabIndex = 5;
            this.labelX3.Text = "服务器IP：";
            // 
            // labelX4
            // 
            this.labelX4.AutoSize = true;
            this.labelX4.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.Class = "";
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelX4.Location = new System.Drawing.Point(-3, -3);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(375, 46);
            this.labelX4.TabIndex = 7;
            this.labelX4.Text = "车  辆  交  易  信  息  系  统";
            // 
            // loginBtn
            // 
            this.loginBtn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.loginBtn.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.loginBtn.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.loginBtn.Location = new System.Drawing.Point(218, 190);
            this.loginBtn.Name = "loginBtn";
            this.loginBtn.Size = new System.Drawing.Size(75, 28);
            this.loginBtn.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.loginBtn.TabIndex = 8;
            this.loginBtn.TabStop = false;
            this.loginBtn.Text = "登录";
            this.loginBtn.Click += new System.EventHandler(this.loginBtn_Click);
            // 
            // pwdCBox
            // 
            this.pwdCBox.AutoSize = true;
            this.pwdCBox.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.pwdCBox.BackgroundStyle.Class = "";
            this.pwdCBox.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.pwdCBox.Location = new System.Drawing.Point(194, 158);
            this.pwdCBox.Name = "pwdCBox";
            this.pwdCBox.Size = new System.Drawing.Size(76, 18);
            this.pwdCBox.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.pwdCBox.TabIndex = 6;
            this.pwdCBox.Text = "记住密码";
            // 
            // cancelBtn
            // 
            this.cancelBtn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.cancelBtn.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cancelBtn.Location = new System.Drawing.Point(63, 190);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 28);
            this.cancelBtn.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cancelBtn.TabIndex = 9;
            this.cancelBtn.TabStop = false;
            this.cancelBtn.Text = "取消";
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // styleManager
            // 
            this.styleManager.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2007VistaGlass;
            this.styleManager.MetroColorParameters = new DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.White, System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(163)))), ((int)(((byte)(26))))));
            // 
            // userName
            // 
            // 
            // 
            // 
            this.userName.Border.Class = "TextBoxBorder";
            this.userName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.userName.Location = new System.Drawing.Point(169, 55);
            this.userName.Name = "userName";
            this.userName.Size = new System.Drawing.Size(137, 21);
            this.userName.TabIndex = 1;
            // 
            // password
            // 
            // 
            // 
            // 
            this.password.Border.Class = "TextBoxBorder";
            this.password.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.password.Location = new System.Drawing.Point(170, 91);
            this.password.Name = "password";
            this.password.PasswordChar = '*';
            this.password.Size = new System.Drawing.Size(137, 21);
            this.password.TabIndex = 2;
            // 
            // server
            // 
            // 
            // 
            // 
            this.server.Border.Class = "TextBoxBorder";
            this.server.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.server.Location = new System.Drawing.Point(170, 127);
            this.server.Name = "server";
            this.server.Size = new System.Drawing.Size(137, 21);
            this.server.TabIndex = 3;
            // 
            // LoginForm
            // 
            this.AcceptButton = this.loginBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::VTMS.Properties.Resources.loginBack;
            this.CancelButton = this.cancelBtn;
            this.ClientSize = new System.Drawing.Size(374, 234);
            this.Controls.Add(this.server);
            this.Controls.Add(this.password);
            this.Controls.Add(this.userName);
            this.Controls.Add(this.pwdCBox);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.loginBtn);
            this.Controls.Add(this.labelX4);
            this.Controls.Add(this.labelX3);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.labelX1);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(390, 272);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(390, 272);
            this.Name = "LoginForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "欢迎使用本系统";
            this.TitleText = "<b>欢迎使用本系统</b>";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LoginForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.ButtonX loginBtn;
        private DevComponents.DotNetBar.Controls.CheckBoxX pwdCBox;
        private DevComponents.DotNetBar.ButtonX cancelBtn;
        private DevComponents.DotNetBar.StyleManager styleManager;
        private ControlLib.TextBoxExt userName;
        private ControlLib.TextBoxExt password;
        private ControlLib.TextBoxExt server;
    }
}