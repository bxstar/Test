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
    /// <summary>
    /// 用户业务类
    /// </summary>
    public class BllUser
    {
        /// <summary>
        /// 增加用户
        /// </summary>
        public int Add(EntityUser model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into t_user(");
            strSql.Append("end_date,create_time,update_time,user_name,pwd,email,phone,mac_address,ip_address,cpu,mem,os,user_level,start_date");
            strSql.Append(") values (");
            strSql.Append("@end_date,@create_time,@update_time,@user_name,@pwd,@email,@phone,@mac_address,@ip_address,@cpu,@mem,@os,@user_level,@start_date");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
			            new SqlParameter("@end_date", SqlDbType.Date,3) ,
                        new SqlParameter("@create_time", SqlDbType.DateTime) ,
                        new SqlParameter("@update_time", SqlDbType.DateTime) ,
                        new SqlParameter("@user_name", SqlDbType.NVarChar,50) ,
                        new SqlParameter("@pwd", SqlDbType.NVarChar,50) ,
                        new SqlParameter("@email", SqlDbType.VarChar,50) ,
                        new SqlParameter("@phone", SqlDbType.VarChar,50) ,
                        new SqlParameter("@mac_address", SqlDbType.VarChar,50) ,
                        new SqlParameter("@ip_address", SqlDbType.VarChar,50) ,
                        new SqlParameter("@cpu", SqlDbType.VarChar,50) ,
                        new SqlParameter("@mem", SqlDbType.VarChar,50) ,
                        new SqlParameter("@os", SqlDbType.VarChar,50) ,
                        new SqlParameter("@user_level", SqlDbType.TinyInt,1) ,
                        new SqlParameter("@start_date", SqlDbType.Date,3)
            };

            parameters[0].Value = model.end_date;
            parameters[1].Value = model.create_time;
            parameters[2].Value = model.update_time;
            parameters[3].Value = model.user_name;
            parameters[4].Value = model.pwd;
            parameters[5].Value = model.email;
            parameters[6].Value = model.phone;
            parameters[7].Value = model.mac_address;
            parameters[8].Value = model.ip_address;
            parameters[9].Value = model.cpu;
            parameters[10].Value = model.mem;
            parameters[11].Value = model.os;
            parameters[12].Value = model.user_level;
            parameters[13].Value = model.start_date;

            object obj = DataBase.ExecuteObject(strSql.ToString(),CommandType.Text, parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }

        }

        /// <summary>
        /// 得到用户
        /// </summary>
        public EntityUser Get(int user_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select user_id, end_date, create_time, update_time, user_name, pwd, email, phone, mac_address, ip_address, user_level, start_date  ");
            strSql.Append("  from t_user ");
            strSql.Append(" where user_id=@user_id");
            SqlParameter[] parameters = {
					new SqlParameter("@user_id", SqlDbType.Int,4)
			};
            parameters[0].Value = user_id;


            EntityUser model = new EntityUser();
            DataTable dt = DataBase.ExecuteTable(strSql.ToString(), parameters);

            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["user_id"].ToString() != "")
                {
                    model.user_id = int.Parse(dt.Rows[0]["user_id"].ToString());
                }
                if (dt.Rows[0]["end_date"].ToString() != "")
                {
                    model.end_date = DateTime.Parse(dt.Rows[0]["end_date"].ToString());
                }
                if (dt.Rows[0]["create_time"].ToString() != "")
                {
                    model.create_time = DateTime.Parse(dt.Rows[0]["create_time"].ToString());
                }
                if (dt.Rows[0]["update_time"].ToString() != "")
                {
                    model.update_time = DateTime.Parse(dt.Rows[0]["update_time"].ToString());
                }
                model.user_name = dt.Rows[0]["user_name"].ToString();
                model.pwd = dt.Rows[0]["pwd"].ToString();
                model.email = dt.Rows[0]["email"].ToString();
                model.phone = dt.Rows[0]["phone"].ToString();
                model.mac_address = dt.Rows[0]["mac_address"].ToString();
                model.ip_address = dt.Rows[0]["ip_address"].ToString();
                if (dt.Rows[0]["user_level"].ToString() != "")
                {
                    model.user_level = int.Parse(dt.Rows[0]["user_level"].ToString());
                }
                if (dt.Rows[0]["start_date"].ToString() != "")
                {
                    model.start_date = DateTime.Parse(dt.Rows[0]["start_date"].ToString());
                }

                return model;
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 得到用户
        /// </summary>
        public EntityUser Get(string user_name)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select user_id, end_date, create_time, update_time, user_name, pwd, email, phone, mac_address, ip_address, user_level, start_date  ");
            strSql.Append("  from t_user ");
            strSql.Append(" where user_name=@user_name");
            SqlParameter[] parameters = {
					new SqlParameter("@user_name", SqlDbType.NVarChar,50)
			};
            parameters[0].Value = user_name;


            EntityUser model = new EntityUser();
            DataTable dt = DataBase.ExecuteTable(strSql.ToString(), parameters);

            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["user_id"].ToString() != "")
                {
                    model.user_id = int.Parse(dt.Rows[0]["user_id"].ToString());
                }
                if (dt.Rows[0]["end_date"].ToString() != "")
                {
                    model.end_date = DateTime.Parse(dt.Rows[0]["end_date"].ToString());
                }
                if (dt.Rows[0]["create_time"].ToString() != "")
                {
                    model.create_time = DateTime.Parse(dt.Rows[0]["create_time"].ToString());
                }
                if (dt.Rows[0]["update_time"].ToString() != "")
                {
                    model.update_time = DateTime.Parse(dt.Rows[0]["update_time"].ToString());
                }
                model.user_name = dt.Rows[0]["user_name"].ToString();
                model.pwd = dt.Rows[0]["pwd"].ToString();
                model.email = dt.Rows[0]["email"].ToString();
                model.phone = dt.Rows[0]["phone"].ToString();
                model.mac_address = dt.Rows[0]["mac_address"].ToString();
                model.ip_address = dt.Rows[0]["ip_address"].ToString();
                if (dt.Rows[0]["user_level"].ToString() != "")
                {
                    model.user_level = int.Parse(dt.Rows[0]["user_level"].ToString());
                }
                if (dt.Rows[0]["start_date"].ToString() != "")
                {
                    model.start_date = DateTime.Parse(dt.Rows[0]["start_date"].ToString());
                }

                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 得到用户
        /// </summary>
        public EntityUser Get(string user_name,string pwd)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select user_id, end_date, create_time, update_time, user_name, pwd, email, phone, mac_address, ip_address, user_level, start_date  ");
            strSql.Append("  from t_user ");
            strSql.Append(" where user_name=@user_name and pwd=@pwd");
            SqlParameter[] parameters = {
					new SqlParameter("@user_name", SqlDbType.NVarChar,50),
                    new SqlParameter("@pwd", SqlDbType.NVarChar,50)
                                        };
            parameters[0].Value = user_name;
            parameters[1].Value = pwd;


            EntityUser model = new EntityUser();
            DataTable dt = DataBase.ExecuteTable(strSql.ToString(), parameters);

            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["user_id"].ToString() != "")
                {
                    model.user_id = int.Parse(dt.Rows[0]["user_id"].ToString());
                }
                if (dt.Rows[0]["end_date"].ToString() != "")
                {
                    model.end_date = DateTime.Parse(dt.Rows[0]["end_date"].ToString());
                }
                if (dt.Rows[0]["create_time"].ToString() != "")
                {
                    model.create_time = DateTime.Parse(dt.Rows[0]["create_time"].ToString());
                }
                if (dt.Rows[0]["update_time"].ToString() != "")
                {
                    model.update_time = DateTime.Parse(dt.Rows[0]["update_time"].ToString());
                }
                model.user_name = dt.Rows[0]["user_name"].ToString();
                model.pwd = dt.Rows[0]["pwd"].ToString();
                model.email = dt.Rows[0]["email"].ToString();
                model.phone = dt.Rows[0]["phone"].ToString();
                model.mac_address = dt.Rows[0]["mac_address"].ToString();
                model.ip_address = dt.Rows[0]["ip_address"].ToString();
                if (dt.Rows[0]["user_level"].ToString() != "")
                {
                    model.user_level = int.Parse(dt.Rows[0]["user_level"].ToString());
                }
                if (dt.Rows[0]["start_date"].ToString() != "")
                {
                    model.start_date = DateTime.Parse(dt.Rows[0]["start_date"].ToString());
                }

                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 得到用户
        /// </summary>
        public EntityUser GetByMac(string mac_address)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select user_id, end_date, create_time, update_time, user_name, pwd, email, phone, mac_address, ip_address, user_level, start_date  ");
            strSql.Append("  from t_user ");
            strSql.Append(" where mac_address=@mac_address");
            SqlParameter[] parameters = {
					new SqlParameter("@mac_address", SqlDbType.NVarChar,50)
			};
            parameters[0].Value = mac_address;


            EntityUser model = new EntityUser();
            DataTable dt = DataBase.ExecuteTable(strSql.ToString(), parameters);

            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["user_id"].ToString() != "")
                {
                    model.user_id = int.Parse(dt.Rows[0]["user_id"].ToString());
                }
                if (dt.Rows[0]["end_date"].ToString() != "")
                {
                    model.end_date = DateTime.Parse(dt.Rows[0]["end_date"].ToString());
                }
                if (dt.Rows[0]["create_time"].ToString() != "")
                {
                    model.create_time = DateTime.Parse(dt.Rows[0]["create_time"].ToString());
                }
                if (dt.Rows[0]["update_time"].ToString() != "")
                {
                    model.update_time = DateTime.Parse(dt.Rows[0]["update_time"].ToString());
                }
                model.user_name = dt.Rows[0]["user_name"].ToString();
                model.pwd = dt.Rows[0]["pwd"].ToString();
                model.email = dt.Rows[0]["email"].ToString();
                model.phone = dt.Rows[0]["phone"].ToString();
                model.mac_address = dt.Rows[0]["mac_address"].ToString();
                model.ip_address = dt.Rows[0]["ip_address"].ToString();
                if (dt.Rows[0]["user_level"].ToString() != "")
                {
                    model.user_level = int.Parse(dt.Rows[0]["user_level"].ToString());
                }
                if (dt.Rows[0]["start_date"].ToString() != "")
                {
                    model.start_date = DateTime.Parse(dt.Rows[0]["start_date"].ToString());
                }

                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 更新用户的计算机配置信息
        /// </summary>
        public void UpdateComputerInfo(int user_id, string cpu, string mem, string os)
        {
            string strSql = "update t_user set cpu=@cpu,mem=@mem,os=@os where user_id=@user_id";

            SqlParameter[] parameters = {
                        new SqlParameter("@cpu", SqlDbType.VarChar,50) ,
                        new SqlParameter("@mem", SqlDbType.VarChar,50) ,
                        new SqlParameter("@os", SqlDbType.VarChar,50) ,
                        new SqlParameter("@user_id", SqlDbType.Int,4) 
            };

            parameters[0].Value = cpu;
            parameters[1].Value = mem;
            parameters[2].Value = os;
            parameters[3].Value = user_id;

            DataBase.ExecuteNone(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 更新用户基本信息
        /// </summary>
        public void UpdateUserInfo(int user_id, string user_name, string phone, string email)
        {
            string strSql = "update t_user set user_name=@user_name,phone=@phone,email=@email where user_id=@user_id";

            SqlParameter[] parameters = {
                        new SqlParameter("@user_name", SqlDbType.VarChar,50) ,
                        new SqlParameter("@phone", SqlDbType.VarChar,50) ,
                        new SqlParameter("@email", SqlDbType.VarChar,50) ,
                        new SqlParameter("@user_id", SqlDbType.Int,4) 
            };

            parameters[0].Value = user_name;
            parameters[1].Value = phone;
            parameters[2].Value = email;
            parameters[3].Value = user_id;

            DataBase.ExecuteNone(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 更新用户密码
        /// </summary>
        public void UpdateUserPwd(int user_id, string pwd)
        {
            string strSql = "update t_user set pwd=@pwd where user_id=@user_id";

            SqlParameter[] parameters = {
                        new SqlParameter("@pwd", SqlDbType.VarChar,50) ,
                        new SqlParameter("@user_id", SqlDbType.Int,4) 
            };

            parameters[0].Value = pwd;
            parameters[1].Value = user_id;

            DataBase.ExecuteNone(strSql.ToString(), parameters);
        }
    }
}