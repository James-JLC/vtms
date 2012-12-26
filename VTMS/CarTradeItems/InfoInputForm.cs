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
using System.IO;
using AForge.Video;
using AForge.Video.DirectShow;
using VTMS.Access;
using VTMS.Model;
using VTMS.Common;
using VTMS.ControlLib;
namespace VTMS
{
    public partial class InfoInputForm : Office2007Form
    {
        #region 初始化参数
        /// <summary>
        /// 买卖双方头像
        /// </summary>
        private Bitmap videoImage;
        /// <summary>
        /// 是否为新记录
        /// </summary>
        private bool isUpdate;
        #endregion

        #region 窗口初始化事件
        /// <summary>
        /// 窗口初始化事件，初始化时启动摄像头
        /// </summary>
        public InfoInputForm()
        {
            InitializeComponent();
        }
        private void InfoInputForm_Load(object sender, EventArgs e)
        {
            this.StartVideo();
            this.setControlReadOnly(true);
        }
        public void InitComboBox()
        {
            if (Vehicles.GetVehicleType() != null)
            {
                this.vehicleType.DataSource = Vehicles.GetVehicleType().Tables[0];
                this.vehicleType.DisplayMember = "name";
                this.vehicleType.ValueMember = "id";
            }
            if (Vehicles.GetCompany() != null)
            {
                this.company.DataSource = Vehicles.GetCompany().Tables[0];
                this.company.DisplayMember = "name";
                this.company.ValueMember = "id";
            }
        }
        #endregion

        #region 重置控件内容
        private void resetControlContent()
        {
            this.originId.Text = string.Empty;
            this.originName.Text = string.Empty;
            this.originPhone.Text = string.Empty;
            this.originAddress.Text = string.Empty;
            this.originPic.Image = global::VTMS.Properties.Resources.NoneImage;

            this.currentId.Text = string.Empty;
            this.currentName.Text = string.Empty;
            this.currentPhone.Text = string.Empty;
            this.currentAddress.Text = string.Empty;
            this.currentPic.Image = global::VTMS.Properties.Resources.NoneImage;

            this.serial.Text = string.Empty;
            this.invoice.Text = string.Empty;
            this.license.Text = string.Empty;
            this.vin.Text = string.Empty;
            this.vehicleType.SelectedValue = "00";
            this.brand.Text = string.Empty;
            this.certificate.Text = string.Empty;
            this.register.Text = string.Empty;
            this.certification.Text = string.Empty;
            this.actual.Text = string.Empty;
            this.transactions.Text = string.Empty;
            this.department.Text = string.Empty;
            this.company.SelectedValue = "00";
            this.pictureBox1.Image = null;
            this.pictureBox2.Image = null;
            this.pictureBox3.Image = null;
            this.pictureBox4.Image = null;
        }
        #endregion

        #region 设置控件可读状态
        /// <summary>
        /// 窗口初始化时，除了流水号之外所有控件均为只读
        /// </summary>
        /// <param name="isEnable"></param>
        private void setControlReadOnly(bool isEnable)
        {
            this.serial.ReadOnly = !isEnable;

            this.originId.ReadOnly = isEnable;
            this.originName.ReadOnly = isEnable;
            this.originPhone.ReadOnly = isEnable;
            this.originAddress.ReadOnly = isEnable;
            this.originPicBtn.Enabled = !isEnable;

            this.currentId.ReadOnly = isEnable;
            this.currentName.ReadOnly = isEnable;
            this.currentPhone.ReadOnly = isEnable;
            this.currentAddress.ReadOnly = isEnable;
            this.currentPicBtn.Enabled = !isEnable;

            this.invoice.ReadOnly = isEnable;
            this.license.ReadOnly = isEnable;
            this.vin.ReadOnly = isEnable;
            this.vehicleType.Enabled = !isEnable;
            this.brand.ReadOnly = isEnable;
            this.certificate.ReadOnly = isEnable;
            this.register.ReadOnly = isEnable;
            this.certification.ReadOnly = isEnable;
            this.actual.ReadOnly = isEnable;
            this.transactions.ReadOnly = isEnable;
            this.department.ReadOnly = isEnable;
            this.company.Enabled = !isEnable;
            this.searchBtn.Enabled = !isEnable;
            this.copyBtn.Enabled = !isEnable;
            this.saveBtn.Enabled = !isEnable;
            this.printBtn.Enabled = !isEnable;
        }
        #endregion

