using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VTMS.Access;
using VTMS.Model.Entities;
using VTMS.Common;
namespace VTMS.CarTradeItems
{
    public delegate void Send(string info);
    public partial class SearchForm : Form
    {
        public event Send SendMessage;
        public SearchForm()
        {
            InitializeComponent();
            this.dataGridView.AutoGenerateColumns = false;
        }

        private void SearchForm_Load(object sender, EventArgs e)
        {
            this.dataGridView.DataSource = VehicleDao.GetFirst20Row();
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            if (Utilities.IsNullOrEmpty(this.serialSearch.Text) && Utilities.IsNullOrEmpty(this.customerId.Text) && Utilities.IsNullOrEmpty(this.license.Text))
            {
                this.dataGridView.DataSource = VehicleDao.GetFirst20Row();
                return;
            }
            this.dataGridView.DataSource = VehicleDao.SearchResult(this.serialSearch.Text, this.customerId.Text, this.license.Text);
        }

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

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
                return;
            if (dataGridView.Columns[e.ColumnIndex].Name == "SerialColumn")
            {
                SendMessage(dataGridView.Rows[e.RowIndex].Cells["SerialColumn"].Value.ToString());
                this.Close();
            }
        }

        private void dataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
                Vehicle vehicle = dataGridView.Rows[e.RowIndex].DataBoundItem as Vehicle;
                try
                {
                    if (dataGridView.Columns[e.ColumnIndex].Name == "OriginId")
                    {
                        e.Value = vehicle.OriginCustomer.Id;
                    }
                    else if (dataGridView.Columns[e.ColumnIndex].Name == "OriginName")
                    {
                        e.Value = vehicle.OriginCustomer.Name;
                    }
                    else if (dataGridView.Columns[e.ColumnIndex].Name == "CurrentId")
                    {
                        e.Value = vehicle.CurrentCustomer.Id;
                    }
                    else if (dataGridView.Columns[e.ColumnIndex].Name == "CurrentName")
                    {
                        e.Value = vehicle.CurrentCustomer.Name;
                    }
                    else if (dataGridView.Columns[e.ColumnIndex].Name == "VehicleType")
                    {
                        e.Value = vehicle.Vehicletype.Name;
                    }
                }
                catch
                {
                    MessageUtil.ShowTips("错误" + vehicle.Serial);
                }
        }
    }
}
