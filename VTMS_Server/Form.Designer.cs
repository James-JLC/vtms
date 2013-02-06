namespace VTMS_Server
{
    partial class Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form));
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.backupBtn = new DevComponents.DotNetBar.ButtonX();
            this.backupPath = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.timeSetup = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.restoreBtn = new DevComponents.DotNetBar.ButtonX();
            this.confirmBtn = new DevComponents.DotNetBar.ButtonX();
            this.restorePath = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.SuspendLayout();
            // 
            // notifyIcon
            // 
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "notifyIcon1";
            this.notifyIcon.DoubleClick += new System.EventHandler(this.notifyIcon_DoubleClick);
            // 
            // backupBtn
            // 
            this.backupBtn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.backupBtn.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.backupBtn.Location = new System.Drawing.Point(419, 62);
            this.backupBtn.Name = "backupBtn";
            this.backupBtn.Size = new System.Drawing.Size(75, 23);
            this.backupBtn.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.backupBtn.TabIndex = 10;
            this.backupBtn.Text = "立即备份";
            this.backupBtn.Click += new System.EventHandler(this.backupBtn_Click);
            // 
            // backupPath
            // 
            this.backupPath.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.backupPath.Border.Class = "TextBoxBorder";
            this.backupPath.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.backupPath.Location = new System.Drawing.Point(86, 64);
            this.backupPath.Name = "backupPath";
            this.backupPath.ReadOnly = true;
            this.backupPath.Size = new System.Drawing.Size(308, 21);
            this.backupPath.TabIndex = 9;
            this.backupPath.Click += new System.EventHandler(this.backupPath_Click);
            // 
            // timeSetup
            // 
            this.timeSetup.DisplayMember = "Text";
            this.timeSetup.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.timeSetup.FormattingEnabled = true;
            this.timeSetup.ItemHeight = 15;
            this.timeSetup.Location = new System.Drawing.Point(86, 21);
            this.timeSetup.Name = "timeSetup";
            this.timeSetup.Size = new System.Drawing.Size(121, 21);
            this.timeSetup.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.timeSetup.TabIndex = 8;
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
            this.labelX2.Location = new System.Drawing.Point(12, 67);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(68, 18);
            this.labelX2.TabIndex = 7;
            this.labelX2.Text = "备份目录：";
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
            this.labelX1.Location = new System.Drawing.Point(12, 24);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(68, 18);
            this.labelX1.TabIndex = 6;
            this.labelX1.Text = "备份频率：";
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
            this.labelX3.Location = new System.Drawing.Point(12, 134);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(68, 18);
            this.labelX3.TabIndex = 12;
            this.labelX3.Text = "恢复目录：";
            // 
            // restoreBtn
            // 
            this.restoreBtn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.restoreBtn.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.restoreBtn.Location = new System.Drawing.Point(419, 129);
            this.restoreBtn.Name = "restoreBtn";
            this.restoreBtn.Size = new System.Drawing.Size(75, 23);
            this.restoreBtn.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.restoreBtn.TabIndex = 14;
            this.restoreBtn.Text = "恢复";
            this.restoreBtn.Click += new System.EventHandler(this.restoreBtn_Click);
            // 
            // confirmBtn
            // 
            this.confirmBtn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.confirmBtn.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.confirmBtn.Location = new System.Drawing.Point(419, 12);
            this.confirmBtn.Name = "confirmBtn";
            this.confirmBtn.Size = new System.Drawing.Size(75, 23);
            this.confirmBtn.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.confirmBtn.TabIndex = 15;
            this.confirmBtn.Text = "应用";
            this.confirmBtn.Click += new System.EventHandler(this.confirmBtn_Click);
            // 
            // restorePath
            // 
            this.restorePath.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.restorePath.Border.Class = "TextBoxBorder";
            this.restorePath.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.restorePath.Location = new System.Drawing.Point(86, 129);
            this.restorePath.Name = "restorePath";
            this.restorePath.ReadOnly = true;
            this.restorePath.Size = new System.Drawing.Size(308, 21);
            this.restorePath.TabIndex = 16;
            this.restorePath.Click += new System.EventHandler(this.restorePath_Click);
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(507, 176);
            this.Controls.Add(this.restorePath);
            this.Controls.Add(this.confirmBtn);
            this.Controls.Add(this.restoreBtn);
            this.Controls.Add(this.labelX3);
            this.Controls.Add(this.backupBtn);
            this.Controls.Add(this.backupPath);
            this.Controls.Add(this.timeSetup);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.labelX1);
            this.DoubleBuffered = true;
            this.Name = "Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "服务端";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_FormClosing);
            this.SizeChanged += new System.EventHandler(this.Form_SizeChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon;
        private DevComponents.DotNetBar.ButtonX backupBtn;
        private DevComponents.DotNetBar.Controls.TextBoxX backupPath;
        private DevComponents.DotNetBar.Controls.ComboBoxEx timeSetup;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.ButtonX restoreBtn;
        private DevComponents.DotNetBar.ButtonX confirmBtn;
        private DevComponents.DotNetBar.Controls.TextBoxX restorePath;

    }
}

