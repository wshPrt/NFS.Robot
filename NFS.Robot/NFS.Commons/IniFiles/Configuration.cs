using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFS.Commons.IniFile
{
   public class Configuration
    {
        /// <summary>
        /// 配置user.Ini文件
        /// </summary>
        public class SerivceFiguration
        {
            /// <summary>
            /// 配置文件
            /// </summary>
            public const string INI_CFG = "config\\user.ini";
            public const string XML_MONITOR = "config\\monitor";
            public const string Path_URL = "Ftp\\";
            /// <summary>
            ///
            /// </summary>
            public const string Save_Records = "data\\userSetting.ini";
            /// <summary>
            /// 
            /// </summary>
            public const string SaveYc_Records = "data\\userYcSetting.ini";
            /// <summary>
            /// 版本文件
            /// </summary>
            public const string INI_VERSION = "config\\version.ini";
            /// <summary>
            /// 获取本地样式参数
            /// </summary>
            /// <returns></returns>
            public static string GetSkin()
            {
                string cfgINI = AppDomain.CurrentDomain.BaseDirectory + INI_CFG;
                if (File.Exists(cfgINI))
                {
                    IniFiles.IniFile ini = new IniFiles.IniFile(cfgINI);
                    string SkinName = ini.IniReadValue("Skin", "Skin");
                    return SkinName;
                }
                else
                    return string.Empty;
            }
        }
    }
}
