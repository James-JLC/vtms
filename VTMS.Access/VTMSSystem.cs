using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using MySql.Data.MySqlClient;
namespace VTMS.Access
{
    public class VTMSSystem
    {
        public static string GetCurrentDate()
        {
            string result = "";
            string sqlStr = @"SELECT DATE_FORMAT(CURRENT_DATE,'%Y.%m.%d') as temp FROM DUAL";

            using (IDataReader reader = SqlHelper.ExecuteReader(DbProvider.dbconnstring, CommandType.Text, sqlStr))
            {
                if (reader.Read())
                {
                    try
                    {
                        result = DbProvider.DBNullCheck(reader["temp"]);
                    }
                    catch (Exception e)
                    {
                        string str = e.Message;
                    }
                }

                return result;
            }
        }
    }
}
