using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Models;



namespace SMProject
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //显示登陆窗体
            FrmLogin frmLogin = new SMProject.FrmLogin();
            DialogResult result = frmLogin.ShowDialog();
            //判断是否登陆成功
            if(result == DialogResult.OK)
            {
                Application.Run(new FrmSaleManage());
            }
            else
            {
                Application.Exit(); //登陆不成功，退出整个程序
            }
            
        }

        //定义全局变量保存当前用户信息对象
        public static SalesPerson objCurrentPerson = null;

    }
}
