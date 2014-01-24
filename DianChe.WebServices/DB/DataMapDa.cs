using System;
using System.Data;
using System.Text;

namespace DianChe.WebServices
{
    public class DataMapDa {
        private StringBuilder patchSQL;

        public DataMapDa()
            : base() {
            patchSQL = new StringBuilder();
        }

        #region Insert
        public int Insert(DataRow r) {
            return (int)DataBase.ExecuteNone(DataUtil.BuildInsertSQL(r));
        }

        public int Insert(DataTable t) {
            return (int)DataBase.ExecuteNone(DataUtil.BuildInsertSQL(t));
        }

        public int Insert(params DataRow[] rs) {
            StringBuilder b = new StringBuilder();
            foreach (DataRow r in rs) {
                if (r != null) {
                    b.Append(DataUtil.BuildInsertSQL(r));
                }
            }
            return (int)DataBase.ExecuteNone(b.ToString());
        }
        #endregion

        #region update 限制: 仅支持第一列为主键的数据操作
        public int Update(DataRow r) {
            return (int)DataBase.ExecuteNone(DataUtil.BuildUpdateSQL(r));
        }

        public int Update(DataTable t) {
            return (int)DataBase.ExecuteNone(DataUtil.BuildUpdateSQL(t));
        }

        public int Update(params DataRow[] rs) {
            StringBuilder b = new StringBuilder();
            foreach (DataRow r in rs) {
                b.Append(DataUtil.BuildUpdateSQL(r));
            }
            return (int)DataBase.ExecuteNone(b.ToString());
        }

        //public int UpdateParams(DataRow r){
        //    OleDbParameter[] ps;
        //    string cmd = DataUtil.BuildUpdateSQL(r, out ps);
        //    return (int)DataBase.ExecuteNone(cmd, ps);
        //}
        #endregion endupdate

        #region delete  限制: 仅支持第一列为主键的数据操作
        public int Delete(DataRow r) {
            return (int)DataBase.ExecuteNone(DataUtil.BuildDeleteSQL(r));
        }

        public int Delete(DataTable t) {
            return (int)DataBase.ExecuteNone(DataUtil.BuildDeleteSQL(t));
        }

        public int Delete(params DataRow[] rs) {
            StringBuilder b = new StringBuilder();
            foreach (DataRow r in rs) {
                b.Append(DataUtil.BuildDeleteSQL(r));
            }
            return (int)DataBase.ExecuteNone(b.ToString());
        }

        //public int DeleteParams(DataRow r) {
        //    OleDbParameter[] ps;
        //    string cmd = DataUtil.BuildDeleteSQL(r, out ps);
        //    return (int)DataBase.ExecuteNone(cmd, ps);
        //}
        #endregion

        #region Select
        //代码已经重构，参见DataBase中的Select操作
        #endregion

        public void AddInsertData(DataRow r) {
            patchSQL.Append(DataUtil.BuildInsertSQL(r));
        }

        public void AddUpdateData(DataRow r) {
            patchSQL.Append(DataUtil.BuildUpdateSQL(r));
        }

        public void AddDeleteData(DataRow r) {
            patchSQL.Append(DataUtil.BuildDeleteSQL(r));
        }


        public void AddInsertData(DataTable dt) {
            foreach (DataRow r in dt.Rows) {
                patchSQL.Append(DataUtil.BuildInsertSQL(r));
            }
        }

        public void AddUpdateData(DataTable dt) {
            foreach (DataRow r in dt.Rows) {
                patchSQL.Append(DataUtil.BuildUpdateSQL(r));
            }
        }

        public void AddDeleteData(DataTable dt) {
            foreach (DataRow r in dt.Rows) {
                patchSQL.Append(DataUtil.BuildDeleteSQL(r));
            }
        }

        public void AddSQL(string sql) {
            patchSQL.Append('\n' + sql);
        }

        public int CommitTrans() {
            if (patchSQL.Length == 0)
                throw new System.Exception("没有可提交的数据");
            return (int)DataBase.ExecuteTrans(patchSQL);
        }
    }
}
