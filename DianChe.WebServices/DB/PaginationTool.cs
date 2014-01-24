using System;
using System.Data;
using System.Collections.Generic;
using System.Text;

namespace DianChe.WebServices
{
    

    /// <summary>
    /// Summary description for PaginationTool.
    /// 
    /// Author:John
    /// </summary>
    /// <example>
    ///		PaginationTool Pager = new PagerInfo(); 
    ///		Pager.CurrentPageIndex = 1; 
    ///		
    ///		//first query ,please count record
    ///		Pager.DoCount = true;
    ///		Pager.PageSize = 10; 
    ///		Pager.Order ="name_f,customerNumber_f";
    ///		
    ///		//get query result:  
    ///		DataSet ds=	Pager.Pager.Query("select * from customer_t" );  
    ///		
    ///		//if Pager.DoCount is true , then Update Pager.RecordCount 
    ///		
    ///		int count = Pager.RecordCount ;
    /// 
    /// </example>
    public class PaginationTool
    {



        private const string SqlTemplate_Pager_Top1 = @"select   top {0} * from ({1}) as a {2} ";
        private const string SqlTemplate_Pager = @"select  Temp_ID =identity(int,0,1), * into #tb from ({0} ) a {1}
				select  * from #tb where Temp_ID between {2} and {3} ";


        private string BuilderPagerSql(string sql)
        {
            string orderByString = string.Empty;
            if (this.Order != null && this.Order.Length > 0)
            {
                orderByString = " order by " + this.Order;
            }

            if (this.CurrentPageIndex <= 0)
            {
                return sql + orderByString;
            }


            StringBuilder pagerSql = new StringBuilder();
            PaginationTool pager = this;

            //
            if (pager.CurrentPageIndex == 1)
            {//first page	
                // select top 1
                pagerSql.AppendFormat(SqlTemplate_Pager_Top1, pager.PageSize, sql, orderByString);

            }
            else
            {//other page 
                //
                int nStartRecord = 0;
                int nEndRecord = 0;
                nStartRecord = pager.PageSize * (pager.CurrentPageIndex - 1);
                nEndRecord = pager.PageSize * pager.CurrentPageIndex - 1;
                pagerSql.AppendFormat(SqlTemplate_Pager,
                    sql,
                    orderByString,
                    nStartRecord.ToString(),
                    nEndRecord.ToString());
            }

            if (pager.DoCount)
            {
                pagerSql.AppendFormat("select count(*) from ({0}) a_count ", sql);
            }
            return pagerSql.ToString();

        }


        public DataSet Query(string sql)
        {
            string paginationSql;
            paginationSql = BuilderPagerSql(sql);


            DataSet ds = DataBase.ExecuteDataSet( 
                paginationSql.ToString()
                );

            //DataSet ds = SqlHelper.ExecuteDataset(
            //    DBManager.getConnectionString(),
            //    System.Data.CommandType.Text,
            //    sql.ToString()
            //    );

            if (this.DoCount && ds.Tables.Count == 2)
            { //get record count:
                this.RecordCount = Convert.ToInt32(ds.Tables[1].Rows[0][0]);
            }

            return ds;
        }



        public PaginationTool()
        {
            this.CurrentPageIndex = 1;
            this.RecordCount = 0;
            this.PageSize = 10;
            this.DoCount = true;
            this.Order = string.Empty;
        }


        public PaginationTool(int PageIndex)
        {
            this.CurrentPageIndex = PageIndex;
            this.RecordCount = 0;
            this.PageSize = 10;
            this.DoCount = (PageIndex==1);
            this.Order = string.Empty;
        }

        public int CurrentPageIndex;
        public int RecordCount;
        public int PageSize;  // 
        public bool DoCount;  // enable count record
        public string _Order;  //　

        /// <summary>
        /// Order by SQL 子串
        /// 注意 
        /// 前面不能加" Order by" ;
        /// 字段名前不能加表名
        /// </summary>
        public string Order
        {
            get
            {
                return this._Order;
            }
            set 
            {
                this._Order = value;
            }
        }

    }

	
}