        #region 将数据库中的信息呈现到界面上
        /// <summary>
        /// 设置卖主信息
        /// </summary>
        /// <param name="originCustomer"></param>
        public void SetOriginCustomer(CustomerInfo originCustomer)
        {
            this.originId.Text = originCustomer.Id;
            this.originName.Text = originCustomer.Name;
            this.originPhone.Text = originCustomer.Phone;
            this.originAddress.Text = originCustomer.Address;
        }
        /// <summary>
        /// 设置买主信息
        /// </summary>
        /// <param name="currentCustomer"></param>
        public void SetCurrentCustomer(CustomerInfo currentCustomer)
        {
            this.currentId.Text = currentCustomer.Id;
            this.currentName.Text = currentCustomer.Name;
            this.currentPhone.Text = currentCustomer.Phone;
            this.currentAddress.Text = currentCustomer.Address;
        }
        /// <summary>
        /// 设置车辆信息
        /// </summary>
        /// <param name="vehicleInfo"></param>
        public void SetVehicleInfo(VehicleInfo vehicleInfo)
        {
            this.originId.Text = vehicleInfo.OriginId;
            if(vehicleInfo.OriginPic != null)
                this.originPic.Image = Utilities.ConvertBytes2Image(vehicleInfo.OriginPic);
            this.currentId.Text = vehicleInfo.CurrentId;
            if (vehicleInfo.CurrentPic != null)
                this.currentPic.Image = Utilities.ConvertBytes2Image(vehicleInfo.CurrentPic);
            this.invoice.Text = vehicleInfo.Invoice;
            this.license.Text = vehicleInfo.License;
            this.vin.Text = vehicleInfo.Vin;
            this.vehicleType.SelectedValue = vehicleInfo.Category;
            this.brand.Text = vehicleInfo.Brand;
            this.certificate.Text = vehicleInfo.Certificate;
            this.register.Text = vehicleInfo.Register;
            this.certification.Text = vehicleInfo.Certification;
            this.actual.Text = vehicleInfo.Actual;
            this.transactions.Text = vehicleInfo.Transactions;
            this.department.Text = vehicleInfo.Department;
            if(vehicleInfo.Company != null)
                this.company.SelectedValue = vehicleInfo.Company;
            this.Isrecorded.Checked = vehicleInfo.Isrecorded;
            this.Ischarged.Checked = vehicleInfo.Ischarged;
            this.Isprstringed.Checked = vehicleInfo.Isprstringed;
            this.Isrefund.Checked = vehicleInfo.Isrefund;
            this.Isgrant.Checked = vehicleInfo.Isgrant;
            if (vehicleInfo.Firstpic != null)
                this.pictureBox1.Image = Utilities.ConvertBytes2Image(vehicleInfo.Firstpic);
            if (vehicleInfo.Secondpic != null)
                this.pictureBox2.Image = Utilities.ConvertBytes2Image(vehicleInfo.Secondpic);
            if (vehicleInfo.Thirdpic != null)
                this.pictureBox3.Image = Utilities.ConvertBytes2Image(vehicleInfo.Thirdpic);
            if (vehicleInfo.Forthpic != null)
                this.pictureBox4.Image = Utilities.ConvertBytes2Image(vehicleInfo.Forthpic);
        }
        #endregion

