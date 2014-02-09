using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using DianChe.Model;

namespace DianChe.WebServices
{
    /// <summary>
    /// 宝贝点击WebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class ItemClickService : System.Web.Services.WebService
    {
        //声明Soap头实例
        public MySoapHeader myHeader = new MySoapHeader();

        BLL.BllItemClick bllItemClick = new BLL.BllItemClick();
        BLL.BllUser bllUser = new BLL.BllUser();

        [System.Web.Services.Protocols.SoapHeader("myHeader")]
        [WebMethod]
        public string HelloWorld()
        {
            string userName = myHeader.UserName;
            string pwd = myHeader.PassWord;

            //可以通过存储在数据库中的用户与密码来验证
            if (bllUser.Get(userName, pwd) != null)
            {
                return "Hello World";
            }
            else
            {
                return "对不起，您没有权限调用此服务！";
            }
            
        }

        [WebMethod]
        public Boolean IsExistUser(string user_name)
        {
            EntityUser user = bllUser.Get(user_name);
            if (user != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        [WebMethod]
        public Boolean IsExistMac(string mac_address)
        {
            EntityUser user = bllUser.GetByMac(mac_address);
            if (user != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        [WebMethod]
        public EntityUser RegUser(string user_name, string pwd, string phone, string email, string mac_address,string cpu,string mem,string os)
        {
            EntityUser userForReg = new EntityUser();
            userForReg.user_name = user_name;
            userForReg.pwd = pwd;
            userForReg.phone = phone;
            userForReg.email = email;
            userForReg.mac_address = mac_address;
            userForReg.ip_address = GetRequestIP();
            userForReg.cpu = cpu;
            userForReg.mem = mem;
            userForReg.os = os;
            userForReg.start_date = userForReg.create_time = userForReg.update_time = DateTime.Now;
            userForReg.end_date = new DateTime(2050, 12, 1);
            int user_id = bllUser.Add(userForReg);
            EntityUser user = bllUser.Get(user_id);

            return user;
        }

        [WebMethod]
        public EntityUser UserLogin(string user_name, string pwd, string cpu, string mem, string os)
        {
            EntityUser user = bllUser.Get(user_name, pwd);
            if (user != null)
            {
                bllUser.UpdateComputerInfo(user.user_id, cpu, mem, os);
            }
            return user;
        }

        [System.Web.Services.Protocols.SoapHeader("myHeader")]
        [WebMethod]
        public string AddMyItem(EntityItemTask model)
        {
            if (bllUser.Get(myHeader.UserName, myHeader.PassWord) == null)
            {
                return "对不起，您没有权限调用此服务！";
            }
            return bllItemClick.AddItemTask(model);
        }

        [System.Web.Services.Protocols.SoapHeader("myHeader")]
        [WebMethod]
        public string EditMyItem(EntityItemTask model)
        {
            if (bllUser.Get(myHeader.UserName, myHeader.PassWord) == null)
            {
                return "对不起，您没有权限调用此服务！";
            }
            return bllItemClick.EditItemTask(model);
        }

        [System.Web.Services.Protocols.SoapHeader("myHeader")]
        [WebMethod]
        public string DeleteMyItem(string local_item_task_id)
        {
            if (bllUser.Get(myHeader.UserName, myHeader.PassWord) == null)
            {
                return "对不起，您没有权限调用此服务！";
            }
            return bllItemClick.DeleteItemTask(new Guid(local_item_task_id));
        }

        /// <summary>
        /// 分配点击任务
        /// </summary>
        [System.Web.Services.Protocols.SoapHeader("myHeader")]
        [WebMethod]
        public List<EntityItemClick> DispatchItemClick(string mac_address)
        {
            if (bllUser.Get(myHeader.UserName, myHeader.PassWord) == null)
            {
                throw new Exception("对不起，您没有权限调用此服务！");
            }
            string ip_address = GetRequestIP();

            return bllItemClick.DispatchItemClick(mac_address, ip_address);
        }

        /// <summary>
        /// 设置点击任务的完成状态
        /// </summary>
        [WebMethod]
        public void SetItemClickSucceed(long item_id, string mac_address, Boolean is_succeed)
        {
            bllItemClick.SetItemClickSucceed(item_id, mac_address, is_succeed);
        }

        [System.Web.Services.Protocols.SoapHeader("myHeader")]
        [WebMethod]
        public void SaveAlive(string mac_address)
        {
            if (bllUser.Get(myHeader.UserName, myHeader.PassWord) == null)
            {
                throw new Exception("对不起，您没有权限调用此服务！");
            }
            string ip_address = GetRequestIP();
            new BLL.BllAlive().AddAlive(ip_address, mac_address);
        }

        [System.Web.Services.Protocols.SoapHeader("myHeader")]
        [WebMethod]
        public void AddMsg(string msg_from,string msg_to,string msg_subject,string msg_content,string msg_type)
        {
            if (bllUser.Get(myHeader.UserName, myHeader.PassWord) == null)
            {
                throw new Exception("对不起，您没有权限调用此服务！");
            }
            EntityMsg msg = new EntityMsg() { msg_from = msg_from ?? string.Empty, msg_to = msg_to, msg_subject = msg_subject ?? string.Empty, msg_content = msg_content ?? string.Empty, msg_type = msg_type };
            msg.create_time = msg.update_time = DateTime.Now;
            msg.send_status = 0;
            msg.file_path = string.Empty;
            BLL.BllMsg.AddMsg(msg);
        }

        [System.Web.Services.Protocols.SoapHeader("myHeader")]
        [WebMethod]
        public List<EntityMsg> GetMsg(string msg_type)
        {
            if (bllUser.Get(myHeader.UserName, myHeader.PassWord) == null)
            {
                throw new Exception("对不起，您没有权限调用此服务！");
            }
            List<EntityMsg> lstMsg = BLL.BllMsg.GetMsg(msg_type);
            return lstMsg;
        }

        [System.Web.Services.Protocols.SoapHeader("myHeader")]
        [WebMethod]
        public void UpdateMsgStatus(long local_msg_id,int send_status)
        {
            if (bllUser.Get(myHeader.UserName, myHeader.PassWord) == null)
            {
                throw new Exception("对不起，您没有权限调用此服务！");
            }
            EntityMsg msg = new EntityMsg() { local_msg_id = local_msg_id, send_status = send_status };
            BLL.BllMsg.UpdateMsgStatus(msg);
        }

        /// <summary>
        /// 获取客户端IP
        /// </summary>
        private string GetRequestIP()
        {
            string ip_address = string.Empty;
            if (HttpContext.Current.Request.ServerVariables["HTTP_VIA"] != null)
            {
                ip_address = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString();
            }
            else
            {
                ip_address = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"].ToString();
            }
            if (ip_address.Contains("::1"))
            {
                ip_address = "127.0.0.1";
            }
            return ip_address;
        }

        /// <summary>
        /// 淘宝在线获取宝贝信息
        /// </summary>
        [WebMethod]
        public string GetItemOnline(long item_id)
        {
            string jsonItem = BLL.BllTopApi.GetItemOnline(item_id);
            return jsonItem;
        }

        /// <summary>
        /// 从宝贝的Json数据中，获取结构化的宝贝对象
        /// </summary>
        [WebMethod]
        public EntityItemTask GetItemTaskFromJson(string jsonItem)
        {
            EntityItemTask model = BLL.BllTopApi.GetItemTaskFromJson(jsonItem);
            return model;
        }

        /// <summary>
        /// 从宝贝的Json数据中，获取结构化的宝贝对象
        /// </summary>
        [WebMethod]
        public EntityItemRank GetItemRankFromJson(string jsonItem)
        {
            EntityItemRank model = BLL.BllTopApi.GetItemRankFromJson(jsonItem);
            return model;
        }
    }
}