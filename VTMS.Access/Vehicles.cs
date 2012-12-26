using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using MySql.Data.MySqlClient;
using VTMS.Model;
using VTMS.Common;
namespace VTMS.Access
{
    public class Vehicles
    {
        /// <summary>
        /// 取得最新的流水号
        /// </summary>
        /// <returns></returns>
        public static VehicleInfo GetLatestSerial()
        {
            VehicleInfo vehicleInfo = new VehicleInfo();

            string sqlStr = @"SELECT CASE WHEN NOT EXISTS 
                                    (SELECT * FROM vehicle WHERE save_date = CURRENT_DATE) 
                                        then CONCAT(DATE_FORMAT(CURRENT_DATE,'%Y%m%d'),'001')
                                    else (SELECT MAX(serial)+1 FROM vehicle) END AS serial FROM DUAL";
            try
            {
                using (IDataReader reader = SqlHelper.ExecuteReader(DbProvider.dbconnstring, CommandType.Text, sqlStr))
                {
                    if (reader.Read())
                    {
                        try
                        {
                            vehicleInfo.Serial = DbProvider.DBNullCheck(reader["serial"]);
                        }
                        catch (Exception e)
                        {
                            string str = e.Message;
                        }

                    }
                    reader.Close();
                }
            }
            catch (MySqlException ex)
            {
                MessageUtil.ShowError("取得流水号出错! 错误信息为：" + ex.Message);
            }
            return vehicleInfo;
        }

        /// <summary>
        /// 取得车辆类型
        /// </summary>
        /// <returns></returns>
        public static DataSet GetVehicleType()
        {
            string sqlStr = @"SELECT id,name FROM vehicleType WHERE isactive=true ORDER BY priority,id";

            try
            {
                return SqlHelper.ExecuteDataset(DbProvider.dbconnstring, sqlStr, CommandType.Text);
            }
            catch (MySqlException ex)
            {
                MessageUtil.ShowError("取得车辆类型数据出错! 错误信息为：" + ex.Message);
            }
            return null;
        }
        /// <summary>
        /// 取得经济公司列表
        /// </summary>
        /// <returns></returns>
        public static DataSet GetCompany()
        {
            string sqlStr = @"SELECT id,name FROM company WHERE isactive=true ORDER BY priority,id";

            try
            {
                return SqlHelper.ExecuteDataset(DbProvider.dbconnstring, sqlStr, CommandType.Text);
            }
            catch (MySqlException ex)
            {
                MessageUtil.ShowError("获取经济公司数据出错! 错误信息为：" + ex.Message);
            }
            return null;
        }
        /// <summary>
        /// 如果车辆信息不存在，则添加车辆信息，否则进行更新
        /// </summary>
        /// <param name="goodpointinfo"></param>
        /// <returns></returns>
        public static int AddVehicleInfo(VehicleInfo vehicleInfo)
        {
            string sqlStr = @"INSERT INTO 
                                vehicle (serial,originid,originpic,currentid,currentpic,invoice,license,vin,category,engine,brand,model,gross,mass,passengers,
                                        certificate,register,certification,displacement,actual,transactions,department,saver,save_date,firstpic,secondpic,thirdpic,forthpic)

                              VALUES(?serial,?originid,?originpic,?currentid,?currentpic,?invoice,?license,?vin,?category,?engine,?brand,?model,?gross,?mass,?passengers,
                                        ?certificate,?register,?certification,?displacement,?actual,?transactions,?department,?saver,current_date,?firstpic,?secondpic,?thirdpic,?forthpic)";

            MySqlParameter[] parms ={new MySqlParameter("?serial",vehicleInfo.Serial),
                                        new MySqlParameter("?originid",vehicleInfo.OriginId),
                                        new MySqlParameter("?originpic",vehicleInfo.OriginPic),
                                        new MySqlParameter("?currentid",vehicleInfo.OriginId),
                                        new MySqlParameter("?currentpic",vehicleInfo.CurrentPic),
                                        new MySqlParameter("?invoice",vehicleInfo.Invoice),
                                        new MySqlParameter("?license",vehicleInfo.License),
                                        new MySqlParameter("?vin",vehicleInfo.Vin),
                                        new MySqlParameter("?category",vehicleInfo.Category),
                                        new MySqlParameter("?engine",vehicleInfo.Engine),
                                        new MySqlParameter("?brand",vehicleInfo.Brand),
                                        new MySqlParameter("?model",vehicleInfo.Model),
                                        new MySqlParameter("?gross",vehicleInfo.Gross),
                                        new MySqlParameter("?mass",vehicleInfo.Mass),
                                        new MySqlParameter("?passengers",vehicleInfo.Passengers),
                                        new MySqlParameter("?certificate",vehicleInfo.Certificate),
                                        new MySqlParameter("?register",vehicleInfo.Register),
                                        new MySqlParameter("?certification",vehicleInfo.Certification),
                                        new MySqlParameter("?displacement",vehicleInfo.Displacement),
                                        new MySqlParameter("?actual",vehicleInfo.Actual),
                                        new MySqlParameter("?transactions",vehicleInfo.Transactions),
                                        new MySqlParameter("?department",vehicleInfo.Department),
                                        new MySqlParameter("?saver",vehicleInfo.Saver),
                                        new MySqlParameter("?firstpic",vehicleInfo.Firstpic),
                                        new MySqlParameter("?secondpic",vehicleInfo.Secondpic),
                                        new MySqlParameter("?thirdpic",vehicleInfo.Thirdpic),
                                        new MySqlParameter("?forthpic",vehicleInfo.Forthpic)};
            try
            {
                return SqlHelper.ExecuteNonQuery(DbProvider.dbconnstring, CommandType.Text, sqlStr, parms);
            }
            catch (MySqlException ex)
            {
                MessageUtil.ShowError("保存数据出错! 错误信息为：" + ex.Message);
            }
            return 0;

        }

