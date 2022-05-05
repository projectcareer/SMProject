using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Models;
using DAL;

namespace DAL
{
    /// <summary>
    /// 销售员
    /// </summary>
    public class SalesPersonService
    {
        /// <summary>
        /// 根据登陆账号和密码实现用户登陆
        /// </summary>
        /// <param name="objPerson">包含登陆账号和密码的用户对象</param>
        /// <returns>返回包含登陆账号、密码和用户名的对象或null</returns>
        public SalesPerson UserLogin(SalesPerson objPerson)
        {
            string sql = "select SPName from SalesPerson where SalesPersonId = @SalesPersonId";
            sql += " and LoginPwd = @LoginPwd";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@SalesPersonId",objPerson.SalesPersonId),
                new SqlParameter("@LoginPwd", objPerson.LoginPwd)
            };
            object result = SQLHelper.GetSingleResult(sql, param);
            if(result == null)
            {
                return null;
            }
            else
            {
                objPerson.SPName = result.ToString();
                return objPerson;
            }
        }
        /// <summary>
        /// 添加登陆日志，返回日志编号
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public int WriteLoginLog(LoginLogs info)
        {
            string sql = "insert into LoginLogs (loginId,SPName,ServerName)";
            sql += " values(@LoginId,@SPName,@ServerName); select @@identity";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@LoginId",info.LoginId),
                new SqlParameter("@SPName",info.SPName),
                new SqlParameter("@ServerName ",info.ServerName)
            };

            try
            {
                return Convert.ToInt32(SQLHelper.GetSingleResult(sql,param));
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// 将用户退出的时间保存在日志中
        /// </summary>
        /// <param name="logld"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        public int WriteExitLog(int logld, DateTime dt)
        {
            string sql = "update LoginLogs set ExitTime = @ExitTime where LogId = @LogId";
            SqlParameter[] param = new SqlParameter[]
             {
                new SqlParameter("@ExitTime",dt),
                new SqlParameter("@LogId ",logld)
             };
            return SQLHelper.Update(sql, param);
        }

        /// <summary>
        /// 获取服务器的时间
        /// </summary>
        /// <returns></returns>
        public DateTime GetDBServerTimes()
        {
            return SQLHelper.GetDBServerTime();
        }
    }
}
