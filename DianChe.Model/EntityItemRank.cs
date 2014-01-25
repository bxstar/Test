using System;
using System.Collections.Generic;
using System.Text;
using Common;

namespace DianChe.Model
{
    /// <summary>
    /// 宝贝排名监控实体类
    /// </summary>
    public class EntityItemRank
    {
        /// <summary>
        /// 本地ID，主键
        /// </summary>
        public Guid local_item_rank_id { get; set; }

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
        /// 宝贝当前的自然排名，-1表示在前10页中未能找到排名，0表示正在抓取排名
        /// </summary>
        public int current_nature_rank { get; set; }

        /// <summary>
        /// 当前自然排名的呈现
        /// </summary>
        public string current_nature_rank_display
        { 
            get
            {
                if (is_enable)
                {
                    if (lowest_nature_rank == 0 && highest_nature_rank == 0)
                    {
                        return "暂停监控";
                    }

                    if (current_nature_rank == -1)
                    {
                        return "未找到排名";
                    }
                    else if (current_nature_rank == 0)
                    {
                        return "正在查询";
                    }
                    else if (current_nature_rank > lowest_nature_rank || current_nature_rank < highest_nature_rank)
                    {
                        return string.Format("{0}，不在区间{1}至{2}", current_nature_rank, highest_nature_rank, lowest_nature_rank);
                    }
                    else
                    {
                        return current_nature_rank.ToString();
                    }
                }
                else
                {
                    return "暂停监控";
                }
            }
        }

        /// <summary>
        /// 期望最低自然排名
        /// </summary>
        public int lowest_nature_rank { get; set; }

        /// <summary>
        /// 期望最高自然排名
        /// </summary>
        public int highest_nature_rank { get; set; }

        /// <summary>
        /// 宝贝当前的直通车排名，-1表示在前10页中未能找到排名，0表示正在抓取排名
        /// </summary>
        public int current_ztc_rank { get; set; }

        /// <summary>
        /// 当前直通车排名的呈现
        /// </summary>
        public string current_ztc_rank_display
        {
            get
            {
                if (is_enable)
                {
                    if (lowest_ztc_rank == 0 && highest_ztc_rank == 0)
                    {
                        return "暂停监控";
                    }

                    if (current_ztc_rank == -1)
                    {
                        return "未找到排名";
                    }
                    else if (current_ztc_rank == 0)
                    {
                        return "正在查询";
                    }
                    else if (current_ztc_rank > lowest_ztc_rank || current_ztc_rank < highest_ztc_rank)
                    {
                        return string.Format("{0}，不在区间{1}至{2}", current_ztc_rank, highest_ztc_rank, lowest_ztc_rank);
                    }
                    else
                    {
                        return current_ztc_rank.ToString();
                    }
                }
                else
                {
                    return "暂停监控";
                }
            }
        }

        /// <summary>
        /// 期望最低直通车排名
        /// </summary>
        public int lowest_ztc_rank { get; set; }

        /// <summary>
        /// 期望最高直通车排名
        /// </summary>
        public int highest_ztc_rank { get; set; }

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
        /// 是否短信通知排名超出范围
        /// </summary>
        public Boolean is_sms_notify { get; set; }

        /// <summary>
        /// 是否邮件通知排名超出范围
        /// </summary>
        public Boolean is_mail_notify { get; set; }

        /// <summary>
        /// 排名超出范围的通知方式，显示值
        /// </summary>
        public string notify_display
        {
            get
            {
                if (is_sms_notify && is_mail_notify)
                {
                    return "短信，邮件";
                }
                else if (is_sms_notify && !is_mail_notify)
                {
                    return "短信";
                }
                else if (!is_sms_notify && is_mail_notify)
                {
                    return "邮件";
                }
                else
                    return "无";
            }
        }

        /// <summary>
        /// 是否有效
        /// </summary>
        public Boolean is_enable { get; set; }

        /// <summary>
        /// 是否完成排名查询
        /// </summary>
        public Boolean is_complete_search { get; set; }

        #region
        /// <summary>
        /// 是否被用户删除，true已删除，false未删除，属于扩充字段不存数据库，只在业务逻辑中使用
        /// </summary>
        public Boolean is_delete_by_user { get; set; }
        #endregion

    }
}
