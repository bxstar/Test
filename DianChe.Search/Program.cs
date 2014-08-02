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
            string user_name = string.Empty;
            string pwd_encry = string.Empty;
            string keyword = string.Empty;
            string itemIds = string.Empty;
            string itemclick_local_id = string.Empty;

            if (args.Length == 3)
            {
                user_name = args[0];
                pwd_encry = args[1];
                itemclick_local_id = args[2];
            }
            else if (args.Length == 4)
            {
                user_name = args[0];
                pwd_encry = args[1];
                keyword = args[2];
                itemIds = args[3];
            }
            else
            {
                keyword = "自来水";
                itemIds = "22369723353";
            }

            //logger.InfoFormat(itemclick_local_id);
            //logger.InfoFormat("{0} {1}", keyword, itemIds);


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (args.Length == 3)
            {
                FrmItemClick frm = new FrmItemClick();
                frm.CurrentUser = new DianCheWebService.EntityUser() { user_name = user_name, pwd = pwd_encry };
                frm.FindItem = new BLL.BllItemClick().GetItemClickById(Convert.ToInt64(itemclick_local_id));
                frm.FindItem.mac_address = Common.Helper.GetMacAddress();
                Application.Run(frm);
            }
            else if (args.Length == 4)
            {
                FrmSearch frm = new FrmSearch();
                frm.currMonitorKeyword = keyword;
                frm.findItemIds = itemIds;
                Application.Run(frm);
            }
        }
    }
}
