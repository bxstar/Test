using System;
using System.Collections.Generic;
using System.Text;

namespace DianChe.Model
{
    public class EntityMsg
    {
        /// <summary>
        /// 本地ID
        /// </summary>		
        public long local_msg_id { get; set; }
        /// <summary>
        /// 发件人地址或手机号
        /// </summary>
        public string msg_from { get; set; }
        /// <summary>
        /// 收件人地址或手机号
        /// </summary>
        public string msg_to { get; set; }
        /// <summary>
        /// 信息标题
        /// </summary>		
        public string msg_subject { get; set; }
        /// <summary>
        /// 信息类型，有：短信，邮件，旺旺
        /// </summary>
        public string msg_type { get; set; }

        /// <summary>
        /// 信息正文
        /// </summary>		
        public string msg_content { get; set; }
        /// <summary>
        /// 附件路径
        /// </summary>		
        public string file_path { get; set; }
        /// <summary>
        /// 发送状态，0待发送，1发送中，2发送成功，3发送失败
        /// </summary>
        public int send_status { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>	
        public DateTime create_time { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>		
        public DateTime update_time { get; set; }    

    }
}
