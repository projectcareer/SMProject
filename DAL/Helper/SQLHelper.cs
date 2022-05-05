using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DAL
{
    /// <summary>
    /// 通用数据访问类
    /// </summary>
     public class SQLHelper
    {
        private static string connString = ConfigurationManager.ConnectionStrings["connString"].ToString();
        /// <summary>
        /// 执行insert、 update、delete类型的SQL语句
        /// </summary>
        /// <param name="sql">提交的SQL语句，可以根据需要添加参数</param>
        /// <param name="param">参数数组（如果没有参数，请传递null)</param>
        /// <returns>返回受影响的行数</returns>
        public static int Update(string sql, SqlParameter[] param)
        {
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(sql, conn);
            if(param != null)
            {
                cmd.Parameters.AddRange(param); //添加参数组
            }
            try
            {
                conn.Open();
                return cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                string info = "执行 public int Update(string sql, SqlParameter[] param)方法发生异常：" + ex.Message;
                //在这里写入日志
                throw new Exception(info);
            }
            finally
            {
                conn.Close();
            }
        }
        /// <summary>
        /// 返回单一结果的查询
        /// </summary>
        /// <param name="sql">提交的SQL语句，可以根据需要添加参数</param>
        /// <param name="param">参数数组（如果没有参数，请传递null)</param>
        /// <returns>返回object类型</returns>
        public static object GetSingleResult(string sql, SqlParameter[] param)
        {
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(sql, conn);
            if (param != null)
            {
                cmd.Parameters.AddRange(param); //添加参数组
            }
            try
            {
                conn.Open();
                return cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                string info = "执行 public object GetSingleResult(string sql, SqlParameter[] param)方法发生异常：" + ex.Message;
                //在这里写入日志
                throw new Exception(info);
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// 返回一个结果集的查询
        /// </summary>
        /// <param name="sql">提交的SQL语句，可以根据需要添加参数</param>
        /// <param name="param">参数数组（如果没有参数，请传递null)</param>
        /// <returns>返回SqlDataReader对象</returns>
        public static SqlDataReader GetReader(string sql, SqlParameter[] param)
        {
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(sql, conn);
            if (param != null)
            {
                cmd.Parameters.AddRange(param); //添加参数组
            }
            try
            {
                conn.Open();
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
                string info = "执行  public SqlDataReader GetReader(string sql, SqlParameter[] param)方法发生异常：" + ex.Message;
                //在这里写入日志
                throw new Exception(info);
            }
         
        }
        /// <summary>
        /// 获取数据库服务器时间
        /// </summary>
        /// <returns></returns>
        public static DateTime GetDBServerTime()
        {
            string sql = "select getdate()";
            return Convert.ToDateTime(GetSingleResult(sql, null));
        }
    }
}
