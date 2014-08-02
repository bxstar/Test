using System;
using System.Collections.Generic;
using System.Text;
using DianChe.Model;
using System.Data.SQLite;
using Common.DB;
using System.Data;

namespace DianChe.BLL
{
    /// <summary>
    /// 宝贝排名监控业务类
    /// </summary>
    public class BllItemRank
    {
        /// <summary>
        /// 增加需要监控排名的宝贝
        /// </summary>
        public void AddMyItem(EntityItemRank model)
        {
            StringBuilder sbSql = new StringBuilder();
            sbSql.Append("insert into t_item_rank(");
            sbSql.Append("local_item_rank_id,item_id,keyword,create_time,update_time,is_sms_notify,is_mail_notify,is_enable,nick,item_title,img_url,img_data,price,lowest_nature_rank,highest_nature_rank,lowest_ztc_rank,highest_ztc_rank,remark");
            sbSql.Append(") values (");
            sbSql.Append("'{0}',{1},'{2}','{3}','{4}',{5},{6},{7},'{7}','{9}','{10}',@img_data,{11},{12},{13},{14},{15},'{16}'");
            sbSql.Append(") ");

            string strSql = string.Format(sbSql.ToString(), model.local_item_rank_id.ToString(), model.item_id, model.keyword, model.create_time.ToString("s"), model.update_time.ToString("s"),
                model.is_sms_notify ? 1 : 0, model.is_mail_notify ? 1 : 0, model.is_enable ? 1 : 0, model.nick, model.item_title, model.img_url, model.price, model.lowest_nature_rank, model.highest_nature_rank, model.lowest_ztc_rank, model.highest_ztc_rank, model.remark);

            SQLiteParameter[] ps = new SQLiteParameter[1];
            ps[0] = new SQLiteParameter("@img_data", DbType.Binary);
            ps[0].Size = 55000;
            ps[0].Value = model.img_data;

            DataBase.ExecuteNone(strSql, ps);
        }

        /// <summary>
        /// 获取需要监控排名的宝贝
        /// </summary>
        public List<EntityItemRank> GetItem()
        {
            List<EntityItemRank> lstItem = new List<EntityItemRank>();
            string strSql = "select * from t_item_rank";
            DataTable dt = DataBase.ExecuteTable(strSql);
            if (dt != null && dt.Rows.Count != 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dr = dt.Rows[i];
                    EntityItemRank model = new EntityItemRank();
                    model.local_item_rank_id = new Guid(dr["local_item_rank_id"].ToString());
                    model.item_id = Convert.ToInt64(dr["item_id"]);
                    model.nick = dr["nick"].ToString();
                    model.item_title = dr["item_title"].ToString();
                    model.img_url = dr["img_url"].ToString();
                    model.img_data = dr["img_data"] as byte[];
                    if (dr["price"] != DBNull.Value)
                        model.price = Convert.ToDecimal(dr["price"]);
                    if (dr["current_nature_rank"] != DBNull.Value)
                        model.current_nature_rank = Convert.ToInt32(dr["current_nature_rank"]);
                    if (dr["lowest_nature_rank"] != DBNull.Value)
                        model.lowest_nature_rank = Convert.ToInt32(dr["lowest_nature_rank"]);
                    if (dr["highest_nature_rank"] != DBNull.Value)
                        model.highest_nature_rank = Convert.ToInt32(dr["highest_nature_rank"]);
                    if (dr["current_ztc_rank"] != DBNull.Value)
                        model.current_ztc_rank = Convert.ToInt32(dr["current_ztc_rank"]);
                    if (dr["lowest_ztc_rank"] != DBNull.Value)
                        model.lowest_ztc_rank = Convert.ToInt32(dr["lowest_ztc_rank"]);
                    if (dr["highest_ztc_rank"] != DBNull.Value)
                        model.highest_ztc_rank = Convert.ToInt32(dr["highest_ztc_rank"]);
                    model.keyword = dr["keyword"].ToString();
                    model.create_time = Convert.ToDateTime(dr["create_time"]);
                    model.update_time = Convert.ToDateTime(dr["update_time"]);
                    model.remark = dr["remark"].ToString();
                    model.is_sms_notify = Convert.ToBoolean(dr["is_sms_notify"]);
                    model.is_mail_notify = Convert.ToBoolean(dr["is_mail_notify"]);
                    if (dr["is_enable"] != DBNull.Value)
                        model.is_enable = Convert.ToBoolean(dr["is_enable"]);

                    model.is_delete_by_user = false;
                    lstItem.Add(model);
                }
            }

            return lstItem;
        }

