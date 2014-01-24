using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace DianChe.WebServices
{

    [System.ComponentModel.DesignerCategory("code")]
    public abstract class BaseTable : DataTable {

        public BaseTable()
            : base() {
        }

        //public BaseTable(DataTable t) {
        //    this.TableName = t.TableName;
        //    foreach(DataColumn c in t.Columns)
        //        this.Columns.Add(new DataColumn(c.ColumnName, c.DataType));
        //    foreach(DataRow r in t.Rows) {
        //        DataRow r1 = this.NewRow();
        //        for(int i = 0;i < this.Columns.Count;i++) {
        //            r1[i] = r[i];
        //        }
        //        this.Rows.Add(r1);
        //    }
        //    this.AcceptChanges();
        //}

        public virtual string GetInsertSQL() {
            return DataUtil.BuildInsertSQL(this);
        }

        public virtual string GetUpdateSQL() {
            return DataUtil.BuildUpdateSQL(this);
        }

        public virtual string GetDeleteSQL() {
            return DataUtil.BuildDeleteSQL(this);
        }
    }

    [System.ComponentModel.DesignerCategory("code")]
    public class BaseRow : DataRow {

        public BaseRow(DataRowBuilder b)
            : base(b) {}

        public virtual string GetInsertSQL() {
            return DataUtil.BuildInsertSQL(this);
        }

        public virtual string GetUpdateSQL() {
            return DataUtil.BuildUpdateSQL(this);
        }

        public virtual string GetDeleteSQL() {
            return DataUtil.BuildDeleteSQL(this);
        }
    }
}
