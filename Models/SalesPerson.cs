using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    /// <summary>
    /// 销售员实体类
    /// </summary>
    [Serializable]
    public class SalesPerson
    {
        public int SalesPersonId { get; set; }
        public string SPName { get; set; }
        public string LoginPwd { get; set; }

        //登陆日志ID（扩展属性，用于登陆退出的时候使用）
        public int LoginLogId { get; set; }

    }
}
