using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DianChe.Model;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace DianChe.WebServices.BLL
{
    public class BllMsg
    {
        public static void AddMsg(EntityMsg model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into t_msg(");
            strSql.Append("update_time,msg_from,msg_to,msg_subject,msg_content,msg_type,file_path,send_status,create_time");
            strSql.Append(") values (");
            strSql.Append("@update_time,@msg_from,@msg_to,@msg_subject,@msg_content,@msg_type,@file_path,@send_status,@create_time");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
			            new SqlParameter("@update_time", SqlDbType.DateTime) ,
                        new SqlParameter("@msg_from", SqlDbType.VarChar,50) ,
                        new SqlParameter("@msg_to", SqlDbType.VarChar,50) ,
                        new SqlParameter("@msg_subject", SqlDbType.NVarChar,50) ,
                        new SqlParameter("@msg_content", SqlDbType.NVarChar,4000) ,
                        new SqlParameter("@msg_type", SqlDbType.NVarChar,10) ,
                        new SqlParameter("@file_path", SqlDbType.VarChar,100) ,
                        new SqlParameter("@send_status", SqlDbType.TinyInt,1) ,
                        new SqlParameter("@create_time", SqlDbType.DateTime)
            };

            parameters[0].Value = model.update_time;
            parameters[1].Value = model.msg_from;
            parameters[2].Value = model.msg_to;
            parameters[3].Value = model.msg_subject;
            parameters[4].Value = model.msg_content;
            parameters[5].Value = model.msg_type;
            parameters[6].Value = model.file_path;
            parameters[7].Value = model.send_status;
            parameters[8].Value = model.create_time;

            DataBase.ExecuteNone(strSql.ToString(), parameters);
        }

        public static List<EntityMsg> GetMsg(string msg_type)
        {
            List<EntityMsg> lstMsg = new List<EntityMsg>();
            string strSql = string.Format("select * from t_msg where send_status = 0 and msg_type='{0}' ", msg_type);
            DataSet ds = DataBase.ExecuteDataSet(strSql);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    EntityMsg model = new EntityMsg();
                    DataRow dr = ds.Tables[0].Rows[i];
                    if (dr["local_msg_id"].ToString() != "")
                    {
                        model.local_msg_id = long.Parse(dr["local_msg_id"].ToString());
                    }
                    model.msg_from = dr["msg_from"].ToString();
                    model.msg_to = dr["msg_to"].ToString();
                    model.msg_subject = dr["msg_subject"].ToString();
                    model.msg_content = dr["msg_content"].ToString();
                    model.msg_type = dr["msg_type"].ToString();
                    model.file_path = dr["file_path"].ToString();
                    if (dr["send_status"].ToString() != "")
                    {
                        model.send_status = int.Parse(dr["send_status"].ToString());
                    }
                    if (dr["update_time"].ToString() != "")
                    {
                        model.update_time = DateTime.Parse(dr["update_time"].ToString());
                    }
                    if (dr["create_time"].ToString() != "")
                    {
                        model.create_time = DateTime.Parse(dr["create_time"].ToString());
                    }
                    lstMsg.Add(model);
                }
                
            }

            return lstMsg;
        }

        /// <summary>
        /// 更新信息发送状态
        /// </summary>
        /// <param name="msg"></param>
        public static void UpdateMsgStatus(EntityMsg msg)
        {
            string strSql = string.Format("update t_msg set send_status={0},update_time=getdate() where local_msg_id={1}", msg.send_status, msg.local_msg_id);
            DataBase.ExecuteNone(strSql.ToString());
        }
    }
}