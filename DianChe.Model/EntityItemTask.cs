using System;
using System.Collections.Generic;
using System.Text;
using Common;

namespace DianChe.Model
{
    /// <summary>
    /// 我的宝贝，需要被别人点击
    /// </summary>
    public class EntityItemTask
    {
        /// <summary>
        /// 本地ID，主键
        /// </summary>
        public Guid local_item_task_id { get; set; }

        /// <summary>
        /// 昵称
        /// </summary>
        public string nick { get; set; }

        /// <summary>
        /// 宝贝ID
        /// </summary>		
        public long item_id { get; set; }
        /// <summary>
        /// 宝贝标题
        /// </summary>		
        public string item_title { get; set; }

        /// <summary>
        /// 宝贝图片地址
        /// </summary>
        public string img_url { get; set; }

        /// <summary>
        /// 图片内容
        /// </summary>
        public byte[] img_data { get; set; }

        /// <summary>
        /// 用于Winform中显示图片对象，不存入数据库
        /// </summary>
        public System.Drawing.Image img_display
        {
            get
            {
                return Helper.GetImageFromImageWidth(Strings.GetImageFormByte(img_data as byte[]), 90);
            }
        }

        /// <summary>
        /// 宝贝价格
        /// </summary>
        public decimal price { get; set; }

        /// <summary>
        /// 创意一标题
        /// </summary>		
        public string creative_one_title { get; set; }

        /// <summary>
        /// 创意二标题
        /// </summary>
        public string creative_two_title { get; set; }

        /// <summary>
        /// 宝贝搜索的关键词
        /// </summary>
        public string keyword { get; set; }

        /// <summary>
        /// 每天需要点击的次数
        /// </summary>
        public int max_click { get; set; }

        /// <summary>
        /// 执行多少天
        /// </summary>
        public int run_days { get; set; }

        /// <summary>
        /// 点击有效开始时间，比如：0100
        /// </summary>
        public string effect_start_time { get; set; }

        /// <summary>
        /// 点击有效截至时间，比如：0800
        /// </summary>
        public string effect_end_time { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>		
        public DateTime create_time { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>		
        public DateTime update_time { get; set; }

        /// <summary>
        /// 备注，可以填写点击率的历史记录之类
        /// </summary>
        public string remark { get; set; }

        /// <summary>
        /// 是否有效
        /// </summary>
        public Boolean is_enable { get; set; }


    }
}