        /// <summary>
        /// 通过本地主键获取宝贝
        /// </summary>
        public EntityItemRank GetItem(Guid local_item_rank_id)
        {
            EntityItemRank model = new EntityItemRank();
            string strSql = string.Format("select * from t_item_rank where local_item_rank_id='{0}'", local_item_rank_id.ToString());
            DataTable dt = DataBase.ExecuteTable(strSql);
            if (dt != null && dt.Rows.Count != 0)
            {
                DataRow dr = dt.Rows[0];
                model.local_item_rank_id = new Guid(dr["local_item_rank_id"].ToString());
                model.item_id = Convert.ToInt64(dr["item_id"]);
                model.nick = dr["nick"].ToString();
                model.item_title = dr["item_title"].ToString();
                model.img_url = dr["img_url"].ToString();
                model.img_data = dr["img_data"] as byte[];
                if (dr["price"] != DBNull.Value)
                    model.price = Convert.ToDecimal(dr["price"]);
                if (dr["current_nature_rank"] != DBNull.Value)
                    model.current_nature_rank = Convert.ToInt32(dr["current_nature_rank"]);
                if (dr["lowest_nature_rank"] != DBNull.Value)
                    model.lowest_nature_rank = Convert.ToInt32(dr["lowest_nature_rank"]);
                if (dr["highest_nature_rank"] != DBNull.Value)
                    model.highest_nature_rank = Convert.ToInt32(dr["highest_nature_rank"]);
                if (dr["current_ztc_rank"] != DBNull.Value)
                    model.current_ztc_rank = Convert.ToInt32(dr["current_ztc_rank"]);
                if (dr["lowest_ztc_rank"] != DBNull.Value)
                    model.lowest_ztc_rank = Convert.ToInt32(dr["lowest_ztc_rank"]);
                if (dr["highest_ztc_rank"] != DBNull.Value)
                    model.highest_ztc_rank = Convert.ToInt32(dr["highest_ztc_rank"]);
                model.keyword = dr["keyword"].ToString();
                model.create_time = Convert.ToDateTime(dr["create_time"]);
                model.update_time = Convert.ToDateTime(dr["update_time"]);
                model.remark = dr["remark"].ToString();
                model.is_sms_notify = Convert.ToBoolean(dr["is_sms_notify"]);
                model.is_mail_notify = Convert.ToBoolean(dr["is_mail_notify"]);
                if (dr["is_enable"] != DBNull.Value)
                    model.is_enable = Convert.ToBoolean(dr["is_enable"]);
                model.is_delete_by_user = false;
            }

            return model;
        }

        /// <summary>
        /// 更新监控的宝贝
        /// </summary>
        public void UpdateItem(EntityItemRank item)
        {
            string strSql = string.Format("update t_item_rank set item_title='{0}',price={1},keyword='{2}',lowest_nature_rank={3},highest_nature_rank={4},lowest_ztc_rank={5},highest_ztc_rank={6},remark='{7}',update_time='{8}',is_sms_notify={9},is_mail_notify={10} where local_item_rank_id='{11}'"
                , item.item_title, item.price, item.keyword, item.lowest_nature_rank, item.highest_nature_rank, item.lowest_ztc_rank, item.highest_ztc_rank, item.remark, item.update_time.ToString("s"), item.is_sms_notify ? 1 : 0, item.is_mail_notify ? 1 : 0, item.local_item_rank_id);
            DataBase.ExecuteNone(strSql);
        }

        /// <summary>
        /// 设置宝贝的监控状态
        /// </summary>
        public void SetItemEnable(Boolean is_enable, string local_item_rank_id)
        {
            string strSql = string.Format("update t_item_rank set is_enable={0} where local_item_rank_id='{1}'"
                , is_enable ? 1 : 0, local_item_rank_id);
            DataBase.ExecuteNone(strSql);
        }

        /// <summary>
        /// 根据关键词设置宝贝的查询完成状态
        /// </summary>
        public void SetItemCompleteStatus(Boolean is_complete_search, string keyword)
        {
            string strSql = string.Format("update t_item_rank set is_complete_search={0} where is_enable=1 and keyword='{1}'"
    , is_complete_search ? 1 : 0, keyword);
            DataBase.ExecuteNone(strSql);
        }

        /// <summary>
        /// 根据关键词获取宝贝的查询完成状态
        /// </summary>
        public Boolean GetItemCompleteStatus(string keyword)
        {
            string strSql = string.Format("select local_item_rank_id from t_item_rank where is_enable=1 and keyword='{0}' and is_complete_search=1", keyword);
            object o = DataBase.ExecuteObject(strSql);
            if (o != null && o != DBNull.Value)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 设置宝贝的自然排名
        /// </summary>
        public void SetItemNatureRank(List<EntityItemRank> lstItemRank)
        {
            foreach (var item in lstItemRank)
            {
                string strSql = string.Format("update t_item_rank set current_nature_rank={0},is_complete_search=1,update_time='{1}' where item_id={2} and keyword='{3}'"
    , item.current_nature_rank, DateTime.Now.ToString("s"), item.item_id, item.keyword);
                DataBase.ExecuteNone(strSql);
            }
        }

        /// <summary>
        /// 设置宝贝的直通车排名
        /// </summary>
        public void SetItemZtcRank(List<EntityItemRank> lstItemRank)
        {
            foreach (var item in lstItemRank)
            {
                string strSql = string.Format("update t_item_rank set current_ztc_rank={0},update_time='{1}' where item_id={2} and keyword='{3}'"
    , item.current_ztc_rank, DateTime.Now.ToString("s"), item.item_id, item.keyword);
                DataBase.ExecuteNone(strSql);
            }
        }

        /// <summary>
        /// 删除监控的宝贝
        /// </summary>
        public void DeleteItem(EntityItemRank item)
        {
            string strSql = string.Format("delete from t_item_rank where local_item_rank_id='{0}'", item.local_item_rank_id);
            DataBase.ExecuteNone(strSql);
        }
    }
}
