using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Data;
using System.Collections;
using System.IO.Compression;
using System.Management;

namespace Common
{
    public class Strings
    {

        /// <summary>
        /// 通过路径取该目录及下一级目前中所有应用程序
        /// </summary>
        /// <param name="path">目录</param>
        /// <returns></returns>
        public static Hashtable GetappByPath(string path)
        {
            Hashtable haslist = new Hashtable();
            if (Directory.Exists(path))
            {
                //只有当这个文件目录存在的时候才去执行，否则直接返回空的list 
                foreach (string dpath in Directory.GetFileSystemEntries(path))
                {
                    string str = string.Empty;//用于存放exe文件的真实路径
                    if (File.Exists(dpath))
                    {
                        //说明是文件 
                        if (dpath.Length >= 4)
                        {
                            //一些特殊情况不去处理
                            if (dpath.Substring(dpath.Length - 4).ToLower() == ".exe")
                            {
                                //说明是.exe文件 
                                str = dpath;
                            }
                        }
                    }
                    else
                    {
                        //文件夹 
                        str = Getpath(dpath);
                    }
                    if (!string.IsNullOrEmpty(str))
                    {
                        if (!haslist.ContainsKey(str))
                        {
                            haslist.Add(str, null);
                        }
                    }
                }
            }
            return haslist;
        }

        /// <summary>
        /// 或者exe的路径
        /// </summary>
        static string Getpath(string filepath)
        {
            string str = string.Empty;
            if (Directory.Exists(filepath))
            {
                //路径存在的时候才执行 
                foreach (string d in Directory.GetFileSystemEntries(filepath))
                {
                    if (File.Exists(d))
                    {
                        if (d.Substring(d.Length - 4).ToLower() == ".exe")
                        {
                            //说明是.exe文件 
                            str = d;
                            break;
                        }
                    }
                }
            }
            return str;
        }

        /// <summary>
        /// 网址中如果没有http或https则加上
        /// </summary>
        /// <param name="url">网址</param>
        /// <returns>最终格式完整的网址</returns>
        public static string GetRightUrl(string url)
        {
            url = url.Trim();
            if (url != "")
            {
                //网址中如果没有http或https则加上
                if (Strings.ToDBC(url).Length > 7)
                {
                    if (Strings.ToDBC(url.Substring(0, 7).ToLower()) != "http://" && Strings.ToDBC(url.Substring(0, 8).ToLower()) != "https://")
                    {
                        url = "http://" + Strings.ToDBC(url);
                    }
                }
                else
                {
                    if (url.ToLower() != "http://")
                    {
                        url = "http://" + Strings.ToDBC(url);
                    }
                }
            }
            return url;
        }

        /// <summary>
        /// 统计中文操作系统下的字节数
        /// </summary>
        public static int CheckByteCount(string eword)
        {
            byte[] bytecount = System.Text.Encoding.Default.GetBytes(eword.Trim());
            return bytecount.Length;
        }

        /// <summary>
        /// 统计去除一对{}的个数统计
        /// </summary>
        public static int CheckBetyCountForCreative(string eword)
        {
            //不统计断句符的个数
            eword = eword.Replace("^", "");
            eword = eword.Trim();
            string eword1 = eword.Replace("{", "");
            string eword2 = eword.Replace("}", "");
            eword = eword.Replace("{", "").Replace("}", "");
            byte[] bytecount = System.Text.Encoding.Default.GetBytes(eword);
            if (eword1.Length > eword2.Length)
            {
                return bytecount.Length + (eword1.Length - eword2.Length);
            }
            else
            {
                return bytecount.Length + (eword2.Length - eword1.Length);
            }
        }

