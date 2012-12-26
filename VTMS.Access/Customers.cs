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
    public class Customers
    {
        public Customers() { }

        /// <summary>
        /// 如果客户信息不存在，则添加客户信息
        /// </summary>
        /// <param name="goodpointinfo"></param>
        /// <returns></returns>
        public static int AddCustomerInfo(CustomerInfo customerInfo)
        {
            string sqlStr = @"INSERT INTO customer (id,name,phone,address) 
                            VALUES(?id,?name,?phone,?address)
                            ON DUPLICATE KEY UPDATE name=?name, phone=?phone, address=?address";
            MySqlParameter[] parms ={new MySqlParameter("?id",customerInfo.Id),
                                    new MySqlParameter("?name",customerInfo.Name),
                                    new MySqlParameter("?phone",customerInfo.Phone),
                                    new MySqlParameter("?address",customerInfo.Address)};
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
        /// 根据客户ID更新客户信息
        /// </summary>
        /// <returns></returns>
        public static int UpdateCustomerInfoById(CustomerInfo customerInfo)
        {
            string sqlStr = @"UPDATE customer SET name=?name, phone=?phone, address=?address WHERE id=?id";

            MySqlParameter[] parms ={new MySqlParameter("?name",customerInfo.Name),
                                    new MySqlParameter("?phone",customerInfo.Phone),
                                    new MySqlParameter("?address",customerInfo.Address),
                                    new MySqlParameter("?id",customerInfo.Id)};

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
        /// 根据查询条件查询出符合条件的客户信息
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static bool GetCustomerInfoById(CustomerInfo customerInfo)
        {
            string sqlStr = @"SELECT id,name,phone,address FROM customer WHERE id=?id limit 1";

            MySqlParameter[] parms = { new MySqlParameter("?id", customerInfo.Id) };
            try
            {
                using (IDataReader reader = SqlHelper.ExecuteReader(DbProvider.dbconnstring, CommandType.Text, sqlStr, parms))
                {
                    if (reader.Read())
                    {
                        customerInfo.Id = DbProvider.DBNullCheck(reader["id"]);
                        customerInfo.Name = DbProvider.DBNullCheck(reader["name"]);
                        customerInfo.Phone = DbProvider.DBNullCheck(reader["phone"]);
                        customerInfo.Address = DbProvider.DBNullCheck(reader["address"]);
                        return true;
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageUtil.ShowError("取得数据出错! 错误信息为：" + ex.Message);
            }
            return false;
        }
    }
}
