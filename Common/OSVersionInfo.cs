using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace Common
{
    public class OSVersionInfo
    {
        private struct OsVersionInfo
        {
            public int dwOSVersionInfoSize;
            public int dwMajorVersion;
            public int dwMinorVersion;
            public int dwBuildNumber;
            public int dwPlatformId;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
            public string szCSDVersion;
            public short wServicePackMajor;
            public short wServicePackMinor;
            public short wSuiteMask;
            public byte wProductType;
            public byte wReserved;
        }

        [DllImport("kernel32.dll")]
        private static extern bool GetVersionEx(ref OsVersionInfo osVersionInfo);

        private static string systemName;

        public static string SystemName
        {
            get
            {
                if (OSVersionInfo.systemName != null)
                {
                    return OSVersionInfo.systemName;
                }
                return OSVersionInfo.systemName = OSVersionInfo.GetSystemName();
            }
        }

        public static string GetSystemName()
        {
            OsVersionInfo osVersionInfo = default(OsVersionInfo);
            osVersionInfo.dwOSVersionInfoSize = Marshal.SizeOf(typeof(OsVersionInfo));
            if (OSVersionInfo.GetVersionEx(ref osVersionInfo))
            {
                OperatingSystem osVersion = Environment.OSVersion;
                switch (osVersion.Platform)
                {
                    case PlatformID.Win32S:
                        return "Windows 3.1";
                    case PlatformID.Win32Windows:
                        if (osVersion.Version.Major == 4)
                        {
                            string csdVersion = osVersionInfo.szCSDVersion;
                            if (osVersion.Version.Minor != 0)
                            {
                                if (osVersion.Version.Minor != 10)
                                {
                                    if (osVersion.Version.Minor == 90)
                                    {
                                        return "Windows Me";
                                    }
                                }
                                else
                                {
                                    if (csdVersion == "A")
                                    {
                                        return "Windows 98 Second Edition";
                                    }
                                    return "Windows 98";
                                }
                            }
                            else
                            {
                                if (csdVersion == "B" || csdVersion == "C")
                                {
                                    return "Windows 95 OSR2";
                                }
                                return "Windows 95";
                            }
                        }
                        break;
                    case PlatformID.Win32NT:
                        {
                            byte productType = osVersionInfo.wProductType;
                            switch (osVersion.Version.Major)
                            {
                                case 3:
                                    return "Windows NT 3.51";
                                case 4:
                                    switch (productType)
                                    {
                                        case 1:
                                            return "Windows NT 4.0";
                                        case 3:
                                            return "Windows NT 4.0 Server";
                                    }
                                    break;
                                case 5:
                                    switch (osVersion.Version.Minor)
                                    {
                                        case 0:
                                            return "Windows 2000";
                                        case 1:
                                            return "Windows XP";
                                        case 2:
                                            return "Windows Server 2003";
                                    }
                                    break;
                                case 6:
                                    switch (osVersion.Version.Minor)
                                    {
                                        case 0:
                                            switch (productType)
                                            {
                                                case 1:
                                                    return "Windows Vista";
                                                case 3:
                                                    return "Windows Server 2008";
                                            }
                                            break;
                                        case 1:
                                            switch (productType)
                                            {
                                                case 1:
                                                    return "Windows 7";
                                                case 3:
                                                    return "Windows Server 2008 R2";
                                            }
                                            break;
                                        case 2:
                                            switch (productType)
                                            {
                                                case 1:
                                                    return "Windows 8";
                                                case 3:
                                                    return "Windows Server 2012";
                                            }
                                            break;
                                    }
                                    break;
                            }
                            break;
                        }
                    case PlatformID.WinCE:
                        return "Windows CE";
                }
            }
            return "Unknown";
        }
    }
}
