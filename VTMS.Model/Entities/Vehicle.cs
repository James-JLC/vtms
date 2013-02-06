using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VTMS.Model.Entities
{
    public class Vehicle
    {
        #region Private Members

        // Primary Key(s) 
        private string serial;

        // Properties 
        private Customer originCustomer;
        private byte[] originpic;
        private Customer currentCustomer;
        private byte[] currentpic;
        private string invoice;
        private string license;
        private string vin;
        private Vehicletype vehicletype;
        private string brand;
        private string certificate;
        private string register;
        private string certification;
        private string actual;
        private string transactions;
        private string department;
        private Company company;
        private string saver;
        private DateTime savedate;
        private string recorder;
        private DateTime recorddate;
        private bool isrecorded;
        private string charger;
        private DateTime chargedate;
        private bool ischarged;
        private string printer;
        private DateTime printdate;
        private bool isprinted;
        private string refunder;
        private DateTime refunddate;
        private bool isrefund;
        private string granter;
        private DateTime grantdate;
        private bool isgrant;
        private byte[] firstpic;
        private byte[] secondpic;
        private byte[] thirdpic;
        private byte[] forthpic;

        #endregion

        #region Public Properties

        /// <summary>
        /// 
        /// </summary>		
        public virtual string Serial
        {
            get { return serial; }
            set
            {
                serial = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>		
        public virtual Customer OriginCustomer
        {
            get { return originCustomer; }
            set
            {
                originCustomer = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>		
        public virtual byte[] Originpic
        {
            get { return originpic; }
            set
            {
                originpic = value;
            }

        }

        /// <summary>
        /// 
        /// </summary>		
        public virtual Customer CurrentCustomer
        {
            get { return currentCustomer; }
            set
            {
                currentCustomer = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>		
        public virtual byte[] Currentpic
        {
            get { return currentpic; }
            set
            {
                currentpic = value;
            }

        }

        /// <summary>
        /// 
        /// </summary>		
        public virtual string Invoice
        {
            get { return invoice; }
            set
            {
                invoice = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>		
        public virtual string License
        {
            get { return license; }
            set
            {
                license = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>		
        public virtual string Vin
        {
            get { return vin; }
            set
            {
                vin = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>		
        public virtual Vehicletype Vehicletype
        {
            get { return vehicletype; }
            set
            {
                vehicletype = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>		
        public virtual string Brand
        {
            get { return brand; }
            set
            {
                brand = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>		
        public virtual string Certificate
        {
            get { return certificate; }
            set
            {
                certificate = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>		
        public virtual string Register
        {
            get { return register; }
            set
            {
                register = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>		
        public virtual string Certification
        {
            get { return certification; }
            set
            {
                certification = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>		
        public virtual string Actual
        {
            get { return actual; }
            set { actual = value; }
        }

        /// <summary>
        /// 
        /// </summary>		
        public virtual string Transactions
        {
            get { return transactions; }
            set { transactions = value; }
        }

        /// <summary>
        /// 
        /// </summary>		
        public virtual string Department
        {
            get { return department; }
            set
            {
                department = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>		
        public virtual Company Company
        {
            get { return company; }
            set
            {
                company = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>		
        public virtual string Saver
        {
            get { return saver; }
            set
            {
                saver = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>		
        public virtual DateTime SaveDate
        {
            get { return savedate; }
            set { savedate = value; }
        }

        /// <summary>
        /// 
        /// </summary>		
        public virtual string Recorder
        {
            get { return recorder; }
            set
            {
                recorder = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>		
        public virtual DateTime RecordDate
        {
            get { return recorddate; }
            set { recorddate = value; }
        }

        /// <summary>
        /// 
        /// </summary>		
        public virtual bool Isrecorded
        {
            get { return isrecorded; }
            set { isrecorded = value; }
        }

        /// <summary>
        /// 
        /// </summary>		
        public virtual string Charger
        {
            get { return charger; }
            set
            {
                charger = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>		
        public virtual DateTime ChargeDate
        {
            get { return chargedate; }
            set { chargedate = value; }
        }

        /// <summary>
        /// 
        /// </summary>		
        public virtual bool Ischarged
        {
            get { return ischarged; }
            set { ischarged = value; }
        }

        /// <summary>
        /// 
        /// </summary>		
        public virtual string Printer
        {
            get { return printer; }
            set
            {
                printer = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>		
        public virtual DateTime PrintDate
        {
            get { return printdate; }
            set { printdate = value; }
        }

        /// <summary>
        /// 
        /// </summary>		
        public virtual bool Isprinted
        {
            get { return isprinted; }
            set { isprinted = value; }
        }

        /// <summary>
        /// 
        /// </summary>		
        public virtual string Refunder
        {
            get { return refunder; }
            set
            {
                refunder = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>		
        public virtual DateTime RefundDate
        {
            get { return refunddate; }
            set { refunddate = value; }
        }

        /// <summary>
        /// 
        /// </summary>		
        public virtual bool Isrefund
        {
            get { return isrefund; }
            set { isrefund = value; }
        }

        /// <summary>
        /// 
        /// </summary>		
        public virtual string Granter
        {
            get { return granter; }
            set
            {
                granter = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>		
        public virtual DateTime GrantDate
        {
            get { return grantdate; }
            set { grantdate = value; }
        }

        /// <summary>
        /// 
        /// </summary>		
        public virtual bool Isgrant
        {
            get { return isgrant; }
            set { isgrant = value; }
        }

        /// <summary>
        /// 
        /// </summary>		
        public virtual byte[] Firstpic
        {
            get { return firstpic; }
            set
            {
                firstpic = value;
            }

        }

        /// <summary>
        /// 
        /// </summary>		
        public virtual byte[] Secondpic
        {
            get { return secondpic; }
            set
            {
                secondpic = value;
            }

        }

        /// <summary>
        /// 
        /// </summary>		
        public virtual byte[] Thirdpic
        {
            get { return thirdpic; }
            set
            {
                thirdpic = value;
            }

        }

        /// <summary>
        /// 
        /// </summary>		
        public virtual byte[] Forthpic
        {
            get { return forthpic; }
            set
            {
                forthpic = value;
            }

        }
        #endregion
    }
}