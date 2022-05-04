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

    }
}
