﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using VTMS.Common;
using VTMS.Model.Entities;
using VTMS.Access;

namespace VTMS.Statistics
{
    public partial class VehicleReportForm : Office2007Form
    {
        #region 窗口初始化
        /// <summary>
        /// 窗口初始化
        /// </summary>
        public VehicleReportForm()
        {
            InitializeComponent();
            this.dataGridView.AutoGenerateColumns = false;
            this.startDate.Value = DateTime.Today;
            this.endDate.Value = DateTime.Today;
        }
        #endregion

        #region 统计按钮点击
        /// <summary>
        /// 根据输入日期开始统计
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void caculate_Click(object sender, EventArgs e)
        {
            this.dataGridView.DataSource = VehicleDao.CaculateVehicleReport(this.startDate.Value.Date.AddMilliseconds(-1), this.endDate.Value.Date.AddDays(1).AddMilliseconds(-1), this.brand.Text);
        }
        #endregion

        #region 生成行号
        /// <summary>
        /// 生成行号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            try
            {
                //添加行号 
                SolidBrush v_SolidBrush = new SolidBrush(dataGridView.RowHeadersDefaultCellStyle.ForeColor);

                int v_LineNo = e.RowIndex + 1;

                string v_Line = v_LineNo.ToString();

                e.Graphics.DrawString(v_Line, e.InheritedRowStyle.Font, v_SolidBrush, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + 5);

            }
            catch (Exception ex)
            {
                //MessageBox.Show("添加行号时发生错误，错误信息：" + ex.Message, "操作失败");
            }
        }
        #endregion

        #region 格式化表格输出
        /// <summary>
        /// 格式化输出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            Vehicle vehicle = dataGridView.Rows[e.RowIndex].DataBoundItem as Vehicle;
            if (dataGridView.Columns[e.ColumnIndex].Name == "VehicleType")
            {
                e.Value = vehicle.Vehicletype.Name;
            }
            else if (dataGridView.Columns[e.ColumnIndex].Name == "RegisterColumn")
            {
                e.Value = DateTime.ParseExact(vehicle.Register, "yyyyMM", System.Globalization.CultureInfo.CurrentCulture).ToString("yyyy年MM月");
            }
        }
        #endregion
    }
}
