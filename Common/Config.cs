using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32;
using System.Xml;
using System.Configuration;

namespace Common
{
    public class Config
    {
        /// <summary>
        /// 数据库名称
        /// </summary>
        public static string DBName
        {
            get { return GetCfgValue("DBName"); }
            set { SetCfgValue("DBName", value); }
        }

        /// <summary>
        /// 用户数据库路径
        /// </summary>
        public static string ConnectionStringOfUser
        {
            get { return GetCfgValue("ConnectionStringOfUser"); }
            set { SetCfgValue("ConnectionStringOfUser", value); }
        }
        /// <summary>
        /// 业务数据库路径
        /// </summary>
        public static string ConnectionString
        {
            get { return GetCfgValue("ConnectionString"); }
            set { SetCfgValue("ConnectionString", value); }
        }

        /// <summary>
        /// WebService地址
        /// </summary>
        public static string WebServiceBaseUrl
        {
            get { return GetCfgValue("ConnectionString"); }
            set { SetCfgValue("ConnectionString", value); }
        }

        /// <summary>
        /// 软件更新地址
        /// </summary>
        public static string UpdateUrl
        {
            get { return GetCfgValue("UpdateUrl"); }
            set { SetCfgValue("UpdateUrl", value); }
        }

        /// <summary>
        /// 从XML中得到配置数据
        /// </summary>
        /// <param name="AppKey"></param>
        /// <returns></returns>
        public static string GetCfgValue(string AppKey)
        {
            try
            {
                XmlDocument xDoc = new XmlDocument();
                xDoc.Load(System.Windows.Forms.Application.StartupPath + "\\Configs\\" + "appSettings.config");

                XmlNode xNode;
                XmlElement xElemKey;

                xNode = xDoc.SelectSingleNode("//appSettings");

                xElemKey = (XmlElement)xNode.SelectSingleNode("//add[@key=\"" + AppKey + "\"]");
                if (xElemKey != null)
                    return xElemKey.GetAttribute("value");
                else
                    return string.Empty;
            }
            catch (XmlException err)
            {
                throw err;
            }
        }

        /// <summary>
        /// 写，引入 System.XML
        /// </summary>
        /// <param name="AppKey"></param>
        /// <param name="AppValue"></param>
        public static void SetCfgValue(string AppKey, string AppValue)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(System.Windows.Forms.Application.ExecutablePath + "\\Configs\\" + "appSettings.config");

            XmlNode xNode;
            XmlElement xElemKey;
            XmlElement xElemValue;

            xNode = xDoc.SelectSingleNode("//appSettings");

            xElemKey = (XmlElement)xNode.SelectSingleNode("//add[@key=\"" + AppKey + "\"]");
            if (xElemKey != null) xElemKey.SetAttribute("value", AppValue);
            else
            {
                xElemValue = xDoc.CreateElement("add");
                xElemValue.SetAttribute("key", AppKey);
                xElemValue.SetAttribute("value", AppValue);
                xNode.AppendChild(xElemValue);
            }
            xDoc.Save(System.Windows.Forms.Application.ExecutablePath + ".config");
        }
    }
}
