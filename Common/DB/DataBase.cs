using System;
using System.Collections.Generic;

using System.Text;
using System.Data;
using System.Data.SQLite;
using System.Collections;
using log4net;
using System.IO;
using System.Security.AccessControl;
using System.Diagnostics;
using System.Windows.Forms;

namespace Common.DB
{
    public class DataBase
    {
        //type 1表示数据的链接，2表示用户的链接
        public static string ConnString = "";
        //日志类
        ILog logAX = LogManager.GetLogger("Logger");

        /// <summary>
        /// 新建用户库
        /// </summary>
        /// <returns></returns>
        public static bool CreateUserDataBase()
        {
            bool isExists = true;
            string userdbPath = string.Format(Config.ConnectionStringOfUser, System.Windows.Forms.Application.StartupPath);
            userdbPath = userdbPath.Substring(userdbPath.IndexOf("=") + 1);
            try
            {
                if (!File.Exists(userdbPath))
                {
                    string filepath = System.Windows.Forms.Application.StartupPath + "\\..\\resource";
                    if (!Directory.Exists(filepath))
                    {
                        Directory.CreateDirectory(filepath);
                        File.SetAttributes(filepath, FileAttributes.Hidden | FileAttributes.System);
                    }
                    SQLiteConnection.CreateFile(userdbPath);
                    isExists = false;
                }
                File.SetAttributes(userdbPath, FileAttributes.Hidden | FileAttributes.System);
            }
            catch (Exception e)
            {
                throw e;
            }
            return isExists;
        }

        /// <summary>
        /// 根据账户创建库(一个账户对应一个库)(如果存在该库文件返回True,否则返回False)
        /// </summary>
        /// <param name="username">用户名</param>
        public static bool CreateDataBase(string username)
        {
            //隐藏DB文件夹
            string dbPath = string.Format(Config.ConnectionString, System.Windows.Forms.Application.StartupPath);
            dbPath = dbPath.Substring(dbPath.IndexOf("=") + 1);
            dbPath = dbPath.Substring(0, dbPath.Length - 1);
            File.SetAttributes(dbPath, FileAttributes.Hidden | FileAttributes.System);
            bool isExists = true;
            if (username == "")
                ConnString = string.Format(Config.ConnectionString, System.Windows.Forms.Application.StartupPath) + Config.DBName + ".db3";
            else
                ConnString = string.Format(Config.ConnectionString, System.Windows.Forms.Application.StartupPath) + username + ".db3";
            string databasePath = ConnString.Substring(ConnString.IndexOf(@"=") + 1);
            try
            {
                if (!File.Exists(databasePath))
                {
                    SQLiteConnection.CreateFile(databasePath);
                    isExists = false;
                    File.SetAttributes(databasePath, FileAttributes.Hidden | FileAttributes.System);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return isExists;
        }


        #region Execute and return DataSet or DataTable
        public static DataSet ExecuteDataSet(string sql)
        {
            ConnString = string.Format(Config.ConnectionString, System.Windows.Forms.Application.StartupPath) + Config.DBName + ".db";
            using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(sql, ConnString))
            {
                DataSet ds = new DataSet();
                try
                {
                    adapter.Fill(ds);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message + " 数据库操作错误，请检测SQL语句：" + sql);
                }
                return ds;
            }
        }

