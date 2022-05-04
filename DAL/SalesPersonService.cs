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
    }
}
