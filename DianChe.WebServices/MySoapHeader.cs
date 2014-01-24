using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DianChe.WebServices
{
    /// <summary>
    ///自定义的SoapHeader
    /// </summary>
    public class MySoapHeader : System.Web.Services.Protocols.SoapHeader
    {

        private string userName = string.Empty;
        private string passWord = string.Empty;

        /// <summary>
        /// 构造函数
        /// </summary>
        public MySoapHeader()
        {

        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="passWord">密码</param>
        public MySoapHeader(string userName, string passWord)
        {
            this.userName = userName;
            this.passWord = passWord;
        }

        /// <summary>
        /// 获取或设置用户用户名
        /// </summary>
        public string UserName
        {
            get { return userName; }
            set { userName = value; }

        }

        /// <summary>
        /// 获取或设置用户密码
        /// </summary>
        public string PassWord
        {
            get { return passWord; }
            set { passWord = value; }
        }
    }
}