        /// <summary>
        /// 通过sql语句返回导出CSV格式的string
        /// </summary>
        /// <param name="SQL">sql语句</param>
        /// <param name="index">从第几列开始</param>
        /// <param name="filePath">保存的路径</param>
        /// <returns>错误信息</returns>
        public static string ExportCSV(string SQL, int index, string filePath)
        {
            string errorMsg = "";
            try
            {
                ConnString = string.Format(Config.ConnectionString, System.Windows.Forms.Application.StartupPath) + Config.DBName + ".db3";
                //采用边读边写的方式，防止内存溢出
                int currentIndex = 0;
                StreamWriter sw = new StreamWriter(filePath, false, Encoding.Default);
                StringBuilder sb = new StringBuilder("");//要写入的数据
                using (SQLiteConnection conn = new SQLiteConnection(ConnString))
                {
                    SQLiteCommand cmd = new SQLiteCommand(SQL, conn);
                    cmd.CommandType = CommandType.Text;
                    conn.Open();
                    SQLiteDataReader dr = cmd.ExecuteReader();

                    //表头
                    for (int count = index; count < dr.FieldCount; count++)
                    {
                        if (dr.GetName(count) != null)
                            sb.Append(dr.GetName(count));
                        if (count < dr.FieldCount - 1)
                        {
                            sb.Append(",");
                        }
                    }
                    sb.Append("\r\n");

                    //内容
                    string value = "";
                    while (dr.Read())
                    {
                        for (int col = index; col < dr.FieldCount; col++)
                        {
                            if (!dr.IsDBNull(col))
                            {
                                value = dr.GetValue(col).ToString().Trim().Replace("\"", "\"\"");
                                if (value.Contains(","))
                                {
                                    sb.Append("\"" + value + "\"");
                                }
                                else
                                {
                                    sb.Append(value);
                                }
                            }
                            //换行
                            if (col != dr.FieldCount - 1)
                                sb.Append(",");
                        }
                        sb.Append("\r\n");

                        currentIndex++;
                        if (currentIndex % 500 == 0)
                        {
                            sw.Write(sb.ToString());
                            sb = new StringBuilder("");
                        }
                    }

                    if (sb.ToString() != "")
                    {
                        sw.Write(sb.ToString());
                        sb = new StringBuilder("");
                    }

                    //释放变量
                    try
                    {
                        sw.Close();
                        dr.Dispose();
                    }
                    catch
                    {
                    }
                }
            }
            catch (Exception e)
            {
                errorMsg = "导出失败，请再试一次或通过菜单中的【问题反馈】将问题报告给我们！\n" + e.Message;
            }
            return errorMsg;
        }

        public static DataSet ExecuteDataSet(string spName, SQLiteParameter[] sps, string type)
        {
            if (type == "1")
            {
                ConnString = string.Format(Config.ConnectionString, System.Windows.Forms.Application.StartupPath) + Config.DBName + ".db3";
            }
            else
            {
                ConnString = string.Format(Config.ConnectionStringOfUser, System.Windows.Forms.Application.StartupPath);
            }
            using (SQLiteDataAdapter adapter = new SQLiteDataAdapter())
            {
                SQLiteCommand cmd = new SQLiteCommand(spName, new SQLiteConnection(ConnString));
                cmd.CommandType = CommandType.StoredProcedure;
                foreach (SQLiteParameter p in sps)
                {
                    cmd.Parameters.Add(p);
                }
                adapter.SelectCommand = cmd;
                DataSet ds = new DataSet();
                adapter.Fill(ds);   //adapter.FillSchema(ds,SchemaType.Mapped);
                return ds;
            }
        }

        public static DataTable ExecuteTable(string SQL)
        {
            return ExecuteDataSet(SQL).Tables[0];
        }

        public static DataTable ExecuteTable(string SQL, string type, params object[] args)
        {
            return ExecuteTable(string.Format(SQL, args), type);
        }

        public static DataRow ExecuteRow(string SQL)
        {
            DataTable t = ExecuteDataSet(SQL).Tables[0];
            if (t.Rows.Count == 1)
                return t.Rows[0];
            return null;
        }

        public static DataRow ExecuteRow(string SQL, string type, params object[] args)
        {
            return ExecuteRow(string.Format(SQL, args), type);
        }

        public static DataRow ExecuteRow(string spName, SQLiteParameter[] sps, string type)
        {
            DataTable t = ExecuteDataSet(spName, sps, type).Tables[0];
            if (t.Rows.Count == 1)
                return t.Rows[0];
            return null;
        }
        #endregion

        #region Execute None
        public static int ExecuteNone(string SQL)
        {
            ConnString = string.Format(Config.ConnectionString, System.Windows.Forms.Application.StartupPath) + Config.DBName + ".db";
            using (SQLiteConnection conn = new SQLiteConnection(ConnString))
            {
                SQLiteCommand cmd = new SQLiteCommand(SQL, conn);
                cmd.CommandType = CommandType.Text;
                conn.Open();
                try
                {
                    return cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message + " 数据库操作错误，请检测SQL语句：" + SQL);
                    return -1;
                }
            }
        }

