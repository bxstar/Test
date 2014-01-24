using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DianChe.WebServices.BLL
{
    public class BllAlive
    {
        public void AddAlive(string ip_address,string mac_address)
        {
            string strSql = string.Format(@"
INSERT INTO t_alive
(
	ip_address,mac_address
)
VALUES
(
'{0}','{1}'
)", ip_address, mac_address);
            DataBase.ExecuteNone(strSql.ToString());
        }
    }
}