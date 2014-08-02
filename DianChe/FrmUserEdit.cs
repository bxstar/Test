using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DianChe
{
    public partial class FrmUserEdit : Form
    {
        public FrmUserEdit()
        {
            InitializeComponent();
        }

        private void FrmUserEdit_Load(object sender, EventArgs e)
        {
            txtRegUserName.Text = FrmMain.CurrentUser.user_name;
            txtRegEmail.Text = FrmMain.CurrentUser.email;
            txtRegPhone.Text = FrmMain.CurrentUser.phone;

            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int user_id = FrmMain.CurrentUser.user_id;

            try
            {
                var newUserInfo = FrmMain.ws.UserInfoEdit(user_id, txtRegUserName.Text, txtRegPhone.Text, txtRegEmail.Text);
                FrmMain.CurrentUser.user_name = newUserInfo.user_name;
                FrmMain.CurrentUser.email = newUserInfo.email;
                FrmMain.CurrentUser.phone = newUserInfo.phone;
                FrmMain.ws.MySoapHeaderValue.UserName = newUserInfo.user_name;
                MessageBox.Show("注册信息保存成功！");
            }
            catch (Exception se)
            {
                MessageBox.Show("更新注册信息失败，" + se.Message);
                return;
            }
            
        }

        private void btnEditPwd_Click(object sender, EventArgs e)
        {
            if (txtRegPwd.Text.Trim().Length == 0)
            {
                MessageBox.Show("请输入密码！");
                return;
            }

            if (txtRegPwd.Text.Trim().Length < 6)
            {
                MessageBox.Show("密码长度不能小于6位！");
                return;
            }

            if (txtRegPwd.Text.Trim() != txtRegPwdConfirm.Text.Trim())
            {
                MessageBox.Show("两次输入的密码不一致，请重新输入密码，并且两次的密码一致！");
                return;
            }
            
            int user_id = FrmMain.CurrentUser.user_id;

            try
            {
                string newPwd = Common.EncryptUtils.EncryptString(txtRegPwd.Text.Trim());
                FrmMain.ws.UserPwdEdit(user_id, newPwd);
                FrmMain.CurrentUser.pwd = newPwd;
                FrmMain.ws.MySoapHeaderValue.PassWord = newPwd;
                MessageBox.Show("密码修改成功！");
            }
            catch (Exception se)
            {
                MessageBox.Show("密码修改失败，" + se.Message);
                return;
            }
        }
    }
}
