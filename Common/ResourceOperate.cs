using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace DianChe
{
    /// <summary>
    /// 将一个exe嵌入到项目资源中并访问该资源(运行该exe)，参见http://www.cnblogs.com/kongfl888/p/3351731.html
    /// 嵌入资源中的文件的释放类--kongfl888 2013
    ///将要嵌入的文件加载到项目中，放入到Resources文件夹（项目文件目录下）
    ///然后修改属性为嵌入的资源（很重要）
    ///具体查看War3Screen项目
    ///参考自http://hi.baidu.com/youlix/item/9d2e0c9472991cf0281647ed的文章
    ///另一种访问嵌入资源中的exe的方法：http://bbs.csdn.net/topics/80158825
    ///以及：http://www.cnblogs.com/mrlen/archive/2010/08/02/1790592.html
    ///其他文件如xml同理
    /// </summary>
    public class ResourceOperate
    {
        /// <summary>
        /// 释放资源文件
        /// </summary>
        /// <param name="resourceName">资源文件名</param>
        /// <param name="releasePath">释放的路径</param>
        /// <returns></returns>
        public static string ReleaseFile(string resourceName,string releasePath)
        {
            string filefullname = string.Empty;

            try
            {
                Random rd = new Random();

                String projectName = Assembly.GetExecutingAssembly().GetName().Name.ToString();
                Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(projectName + string.Format(".Resources.{0}", resourceName));
                byte[] b = new byte[stream.Length];
                stream.Read(b, 0, (int)stream.Length);
                SaveFileDialog SaveFileDialog1 = new SaveFileDialog();
                if (string.IsNullOrEmpty(releasePath))
                {
                    if (resourceName.Contains(".exe"))
                    {
                        filefullname = System.IO.Path.GetTempPath() + "regfix" + rd.Next().ToString() + ".exe";
                    }
                    else
                    {
                        filefullname = System.IO.Path.GetTempPath() + resourceName;
                    }
                }
                else
                {
                    filefullname = releasePath + "regfix" + rd.Next().ToString() + ".exe";
                }
                //filefullname="D:\\regfix" + rd.Next().ToString() + ".exe";
                FileStream FS = new FileStream(filefullname, FileMode.Create);//新建文件
                BinaryWriter BWriter = new BinaryWriter(FS);//以二进制打开文件流
                BWriter.Write(b, 0, b.Length);//从资源文件读取文件内容，写入到一个文件中
                BWriter.Close();
                FS.Close();
            }
            catch { }

            return filefullname;
        }

        public static void CloseFile(string filefullname)
        {
            try
            {
                if (File.Exists(filefullname) && !IsFileInUse(filefullname))
                {

                    File.Delete(filefullname);
                }
            }
            catch { }

        }

        /// <summary>
        /// 判断一个文件是否正在使用函数
        /// </summary>
        /// <param name="fileName">将要判断文件的文件名</param>
        /// <returns></returns>
        public static bool IsFileInUse(string fileName)
        {
            bool inUse = true;
            if (System.IO.File.Exists(fileName))
            {
                System.IO.FileStream fs = null;
                try
                {
                    fs = new System.IO.FileStream(fileName, System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.None);
                    inUse = false;
                }
                catch (System.IO.IOException)
                {
                    return true;
                }
                finally
                {
                    if (fs != null)
                    {
                        fs.Close();
                    }
                }
                return inUse;
            }
            else
            {
                return false;
            }
        }
    }
}