        public static int ExecuteNone(string SQL, string type, params object[] args)
        {
            return ExecuteNone(string.Format(SQL, args), type);
        }

        public static int ExecuteSpNone(string spName, SQLiteParameter[] ps, string type)
        {
            if (type == "1")
            {
                ConnString = string.Format(Config.ConnectionString, System.Windows.Forms.Application.StartupPath) + Config.DBName + ".db3";
            }
            else
            {
                ConnString = string.Format(Config.ConnectionStringOfUser, System.Windows.Forms.Application.StartupPath);
            }
            using (SQLiteConnection conn = new SQLiteConnection(ConnString))
            {
                SQLiteCommand cmd = new SQLiteCommand(spName, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                foreach (SQLiteParameter p in ps)
                {
                    cmd.Parameters.Add(p);
                }
                conn.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        public static int ExecuteTransSpNone(string spName, SQLiteParameter[] ps, string type)
        {
            if (type == "1")
            {
                ConnString = string.Format(Config.ConnectionString, System.Windows.Forms.Application.StartupPath) + Config.DBName + ".db3";
            }
            else
            {
                ConnString = string.Format(Config.ConnectionStringOfUser, System.Windows.Forms.Application.StartupPath);
            }
            int i = -1;
            using (SQLiteConnection conn = new SQLiteConnection(ConnString))
            {
                SQLiteTransaction trans = null;

                conn.Open();
                trans = conn.BeginTransaction();
                SQLiteCommand cmd = new SQLiteCommand(spName, conn, trans);
                cmd.CommandType = CommandType.StoredProcedure;
                foreach (SQLiteParameter p in ps)
                {
                    cmd.Parameters.Add(p);
                }

                try
                {

                    i = cmd.ExecuteNonQuery();
                    trans.Commit();
                    return i;
                }
                catch (SQLiteException se)
                {
                    if (trans != null)
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
        public static IDataReader ExecuteReader(string SQL, string type)
        {
            if (type == "1")
            {
                ConnString = string.Format(Config.ConnectionString, System.Windows.Forms.Application.StartupPath) + Config.DBName + ".db3";
            }
            else
            {
                ConnString = string.Format(Config.ConnectionStringOfUser, System.Windows.Forms.Application.StartupPath);
            }
            SQLiteConnection conn = new SQLiteConnection(ConnString);
            SQLiteCommand cmd = new SQLiteCommand(SQL, conn);
            conn.Open();
            return cmd.ExecuteReader(CommandBehavior.CloseConnection);
        }
        public static IDataReader ExecuteReader(string SQL, string type, params object[] args)
        {
            return ExecuteReader(string.Format(SQL, args), type);
        }
        #endregion

        #region Execute object
        public static Object ExecuteObject(string SQL, string type)
        {
            if (type == "1")
            {
                ConnString = string.Format(Config.ConnectionString, System.Windows.Forms.Application.StartupPath) + Config.DBName + ".db3";
            }
            else if (type == "2")
            {
                ConnString = string.Format(Config.ConnectionStringOfUser, System.Windows.Forms.Application.StartupPath);
            }
            else
                ConnString = type;
            using (SQLiteConnection conn = new SQLiteConnection(ConnString))
            {
                SQLiteCommand cmd = new SQLiteCommand(SQL, conn);
                cmd.CommandType = CommandType.Text;
                conn.Open();
                try
                {
                    return cmd.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message + " 数据库操作错误，请检测SQL语句：" + SQL);
                }
                return cmd.ExecuteScalar();
            }
        }

        public static object ExecuteObject(string SQL, string type, params object[] args)
        {
            return ExecuteObject(string.Format(SQL, args), type);
        }

        public static object ExecuteObject(string SQL, string type, CommandType type2, SQLiteParameter[] ps)
        {
            if (type == "1")
            {
                ConnString = string.Format(Config.ConnectionString, System.Windows.Forms.Application.StartupPath) + Config.DBName + ".db3";
            }
            else
            {
                ConnString = string.Format(Config.ConnectionStringOfUser, System.Windows.Forms.Application.StartupPath);
            }
            using (SQLiteConnection conn = new SQLiteConnection(ConnString))
            {
                SQLiteCommand cmd = new SQLiteCommand(SQL, conn);
                cmd.CommandType = type2;
                foreach (SQLiteParameter p in ps)
                {
                    cmd.Parameters.Add(p);
                }
                conn.Open();
                cmd.Prepare();
                return cmd.ExecuteScalar();
            }
        }
        #endregion

        #region Execute trans
        public static int ExecuteNone(string sqlText, List<SQLiteParameter[]> parameters, string type)
        {
            if (type == "1")
            {
                ConnString = string.Format(Config.ConnectionString, Application.StartupPath) + Config.DBName + ".db3";
            }
            else
            {
                ConnString = string.Format(Config.ConnectionStringOfUser, Application.StartupPath);
            }
            using (var conn = new SQLiteConnection(ConnString))
            {
                conn.Open();
                using (var trans = conn.BeginTransaction())
                {
                    try
                    {
                        int nResult = 0;
                        using (var cmd = new SQLiteCommand(sqlText, conn))
                        {
                            cmd.CommandType = CommandType.Text;
                            foreach (SQLiteParameter[] t in parameters)
                            {
                                cmd.Parameters.Clear();
                                foreach (var param in t)
                                {
                                    cmd.Parameters.Add(param);
                                }
                                nResult = cmd.ExecuteNonQuery();
                            }
                        }
                        trans.Commit();
                        return nResult;
                    }
                    catch (SQLiteException)
                    {
                        trans.Rollback();
                        throw;
                    }
                }
            }
        }

        public static int ExecuteNoneTran(string SQL, SQLiteParameter[] ps)
        {
            ConnString = string.Format(Config.ConnectionString, System.Windows.Forms.Application.StartupPath) + Config.DBName + ".db";
            using (SQLiteConnection conn = new SQLiteConnection(ConnString))
            {
                conn.Open();
                SQLiteTransaction trans = conn.BeginTransaction();
                try
                {
                    SQLiteCommand cmd = new SQLiteCommand(SQL, conn);
                    cmd.CommandType = CommandType.Text;
                    //foreach (SQLiteParameter p in ps)
                    for (int i = 0; i < ps.Length; i++)
                    {
                        if (ps[i] != null)
                        {
                            cmd.Parameters.Add(ps[i]);
                            cmd.ExecuteNonQuery();
                        }
                        else
                        {
                            break;
                        }
                    }
                    trans.Commit();
                    return 1;
                }
                catch (SQLiteException se)
                {
                    if (trans != null)
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

        /// <summary>
        /// 适合于多个方法执行，保证数据完整性和一致性
        /// </summary>
        /// <param name="tran">事物</param>
        /// <param name="SQL">语句</param>
        /// <param name="ps">参数</param>
        /// <param name="type">类型</param>
        /// <returns></returns>
        public static int ExecuteNone(SQLiteTransaction tran, string SQL, SQLiteParameter[] ps, string type)
        {
            if (tran == null)
            {
                if (type == "1")
                {
                    ConnString = string.Format(Config.ConnectionString, System.Windows.Forms.Application.StartupPath) + Config.DBName + ".db3";
                }
                else
                {
                    ConnString = string.Format(Config.ConnectionStringOfUser, System.Windows.Forms.Application.StartupPath);
                }
                using (SQLiteConnection conn = new SQLiteConnection(ConnString))
                {
                    conn.Open();
                    SQLiteTransaction trans = conn.BeginTransaction();
                    try
                    {
                        SQLiteCommand cmd = new SQLiteCommand(SQL, conn);
                        cmd.CommandType = CommandType.Text;
                        for (int i = 0; i < ps.Length; i++)
                        {
                            if (ps[i] != null)
                            {
                                cmd.Parameters.Add(ps[i]);
                                cmd.ExecuteNonQuery();
                            }
                            else
                            {
                                break;
                            }
                        }
                        trans.Commit();
                        return 1;
                    }
                    catch (SQLiteException se)
                    {
                        if (trans != null)
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
            else
            {
                try
                {
                    SQLiteCommand cmd = new SQLiteCommand(SQL, tran.Connection, tran);
                    cmd.CommandType = CommandType.Text;
                    for (int i = 0; i < ps.Length; i++)
                    {
                        if (ps[i] != null)
                        {
                            cmd.Parameters.Add(ps[i]);
                            cmd.ExecuteNonQuery();
                        }
                        else
                        {
                            break;
                        }
                    }
                    return 1;
                }
                catch (SQLiteException se)
                {
                    throw se;
                }
            }
        }

        public static int ExecuteNone(string SQL, SQLiteParameter[] ps)
        {
            ConnString = string.Format(Config.ConnectionString, System.Windows.Forms.Application.StartupPath) + Config.DBName + ".db";
            using (SQLiteConnection conn = new SQLiteConnection(ConnString))
            {
                SQLiteCommand cmd = new SQLiteCommand(SQL, conn);
                cmd.CommandType = CommandType.Text;
                foreach (SQLiteParameter p in ps)
                {
                    cmd.Parameters.Add(p);
                }
                conn.Open();
                cmd.Prepare();

                cmd.ExecuteNonQuery();
                return 1;
            }
        }

        /// <summary>
        /// 批量执行多条有一个参数的语句
        /// </summary>
        /// <param name="SQL">带参数的sql语句(只能有一个参数)</param>
        /// <param name="ps">参数(必须和sql语句一一对应)</param>
        /// <param name="type">1表示业务数据库 2表账户数据库</param>
        /// <returns></returns>
        public static int ExecuteNone2(string[] SQL, SQLiteParameter[] ps, string type)
        {
            if (type == "1")
            {
                ConnString = string.Format(Config.ConnectionString, System.Windows.Forms.Application.StartupPath) + Config.DBName + ".db3";
            }
            else if (type == "2")
            {
                ConnString = string.Format(Config.ConnectionStringOfUser, System.Windows.Forms.Application.StartupPath);
            }
            else
                ConnString = type;
            using (SQLiteConnection conn = new SQLiteConnection(ConnString))
            {
                conn.Open();
                SQLiteTransaction trans = conn.BeginTransaction();
                SQLiteCommand cmd = conn.CreateCommand();
                cmd.Connection = conn;
                try
                {
                    for (int i = 0; i < SQL.Length; i++)
                    {
                        cmd.CommandText = SQL[i];
                        cmd.Parameters.Add(ps[i]);
                        cmd.Prepare();
                        cmd.ExecuteNonQuery();
                    }
                    trans.Commit();
                    return 1;
                }
                catch (SQLiteException se)
                {
                    trans.Rollback();
                    throw se;
                }
                finally
                {
                }
            }
        }

        public static int ExecuteTransForSqlite(string type, params string[] args)
        {
            if (type == "1")
            {
                ConnString = string.Format(Config.ConnectionString, System.Windows.Forms.Application.StartupPath) + Config.DBName + ".db3";
            }
            else if (type == "2")
            {
                ConnString = string.Format(Config.ConnectionStringOfUser, System.Windows.Forms.Application.StartupPath);
            }
            else
                ConnString = type;
            SQLiteConnection conn = new SQLiteConnection(ConnString);
            conn.Open();
            SQLiteTransaction trans = conn.BeginTransaction();
            try
            {
                SQLiteCommand cmd = conn.CreateCommand();
                cmd.Connection = conn;

                for (int i = 0; i < args.Length; i++)
                {
                    cmd.CommandText = args[i].ToString();
                    cmd.ExecuteNonQuery();
                }

                trans.Commit();
                return 1;
            }
            catch (Exception ex)
            {
                trans.Rollback();
                throw ex;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        /// <summary>
        /// 批量处理数据
        /// </summary>
        /// <param name="type">类型</param>
        /// <param name="args">语句</param>
        /// <returns></returns>
        public static int ExecuteTransForSqlite_Arrylist(string type, ArrayList args)
        {
            if (type == "1")
            {
                ConnString = string.Format(Config.ConnectionString, System.Windows.Forms.Application.StartupPath) + Config.DBName + ".db3"; ;
            }
            else if (type == "2")
            {
                ConnString = string.Format(Config.ConnectionStringOfUser, System.Windows.Forms.Application.StartupPath);
            }
            else
            {
                ConnString = type;
            }
            SQLiteConnection conn = new SQLiteConnection(ConnString);
            conn.Open();
            SQLiteTransaction trans = conn.BeginTransaction();
            string s = "";
            try
            {
                SQLiteCommand cmd = conn.CreateCommand();
                cmd.Connection = conn;

                for (int i = 0; i < args.Count; i++)
                {
                    s = args[i].ToString();
                    cmd.CommandText = args[i].ToString();
                    cmd.ExecuteNonQuery();
                }

                trans.Commit();
                return 1;
            }
            catch (Exception ex)
            {
                WriteLog(s);
                trans.Rollback();
                throw ex;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        /// <summary>
        /// 写错误日志
        /// </summary>
        /// <param name="s"></param>
        public static void WriteLog(string s)
        {
            //Stream stream = new FileStream(@"C:\\数据库操作日志.txt", FileMode.OpenOrCreate);
            //StreamWriter writer = new StreamWriter(stream, Encoding.GetEncoding("gb2312"));
            //writer.WriteLine(s);
            //writer.Close();
            //stream.Close();
        }

        /// <summary>
        /// 批量处理数据(有事物)
        /// </summary>
        /// <param name="tran">事物</param>
        /// <param name="type">类型</param>
        /// <param name="args">语句</param>
        /// <returns></returns>
        public static int ExecuteTransForSqlite_Arrylist(SQLiteTransaction tran, string type, ArrayList args)
        {
            if (tran == null)
            {
                if (type == "1")
                {
                    ConnString = string.Format(Config.ConnectionString, System.Windows.Forms.Application.StartupPath) + Config.DBName + ".db3";
                }
                else
                {
                    ConnString = string.Format(Config.ConnectionStringOfUser, System.Windows.Forms.Application.StartupPath);
                }
                SQLiteConnection conn = new SQLiteConnection(ConnString);
                conn.Open();
                SQLiteTransaction trans = conn.BeginTransaction();
                try
                {
                    SQLiteCommand cmd = conn.CreateCommand();
                    cmd.Connection = conn;

                    for (int i = 0; i < args.Count; i++)
                    {
                        cmd.CommandText = args[i].ToString();
                        cmd.ExecuteNonQuery();
                    }

                    trans.Commit();
                    return 1;
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    throw ex;
                }
                finally
                {
                    if (conn.State == ConnectionState.Open)
                        conn.Close();
                }
            }
            else
            {
                try
                {
                    SQLiteCommand cmd = new SQLiteCommand(tran.Connection);
                    for (int i = 0; i < args.Count; i++)
                    {
                        cmd.CommandText = args[i].ToString();
                        cmd.ExecuteNonQuery();
                    }
                    return 1;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        //批量获取数据
        public static DataSet ExecuteDataSetForSqlite(string[] str, string type)
        {
            if (type == "1")
            {
                ConnString = string.Format(Config.ConnectionString, System.Windows.Forms.Application.StartupPath) + Config.DBName + ".db3";
            }
            else
            {
                ConnString = string.Format(Config.ConnectionStringOfUser, System.Windows.Forms.Application.StartupPath);
            }
            using (SQLiteDataAdapter adapter = new SQLiteDataAdapter())
            {
                SQLiteConnection conn = new SQLiteConnection(ConnString);
                conn.Open();
                SQLiteTransaction trans = conn.BeginTransaction();
                SQLiteCommand cmd = conn.CreateCommand();
                cmd.Connection = conn;
                DataSet ds = new DataSet();
                for (int i = 0; i < str.Length; i++)
                {
                    cmd.CommandText = str[i];
                    adapter.SelectCommand = cmd;
                    adapter.Fill(ds);
                }
                trans.Commit();
                return ds;
            }
        }

        public static DataSet ExecuteDataSetForSqlite(ArrayList list, string type)
        {
            if (type == "1")
            {
                ConnString = string.Format(Config.ConnectionString, System.Windows.Forms.Application.StartupPath) + Config.DBName + ".db3";
            }
            else if (type == "2")
            {
                ConnString = string.Format(Config.ConnectionStringOfUser, System.Windows.Forms.Application.StartupPath);
            }
            else
            {
                ConnString = type;
            }
            using (SQLiteDataAdapter adapter = new SQLiteDataAdapter())
            {
                SQLiteConnection conn = new SQLiteConnection(ConnString);
                conn.Open();
                SQLiteTransaction trans = conn.BeginTransaction();
                SQLiteCommand cmd = conn.CreateCommand();
                cmd.Connection = conn;
                DataSet ds = new DataSet();
                for (int i = 0; i < list.Count; i++)
                {
                    cmd.CommandText = list[i].ToString();
                    adapter.SelectCommand = cmd;
                    adapter.Fill(ds);
                }
                trans.Commit();
                return ds;
            }
        }

        public static DataSet ExecuteDataSetForSqlite(string SQL, SQLiteParameter[] ps, string type)
        {
            if (type == "1")
            {
                ConnString = string.Format(Config.ConnectionString, System.Windows.Forms.Application.StartupPath) + Config.DBName + ".db3";
            }
            else
            {
                ConnString = string.Format(Config.ConnectionStringOfUser, System.Windows.Forms.Application.StartupPath);
            }
            using (SQLiteDataAdapter adapter = new SQLiteDataAdapter())
            {

                SQLiteConnection conn = new SQLiteConnection(ConnString);
                conn.Open();
                SQLiteTransaction trans = conn.BeginTransaction();
                try
                {
                    DataSet ds = new DataSet();
                    SQLiteCommand cmd = new SQLiteCommand(SQL, conn);
                    cmd.CommandType = CommandType.Text;
                    foreach (SQLiteParameter p in ps)
                    {
                        cmd.Parameters.Add(p);
                        cmd.Prepare();
                        adapter.SelectCommand = cmd;
                        adapter.Fill(ds);
                    }
                    trans.Commit();
                    return ds;
                }
                catch (SQLiteException se)
                {
                    if (trans != null)
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

        public static int ExecuteTrans(string sql, string type)
        {
            if (type == "1")
            {
                ConnString = string.Format(Config.ConnectionString, System.Windows.Forms.Application.StartupPath) + Config.DBName + ".db3";
            }
            else
            {
                ConnString = string.Format(Config.ConnectionStringOfUser, System.Windows.Forms.Application.StartupPath);
            }
            SQLiteConnection conn = new SQLiteConnection(ConnString);
            conn.Open();
            SQLiteTransaction trans = conn.BeginTransaction();
            try
            {
                SQLiteCommand cmd = new SQLiteCommand(sql, conn, trans);
                cmd.CommandType = CommandType.Text;
                int r = cmd.ExecuteNonQuery();
                trans.Commit();
                return r;
            }
            catch (Exception ex)
            {
                trans.Rollback();
                throw ex;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }
        public static int ExecuteTrans(string SQL, string type, params object[] args)
        {
            return ExecuteTrans(string.Format(SQL, args), type);
        }
        public static int ExecuteTrans(StringBuilder b, string type)
        {
            return ExecuteTrans(b.ToString(), type);
        }
        #endregion

        #region Insert
        public static int Insert(DataRow r, string type)
        {
            return ExecuteNone(DataUtil.BuildInsertSQL(r), type);
        }

        public static void Insert(DataTable t, string type)
        {
            ExecuteTrans(DataUtil.BuildInsertSQL(t), type);
        }

        public static void Insert(string type, params DataRow[] rs)
        {
            StringBuilder b = new StringBuilder();
            foreach (DataRow r in rs)
            {
                b.Append(DataUtil.BuildInsertSQL(r));
            }
            ExecuteTrans(b.ToString(), type);
        }

        public static int InsertParams(DataRow r)
        {
            SQLiteParameter[] ps;
            string cmd = DataUtil.BuildInsertSQL(r, out ps);
            return ExecuteNone(cmd, ps);
        }
        #endregion

        #region update
        public static int Update(DataRow r, string type)
        {
            return ExecuteNone(DataUtil.BuildUpdateSQL(r), type);
        }

        public static void Update(DataTable t, string type)
        {
            ExecuteTrans(DataUtil.BuildUpdateSQL(t), type);
        }

        public static void Update(string type, params DataRow[] rs)
        {
            StringBuilder b = new StringBuilder();
            foreach (DataRow r in rs)
            {
                b.Append(DataUtil.BuildUpdateSQL(r));
            }
            ExecuteTrans(b.ToString(), type);
        }

        public static int UpdateParams(DataRow r)
        {
            SQLiteParameter[] ps;
            string cmd = DataUtil.BuildUpdateSQL(r, out ps);
            return ExecuteNone(cmd, ps);
        }
        #endregion endupdate

        #region delete
        public static int Delete(DataRow r, string type)
        {
            return ExecuteNone(DataUtil.BuildDeleteSQL(r), type);
        }

        public static void Delete(DataTable t, string type)
        {
            ExecuteTrans(DataUtil.BuildDeleteSQL(t), type);
        }

        public static void Delete(string type, params DataRow[] rs)
        {
            StringBuilder b = new StringBuilder();
            foreach (DataRow r in rs)
            {
                b.Append(DataUtil.BuildDeleteSQL(r));
            }
            ExecuteTrans(b.ToString(), type);
        }

        public static int DeleteParams(DataRow r)
        {
            SQLiteParameter[] ps;
            string cmd = DataUtil.BuildDeleteSQL(r, out ps);
            return ExecuteNone(cmd, ps);
        }
        #endregion

        #region select
        public static DataTable GetData(string tb, string qury, string type)
        {
            return ExecuteTable(string.Format("select * from {0} {1}", tb, qury), type);
        }
        public static DataRow GetRowData(string tb, string qury, string type)
        {
            return ExecuteRow(string.Format("select * from {0} {1}", tb, qury), type);
        }
        public static DataTable GetAllData(string tb, string type)
        {
            return GetData(tb, "", type);
        }
        /// <summary>
        /// 获取某列等值条件的数据集
        /// </summary>
        public static DataTable GetDataByField(string tbName, string fieldName, object v, string type)
        {
            return ExecuteTable(string.Format("select * from {0} where {1}={2}", tbName, fieldName, DataUtil.SqlItem(v)), type);
        }
        /// <summary>
        /// 获取某列等值条件的数据集的第一行数据
        /// </summary>
        public static DataRow GetRowByField(string tbName, string fieldName, object v, string type)
        {
            return ExecuteRow(string.Format("select * from {0} where {1}={2}", tbName, fieldName, DataUtil.SqlItem(v)), type);
        }
        public static DataTable QryTable(DataRow r, string type)
        {
            return ExecuteTable(DataUtil.BuildSelectSQL(r), type);
        }
        public static DataRow QryRow(DataRow r, string type)
        {
            return ExecuteRow(DataUtil.BuildSelectSQL(r), type);
        }
        #endregion

        public static void CBF(string path)
        {
            try
            {
                if (!File.Exists(path))
                {
                    string cstr;
                    cstr = "Data Source= " + path;
                    SQLiteConnection.CreateFile(path);
                    File.SetAttributes(path, FileAttributes.Hidden | FileAttributes.System);
                    string cbd = "CmsYrbmngf8X7VYDrksvmH6/glDTmOzzHM8L7Ng/KHchbbvXipljBDY6bnI30GLNTqIC+LX7CigIvhcVRNVlRltSpGp7VveezKoKdHj9Qv824DmJrtbrVCD3VSJuk26B2DUjZmm61BaQBfI/h9xy3GMkvFEpqhtMbQdeBkwddIFBIWXPLyFhYizUE3/94M4D2//Kdwd54OzTH0GVQ1LagIgzcmjwNf/gf8xMISV+NxgXw0vunUQFbBeHJdAhvol9+VAEP2TIJkqBtnmQU/ANrEtDRt1mgpT7amxYbTSJCfGB4vCAj53uboogfUC9r9knTp7O3rQsTlg=";
                    ExecuteNone(Strings.DesDecrypt(cbd), cstr);
                    string sql = string.Format(@"CREATE TABLE [RecordAccount] ( 
                        [LocalId] integer PRIMARY KEY AUTOINCREMENT, 
			            [AccountName] NVARCHAR(200),
			            [LastRecord] DATETIME,
			            [Residual] int,
			            [InputTime] DATETIME,
			            [Reserved]  NVARCHAR(4000) null
			            )");
                    ExecuteNone(sql, cstr);
                    SQLiteConnection conn = new SQLiteConnection(cstr);
                    conn.Open();
                    conn.ChangePassword(Common.Strings.DesDecrypt("j59Xqmyxd+yTtwTHnjr2CxWTczv9DZHcNaOs4Vd7hX8="));
                    conn.Close();
                }
            }
            catch
            {

            }
        }
    }
}
