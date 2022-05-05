using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using DAL;

namespace SMProject
{
    public partial class FrmSaleManage : Form
    {
        private SalesPersonService objSalesPersonService = new SalesPersonService();

        #region  窗体拖动、关闭【实际项目中不用】

        private Point mouseOff;//鼠标移动位置变量
        private bool leftFlag;//标签是否为左键
        private void FrmMain_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mouseOff = new Point(-e.X, -e.Y); //得到变量的值
                leftFlag = true;                  //点击左键按下时标注为true;
            }
        }
        private void FrmMain_MouseMove(object sender, MouseEventArgs e)
        {
            if (leftFlag)
            {
                Point mouseSet = Control.MousePosition;
                mouseSet.Offset(mouseOff.X, mouseOff.Y);  //设置移动后的位置
                Location = mouseSet;
            }
        }
        private void FrmMain_MouseUp(object sender, MouseEventArgs e)
        {
            if (leftFlag)
            {
                leftFlag = false;//释放鼠标后标注为false;
            }
        }

        #endregion


        public FrmSaleManage()
        {
            InitializeComponent();
         
        }

        /// <summary>
        /// 窗体关闭前，写入退出日志
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmSaleManage_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("确认退出吗？", "退出提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if(result == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
            else
            {
                DateTime dt = objSalesPersonService.GetDBServerTimes();
                objSalesPersonService.WriteExitLog(Program.objCurrentPerson.LoginLogId, dt);
            }
            
        }
    }
}
