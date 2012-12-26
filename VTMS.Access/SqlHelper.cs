using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace VTMS.Access
{
    public sealed class SqlHelper
    {
        public SqlHelper() { }



        #region ExecuteDataset

        /// <summary>
        /// 
        /// </summary>
        /// <param name="commandtext"></param>
        /// <param name="commandType"></param>
        /// <param name="connstring"></param>
        /// <returns>返回DataSet</returns>
        public static DataSet ExecuteDataset(string connectionString, string commandText, CommandType commandType)
        {
            return ExecuteDataset(connectionString, commandText, commandType, (MySqlParameter[])null);

        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="commandText"></param>
        /// <param name="commandType"></param>
        /// <param name="commandParameters"></param>
        /// <returns>返回DataSet</returns>
        public static DataSet ExecuteDataset(string connectionString, string commandText, CommandType commandType, params MySqlParameter[] commandParameters)
        {
            DataSet ds = new DataSet();
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(commandText, conn);
                cmd.CommandType = commandType;

                if (commandParameters != null)
                {
                    foreach (MySqlParameter parm in commandParameters)
                    {
                        cmd.Parameters.Add(parm);
                    }
                }
                
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);

                da.Fill(ds);
                conn.Close();
            }

            return ds;

        }

        #endregion
                

        #region ExecuteReader

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="commandType"></param>
        /// <param name="commandText"></param>
        /// <returns>返回DataReader</returns>
        public static MySqlDataReader ExecuteReader(string connectionString, CommandType commandType, string commandText)
        {   
            return ExecuteReader(connectionString, commandType, commandText, (MySqlParameter[])null);
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="commandType"></param>
        /// <param name="commandText"></param>
        /// <param name="commandParameters"></param>
        /// <returns>返回DataReader</returns>
        public static MySqlDataReader ExecuteReader(string connectionString, CommandType commandType, string commandText, params MySqlParameter[] commandParameters)
        {
            MySqlCommand cmd = new MySqlCommand();

            MySqlConnection conn = new MySqlConnection(connectionString);

            conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = commandText;
            cmd.CommandType = commandType;

            if (commandParameters != null)
            {
                foreach (MySqlParameter parm in commandParameters)
                {
                    cmd.Parameters.Add(parm);
                }
            }

            MySqlDataReader drd = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            cmd.Parameters.Clear();
            return drd;
        }

        #endregion


        #region ExecuteNonQuery

        /// <summary>
        /// 执行UPDATE,INSERT,DELETE
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="commandType"></param>
        /// <param name="commandText"></param>
        /// <returns>所影响的行数</returns>
        public static int ExecuteNonQuery(string connectionString, CommandType commandType, string commandText)
        {
            return ExecuteNonQuery(connectionString, commandType, commandText, (MySqlParameter[])null);
        }



        /// <summary>
        /// 执行UPDATE,INSERT,DELETE
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="commandType"></param>
        /// <param name="commandText"></param>
        /// <param name="commandParameters"></param>
        /// <returns>所影响的行数</returns>
        public static int ExecuteNonQuery(string connectionString, CommandType commandType, string commandText, params MySqlParameter[] commandParameters)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
             
            MySqlCommand cmd = new MySqlCommand();
            conn.Open();
            //MySqlTransaction transaction = conn.BeginTransaction();
            cmd.Connection = conn;
            cmd.CommandText = commandText;
            cmd.CommandType = commandType;
            //cmd.Transaction = transaction;

            if (commandParameters != null)
            {
                foreach (MySqlParameter parm in commandParameters)
                {
                    cmd.Parameters.Add(parm);
                }
            }
            int retval = -1;
            try
            {
                retval = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                string str = e.Message;
                //transaction.Rollback();
            }
            cmd.Parameters.Clear();
            //transaction.Commit();
        
            return retval;
        }



        #endregion


        #region ExecuteScalar

        /// <summary>
        /// 只需要取一个值,即取第一行第一列的值
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="commandType"></param>
        /// <param name="commandText"></param>
        /// <returns>返回一个Object类型的值</returns>
        public static object ExecuteScalar(string connectionString, CommandType commandType, string commandText)
        {
            return ExecuteScalar(connectionString, commandType, commandText, (MySqlParameter[])null);
        }



        /// <summary>
        /// 只需要取一个值,即取第一行第一列的值
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="commandType"></param>
        /// <param name="commandText"></param>
        /// <param name="commandParameters"></param>
        /// <returns>返回一个Object类型的值</returns>
        public static object ExecuteScalar(string connectionString, CommandType commandType, string commandText, params MySqlParameter[] commandParameters)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand();
            conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = commandText;
            cmd.CommandType = commandType;

            if (commandParameters != null)
            {
                foreach (MySqlParameter parm in commandParameters)
                {
                    cmd.Parameters.Add(parm);
                }
            }

            object retval = cmd.ExecuteScalar();
            cmd.Parameters.Clear();
            conn.Close();

            return retval;

        }

        #endregion


        #region Make Parameter


        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameterName"></param>
        /// <param name="dbType"></param>
        /// <param name="size"></param>
        /// <param name="hisValue"></param>
        /// <returns></returns>
        public static MySqlParameter MakeInParameter(string parameterName, MySqlDbType dbType, int size, object hisValue)
        {
            return MakeParameter(parameterName, dbType, size, ParameterDirection.Input, hisValue);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameterName"></param>
        /// <param name="dbType"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public static MySqlParameter MakeOutParameter(string parameterName, MySqlDbType dbType, int size)
        {
            return MakeParameter(parameterName, dbType, size, ParameterDirection.Output, null);
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameterName"></param>
        /// <param name="dbType"></param>
        /// <param name="size"></param>
        /// <param name="direction"></param>
        /// <param name="hisValue"></param>
        /// <returns></returns>
        public static MySqlParameter MakeParameter(string parameterName, MySqlDbType dbType, int size, ParameterDirection direction, object hisValue)
        {
            MySqlParameter param = (size > 0) ? new MySqlParameter(parameterName, dbType, size) : new MySqlParameter(parameterName, dbType);

            param.Direction = direction;
            if (!((direction == ParameterDirection.Output) && (hisValue == null)))
            {
                param.Value = hisValue;
            }

            return param;
        }



        #endregion


    }
}
