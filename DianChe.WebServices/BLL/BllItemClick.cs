﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DianChe.Model;
using System.Data.SqlClient;
using System.Text;
using System.Data;

namespace DianChe.WebServices.BLL
{
    public class BllItemClick
    {
        public string AddItemTask(EntityItemTask model)
        {
            string result = string.Empty;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into t_item_task(");
            strSql.Append("local_item_task_id,creative_two_title,keyword,create_time,update_time,remark,is_enable,item_id,nick,item_title,img_url,price,max_click,run_days,creative_one_title");
            strSql.Append(") values (");
            strSql.Append("@local_item_task_id,@creative_two_title,@keyword,@create_time,@update_time,@remark,@is_enable,@item_id,@nick,@item_title,@img_url,@price,@max_click,@run_days,@creative_one_title");
            strSql.Append(") ");

            SqlParameter[] parameters = {
			            new SqlParameter("@local_item_task_id", SqlDbType.UniqueIdentifier,16) ,            
                        new SqlParameter("@creative_two_title", SqlDbType.VarChar,100) ,            
                        new SqlParameter("@keyword", SqlDbType.VarChar,100) ,            
                        new SqlParameter("@create_time", SqlDbType.DateTime) ,            
                        new SqlParameter("@update_time", SqlDbType.DateTime) ,            
                        new SqlParameter("@remark", SqlDbType.VarChar,1000) ,            
                        new SqlParameter("@is_enable", SqlDbType.Bit,1) ,            
                        new SqlParameter("@item_id", SqlDbType.BigInt,8) ,            
                        new SqlParameter("@nick", SqlDbType.VarChar,100) ,            
                        new SqlParameter("@item_title", SqlDbType.VarChar,100) ,            
                        new SqlParameter("@img_url", SqlDbType.VarChar,100) ,            
                        new SqlParameter("@price", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@max_click", SqlDbType.Int,4) ,            
                        new SqlParameter("@run_days", SqlDbType.Int,4) ,            
                        new SqlParameter("@creative_one_title", SqlDbType.VarChar,100)             
              
            };

            parameters[0].Value = model.local_item_task_id;
            parameters[1].Value = model.creative_two_title;
            parameters[2].Value = model.keyword;
            parameters[3].Value = model.create_time;
            parameters[4].Value = model.update_time;
            parameters[5].Value = model.remark;
            parameters[6].Value = model.is_enable;
            parameters[7].Value = model.item_id;
            parameters[8].Value = model.nick;
            parameters[9].Value = model.item_title;
            parameters[10].Value = model.img_url;
            parameters[11].Value = model.price;
            parameters[12].Value = model.max_click;
            parameters[13].Value = model.run_days;
            parameters[14].Value = model.creative_one_title;

            DataBase.ExecuteNone(strSql.ToString(),parameters);

            return result;
        }

        /// <summary>
        /// 分配点击任务
        /// </summary>
        public List<EntityItemClick> DispatchItemClick(string mac_address, string ip_address)
        {
            List<EntityItemClick> lst = new List<EntityItemClick>();
            SqlParameter[] parameters = {
			            new SqlParameter("@max_address", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@ip_address", SqlDbType.VarChar,50)           
              
            };

            parameters[0].Value = mac_address;
            parameters[1].Value = ip_address;

            DataSet ds = DataBase.ExecuteDataSet("proc_dispatch_item_click",parameters);
            if (ds != null && ds.Tables.Count != 0 && ds.Tables[0].Rows.Count != 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    EntityItemClick model = new EntityItemClick();
                    DataRow dr = ds.Tables[0].Rows[i];
                    model.item_id = Convert.ToInt64(dr["item_id"]);
                    model.local_item_task_id = Guid.Parse(dr["local_item_task_id"].ToString());
                    model.nick = dr["nick"].ToString();
                    model.creative_one_title = dr["creative_one_title"].ToString();
                    model.creative_two_title = dr["creative_two_title"].ToString();
                    model.keyword = dr["keyword"].ToString();
                    lst.Add(model);
                }
            }

            return lst;
        }

    }
}