        /// <summary>
        /// 判断图片格式
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>
        public static string GetImageTypeFromImage(Image image)
        {
            string imagetype = "";
            if (image.RawFormat.Equals(ImageFormat.Gif))
            {
                imagetype = "gif";
            }
            else if (image.RawFormat.Equals(ImageFormat.Jpeg))
            {
                imagetype = "jpg";
            }
            else if (image.RawFormat.Equals(ImageFormat.Png))
            {
                imagetype = "png";
            }
            else if (image.RawFormat.Equals(ImageFormat.Bmp))
            {
                imagetype = "bmp";
            }
            else if (image.RawFormat.Equals(ImageFormat.Icon))
            {
                imagetype = "icon";
            }
            else if (image.RawFormat.Equals(ImageFormat.MemoryBmp))
            {
                imagetype = "MemoryBmp";
            }
            else if (image.RawFormat.Equals(ImageFormat.Emf))
            {
                imagetype = "emf";
            }
            else if (image.RawFormat.Equals(ImageFormat.Exif))
            {
                imagetype = "Exif";
            }
            else if (image.RawFormat.Equals(ImageFormat.Tiff))
            {
                imagetype = "Tiff";
            }
            else if (image.RawFormat.Equals(ImageFormat.Wmf))
            {
                imagetype = "Wmf";
            }
            else
            {
                imagetype = "swf";
            }
            return imagetype;
        }

        /// <summary>
        /// 将二进制转换成图片
        /// </summary>
        /// <param name="bt"></param>
        /// <returns></returns>
        public static Image GetImageFormByte(byte[] bt)
        {
            Image image = null;
            try
            {
                MemoryStream stm = new MemoryStream(bt);
                image = Image.FromStream(stm);
            }
            catch
            {
                //表示是非图片
                image = null;
            }
            return image;
        }

        /// <summary>
        /// 将图片或flash转换成的二进制进行Hash然后MD5返回图片或flash的唯一标识
        /// </summary>
        /// <param name="myData"></param>
        /// <returns></returns>
        public static string MD5FromImage(byte[] myData)
        {
            StringBuilder sMd5Code = new StringBuilder();
            HashAlgorithm algorithm = MD5.Create();
            byte[] hashbyte = algorithm.ComputeHash(myData, 0, myData.Length - 1);
            for (int i = 0; i < hashbyte.Length; i++)
            {
                sMd5Code.Append(hashbyte[i]);
            }
            string result = Strings.Md5Encrypt(sMd5Code.ToString());
            return result;
        }

        /// <summary>
        /// MD5 加密算法
        /// </summary>
        public static string Md5Encrypt(string s)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            UTF8Encoding en = new UTF8Encoding();
            byte[] md5Bt = en.GetBytes(s);
            byte[] cryBt = md5.ComputeHash(md5Bt);
            return BitConverter.ToString(cryBt).Replace("-", "");
        }

        /// <summary>DES加密</summary>
        public static string DesEncrypt(string s)
        {
            byte[] byKey = System.Text.Encoding.UTF8.GetBytes("wondersg");//wondersgroup
            byte[] IV = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            byte[] inputByteArray = Encoding.UTF8.GetBytes(s);
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(byKey, IV), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            return System.Convert.ToBase64String(ms.ToArray());
        }

        /// <summary>DES解密</summary>
        public static string DesDecrypt(string s)
        {
            byte[] byKey = System.Text.Encoding.UTF8.GetBytes("wondersg");
            byte[] IV = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            byte[] inputByteArray = System.Convert.FromBase64String(s);
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(byKey, IV), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            System.Text.Encoding encoding = new System.Text.UTF8Encoding();
            return encoding.GetString(ms.ToArray());
        }

        /// <summary>DES加密</summary>
        public static string DesEncrypt2(string s)
        {
            byte[] byKey = System.Text.Encoding.UTF8.GetBytes("wondersg");//wondersgroup
            byte[] IV = { 0x0, 0x0, 0x0, 0x0, 0x0, 0x2, 0x3, 0x5 };
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            byte[] inputByteArray = Encoding.UTF8.GetBytes(s);
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(byKey, IV), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            return System.Convert.ToBase64String(ms.ToArray());
        }

        /// <summary>DES解密</summary>
        public static string DesDecrypt2(string s)
        {
            byte[] byKey = System.Text.Encoding.UTF8.GetBytes("wondersg");
            byte[] IV = { 0x0, 0x0, 0x0, 0x0, 0x0, 0x2, 0x3, 0x5 };
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            byte[] inputByteArray = System.Convert.FromBase64String(s);
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(byKey, IV), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            System.Text.Encoding encoding = new System.Text.UTF8Encoding();
            return encoding.GetString(ms.ToArray());
        }

