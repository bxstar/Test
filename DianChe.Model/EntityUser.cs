using System;
using System.Collections.Generic;
using System.Text;

namespace DianChe.Model
{
    /// <summary>
    /// 用户实体类
    /// </summary>
    public class EntityUser
    {
        /// <summary>
        /// user_id
        /// </summary>		
        public int user_id { get; set; }
        /// <summary>
        /// user_name
        /// </summary>		
        public string user_name { get; set; }
        /// <summary>
        /// pwd
        /// </summary>		
        public string pwd { get; set; }
        /// <summary>
        /// email
        /// </summary>		
        public string email { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>		
        public string phone { get; set; }
        /// <summary>
        /// mac_address
        /// </summary>		
        public string mac_address { get; set; }
        /// <summary>
        /// ip_address
        /// </summary>		
        public string ip_address { get; set; }
        /// <summary>
        /// CPU信息
        /// </summary>
        public string cpu { get; set; }
        /// <summary>
        /// 内存信息
        /// </summary>
        public string mem { get; set; }
        /// <summary>
        /// 操作系统
        /// </summary>
        public string os { get; set; }
        /// <summary>
        /// 用户级别，免费用户0，收费用户1
        /// </summary>		
        public int user_level { get; set; }
        /// <summary>
        /// 收费用户的有效开始日期
        /// </summary>		
        public DateTime start_date { get; set; }
        /// <summary>
        /// 收费用户的有效结束日期
        /// </summary>		
        public DateTime end_date { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>		
        public DateTime create_time { get; set; }
        /// <summary>
        /// 最后一次修改时间
        /// </summary>		
        public DateTime update_time { get; set; }
    }
}
