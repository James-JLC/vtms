using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Cfg;
using VTMS.Model.Entities;
namespace VTMS.Access
{
    public class VehicleDao
    {
        public static string GetCurrentDate()
        {
            using (ISession session = SessionFactory.OpenSession())
            {
                string currentDate = session.CreateSQLQuery(
                            @"SELECT DATE_FORMAT(CURRENT_DATE,'%Y%m%d') FROM DUAL"
                            ).List()[0].ToString();
                return currentDate;
            }
        }
        public static string GetLatestSerial()
        {
            using (ISession session = SessionFactory.OpenSession())
            {
                string serial = session.CreateSQLQuery(
                            @"SELECT IF(NOT EXISTS(SELECT * FROM vtms.vehicle WHERE serial = CONCAT(DATE_FORMAT(CURRENT_DATE,'%Y%m%d'),'001')),
                            CONCAT(DATE_FORMAT(CURRENT_DATE,'%Y%m%d'),'001'),
                            (SELECT MAX(serial)+1 FROM vtms.vehicle)) as serial"
                            ).List()[0].ToString();
                return serial;
            }
        }

        public static object AddVehicle(Vehicle entity)
        {
            entity.Serial = GetLatestSerial();
            using (ISession session = SessionFactory.OpenSession())
            {
                var id = session.Save(entity);
                session.Flush();
                return id;
            }
        }

        public static void UpdateVehicle(Vehicle entity)
        {
            using (ISession session = SessionFactory.OpenSession())
            {
                session.Update(entity);
                session.Flush();
            }
        }

        public static void DeleteVehicle(Vehicle entity)
        {
            using (ISession session = SessionFactory.OpenSession())
            {
                session.Delete(entity);
                session.Flush();
            }
        }

        public static Vehicle GetBySerial(string id)
        {
            using (ISession session = SessionFactory.OpenSession())
            {
                return session.Get<Vehicle>(id);
            }
        }
        public static IList<Vehicle> GetFirst20Row()
        {
            System.Collections.ArrayList result = new System.Collections.ArrayList();
            
            using (ISession session = SessionFactory.OpenSession())
            {
                return session.CreateQuery("from Vehicle").SetMaxResults(20).List<Vehicle>();
            }
        }
        public static IList<Vehicle> SearchResult(string serial, string customer, string license)
        {
            using (ISession session = SessionFactory.OpenSession())
            {
                IQuery q = session.CreateQuery("from Vehicle where serial = :serial and (originid = :customer or currentid = :customer) and license = :license");
                q.SetParameter("serial", serial);
                q.SetParameter("customer", customer);
                q.SetParameter("license", license);
                return q.List<Vehicle>();
            }
        }
        public static IList<Vehicle> CaculateCompanyReport(DateTime startDate, DateTime endDate, string company)
        {
            using (ISession session = SessionFactory.OpenSession())
            {
                return session.QueryOver<Vehicle>().Where(m => m.SaveDate > startDate).And(m=> m.SaveDate < endDate).And(m=>m.Company.Id == company).OrderBy(c => c.Serial).Asc.List();
            }
        }
        public static IList<Vehicle> CaculateVehicleReport(DateTime startDate, DateTime endDate, string brand)
        {
            using (ISession session = SessionFactory.OpenSession())
            {
                IQuery q = session.CreateQuery("from Vehicle where SaveDate > :startDate and SaveDate < :endDate and brand like :brand");
                q.SetParameter("startDate", startDate);
                q.SetParameter("endDate", endDate);
                q.SetParameter("brand", "%"+brand+"%");
                return q.List<Vehicle>();
            }
        }
        public static IList<Vehicle> CaculateTradeDailyReport(DateTime startDate, DateTime endDate, string condition)
        {
            string sqlAll = "from Vehicle where SaveDate > :startDate and SaveDate < :endDate";
            string sqlPrinted = " and isprinted = true";
            string sqlCharged = " and ischarged = true";
            string sqlOrderby = " order by SaveDate";
            IQuery q = null;
            using (ISession session = SessionFactory.OpenSession())
            {
                if (condition.Equals("已出票"))
                {
                    q = session.CreateQuery(sqlAll + sqlPrinted + sqlOrderby);
                }
                else if (condition.Equals("已缴费"))
                {
                    q = session.CreateQuery(sqlAll + sqlCharged + sqlOrderby);
                }
                else
                {
                    q = session.CreateQuery(sqlAll + sqlOrderby);
                }
                q.SetParameter("startDate", startDate);
                q.SetParameter("endDate", endDate);
                return q.List<Vehicle>();
            }
        }
        public static System.Collections.IList CaculateTradeMonthReport(DateTime startDate, DateTime endDate)
        {
            string sql = "select DATE_FORMAT(Save_Date,'%Y年%m月%d日'), sum(Actual), count(*) from Vehicle where Save_Date > :startDate and Save_Date < :endDate group by DATE_FORMAT(Save_Date,'%Y年%m月%d日') order by DATE_FORMAT(Save_Date,'%Y年%m月%d日')";
            System.Collections.IList listVehicle = new System.Collections.ArrayList();
            IQuery q = null;

            using (ISession session = SessionFactory.OpenSession())
            {
                q = session.CreateSQLQuery(sql);
                q.SetParameter("startDate", startDate);
                q.SetParameter("endDate", endDate);
                System.Collections.IList tmp = q.List();
                foreach (object[] o in tmp)
                {
                    VirtualReport report = new VirtualReport();
                    report.SaveDate = o[0].ToString();
                    report.Money = o[1].ToString();
                    report.Count = int.Parse(o[2].ToString());
                    listVehicle.Add(report);
                }
                return listVehicle;
            }
        }
        public static System.Collections.IList CaculateTradeYearReport(DateTime startDate, DateTime endDate)
        {
            string sql = "select DATE_FORMAT(Save_Date,'%Y年%m月'), sum(Actual), count(*) from Vehicle where Save_Date > :startDate and Save_Date < :endDate group by DATE_FORMAT(Save_Date,'%Y年%m月') order by DATE_FORMAT(Save_Date,'%Y年%m月')";
            System.Collections.IList listVehicle = new System.Collections.ArrayList();
            IQuery q = null;

            using (ISession session = SessionFactory.OpenSession())
            {
                q = session.CreateSQLQuery(sql);
                q.SetParameter("startDate", startDate);
                q.SetParameter("endDate", endDate);
                System.Collections.IList tmp = q.List();
                foreach (object[] o in tmp)
                {
                    VirtualReport report = new VirtualReport();
                    report.SaveDate = o[0].ToString();
                    report.Money = o[1].ToString();
                    report.Count = int.Parse(o[2].ToString());
                    listVehicle.Add(report);
                }
                return listVehicle;
            }
        }
        public static IList<Vehicle> CaculateTaxReport(DateTime startDate, DateTime endDate)
        {
            using (ISession session = SessionFactory.OpenSession())
            {
                IQuery q = session.CreateQuery("from Vehicle where SaveDate > :startDate and SaveDate < :endDate");
                q.SetParameter("startDate", startDate);
                q.SetParameter("endDate", endDate);
                return q.List<Vehicle>();
            }
        }
    }
}