        #region 将界面上的信息保存在数据库中
        /// <summary>
        /// 取得卖主信息
        /// </summary>
        /// <returns></returns>
        public CustomerInfo GetOriginCustomer()
        {
            CustomerInfo originCustomer = new CustomerInfo();
            originCustomer.Id = this.originId.Text;
            originCustomer.Name = this.originName.Text;
            originCustomer.Phone = this.originPhone.Text;
            originCustomer.Address = this.originAddress.Text;

            return originCustomer;
        }
        /// <summary>
        /// 取得买主信息
        /// </summary>
        /// <returns></returns>
        public CustomerInfo GetCurrentCustomer()
        {
            CustomerInfo currentCustomer = new CustomerInfo();
            currentCustomer.Id = this.currentId.Text;
            currentCustomer.Name = this.currentName.Text;
            currentCustomer.Phone = this.currentPhone.Text;
            currentCustomer.Address = this.currentAddress.Text;

            return currentCustomer;
        }
        /// <summary>
        /// 取得车辆信息
        /// </summary>
        /// <returns></returns>
        public VehicleInfo GetVehicleInfo()
        {
            VehicleInfo vehicleInfo = new VehicleInfo();
            vehicleInfo.Serial = this.serial.Text;
            vehicleInfo.OriginId = this.originId.Text;
            vehicleInfo.CurrentId = this.currentId.Text;
            vehicleInfo.Invoice = this.invoice.Text;
            vehicleInfo.License = this.license.Text;
            vehicleInfo.Vin = this.vin.Text;
            vehicleInfo.Category = this.vehicleType.SelectedValue.ToString();
            vehicleInfo.Brand = this.brand.Text;
            vehicleInfo.Certificate = this.certificate.Text;
            vehicleInfo.Register = this.register.Text;
            vehicleInfo.Certification = this.certification.Text;
            vehicleInfo.Actual = this.actual.Text;
            vehicleInfo.Transactions = this.transactions.Text;
            vehicleInfo.Department = this.department.Text;
            vehicleInfo.Company = this.company.SelectedValue.ToString();
            
            vehicleInfo.OriginPic = Utilities.ConvertImage2Bytes(this.originPic.Image);
            vehicleInfo.CurrentPic = Utilities.ConvertImage2Bytes(this.currentPic.Image);

            vehicleInfo.Firstpic = Utilities.ConvertImage2Bytes(this.pictureBox1.Image);
            vehicleInfo.Secondpic = Utilities.ConvertImage2Bytes(this.pictureBox2.Image);
            vehicleInfo.Thirdpic = Utilities.ConvertImage2Bytes(this.pictureBox3.Image);
            vehicleInfo.Forthpic = Utilities.ConvertImage2Bytes(this.pictureBox4.Image);

            vehicleInfo.Saver = "admin";

            return vehicleInfo;
        }
        #endregion

