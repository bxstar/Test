using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DianChe.WebServices
{

    public class DataBase {


        public static string ConnString = ConfigurationManager.ConnectionStrings["MainDB"].ConnectionString;

        #region Execute and return DataSet or DataTable
        public static DataSet ExecuteDataSet(string SQL) {
            using (SqlDataAdapter adapter = new SqlDataAdapter(SQL, ConnString)) {
                DataSet ds = new DataSet();
#if DEBUG
                try {
                    adapter.Fill(ds);   //adapter.FillSchema(ds,SchemaType.Mapped);
                } catch (Exception ex){
                    throw new Exception(ex.Message + " 数据库操作错误，请检测SQL语句："+SQL);
                }
#else
                adapter.Fill(ds);   //adapter.FillSchema(ds,SchemaType.Mapped);
#endif
                return ds;
            }
        }

        /// <summary>
        /// 执行带参数的存储过程
        /// </summary>
        public static DataSet ExecuteDataSet(string spName, SqlParameter[] sps) {
            using (SqlDataAdapter adapter = new SqlDataAdapter()) {
                SqlCommand cmd = new SqlCommand(spName, new SqlConnection(ConnString));
                cmd.CommandType = CommandType.StoredProcedure;
                foreach (SqlParameter p in sps) {
                    cmd.Parameters.Add(p);
                }
                adapter.SelectCommand = cmd;
                DataSet ds = new DataSet();
                adapter.Fill(ds);   //adapter.FillSchema(ds,SchemaType.Mapped);
                return ds;
            }
        }

        public static DataTable ExecuteTable(string SQL) {
            return ExecuteDataSet(SQL).Tables[0];
        }

        /// <summary>
        /// 执行带参数的Sql语句
        /// </summary>
        public static DataTable ExecuteTable(string SQL, SqlParameter[] sps)
        {
            using (SqlDataAdapter adapter = new SqlDataAdapter())
            {
                SqlCommand cmd = new SqlCommand(SQL, new SqlConnection(ConnString));
                cmd.CommandType = CommandType.Text;
                foreach (SqlParameter p in sps)
                {
                    cmd.Parameters.Add(p);
                }
                adapter.SelectCommand = cmd;
                DataSet ds = new DataSet();
                adapter.Fill(ds);   
                if (ds.Tables.Count > 0)
                    return ds.Tables[0];
                else
                    return null;
            }
        }

        public static DataRow ExecuteRow(string SQL) {
            DataTable t = ExecuteDataSet(SQL).Tables[0];
            if (t.Rows.Count == 1)
                return t.Rows[0];
            return null;
        }

        public static DataRow ExecuteRow(string SQL, params object[] args) {
            return ExecuteRow(string.Format(SQL, args));
        }



        public static  DataRow ExecuteRow(string spName, SqlParameter[] sps)
        {
            DataTable t = ExecuteDataSet( spName, sps).Tables[0];
            if (t.Rows.Count == 1)
                return t.Rows[0];
            return null; 
        }
        #endregion

        #region Execute None
        public static int ExecuteNone(string SQL) {
            using (SqlConnection conn = new SqlConnection(ConnString)) {
                SqlCommand cmd = new SqlCommand(SQL, conn);
                cmd.CommandType = CommandType.Text;
                conn.Open();
#if DEBUG
                try {
                    return cmd.ExecuteNonQuery();
                } catch (Exception ex) {
                    throw new Exception(ex.Message + " 数据库操作错误，请检测SQL语句：" + SQL);
                }
#else
                return cmd.ExecuteNonQuery();
#endif
            }
        }

        public static int ExecuteNone(string SQL, params object[] args) {
            return ExecuteNone(string.Format(SQL, args));
        }

        public static int ExecuteNone(string SQL, SqlParameter[] ps) {
            using (SqlConnection conn = new SqlConnection(ConnString)) {
                SqlCommand cmd = new SqlCommand(SQL, conn);
                cmd.CommandType = CommandType.Text;
                foreach (SqlParameter p in ps) {
                    cmd.Parameters.Add(p);
                }
                conn.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        public static int ExecuteSpNone(string spName, SqlParameter[] ps)
        {
            using (SqlConnection conn = new SqlConnection(ConnString))
            {
                SqlCommand cmd = new SqlCommand(spName, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                foreach (SqlParameter p in ps)
                {
                    cmd.Parameters.Add(p);
                }
                conn.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        public static int ExecuteTransSpNone(string spName, SqlParameter[] ps)
        {
            int i = -1;
            using (SqlConnection conn = new SqlConnection(ConnString))
            {
                SqlTransaction trans = null;
                
                conn.Open();
                trans = conn.BeginTransaction();
                SqlCommand cmd = new SqlCommand(spName, conn,trans);
                cmd.CommandType = CommandType.StoredProcedure;
                foreach (SqlParameter p in ps)
                {
                    cmd.Parameters.Add(p);
                }

                try
                {
                    
                    i = cmd.ExecuteNonQuery();
                    trans.Commit();
                    return i;
                }
                catch (SqlException se)
                {
                    if(trans!=null)
                        trans.Rollback();
                    throw se;
                }
                finally
                {
                    if (trans != null)
                        trans.Dispose();
                }
            }
        }
        #endregion

        #region Execute DataReader
        public static IDataReader ExecuteReader(string SQL) {
            /*using (SqlConnection conn = new SqlConnection(ConnString)) {
                SqlCommand cmd = new SqlCommand(SQL, conn);
                conn.Open();
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }*/
            SqlConnection conn = new SqlConnection(ConnString);
            SqlCommand cmd = new SqlCommand(SQL, conn);
            conn.Open();
            return cmd.ExecuteReader(CommandBehavior.CloseConnection);
        }
        public static IDataReader ExecuteReader(string SQL, params object[] args) {
            return ExecuteReader(string.Format(SQL, args));
        }
        #endregion

        #region Execute object
        public static Object ExecuteObject(string SQL) {
            using (SqlConnection conn = new SqlConnection(ConnString)) {
                SqlCommand cmd = new SqlCommand(SQL, conn);
                cmd.CommandType = CommandType.Text;
                conn.Open();
#if DEBUG
                try {
                    return cmd.ExecuteScalar();
                } catch (Exception ex) {
                    throw new Exception(ex.Message + " 数据库操作错误，请检测SQL语句：" + SQL);
                }
#else
                return cmd.ExecuteScalar();
#endif
            }
        }

        public static object ExecuteObject(string SQL, params object[] args) {
            return ExecuteObject(string.Format(SQL, args));
        }


        public static object ExecuteObject(string SQL, CommandType type, SqlParameter[] ps)
        {
            using (SqlConnection conn = new SqlConnection(ConnString))
            {
                SqlCommand cmd = new SqlCommand(SQL, conn);
                cmd.CommandType = type;
                foreach (SqlParameter p in ps)
                {
                    cmd.Parameters.Add(p);
                }
                conn.Open();
                return cmd.ExecuteScalar();
            }
        }
        #endregion

        #region Execute trans
        public static int ExecuteTrans(string sql) {
            SqlConnection conn = new SqlConnection(ConnString);
            conn.Open();
            SqlTransaction trans = conn.BeginTransaction();
            try {
                SqlCommand cmd = new SqlCommand(sql, conn, trans);
                cmd.CommandType = CommandType.Text;
                int r = cmd.ExecuteNonQuery();
                trans.Commit();
                return r;
            } catch (Exception ex) {
                trans.Rollback();
                throw ex;
            } finally {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }
        public static int ExecuteTrans(string SQL, params object[] args) {
            return ExecuteTrans(string.Format(SQL, args));
        }
        public static int ExecuteTrans(StringBuilder b) {
            return ExecuteTrans(b.ToString());
        }
        #endregion

        #region Insert
        public static int Insert(DataRow r) {
            return ExecuteNone(DataUtil.BuildInsertSQL(r));
        }

        public static void Insert(DataTable t) {
            ExecuteTrans(DataUtil.BuildInsertSQL(t));
        }

        /// <summary>
        /// 对传入的DataSet插入数据
        /// </summary>
        /// <param name="ds"></param>
        public static void Insert(DataSet ds)
        {
            ExecuteTrans(DataUtil.BuildInsertSQL(ds));
        }

        public static void Insert(params DataRow[] rs) {
            StringBuilder b = new StringBuilder();
            foreach (DataRow r in rs) {
                b.Append(DataUtil.BuildInsertSQL(r));
            }
            ExecuteTrans(b.ToString());
        }

        public static int InsertParams(DataRow r) {
            SqlParameter[] ps;
            string cmd = DataUtil.BuildInsertSQL(r, out ps);
            return ExecuteNone(cmd, ps);
        }
        #endregion

        #region update
        public static int Update(DataRow r) {
            return ExecuteNone(DataUtil.BuildUpdateSQL(r));
        }

        public static void Update(DataTable t) {
            ExecuteTrans(DataUtil.BuildUpdateSQL(t));
        }

        public static void Update(params DataRow[] rs) {
            StringBuilder b = new StringBuilder();
            foreach (DataRow r in rs) {
                b.Append(DataUtil.BuildUpdateSQL(r));
            }
            ExecuteTrans(b.ToString());
        }

        public static int UpdateParams(DataRow r) {
            SqlParameter[] ps;
            string cmd = DataUtil.BuildUpdateSQL(r, out ps);
            return ExecuteNone(cmd, ps);
        }
        #endregion endupdate

        #region delete
        public static int Delete(DataRow r) {
            return ExecuteNone(DataUtil.BuildDeleteSQL(r));
        }

        public static void Delete(DataTable t) {
            ExecuteTrans(DataUtil.BuildDeleteSQL(t));
        }

        public static void Delete(params DataRow[] rs) {
            StringBuilder b = new StringBuilder();
            foreach (DataRow r in rs) {
                b.Append(DataUtil.BuildDeleteSQL(r));
            }
            ExecuteTrans(b.ToString());
        }

        public static int DeleteParams(DataRow r) {
            SqlParameter[] ps;
            string cmd = DataUtil.BuildDeleteSQL(r, out ps);
            return ExecuteNone(cmd, ps);
        }
        #endregion

        #region select
        public static DataTable GetData(string tb, string qury) {
            return ExecuteTable(string.Format("select * from {0} {1}", tb, qury));
        }
        public static DataRow GetRowData(string tb, string qury) {
            return ExecuteRow(string.Format("select * from {0} {1}", tb, qury));
        }
        public static DataTable GetAllData(string tb) {
            return GetData(tb, "");
        }
        /// <summary>
        /// 获取某列等值条件的数据集
        /// </summary>
        public static DataTable GetDataByField(string tbName, string fieldName, object v) {
            return ExecuteTable(string.Format("select * from {0} where {1}={2}", tbName, fieldName, DataUtil.SqlItem(v)));
        }
        /// <summary>
        /// 获取某列等值条件的数据集的第一行数据
        /// </summary>
        public static DataRow GetRowByField(string tbName, string fieldName, object v) {
            return ExecuteRow(string.Format("select * from {0} where {1}={2}", tbName, fieldName, DataUtil.SqlItem(v)));
        }
        public static DataTable QryTable(DataRow r) {
            return ExecuteTable(DataUtil.BuildSelectSQL(r));
        }
        public static DataRow QryRow(DataRow r) {
            return ExecuteRow(DataUtil.BuildSelectSQL(r));
        }
        #endregion
    }
}