        /// <summary>
        /// AES加密,用于登录时密码加密
        /// </summary>
        /// <param name="encryptString">待加密字符串</param>
        /// <returns>密文</returns>
        public static string EncryptAES(string apiSecret, string encryptString)
        {
            try
            {
                //MD5加密
                byte[] md5Bt = new UTF8Encoding().GetBytes(encryptString);
                byte[] cryBt = new MD5CryptoServiceProvider().ComputeHash(md5Bt);
                string md5Result = BitConverter.ToString(cryBt).Replace("-", "").ToLower();

                //DES加密
                byte[] inputByteArray = Encoding.UTF8.GetBytes(md5Result);
                SymmetricAlgorithm des = Rijndael.Create();
                des.Key = Encoding.ASCII.GetBytes(apiSecret.Substring(0, 16));
                des.IV = Encoding.ASCII.GetBytes(apiSecret.Substring(16, 16));
                des.Mode = CipherMode.CBC;
                des.Padding = PaddingMode.Zeros;
                MemoryStream mStream = new MemoryStream();
                CryptoStream cStream = new CryptoStream(mStream, des.CreateEncryptor(), CryptoStreamMode.Write);
                cStream.Write(inputByteArray, 0, inputByteArray.Length);
                cStream.FlushFinalBlock();

                byte[] desBytes = mStream.ToArray();
                mStream.Close();
                cStream.Close();

                return BitConverter.ToString(desBytes).Replace("-", "").ToLower();
            }
            catch
            {
                return encryptString;
            }
        }

        /// <summary>
        /// 取当前电脑的系统
        /// </summary>
        /// <param name="version">系统版本号</param>
        /// <returns>当前电脑的系统</returns>
        public static string GetSystemVersion(ref string version)
        {
            try
            {
                Hashtable table = new Hashtable();
                table.Add("140", "Windows95");
                table.Add("1410", "Windows98");
                table.Add("1490", "WindowsMe");
                table.Add("230", "WindowsNT35");
                table.Add("240", "WindowsNT40");
                table.Add("250", "Windows2000");
                table.Add("251", "WindowsXP");
                table.Add("252", "Windows2003");
                table.Add("260", "WindowsVista");
                table.Add("261", "Windows7");
                table.Add("271", "Windows8");
                //获取系统信息
                System.OperatingSystem osInfo = System.Environment.OSVersion;
                //获取操作系统ID
                System.PlatformID platformID = osInfo.Platform;
                //获取主版本号
                int versionMajor = osInfo.Version.Major;
                //获取副版本号
                int versionMinor = osInfo.Version.Minor;
                version = versionMajor + "." + versionMinor;
                string osInfor = platformID.GetHashCode().ToString() + versionMajor.ToString() + versionMinor.ToString();
                if (table.ContainsKey(osInfor))
                {
                    return table[osInfor].ToString();
                }
                else
                {
                    return osInfor;
                }
            }
            catch
            {
                version = "0.0";
                return "未知系统";
            }
        }

        /// <summary>
        /// 获取硬盘ID
        /// </summary>
        /// <returns>硬盘ID</returns>
        public static string GetHardID()
        {
            string HDInfo = "";
            try
            {
                ManagementClass cimobject1 = new ManagementClass("Win32_DiskDrive");
                ManagementObjectCollection moc1 = cimobject1.GetInstances();
                foreach (ManagementObject mo in moc1)
                {
                    HDInfo = (string)mo.Properties["SerialNumber"].Value;
                }
            }
            catch
            {
                HDInfo = "未知硬盘";
            }
            if (HDInfo == null)
            {
                HDInfo = "未知硬盘";
            }
            return HDInfo;
        }

        /// <summary>
        /// 转半角的函数(DBC case)
        /// </summary>
        /// <param name="input">任意字符串</param>
        /// <returns>半角字符串</returns>
        ///<remarks>
        ///全角空格为12288，半角空格为32
        ///其他字符半角(33-126)与全角(65281-65374)的对应关系是：均相差65248
        ///</remarks>
        public static string ToDBC(string input)
        {
            char[] c = input.ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {
                if (c[i] == 12288)
                {
                    c[i] = (char)32;
                    continue;
                }
                if (c[i] > 65280 && c[i] < 65375)
                    c[i] = (char)(c[i] - 65248);
            }
            return new string(c);
        }

