using System;
using System.Collections.Generic;
using System.Text;

namespace DianChe.Model
{

    /// <summary>
    /// 宝贝点击执行表
    /// </summary>
    public class EntityItemClick
    {
        /// <summary>
        /// 宝贝点击表本地ID，主键
        /// </summary>		
        public long local_id { get; set; }
        /// <summary>
        /// 宝贝ID
        /// </summary>		
        public long item_id { get; set; }

        /// <summary>
        /// 外键，宝贝任务表ID
        /// </summary>
        public Guid local_item_task_id { get; set; }

        /// <summary>
        /// 网卡唯一地址
        /// </summary>
        public string mac_address { get; set; }

        /// <summary>
        /// 宝贝标题
        /// </summary>		
        public string item_title { get; set; }
        /// <summary>
        /// 创意一标题
        /// </summary>
        public string creative_one_title { get; set; }

        /// <summary>
        /// 创意二标题
        /// </summary>
        public string creative_two_title { get; set; }

        /// <summary>
        /// 用户昵称
        /// </summary>
        public string nick { get; set; }

        /// <summary>
        /// 宝贝搜索的关键词
        /// </summary>
        public string keyword { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime create_time { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>		
        public DateTime update_time { get; set; }

        /// <summary>
        /// 是否点击成功，1成功0失败Null还未执行，需要打开宝贝的页面并停留滚动3秒才算成功，模拟真实用户，以防淘宝作为无效点击
        /// </summary>
        public Boolean? is_succeed { get; set; }
    }
}
