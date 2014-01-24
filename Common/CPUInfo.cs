using System;
using System.Collections.Generic;
using System.Text;
using System.Management;

namespace Common
{
    public class CPUInfo
    {
        #region 属性
        #region CPU名称
        string strCPUName = string.Empty;

        public string CPUName
        {
            get { return strCPUName; }
            set { strCPUName = value; }
        }
        #endregion

        #region CPU序列号
        string strCPUID = string.Empty;

        public string CPUID
        {
            get { return strCPUID; }
            set { strCPUID = value; }
        }
        #endregion

        #region CPU个数
        int nCPUCount = 0;

        public int CPUCount
        {
            get { return nCPUCount; }
            set { nCPUCount = value; }
        }
        #endregion

        #region CPU制造商
        string strCPUManufacturer = string.Empty;

        public string CPUManufacturer
        {
            get { return strCPUManufacturer; }
            set { strCPUManufacturer = value; }
        }
        #endregion

        #region 当前时钟频率
        string strCPUCurrentClockSpeed = string.Empty;

        public string CPUCurrentClockSpeed
        {
            get { return strCPUCurrentClockSpeed; }
            set { strCPUCurrentClockSpeed = value; }
        }
        #endregion

        #region 最大时钟频率
        string strCPUMaxClockSpeed = string.Empty;

        public string CPUMaxClockSpeed
        {
            get { return strCPUMaxClockSpeed; }
            set { strCPUMaxClockSpeed = value; }
        }
        #endregion

        #region 外部频率
        string strCPUExtClock = string.Empty;

        public string CPUExtClock
        {
            get { return strCPUExtClock; }
            set { strCPUExtClock = value; }
        }
        #endregion

        #region 当前电压
        string strCPUCurrentVoltage = string.Empty;

        public string CPUCurrentVoltage
        {
            get { return strCPUCurrentVoltage; }
            set { strCPUCurrentVoltage = value; }
        }
        #endregion

        #region 二级缓存
        string strCPUL2CacheSize = string.Empty;

        public string CPUL2CacheSize
        {
            get { return strCPUL2CacheSize; }
            set { strCPUL2CacheSize = value; }
        }
        #endregion

        #region 数据带宽
        string strCPUDataWidth = string.Empty;

        public string CPUDataWidth
        {
            get { return strCPUDataWidth; }
            set { strCPUDataWidth = value; }
        }
        #endregion

        #region 地址带宽
        string strCPUAddressWidth = string.Empty;

        public string CPUAddressWidth
        {
            get { return strCPUAddressWidth; }
            set { strCPUAddressWidth = value; }
        }
        #endregion

        #region 使用百分比
        float fCPUUsedPercent;

        public float CPUUsedPercent
        {
            get { return fCPUUsedPercent; }
            set { fCPUUsedPercent = value; }
        }
        #endregion

        #region CPU温度
        double strCPUTemperature;

        public double CPUTemperature
        {
            get { return strCPUTemperature; }
            set { strCPUTemperature = value; }
        }
        #endregion
        #endregion

        #region 构造函数
        public CPUInfo()
        {
            //GetCPUInfo();
        }
        #endregion

        #region GetCPUInfo
        public void GetCPUInfo()
        {
            #region 使用百分比
            GetCPULoadPercentage();
            #endregion

            CPUCount = Environment.ProcessorCount;  //CPU个数

            GetCPUCurrentTemperature();

            //实例化一个ManagementClass类，并将Win32_Processor作为参数传递进去，
            //这样就可以查询Win32_Processor这个类里面的一些信息了。
            ManagementClass mClass = new ManagementClass("Win32_Processor");

            //获取Win32_Processor这个类的所有实例
            ManagementObjectCollection moCollection = mClass.GetInstances();

            //对Win32_Processor这个类进行遍历
            foreach (ManagementObject mObject in moCollection)
            {
                CPUName = mObject["Name"].ToString();  //获取CPU名称
                //CPUID = mObject["ProcessorId"].ToString();  //获取 CPU ID
                //CPUManufacturer = mObject["Manufacturer"].ToString();  //获取CPU制造商
                //CPUCurrentClockSpeed = mObject["CurrentClockSpeed"].ToString();  //获取当前时钟频率
                //CPUMaxClockSpeed = mObject["MaxClockSpeed"].ToString();  //获取最大时钟频率
                //CPUExtClock = mObject["ExtClock"].ToString();  //获取外部频率
                //CPUCurrentVoltage = mObject["CurrentVoltage"].ToString();  //获取当前电压
                //CPUL2CacheSize = mObject["L2CacheSize"].ToString();  //获取二级缓存
                //CPUDataWidth = mObject["DataWidth"].ToString();  //获取数据带宽
                //CPUAddressWidth = mObject["AddressWidth"].ToString();  //获取地址带宽
            }

        }

        public void GetCPUCurrentTemperature()
        {
            
        }

        public void GetCPULoadPercentage()
        {
            ManagementObjectSearcher searcher =
                    new ManagementObjectSearcher("root\\CIMV2",
                    "SELECT * FROM Win32_Processor");

            foreach (ManagementObject queryObj in searcher.Get())
            {
                CPUUsedPercent = float.Parse(queryObj["LoadPercentage"].ToString());
            }
        }
        #endregion
    }
}
