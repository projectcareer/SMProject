using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Models;
using DAL;
using System.Net;



namespace SMProject
{
    public partial class FrmLogin : Form
    {
        //创建数据访问对象
        private SalesPersonService objService = new SalesPersonService();
        public FrmLogin()
        {
            InitializeComponent();
        }
        //登录按钮
        private void btnLogin_Click(object sender, EventArgs e)
        {
            //数据验证
            if(this.txtLoginId.Text.Trim().Length == 0 || this.txtLoignPwd.Text.Trim().Length == 0)
            {
                MessageBox.Show("账号和密码不能为空!", "登陆提示");
            }
            //封装用户对象
            SalesPerson objPerson = new SalesPerson()
            {
                SalesPersonId = Convert.ToInt32(this.txtLoginId.Text.Trim()),
                LoginPwd = this.txtLoignPwd.Text.Trim()
            };
            //将用户对象提交数据访问方法实现登陆
            try
            {
                objPerson = objService.UserLogin(objPerson);
                if(objPerson == null)
                {
                    MessageBox.Show("账号或密码错误!", "登陆提示");
                }
                else
                {
                    //保存用户信息到全局变量
                    Program.objCurrentPerson = objPerson;
                    //将用户登陆信息写入日志

                    //设置登陆窗体返回值
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("用户登陆出现异常:" + ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
