namespace VTMS.Statistics
{
    partial class TradeDailyForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.SaveDateColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RegisterColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CompanyColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.caculate = new DevComponents.DotNetBar.ButtonX();
            this.dailyCondition = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.endDate = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.startDate = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.panelEx1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.endDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.startDate)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SaveDateColumn,
            this.Column1,
            this.RegisterColumn,
            this.Column5,
            this.CompanyColumn});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dataGridView.Location = new System.Drawing.Point(0, 44);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView.RowTemplate.Height = 23;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(1008, 568);
            this.dataGridView.TabIndex = 4;
            this.dataGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView_CellFormatting);
            this.dataGridView.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataGridView_RowPostPaint);
            // 
            // SaveDateColumn
            // 
            this.SaveDateColumn.DataPropertyName = "SaveDate";
            this.SaveDateColumn.HeaderText = "日期";
            this.SaveDateColumn.Name = "SaveDateColumn";
            this.SaveDateColumn.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "Serial";
            this.Column1.HeaderText = "流水号";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // RegisterColumn
            // 
            this.RegisterColumn.DataPropertyName = "License";
            this.RegisterColumn.FillWeight = 80F;
            this.RegisterColumn.HeaderText = "车牌号";
            this.RegisterColumn.Name = "RegisterColumn";
            this.RegisterColumn.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "Actual";
            this.Column5.HeaderText = "实收金额";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // CompanyColumn
            // 
            this.CompanyColumn.DataPropertyName = "Company";
            this.CompanyColumn.FillWeight = 120F;
            this.CompanyColumn.HeaderText = "经济公司";
            this.CompanyColumn.Name = "CompanyColumn";
            this.CompanyColumn.ReadOnly = true;
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.caculate);
            this.panelEx1.Controls.Add(this.dailyCondition);
            this.panelEx1.Controls.Add(this.labelX3);
            this.panelEx1.Controls.Add(this.endDate);
            this.panelEx1.Controls.Add(this.labelX2);
            this.panelEx1.Controls.Add(this.startDate);
            this.panelEx1.Controls.Add(this.labelX1);
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelEx1.Location = new System.Drawing.Point(0, 0);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(1008, 44);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 3;
            // 
            // caculate
            // 
            this.caculate.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.caculate.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.caculate.Location = new System.Drawing.Point(780, 11);
            this.caculate.Name = "caculate";
            this.caculate.Size = new System.Drawing.Size(75, 23);
            this.caculate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.caculate.TabIndex = 7;
            this.caculate.Text = "统计";
            this.caculate.Click += new System.EventHandler(this.caculate_Click);
            // 
            // dailyCondition
            // 
            this.dailyCondition.DisplayMember = "Text";
            this.dailyCondition.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.dailyCondition.FormattingEnabled = true;
            this.dailyCondition.ItemHeight = 15;
            this.dailyCondition.Location = new System.Drawing.Point(453, 12);
            this.dailyCondition.Name = "dailyCondition";
            this.dailyCondition.Size = new System.Drawing.Size(121, 21);
            this.dailyCondition.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dailyCondition.TabIndex = 6;
            // 
            // labelX3
            // 
            this.labelX3.AutoSize = true;
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.Class = "";
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(380, 13);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(68, 18);
            this.labelX3.TabIndex = 5;
            this.labelX3.Text = "统计内容：";
            // 
            // endDate
            // 
            this.endDate.AutoSelectDate = true;
            // 
            // 
            // 
            this.endDate.BackgroundStyle.Class = "DateTimeInputBackground";
            this.endDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.endDate.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.endDate.ButtonDropDown.Visible = true;
            this.endDate.CustomFormat = "yyyy/MM/dd";
            this.endDate.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            this.endDate.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.endDate.IsPopupCalendarOpen = false;
            this.endDate.Location = new System.Drawing.Point(221, 12);
            // 
            // 
            // 
            this.endDate.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.endDate.MonthCalendar.BackgroundStyle.Class = "";
            this.endDate.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.endDate.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.endDate.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.endDate.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.endDate.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.endDate.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.endDate.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.endDate.MonthCalendar.CommandsBackgroundStyle.Class = "";
            this.endDate.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.endDate.MonthCalendar.DisplayMonth = new System.DateTime(2013, 1, 1, 0, 0, 0, 0);
            this.endDate.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.endDate.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.endDate.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.endDate.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.endDate.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.endDate.MonthCalendar.NavigationBackgroundStyle.Class = "";
            this.endDate.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.endDate.MonthCalendar.TodayButtonVisible = true;
            this.endDate.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.endDate.Name = "endDate";
            this.endDate.Size = new System.Drawing.Size(114, 21);
            this.endDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.endDate.TabIndex = 4;
            this.endDate.Value = new System.DateTime(2013, 1, 25, 16, 41, 56, 0);
            // 
            // labelX2
            // 
            this.labelX2.AutoSize = true;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.Class = "";
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(196, 13);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(19, 18);
            this.labelX2.TabIndex = 3;
            this.labelX2.Text = "～";
            // 
            // startDate
            // 
            this.startDate.AutoSelectDate = true;
            // 
            // 
            // 
            this.startDate.BackgroundStyle.Class = "DateTimeInputBackground";
            this.startDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.startDate.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.startDate.ButtonDropDown.Visible = true;
            this.startDate.CustomFormat = "yyyy/MM/dd";
            this.startDate.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            this.startDate.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.startDate.IsPopupCalendarOpen = false;
            this.startDate.Location = new System.Drawing.Point(76, 12);
            // 
            // 
            // 
            this.startDate.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.startDate.MonthCalendar.BackgroundStyle.Class = "";
            this.startDate.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.startDate.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.startDate.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.startDate.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.startDate.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.startDate.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.startDate.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.startDate.MonthCalendar.CommandsBackgroundStyle.Class = "";
            this.startDate.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.startDate.MonthCalendar.DisplayMonth = new System.DateTime(2013, 1, 1, 0, 0, 0, 0);
            this.startDate.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.startDate.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.startDate.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.startDate.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.startDate.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.startDate.MonthCalendar.NavigationBackgroundStyle.Class = "";
            this.startDate.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.startDate.MonthCalendar.TodayButtonVisible = true;
            this.startDate.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.startDate.Name = "startDate";
            this.startDate.Size = new System.Drawing.Size(114, 21);
            this.startDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.startDate.TabIndex = 1;
            this.startDate.Value = new System.DateTime(2013, 1, 25, 16, 41, 30, 0);
            // 
            // labelX1
            // 
            this.labelX1.AutoSize = true;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.Class = "";
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(12, 13);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(68, 18);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "日期范围：";
            // 
            // TradeDailyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 612);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.panelEx1);
            this.Name = "TradeDailyForm";
            this.Text = "交易日统计";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.panelEx1.ResumeLayout(false);
            this.panelEx1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.endDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.startDate)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.DataGridViewX dataGridView;
        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.ButtonX caculate;
        private DevComponents.DotNetBar.Controls.ComboBoxEx dailyCondition;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput endDate;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput startDate;
        private DevComponents.DotNetBar.LabelX labelX1;
        private System.Windows.Forms.DataGridViewTextBoxColumn SaveDateColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn RegisterColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn CompanyColumn;
    }
}