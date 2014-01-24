using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DianChe.WebServices
{
    public class DataUtil {

        #region BuildSelectSQL
        public static string BuildSelectSQL(DataRow r) {
            DataTable t = r.Table;
            StringBuilder b1 = new StringBuilder();
            b1.Append("select * from " + t.TableName);
            StringBuilder b2 = new StringBuilder();
            for (int i = 0; i < t.Columns.Count; i++) {
                if (r[i] != DBNull.Value) {
                    b2.Append(string.Format(" and {0}={1}",
                        t.Columns[i].ColumnName,
                        DataUtil.SqlItem(r[i])));
                }
            }
            if (b2.Length > 0) {
                b1.Append(" where");
                b2.Remove(0, 4);
                b1.Append(b2.ToString());
            }
            return b1.ToString();
        }
        #endregion

        #region BuildInsertSQL
        public static string BuildInsertSQL(DataRow r) {
            DataTable t = r.Table;
            string s = "\ninsert into " + t.TableName + " ({0}) values ({1})";
            StringBuilder b1 = new StringBuilder();
            StringBuilder b2 = new StringBuilder();
            for (int i = 0; i < t.Columns.Count; i++) {
                if (r[i] != DBNull.Value) {
                    if (b1.Length > 0) {
                        b1.Append(",");
                        b2.Append(",");
                    }
                    b1.Append(t.Columns[i].ColumnName);
                    b2.Append(SqlItem(r[i]));
                }
            }
            if (b1.Length > 0) {
                return string.Format(s, b1.ToString(), b2.ToString());
            }
            return String.Empty;
        }

        public static string BuildInsertSQL(DataTable t) {
            StringBuilder b = new StringBuilder();
            foreach (DataRow r in t.Rows)
                b.Append(BuildInsertSQL(r));
            return b.ToString();
        }

        public static string BuildInsertSQL(DataSet ds) {
            StringBuilder b = new StringBuilder();
            foreach (DataTable t in ds.Tables)
                b.Append(BuildInsertSQL(t));
            return b.ToString();
        }

        public static string BuildInsertSQL(DataRow r, out SqlParameter[] ps) {
            DataTable t = r.Table;
            string s = "\ninsert into " + t.TableName + " ({0}) values ({1})";
            StringBuilder b1 = new StringBuilder();
            StringBuilder b2 = new StringBuilder();
            int count = 0;
            for (int i = 0; i < t.Columns.Count; i++) {
                if (r[i] != DBNull.Value) {
                    if (b1.Length > 0) {
                        b1.Append(",");
                        b2.Append(",");
                    }
                    b1.Append(t.Columns[i].ColumnName);
                    b2.Append("@" + t.Columns[i].ColumnName);
                    count++;
                }
            }
            ps = new SqlParameter[count];
            count = 0;
            for (int i = 0; i < t.Columns.Count; i++) {
                if (r[i] != DBNull.Value)
                    if (b1.Length > 0) {
                        ps[count] = new SqlParameter("@" + t.Columns[i].ColumnName, t.Columns[i].GetType());
                        ps[count].Value = r[i];
                        count++;
                    }
            }
            if (b1.Length > 0) {
                return string.Format(s, b1.ToString(), b2.ToString());
            }
            return String.Empty;
        }

        #endregion

        #region BuildUpdateSQL
        public static string BuildUpdateSQL(DataRow r) {
            DataTable t = r.Table;
            StringBuilder b = new StringBuilder();
            string s = "\nupdate " + t.TableName + " set {0} where {1}";
            StringBuilder b1 = new StringBuilder();
            StringBuilder b2 = new StringBuilder();
            b2.Append(t.Columns[0].ColumnName + "=" + SqlItem(r[0]));
            for (int i = 1; i < t.Columns.Count; i++) {
                if (r[i] != DBNull.Value) {
                    if (b1.Length > 0)
                        b1.Append(",");
                    b1.Append(t.Columns[i].ColumnName + "=" + SqlItem(r[i]));
                }
            }
            if (b1.Length > 0) {
                b.Append(string.Format(s, b1.ToString(), b2.ToString()));
            }
            return b.ToString();
        }

        public static string BuildUpdateSQL(DataRow r, out SqlParameter[] ps) {
            DataTable t = r.Table;
            string s = "\nupdate " + t.TableName + " set {0} where {1}";
            StringBuilder b1 = new StringBuilder();
            StringBuilder b2 = new StringBuilder();
            b2.Append(t.Columns[0].ColumnName + "=@" + t.Columns[0].ColumnName);
            int count = 0;
            for (int i = 0; i < t.Columns.Count; i++) {
                if (r[i] != DBNull.Value) {
                    if (b1.Length > 0) {
                        b1.Append(",");
                    }
                    b1.Append(t.Columns[0].ColumnName + "=@" + t.Columns[0].ColumnName);
                    count++;
                }
            }
            ps = new SqlParameter[count];
            count = 0;
            for (int i = 0; i < t.Columns.Count; i++) {
                if (r[i] != DBNull.Value)
                    if (b1.Length > 0) {
                        ps[count] = new SqlParameter("@" + t.Columns[i].ColumnName, t.Columns[i].GetType());
                        ps[count].Value = r[i];
                        count++;
                    }
            }
            if (b1.Length > 0) {
                return string.Format(s, b1.ToString(), b2.ToString());
            }
            return String.Empty;
        }

        public static string BuildUpdateSQL(DataTable t) {
            StringBuilder b = new StringBuilder();
            foreach (DataRow r in t.Rows)
                b.Append(BuildUpdateSQL(r));
            return b.ToString();
        }

        public static string BuildUpdateSQL(DataSet ds) {
            StringBuilder b = new StringBuilder();
            foreach (DataTable t in ds.Tables)
                b.Append(BuildUpdateSQL(t));
            return b.ToString();
        }
        #endregion

        #region BuildDeleteSQL
        public static string BuildDeleteSQL(DataRow r) {
            DataTable t = r.Table;
            if (r[0] != DBNull.Value) {
                string s = "\ndelete " + t.TableName + " where {0}";
                return string.Format(s, t.Columns[0].ColumnName + "=" + SqlItem(r[0]));
            } else
                return "";
        }

        public static string BuildDeleteSQL(DataRow r, out SqlParameter[] ps) {
            DataTable t = r.Table;
            ps = new SqlParameter[1];
            ps[0] = new SqlParameter("@" + t.Columns[0].ColumnName, t.Columns[0].GetType());
            ps[0].Value = r[0];
            string s = "\ndelete " + t.TableName + " where {0}";
            return string.Format(s, t.Columns[0].ColumnName + "=@" + t.Columns[0].ColumnName);
        }

        public static string BuildDeleteSQL(DataTable t) {
            StringBuilder b = new StringBuilder();
            foreach (DataRow r in t.Rows)
                b.Append(BuildDeleteSQL(r));
            return b.ToString();
        }

        public static string BuildDeleteSQL(DataSet ds) {
            StringBuilder b = new StringBuilder();
            foreach (DataTable t in ds.Tables)
                b.Append(BuildDeleteSQL(t));
            return b.ToString();
        }
        #endregion

        #region Data Converter
        public static DataRow ConvertToDataRow(BaseRow r) {
            DataRow r1 = r.Table.NewRow();
            for (int i = 0; i < r.Table.Columns.Count; i++) {
                r1[i] = r[i];
            }
            return r1;
        }

        public static DataTable ConvertToDataTable(BaseTable t) {
            DataTable t1 = new DataTable(t.TableName);
            foreach (DataColumn c in t.Columns)
                t1.Columns.Add(new DataColumn(c.ColumnName, c.DataType));
            foreach (DataRow r in t.Rows) {
                DataRow r1 = t1.NewRow();
                for (int i = 0; i < t1.Columns.Count; i++) {
                    r1[i] = r[i];
                }
                t1.Rows.Add(r1);
            }
            return t1;
        }
        #endregion

        public static string SqlItem(object o) {
            Type t = o.GetType();
            if (t.Equals(typeof(System.String)) ||
                t.Equals(typeof(System.Guid)) ||
                t.Equals(typeof(System.DateTime)))
                return "N'" + o.ToString() + "'";
            else if (t.Equals(typeof(System.Int32)) ||
                t.Equals(typeof(System.Int16)) ||
                t.Equals(typeof(System.Int64)) ||
                t.Equals(typeof(System.Decimal)) ||
                t.Equals(typeof(System.Double)) ||
                t.Equals(typeof(System.Single)) ||
                t.Equals(typeof(System.Byte)) ||
                t.Equals(typeof(System.Int64)))
                return o.ToString();
            else if (t.Equals(typeof(System.Boolean)))
                return (bool)o ? "1" : "0";
            else if (t.Equals(typeof(System.Byte[]))) {
                return "null";
            } else
                return "N'" + o.ToString() + "'";
        }

        public static int QueryCount(string tName, string query) {
            if (query != "")
                query = " where " + query;
            return (int)DataBase.ExecuteObject(string.Format("select count(1) from {0}{1}", tName, query));
        }

        public static void CurrentPageData(DataTable t, int pageIndex, int pageSize) {
            int begin = pageIndex * pageSize;
            int end = (begin + pageSize) > t.Rows.Count ? (begin + pageSize) : t.Rows.Count;
            int lastCount = t.Rows.Count - end;
            for (int i = 0; i < begin; i++)
                t.Rows.RemoveAt(0);
            for (int i = 0; i < lastCount; i++)
                t.Rows.RemoveAt(end);
        }

        public static string ConnectColumnName(DataTable t) {
            StringBuilder b = new StringBuilder();
            foreach (DataColumn c in t.Columns) {
                if (b.Length > 0)
                    b.Append(',');
                b.Append(c.ColumnName);
            }
            return b.ToString();
        }

        public static string ConnectColumn(DataTable t, string cName) {
            StringBuilder b = new StringBuilder();
            foreach (DataRow r in t.Rows) {
                if (b.Length > 0)
                    b.Append(',');
                b.Append(r[cName].ToString());
            }
            return b.ToString();
        }

        public static string ConnectColumn(DataTable t, int index) {
            StringBuilder b = new StringBuilder();
            foreach (DataRow r in t.Rows) {
                if (b.Length > 0)
                    b.Append(',');
                b.Append(r[index].ToString());
            }
            return b.ToString();
        }

        public static string ConnectColumn(DataRow[] rs, string cName) {
            StringBuilder b = new StringBuilder();
            foreach (DataRow r in rs) {
                if (b.Length > 0)
                    b.Append(',');
                b.Append(r[cName].ToString());
            }
            return b.ToString();
        }

        public static string ConnectColumn(DataRow[] rs, int index) {
            StringBuilder b = new StringBuilder();
            foreach (DataRow r in rs) {
                if (b.Length > 0)
                    b.Append(',');
                b.Append(r[index].ToString());
            }
            return b.ToString();
        }

        public static string ConnectRow(DataRow r) {
            StringBuilder b = new StringBuilder();
            foreach (DataColumn c in r.Table.Columns) {
                if (b.Length > 0)
                    b.Append(',');
                b.Append(r[c].ToString());
            }
            return b.ToString();
        }





        /// <summary>
        /// 在数据转换时,判断是否为空值,为空返回默认值
        /// </summary>
        /// <param name="o"></param>
        /// <param name="replacement_value"></param>
        /// <returns></returns>
        public static object IsNull(object o, object replacement_value)
        {
            if (o == null || o == DBNull.Value) return replacement_value;
            return o;
        }

 

        public static string IsNull(object o, string replacement_value)
        {
            if (o == null || o == DBNull.Value) return replacement_value;
            return Convert.ToString(o);
        }

        public static int IsNull(object o, int replacement_value)
        {
            if (o == null || o == DBNull.Value) return replacement_value;
            return Convert.ToInt32(o);
        }

        public static bool IsNull(object o, bool replacement_value)
        {
            if (o == null || o == DBNull.Value) return replacement_value;
            return Convert.ToBoolean(o);
        }

    }
}
