using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Common.DB
{

    [System.ComponentModel.DesignerCategory("code")]
    public abstract class BaseTable : DataTable
    {

        public BaseTable()
            : base()
        {
        }
        public virtual string GetInsertSQL()
        {
            return DataUtil.BuildInsertSQL(this);
        }

        public virtual string GetUpdateSQL()
        {
            return DataUtil.BuildUpdateSQL(this);
        }

        public virtual string GetDeleteSQL()
        {
            return DataUtil.BuildDeleteSQL(this);
        }
    }

    [System.ComponentModel.DesignerCategory("code")]
    public class BaseRow : DataRow
    {

        public BaseRow(DataRowBuilder b)
            : base(b) { }

        public virtual string GetInsertSQL()
        {
            return DataUtil.BuildInsertSQL(this);
        }

        public virtual string GetUpdateSQL()
        {
            return DataUtil.BuildUpdateSQL(this);
        }

        public virtual string GetDeleteSQL()
        {
            return DataUtil.BuildDeleteSQL(this);
        }
    }
}