        /// <summary>
        /// 世奇加密
        /// </summary>
        public static string UnknownENC(string s)
        {
            System.Text.Encoding utf8 = System.Text.Encoding.UTF8;
            byte[] bytes = utf8.GetBytes(s);
            for (int i = 0; i < bytes.Length; i++)
            {
                bytes[i] = (byte)(255 - bytes[i] - i);
            }
            return System.Convert.ToBase64String(bytes);
        }

        public static string ChangeToUnicode(string s)
        {
            byte[] buffer = Encoding.Unicode.GetBytes(s);
            string str = "";
            foreach (byte b in buffer)
            {
                str += string.Format("%{0:X}", b);
            }
            return str;
        }

        /// <summary>
        /// 转全角的函数(SBC case)
        /// </summary>
        /// <param name="input">任意字符串</param>
        /// <returns>全角字符串</returns>
        ///<remarks>
        ///全角空格为12288，半角空格为32
        ///其他字符半角(33-126)与全角(65281-65374)的对应关系是：均相差65248
        ///</remarks>        
        public static string ToSBC(string input)
        {
            //半角转全角：
            char[] c = input.ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {
                if (c[i] == 32)
                {
                    c[i] = (char)12288;
                    continue;
                }
                if (c[i] < 127)
                    c[i] = (char)(c[i] + 65248);
            }
            return new string(c);
        }

        public static string GenderRandam(int length)
        {
            Random rd = new Random();
            int ret = rd.Next(Convert.ToInt32(Math.Pow(10, length - 1)), Convert.ToInt32(Math.Pow(10, length)) - 1);
            return ret.ToString();
        }

        /// <summary>
        /// 过滤输入的单引号
        /// </summary>
        /// <param name="inputString">要处理的字符串</param>
        /// <returns></returns>
        public static string InputText(string inputString)
        {
            if (inputString != null && inputString.Trim() != "")
            {
                StringBuilder retVal = new StringBuilder();
                inputString = inputString.Trim();
                for (int i = 0; i < inputString.Length; i++)
                {
                    switch (inputString[i])
                    {
                        case '\'':
                            retVal.Append("''");
                            break;
                        default:
                            retVal.Append(inputString[i]);
                            break;
                    }
                }
                return retVal.ToString().Trim();
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        /// 过滤输入的单引号
        /// </summary>
        /// <param name="inputString">要处理的字符串</param>
        /// <returns></returns>
        public static string InputTextNew(string inputString)
        {
            if (inputString != null && inputString != "")
            {
                inputString = inputString.Trim();
                StringBuilder retVal = new StringBuilder();
                for (int i = 0; i < inputString.Length; i++)
                {
                    switch (inputString[i])
                    {
                        case '\'':
                            retVal.Append("''");
                            break;
                        default:
                            retVal.Append(inputString[i]);
                            break;
                    }
                }
                return retVal.ToString();
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        /// boolean值的首字母转化
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string FormatTureOrFalse(string input)
        {
            string output = input;
            if (input.ToLower().Equals("true"))
            {
                output = "True";
            }
            else if(input.ToLower().Equals("false"))
            {
                output = "False";
            }
            return output;
        }

        /// <summary>
        /// 周几，由数字转成英文缩写
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string FormatWeek(string input)
        {
            string output = input;
            if (input.Equals("1"))
            {
                output = "Mon";
            }
            else if (input.Equals("2"))
            {
                output = "Tue";
            }
            else if (input.Equals("3"))
            {
                output = "Wed";
            }
            else if (input.Equals("4"))
            {
                output = "Thu";
            }
            else if (input.Equals("5"))
            {
                output = "Fri";
            }
            else if (input.Equals("6"))
            {
                output = "Sat";
            }
            else if (input.Equals("7"))
            {
                output = "Sun";
            }
            return output;
        }

        public static string GetSystemVersionStringAndServerPack()
        {
            string SystemVerSion = string.Empty;
            SystemVerSion = Environment.OSVersion.VersionString;
            return SystemVerSion;
        }

        /// <summary>
        /// 获取宝贝的id
        /// </summary>
        public static long GetItemId(string linkUrl)
        {
            System.Text.RegularExpressions.Regex pattern=new Regex("[?|&]id=(\\d*)");
            Match m = pattern.Match(linkUrl);
            if (m.Success)
            {
                return Convert.ToInt64(m.Groups[1].Value);
            }
            else
            {
                return -1;
            }
            //return str.Trim();
        }
    }
}
