using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using log4net;

namespace DianChe.Search
{
    static class Program
    {
        //日志类
        static ILog logger = LogManager.GetLogger("Logger");

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            //logger.InfoFormat("args length ：" + args.Length);
            string keyword = string.Empty;
            string itemIds = string.Empty;
            if (args.Length != 0)
            {
                keyword = args[0];
                itemIds = args[1];
            }
            else
            {
                keyword = "自来水";
                itemIds = "22369723353";
            }

            //logger.InfoFormat("{0} {1}", keyword, itemIds);


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            FrmSearch frm = new FrmSearch();
            frm.currMonitorKeyword = keyword;
            frm.findItemIds = itemIds;
            Application.Run(frm);
        }
    }
}