        #region 摄像头代码
        /// <summary>
        /// 摄像头启动
        /// </summary>
        public void StartVideo()
        {
            FilterInfoCollection videoDevices;
            VideoCaptureDevice videoSource = null;
            try
            {
                // enumerate video devices
                videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);

                if (videoDevices.Count > 0)
                {
                    for (int i = 0; i < videoDevices.Count; i++)
                    {
                        if (videoDevices[i].Name != "NewImage DocCam")
                        {
                            videoSource = new VideoCaptureDevice(videoDevices[i].MonikerString);
                            videoSource.DesiredFrameRate = 30;

                            videoSourcePlayer.VideoSource = videoSource;
                            videoSourcePlayer.Start();

                            break;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        /// <summary>
        /// 关闭时停止摄像头
        /// </summary>
        /// <param name="e"></param>
        protected override void OnClosing(CancelEventArgs e)
        {
            if (videoSourcePlayer.VideoSource != null)
            {
                videoSourcePlayer.SignalToStop();
                videoSourcePlayer.WaitForStop();
            }
            base.OnClosing(e);
        }
        ///// <summary>
        ///// 获取图像，以便拍照时抓取
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="image"></param>
        //private void videoSourcePlayer_NewFrame(object sender, ref Bitmap image)
        //{
        //    videoImage = (Bitmap)image.Clone();
        //}
        /// <summary>
        /// 抓取卖主头像
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void originPicBtn_Click(object sender, EventArgs e)
        {
            originPic.Image = videoSourcePlayer.GetCurrentVideoFrame();
        }
        /// <summary>
        /// 抓取卖主头像
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void currentPicBtn_Click(object sender, EventArgs e)
        {
            currentPic.Image = videoSourcePlayer.GetCurrentVideoFrame();
        }
        #endregion

        #region 回车后跳到下一控件
        /// <summary>
        /// 回车转TAB
        /// </summary>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessDialogKey(Keys keyData)
        {

            if (keyData == Keys.Enter && !(this.ActiveControl is Button))
            {

                return base.ProcessDialogKey(Keys.Tab);

            }

            return base.ProcessDialogKey(keyData);

        } 
        #endregion

        #region 流水号焦点离开事件
        /// <summary>
        /// 流水号失去焦点后，如果用户输入了流水号，则根据输入的流水号进行查找，否则生成流水号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void serial_Leave(object sender, EventArgs e)
        {
            if (this.serial.ReadOnly || this.serial.Text.Length != 11)
                return;
            InitComboBox();
            if (Utilities.IsNullOrEmpty(this.serial.Text))
            {
                this.serial.Text = Vehicles.GetLatestSerial().Serial;
                this.setControlReadOnly(false);
                this.isUpdate = false;
            }
            else
            {
                VehicleInfo vehicleInfo = new VehicleInfo();
                vehicleInfo.Serial = this.serial.Text;

                if (Vehicles.GetVehicleInfoBySerail(vehicleInfo))
                {
                    this.isUpdate = true;
                    SetVehicleInfo(vehicleInfo);

                    CustomerInfo originInfo = new CustomerInfo();
                    originInfo.Id = vehicleInfo.OriginId;
                    if (Customers.GetCustomerInfoById(originInfo))
                    {
                        this.SetOriginCustomer(originInfo);
                    }

                    CustomerInfo currentInfo = new CustomerInfo();
                    currentInfo.Id = vehicleInfo.CurrentId;
                    if (Customers.GetCustomerInfoById(currentInfo))
                    {
                        this.SetCurrentCustomer(currentInfo);
                    }

                    this.setControlReadOnly(false);
                }
                else
                {
                    this.serial.Focus();
                }
            }
        }
        #endregion

        #region 根据客户号码信息设置控件内容
        /// <summary>
        /// 根据证件号码取得卖主信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void originId_Leave(object sender, EventArgs e)
        {
            if(Utilities.IsNullOrEmpty(this.originId.Text) || !Utilities.IsNullOrEmpty(this.originName.Text))
                return;
            CustomerInfo originInfo = new CustomerInfo();
            originInfo.Id = this.originId.Text;
            Customers.GetCustomerInfoById(originInfo);
            SetOriginCustomer(originInfo);
        }
        /// <summary>
        /// 根据证件号码取得买主信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void currentId_Leave(object sender, EventArgs e)
        {
            if (Utilities.IsNullOrEmpty(this.currentId.Text) || !Utilities.IsNullOrEmpty(this.currentName.Text))
                return;
            CustomerInfo currentInfo = new CustomerInfo();
            currentInfo.Id = this.currentId.Text;
            Customers.GetCustomerInfoById(currentInfo);
            SetCurrentCustomer(currentInfo);
        }
        #endregion
        
        #region 检索按钮点击事件
        /// <summary>
        /// 检索按钮点击时检索保存过的车辆信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void searchBtn_Click(object sender, EventArgs e)
        {
            MessageUtil.ShowTips("本版本暂未开通此功能，请购买正式版本！");
        }
        #endregion

        #region 清空按钮点击事件
        /// <summary>
        /// 点击清除按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clearBtn_Click(object sender, EventArgs e)
        {
            this.resetControlContent();
            this.setControlReadOnly(true);
            this.serial.Focus();
            //ValidatorManager.degistControls();
        }
        #endregion

        #region 复制按钮点击事件
        /// <summary>
        /// 点击复制按钮时，取得最新流水号，并置控件为可编辑状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void copyBtn_Click(object sender, EventArgs e)
        {
            this.serial.Text = Vehicles.GetLatestSerial().Serial;
            this.setControlReadOnly(false);
            this.originPic.Image = global::VTMS.Properties.Resources.NoneImage;
            this.currentPic.Image = global::VTMS.Properties.Resources.NoneImage;
            this.invoice.Focus();
            this.isUpdate = false;
        }
        #endregion

        #region 保存按钮点击事件
        /// <summary>
        /// 保存按钮点击，将数据保存至数据库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren(ValidationConstraints.Enabled & ValidationConstraints.TabStop & ValidationConstraints.Selectable))
            {
                MessageBox.Show("控件内容不合法");
                return;
            }
            CustomerInfo originInfo = GetOriginCustomer();
            CustomerInfo currentInfo = GetCurrentCustomer();
            VehicleInfo vehicleInfo = GetVehicleInfo();
            if (this.isUpdate)
            {
                try
                {
                    Customers.UpdateCustomerInfoById(originInfo);
                    Customers.UpdateCustomerInfoById(currentInfo);
                    Vehicles.UpdateVehicleInfoBySerial(vehicleInfo);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
            else
            {
                try
                {
                    Customers.AddCustomerInfo(originInfo);
                    Customers.AddCustomerInfo(currentInfo);
                    Vehicles.AddVehicleInfo(vehicleInfo);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }

            this.resetControlContent();
            this.setControlReadOnly(true);
            this.serial.Focus();
        }
        #endregion

        #region 打印按钮点击事件
        /// <summary>
        /// 打印交易票
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void printBtn_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren(ValidationConstraints.Enabled & ValidationConstraints.TabStop & ValidationConstraints.Selectable))
            {
                MessageBox.Show("控件内容不合法");
                return;
            }
            
            Object oMissing = System.Reflection.Missing.Value;

            Microsoft.Office.Interop.Excel.Application m_objExcel = null;

            Microsoft.Office.Interop.Excel._Workbook m_objBook = null;

            Microsoft.Office.Interop.Excel.Sheets m_objSheets = null;

            Microsoft.Office.Interop.Excel._Worksheet m_objSheet = null;

            Microsoft.Office.Interop.Excel.Range m_objRange = null;

            try
            {

                m_objExcel = new Microsoft.Office.Interop.Excel.Application();

                DirectoryInfo Dir = new DirectoryInfo(".");

                m_objBook = m_objExcel.Workbooks.Open(Dir.FullName + "\\input.xls", oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing);

                m_objSheets = (Microsoft.Office.Interop.Excel.Sheets)m_objBook.Worksheets;

                m_objSheet = (Microsoft.Office.Interop.Excel._Worksheet)(m_objSheets.get_Item(1));

                // 开票日期
                m_objRange = m_objSheet.get_Range("B1", oMissing);

                m_objRange.Value = VTMSSystem.GetCurrentDate();

                // 买 方 单 位 /个人
                m_objRange = m_objSheet.get_Range("C5", oMissing);

                m_objRange.Value = this.currentName.Text;

                // 单位代码/身份证号码

                m_objRange = m_objSheet.get_Range("K5", oMissing);

                m_objRange.Value = this.currentId.Text;

                // 买方单位/个人住址
                m_objRange = m_objSheet.get_Range("C6", oMissing);

                m_objRange.Value = this.currentAddress.Text;

                // 电话
                m_objRange = m_objSheet.get_Range("L6", oMissing);

                m_objRange.Value = this.currentPhone.Text;

                // 卖 方 单 位/ 个人

                m_objRange = m_objSheet.get_Range("C7", oMissing);

                m_objRange.Value = this.originName.Text;

                // 单位代码/身份证号码
                m_objRange = m_objSheet.get_Range("K7", oMissing);

                m_objRange.Value = this.originId.Text;

                // 卖方单位/个人住址
                m_objRange = m_objSheet.get_Range("C8", oMissing);

                m_objRange.Value = this.originAddress.Text;

                // 电话
                m_objRange = m_objSheet.get_Range("L8", oMissing);

                m_objRange.Value = this.originPhone.Text;

                // 车   牌   照   号
                m_objRange = m_objSheet.get_Range("C9", oMissing);

                m_objRange.Value = "辽B." + this.license.Text;

                // 登记证号
                m_objRange = m_objSheet.get_Range("E9", oMissing);

                m_objRange.Value = this.certificate.Text;

                // 车 辆 类 型
                m_objRange = m_objSheet.get_Range("L9", oMissing);

                m_objRange.Value = this.vehicleType.Text;

                // 车架号/车辆识别代码
                m_objRange = m_objSheet.get_Range("C10", oMissing);

                m_objRange.Value = this.vin.Text;

                // 厂牌型号
                m_objRange = m_objSheet.get_Range("E10", oMissing);

                m_objRange.Value = this.brand.Text;

                // 转入地车辆管理所名称
                m_objRange = m_objSheet.get_Range("L10", oMissing);

                m_objRange.Value = this.department.Text;

                // 车价 合 计（大写）
                m_objRange = m_objSheet.get_Range("C11", oMissing);

                m_objRange.Value = this.transactions.Text;

                // 车价 合 计（小写）
                m_objRange = m_objSheet.get_Range("L11", oMissing);

                m_objRange.Value = this.transactions.Text;

                m_objExcel.DisplayAlerts = false;
                m_objSheet.PrintOut();
            }

            catch (Exception ex)
            {
                MessageBox.Show("打印失败，请检查打印机设置。错误代码：" + ex.Message);
            }

            finally
            {
                if (m_objBook != null)
                {
                    m_objBook.Close(oMissing, oMissing, oMissing);

                    System.Runtime.InteropServices.Marshal.ReleaseComObject(m_objBook);
                }
                if (m_objExcel != null)
                {
                    m_objExcel.Workbooks.Close();
                    m_objExcel.Quit();
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(m_objExcel);
                }

                m_objBook = null;

                m_objExcel = null;

                GC.Collect();
            }
        }
        #endregion

        #region 上传按钮点击事件
        /// <summary>
        /// 证件附件上传按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uploadBtn_Click(object sender, EventArgs e)
        {
            switch ((sender as ButtonX).Name)
            {
                case "uploadBtn1":
                    showImage(pictureBox1);
                    break;
                case "uploadBtn2":
                    showImage(pictureBox2);
                    break;
                case "uploadBtn3":
                    showImage(pictureBox3);
                    break;
                case "uploadBtn4":
                    showImage(pictureBox4);
                    break;
            }
            
        }
        #endregion

        #region 删除按钮点击事件
        /// <summary>
        /// 证件附件删除按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deleteBtn_Click(object sender, EventArgs e)
        {
            switch ((sender as ButtonX).Name)
            {
                case "deleteBtn1":
                    this.pictureBox1.Image = null;
                    break;
                case "deleteBtn2":
                    this.pictureBox2.Image = null;
                    break;
                case "deleteBtn3":
                    this.pictureBox3.Image = null;
                    break;
                case "deleteBtn4":
                    this.pictureBox4.Image = null;
                    break;
            }
        }
        #endregion

        #region 双击附件时浏览图片
        /// <summary>
        /// 打开上传文件对话框，上传证件附件
        /// </summary>
        /// <returns></returns>
        private void showImage(PictureBox pb)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "图像文件(*.jpg;*.jpeg;*.gif;*.png)|*.jpg;*.jpeg;*.gif;*.png";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = File.Open(openFileDialog.FileName, FileMode.Open, FileAccess.Read);

                byte[] imageByte = new byte[fs.Length];
                fs.Read(imageByte, 0, imageByte.Length);

                fs.Dispose();
                fs.Close();

                pb.Image = Utilities.ConvertBytes2Image(imageByte);
            }
        }
        /// <summary>
        /// 预览证件附件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void view_Image(object sender, EventArgs e)
        {
            PictureBox pb = sender as PictureBox;

            //如果未上传证件附件
            if (pb.Image == null)
                return;
            //保存在本地
            FileStream fs = new FileStream("temp.jpg", FileMode.Create);
            byte[] image = Utilities.ConvertImage2Bytes(pb.Image);
            fs.Write(image, 0, image.Length);

            fs.Flush();
            fs.Close();
            //启动图片预览
            ProcessStartInfo psi = new ProcessStartInfo(@"temp.jpg");
            Process p = new Process();
            p.StartInfo = psi;
            p.Start();
        }
        #endregion

    }
}
