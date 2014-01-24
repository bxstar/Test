using System;
using System.Collections.Generic;
using System.Text;
using DianChe.Model;
using System.Data;
using Common.DB;

namespace DianChe.BLL
{
    /// <summary>
    /// 宝贝点击业务类
    /// </summary>
    public class BllItemClick
    {
        /// <summary>
        /// 获取宝贝点击列表
        /// </summary>
        public List<EntityItemClick> GetItemClick()
        {
            List<EntityItemClick> lst = new List<EntityItemClick>();
            string strSql = "select * from t_item_click";

            DataTable dt = DataBase.ExecuteTable(strSql);
            if (dt != null  && dt.Rows.Count != 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dr = dt.Rows[i];
                    EntityItemClick model = new EntityItemClick();
                    model.local_id = Convert.ToInt64(dr["local_id"]);
                    model.item_id = Convert.ToInt64(dr["item_id"]);
                    model.item_title = dr["item_title"].ToString();
                    model.creative_one_title = dr["creative_one_title"].ToString();
                    model.creative_two_title = dr["creative_two_title"].ToString();
                    model.keyword = dr["keyword"].ToString();
                    model.create_time = Convert.ToDateTime(dr["create_time"]);
                    model.update_time = Convert.ToDateTime(dr["update_time"]);
                    if (dr["is_succeed"] != DBNull.Value)
                        model.is_succeed = Convert.ToBoolean(dr["is_succeed"]);
                    lst.Add(model);
                }
            }

            return lst;
        }

        /// <summary>
        /// 根据点击ID获取宝贝
        /// </summary>
        public EntityItemClick GetItemClickById(long local_id)
        {
            EntityItemClick model = new EntityItemClick();
            string strSql = string.Format("select * from t_item_click where local_id={0}", local_id);

            DataTable dt = DataBase.ExecuteTable(strSql);
            if (dt != null && dt.Rows.Count != 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dr = dt.Rows[i];

                    model.local_id = Convert.ToInt64(dr["local_id"]);
                    model.item_id = Convert.ToInt64(dr["item_id"]);
                    model.item_title = dr["item_title"].ToString();
                    model.creative_one_title = dr["creative_one_title"].ToString();
                    model.creative_two_title = dr["creative_two_title"].ToString();
                    model.keyword = dr["keyword"].ToString();
                    model.create_time = Convert.ToDateTime(dr["create_time"]);
                    model.update_time = Convert.ToDateTime(dr["update_time"]);
                    if (dr["is_succeed"] != DBNull.Value)
                        model.is_succeed = Convert.ToBoolean(dr["is_succeed"]);
                }
            }
            return model;
        }

        /// <summary>
        /// 设置宝贝点击成功状态
        /// </summary>
        public void SetItemClickSucceed(EntityItemClick model)
        {
            string strSql = string.Format("update t_item_click set is_succeed={0},update_time='{1}' where local_id={2}", model.is_succeed.Value ? 1 : 0, DateTime.Now.ToString("s"), model.local_id);
            int reuslt = DataBase.ExecuteNone(strSql);
        }

        /// <summary>
        /// 新增宝贝点击任务
        /// </summary>
        public void AddItemClick(EntityItemClick model)
        {
            string strSql = string.Format("insert into t_item_click(item_id,item_title,creative_one_title,creative_two_title,keyword,create_time,update_time) values (" +
            "{0},'{1}','{2}','{3}','{4}','{5}','{6}')", model.item_id, model.item_title, model.creative_one_title, model.creative_two_title, model.keyword, model.create_time.ToString("s"), model.update_time.ToString("s"));

            int reuslt = DataBase.ExecuteNone(strSql);
        }
    }
}
