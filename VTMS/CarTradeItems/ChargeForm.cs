using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using VTMS.Access;
using VTMS.Model.Entities;
using VTMS.Common;
namespace VTMS.CarTradeItems
{
    public partial class ChargeForm : BaseForm
    {
        #region 窗口初始化事件
        /// <summary>
        /// 窗口初始化事件，初始化时启动摄像头
        /// </summary>
        public ChargeForm()
        {
            InitializeComponent();
        }
        #endregion

        protected override void SetVehicleInfo(Vehicle vehicle)
        {
            base.SetVehicleInfo(vehicle);
            if (vehicle.Ischarged)
            {
                base.FunctionBtn.Text = "退费";
            }
            else
            {
                base.FunctionBtn.Text = "缴费";
            }
            base.FunctionBtn.Enabled = true;
        }
        public override Vehicle GetVehicleInfo()
        {
            if (base.FunctionBtn.Text == "缴费")
            {
                vehicle.Ischarged = true;
                vehicle.Isrefund = false;
                vehicle.ChargeDate = DateTime.ParseExact(VehicleDao.GetCurrentDate(), "yyyyMMdd", System.Globalization.CultureInfo.CurrentCulture);
                vehicle.Charger = LoginForm.user.UsersId;
                return base.GetVehicleInfo();
            }
            else
            {
                vehicle.Isrefund = true;
                vehicle.Ischarged = false;
                vehicle.RefundDate = DateTime.ParseExact(VehicleDao.GetCurrentDate(), "yyyyMMdd", System.Globalization.CultureInfo.CurrentCulture);
                vehicle.Refunder = LoginForm.user.UsersId;
                return base.GetVehicleInfo();
            }
        }
    }
}