        /// <summary>
        /// 根据根据流水号更新车辆信息
        /// </summary>
        /// <returns></returns>
        public static int UpdateVehicleInfoBySerial(VehicleInfo vehicleInfo)
        {
            string sqlStr = @"UPDATE vehicle SET
	                                originid=?originid,originpic=?originpic,currentid=?currentid,currentpic=?currentpic,invoice=?invoice,license=?license,vin=?vin,category=?category,
	                                engine=?engine,brand=?brand,model=?model,gross=?gross,mass=?mass,passengers=?passengers,certificate=?certificate,
	                                register=?register,certification=?certification,displacement=?displacement,actual=?actual,transactions=?transactions,
                                    department=?department,firstpic=?firstpic,secondpic=?secondpic,thirdpic=?thirdpic,forthpic=?forthpic
                                WHERE serial = ?serial";

            MySqlParameter[] parms ={new MySqlParameter("?serial",vehicleInfo.Serial),
                                        new MySqlParameter("?originid",vehicleInfo.OriginId),
                                        new MySqlParameter("?originpic",vehicleInfo.OriginPic),
                                        new MySqlParameter("?currentid",vehicleInfo.CurrentId),
                                        new MySqlParameter("?currentpic",vehicleInfo.CurrentPic),
                                        new MySqlParameter("?invoice",vehicleInfo.Invoice),
                                        new MySqlParameter("?license",vehicleInfo.License),
                                        new MySqlParameter("?vin",vehicleInfo.Vin),
                                        new MySqlParameter("?category",vehicleInfo.Category),
                                        new MySqlParameter("?engine",vehicleInfo.Engine),
                                        new MySqlParameter("?brand",vehicleInfo.Brand),
                                        new MySqlParameter("?model",vehicleInfo.Model),
                                        new MySqlParameter("?gross",vehicleInfo.Gross),
                                        new MySqlParameter("?mass",vehicleInfo.Mass),
                                        new MySqlParameter("?passengers",vehicleInfo.Passengers),
                                        new MySqlParameter("?certificate",vehicleInfo.Certificate),
                                        new MySqlParameter("?register",vehicleInfo.Register),
                                        new MySqlParameter("?certification",vehicleInfo.Certification),
                                        new MySqlParameter("?displacement",vehicleInfo.Displacement),
                                        new MySqlParameter("?actual",vehicleInfo.Actual),
                                        new MySqlParameter("?transactions",vehicleInfo.Transactions),
                                        new MySqlParameter("?department",vehicleInfo.Department),
                                        new MySqlParameter("?saver",vehicleInfo.Saver),
                                        new MySqlParameter("?firstpic",vehicleInfo.Firstpic),
                                        new MySqlParameter("?secondpic",vehicleInfo.Secondpic),
                                        new MySqlParameter("?thirdpic",vehicleInfo.Thirdpic),
                                        new MySqlParameter("?forthpic",vehicleInfo.Forthpic)};

            try
            {
                return SqlHelper.ExecuteNonQuery(DbProvider.dbconnstring, CommandType.Text, sqlStr, parms);
            }
            catch (MySqlException ex)
            {
                MessageUtil.ShowError("保存数据出错! 错误信息为：" + ex.Message);
            }
            return 0;
        }
        /// <summary>
        /// 根据查询条件查询出符合条件的车辆信息,如果查到信息则返回true，否则为false
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static bool GetVehicleInfoBySerail(VehicleInfo vehicleInfo)
        {
            string sqlStr = @"SELECT originid,originpic,currentid,currentpic,invoice,license,vin,category,engine,brand,model,gross,mass,passengers,
			                                certificate,register,certification,displacement,actual,transactions,department,firstpic,secondpic,thirdpic,forthpic
                                FROM vehicle WHERE serial = ?serial";

            MySqlParameter[] parms = { new MySqlParameter("?serial", vehicleInfo.Serial) };
            try
            {
                using (IDataReader reader = SqlHelper.ExecuteReader(DbProvider.dbconnstring, CommandType.Text, sqlStr, parms))
                {
                    if (reader.Read())
                    {
                        vehicleInfo.OriginId = DbProvider.DBNullCheck(reader["originid"]);
                        vehicleInfo.OriginPic = DbProvider.PicNullCheck(reader["originpic"]);
                        vehicleInfo.CurrentId = DbProvider.DBNullCheck(reader["currentid"]);
                        vehicleInfo.CurrentPic = DbProvider.PicNullCheck(reader["currentpic"]);
                        vehicleInfo.Invoice = DbProvider.DBNullCheck(reader["invoice"]);
                        vehicleInfo.License = DbProvider.DBNullCheck(reader["license"]);
                        vehicleInfo.Vin = DbProvider.DBNullCheck(reader["vin"]);
                        vehicleInfo.Category = DbProvider.DBNullCheck(reader["category"]);
                        vehicleInfo.Engine = DbProvider.DBNullCheck(reader["engine"]);
                        vehicleInfo.Brand = DbProvider.DBNullCheck(reader["brand"]);
                        vehicleInfo.Model = DbProvider.DBNullCheck(reader["model"]);
                        vehicleInfo.Gross = DbProvider.DBNullCheck(reader["gross"]);
                        vehicleInfo.Mass = DbProvider.DBNullCheck(reader["mass"]);
                        vehicleInfo.Passengers = DbProvider.DBNullCheck(reader["passengers"]);
                        vehicleInfo.Certificate = DbProvider.DBNullCheck(reader["certificate"]);
                        vehicleInfo.Register = DbProvider.DBNullCheck(reader["register"]);
                        vehicleInfo.Certification = DbProvider.DBNullCheck(reader["certification"]);
                        vehicleInfo.Displacement = DbProvider.DBNullCheck(reader["displacement"]);
                        vehicleInfo.Actual = DbProvider.DBNullCheck(reader["actual"]);
                        vehicleInfo.Transactions = DbProvider.DBNullCheck(reader["transactions"]);
                        vehicleInfo.Department = DbProvider.DBNullCheck(reader["department"]);
                        vehicleInfo.Firstpic = DbProvider.PicNullCheck(reader["firstpic"]);
                        vehicleInfo.Secondpic = DbProvider.PicNullCheck(reader["secondpic"]);
                        vehicleInfo.Thirdpic = DbProvider.PicNullCheck(reader["thirdpic"]);
                        vehicleInfo.Forthpic = DbProvider.PicNullCheck(reader["forthpic"]);

                        return true;
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageUtil.ShowError("获取数据出错! 错误信息为：" + ex.Message);
            }
            return false;
        }
    }
}
