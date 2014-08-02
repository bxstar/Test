using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using log4net;
using Common;

namespace DianChe
{
    public partial class FrmLoginReg : Form
    {
        /// <summary>
        /// web代理类
        /// </summary>
        DianCheWebService.ItemClickService ws = new DianCheWebService.ItemClickService();

        private static ILog logger = log4net.LogManager.GetLogger("Logger");

        public FrmLoginReg()
        {
            InitializeComponent();
        }

        private void btnReg_Click(object sender, EventArgs e)
        {
            if (txtRegUserName.Text.Trim().Length == 0)
            {
                MessageBox.Show("请输入用户名！");
                return;
            }

            if (txtRegPwd.Text.Trim().Length == 0)
            {
                MessageBox.Show("请输入密码！");
                return;
            }

            if (txtRegPwd.Text.Trim().Length <6)
            {
                MessageBox.Show("密码长度不能小于6位！");
                return;
            }

            if (txtRegPwd.Text.Trim() != txtRegPwdConfirm.Text.Trim())
            {
                MessageBox.Show("两次输入的密码不一致，请重新输入密码，并且两次的密码一致！");
                return;
            }

            btnReg.Enabled = false;
            btnReg.Text = "注册中...";

            string mac_address = Common.Helper.GetMacAddress();
            if (ws.IsExistMac(mac_address))
            {
                MessageBox.Show("该机器已经被注册过，请直接登录！");
                btnReg.Enabled = true;
                btnReg.Text = "注册";
                return;
            }


            string user_name = txtRegUserName.Text.Trim();
            if (ws.IsExistUser(user_name))
            {
                MessageBox.Show("该用户名已经被使用过，请换一个！");
                btnReg.Enabled = true;
                btnReg.Text = "注册";
                return;
            }


            string pwd = EncryptUtils.EncryptString(txtRegPwd.Text.Trim());
            string phone = txtRegPhone.Text.Trim();
            string email = txtRegEmail.Text.Trim();
            CPUInfo cpuInfo = new CPUInfo();
            cpuInfo.GetCPUInfo();
            string cpu= cpuInfo.CPUName;
            string osname = OSVersionInfo.SystemName;
            Computer cp = Computer.Instance();
            string mem = cp.TotalPhysicalMemory;
            
            DianCheWebService.EntityUser user = ws.RegUser(user_name, pwd, phone, email, mac_address,cpu,mem,osname);
            if (user != null)
            {
                this.Hide();
                FrmMain.CurrentUser = user;
                FrmMain frmMain = new FrmMain();
                frmMain.Show();
            }
            else
            {
                MessageBox.Show("注册失败！");
                btnReg.Enabled = true;
                btnReg.Text = "注册";
            }

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            btnLogin.Enabled = false;
            btnLogin.Text = "登录中...";

            string user_name = txtLoginUserName.Text.Trim();
            string pwd = EncryptUtils.EncryptString(txtLoginPwd.Text.Trim());
            CPUInfo cpuInfo = new CPUInfo();
            cpuInfo.GetCPUInfo();
            string cpu = cpuInfo.CPUName;
            string osname = OSVersionInfo.SystemName;
            Computer cp = Computer.Instance();
            string mem = cp.TotalPhysicalMemory;
            DianCheWebService.EntityUser user = ws.UserLogin(user_name, pwd, cpu, mem, osname);
            if (user != null)
            {
                this.Hide();
                FrmMain.CurrentUser = user;
                FrmMain frmMain = new FrmMain();
                frmMain.Show();
            }
            else
            {
                MessageBox.Show("登录失败，请检查用户名密码！");
                btnLogin.Enabled = true;
                btnLogin.Text = "登录";
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                this.AcceptButton = btnLogin;
            }
            else if (tabControl1.SelectedIndex == 1)
            {
                this.AcceptButton = btnReg;
            }
        }

        private void FrmLoginReg_Load(object sender, EventArgs e)
        {
            tabControl1.Focus();
            txtLoginUserName.Focus();
        }
    }
}
