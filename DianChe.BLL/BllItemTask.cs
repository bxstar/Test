using System;
using System.Collections.Generic;
using System.Text;
using DianChe.Model;
using Common.DB;
using System.Data.SQLite;
using System.Data;

namespace DianChe.BLL
{
    /// <summary>
    /// 我的宝贝业务类
    /// </summary>
    public class BllItemTask
    {
        public List<EntityItemTask> GetMyItem()
        {
            List<EntityItemTask> lstMyItem = new List<EntityItemTask>();
            string strSql = "select * from t_item_task";
            DataTable dt = DataBase.ExecuteTable(strSql);
            if (dt != null && dt.Rows.Count != 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dr = dt.Rows[i];
                    EntityItemTask model = new EntityItemTask();
                    model.local_item_task_id = new Guid(dr["local_item_task_id"].ToString());
                    model.item_id = Convert.ToInt64(dr["item_id"]);
                    model.nick = dr["nick"].ToString();
                    model.item_title = dr["item_title"].ToString();
                    model.img_url = dr["img_url"].ToString();
                    model.img_data = dr["img_data"] as byte[];
                    if (dr["price"] != DBNull.Value)
                        model.price = Convert.ToDecimal(dr["price"]);
                    if (dr["max_click"] != DBNull.Value)
                        model.max_click = Convert.ToInt32(dr["max_click"]);
                    if (dr["run_days"] != DBNull.Value)
                        model.run_days = Convert.ToInt32(dr["run_days"]);
                    model.creative_one_title = dr["creative_one_title"].ToString();
                    model.creative_two_title = dr["creative_two_title"].ToString();
                    model.keyword = dr["keyword"].ToString();
                    model.effect_start_time = dr["effect_start_time"].ToString();
                    model.effect_end_time = dr["effect_end_time"].ToString();
                    model.create_time = Convert.ToDateTime(dr["create_time"]);
                    model.update_time = Convert.ToDateTime(dr["update_time"]);
                    model.remark = dr["remark"].ToString();
                    if (dr["is_enable"] != DBNull.Value)
                        model.is_enable = Convert.ToBoolean(dr["is_enable"]);
                    lstMyItem.Add(model);
                }
            }

            return lstMyItem;
        }

        /// <summary>
        /// 增加我的宝贝
        /// </summary>
        public void AddMyItem(EntityItemTask model)
        {
			StringBuilder sbSql=new StringBuilder();
			sbSql.Append("insert into t_item_task(");
            sbSql.Append("local_item_task_id,item_id,creative_two_title,keyword,effect_start_time,effect_end_time,create_time,update_time,is_enable,nick,item_title,img_url,img_data,price,max_click,run_days,creative_one_title,remark");
			sbSql.Append(") values (");
            sbSql.Append("'{0}',{1},'{2}','{3}','{4}','{5}','{6}','{7}',{8},'{9}','{10}','{11}',@img_data,{12},{13},{14},'{15}','{16}'");
            sbSql.Append(") ");

            string strSql = string.Format(sbSql.ToString(), model.local_item_task_id.ToString(), model.item_id, model.creative_two_title, model.keyword, model.effect_start_time, model.effect_end_time, model.create_time.ToString("s"), model.update_time.ToString("s"),
                model.is_enable ? 1 : 0, model.nick, model.item_title, model.img_url, model.price, model.max_click, model.run_days, model.creative_one_title, model.remark);

            SQLiteParameter[] ps = new SQLiteParameter[1];
            ps[0] = new SQLiteParameter("@img_data", DbType.Binary);
            ps[0].Size = 55000;
            ps[0].Value = model.img_data;

            DataBase.ExecuteNone(strSql, ps);
        }


        /// <summary>
        /// 删除宝贝
        /// </summary>
        public void DeleteMyItem(Guid local_item_task_id)
        {
            string strSql = string.Format("delete from t_item_task where local_item_task_id='{0}'", local_item_task_id.ToString());
            DataBase.ExecuteNone(strSql);
        }

        /// <summary>
        /// 编辑宝贝
        /// </summary>
        public void EditMyItem(EntityItemTask model)
        {
            string strSql = string.Format("update t_item_task set creative_one_title='{0}',creative_two_title='{1}',effect_start_time='{2}',effect_end_time='{3}', item_title='{4}',price={5},remark='{6}',update_time='{7}' where local_item_task_id='{8}'"
                , model.creative_one_title, model.creative_two_title, model.effect_start_time, model.effect_end_time, model.item_title, model.price, model.remark, model.update_time.ToString("s"), model.local_item_task_id);
            DataBase.ExecuteNone(strSql);
        }
        
    }
}
