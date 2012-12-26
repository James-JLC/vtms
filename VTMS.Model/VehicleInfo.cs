using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VTMS.Model
{
    public class VehicleInfo
    {
        public string Serial { get; set; }
        public string OriginId { get; set; }
        public byte[] OriginPic { get; set; }
        public string CurrentId { get; set; }
        public byte[] CurrentPic { get; set; }
        public string Invoice { get; set; }
        public string License { get; set; }
        public string Vin { get; set; }
        public string Category { get; set; }
        public string Engine { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Gross { get; set; }
        public string Mass { get; set; }
        public string Passengers { get; set; }
        public string Certificate { get; set; }
        public string Register { get; set; }
        public string Certification { get; set; }
        public string Displacement { get; set; }
        public string Actual { get; set; }
        public string Transactions { get; set; }
        public string Department { get; set; }
        public string Company { get; set; }
        public string Saver { get; set; }
        public DateTime Save_date { get; set; }
        public string Recorder { get; set; }
        public DateTime Record_date { get; set; }
        public bool Isrecorded { get; set; }
        public string Charger { get; set; }
        public DateTime Charge_date { get; set; }
        public bool Ischarged { get; set; }
        public string Prstringer { get; set; }
        public DateTime Prstring_date { get; set; }
        public bool Isprstringed { get; set; }
        public string Refunder { get; set; }
        public DateTime Refund_date { get; set; }
        public bool Isrefund { get; set; }
        public string Granter { get; set; }
        public DateTime Grant_date { get; set; }
        public bool Isgrant { get; set; }
        public byte[] Firstpic { get; set; }
        public byte[] Secondpic { get; set; }
        public byte[] Thirdpic { get; set; }
        public byte[] Forthpic { get; set; }
    }
}