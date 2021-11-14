using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFS.Commons.Configuration
{
    public class LoggerHelper
    {
        //配置的基础路径   
        private static string logFileName = "";

        public class Log
        {
            private static Log singleLog;
            private static object _lock = new object();
            private Log()
            {
            }
            public static Log GetLog()
            {
                if (singleLog == null)
                {
                    lock (_lock)
                    {
                        if (singleLog == null)
                        {
                            singleLog = new Log();
                        }
                    }
                }
                return singleLog;
            }
            /// <summary>
            /// 创建文件夹和日志文件  
            /// </summary>
            /// <param name="category">日志分类</param>
            /// <param name="logType">信息分类，比如：错误，消息</param>  
            private static void CreateLogFile()
            {
                //查看文件路径，没有则建立
                if (!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "\\Log"))
                {
                    Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "\\Log");
                }
                //日志路径，包含文件名
                logFileName = System.AppDomain.CurrentDomain.BaseDirectory + "Log" + "\\" + DateTime.Now.ToString("yyyy-MM-dd") + ".log";
                if (!File.Exists(logFileName))
                {
                    FileStream filestream = null;
                    try
                    {
                        filestream = File.Create(logFileName);
                        filestream.Dispose();
                        filestream.Close();
                    }
                    catch (System.Exception ex)
                    {
                        throw new System.Exception(ex + "创建日志文件失败");
                    }
                }
            }

            /// <summary>
            /// 写入日志
            /// </summary>
            /// <param name="pageName">页面名称</param>
            /// <param name="voidName">方法名</param>
            /// <param name="lineNumber">报错行号，及位置</param>
            /// <param name="msg">消息</param>
            /// <param name="e">如果是错误消息，输出异常信息</param>
            public void WriteLogToFile(string pageName = "未知", string voidName = "未知", string lineNumber = "未知", string msg = "未知", Exception e = null, string errorMsg = "")
            {
                lock (this)
                {
                    StreamWriter sw = null;
                    try
                    {
                        CreateLogFile();//创建文件
                        sw = new System.IO.StreamWriter(logFileName, true, System.Text.Encoding.Unicode);
                        sw.WriteLine();
                        sw.WriteLine("记录时间：" + DateTime.Now.ToString());
                        sw.WriteLine("错误页面：" + pageName.ToString());
                        sw.WriteLine("发生错误的行号：" + lineNumber);
                        sw.WriteLine("发生错误的方法：" + voidName);
                        sw.WriteLine("消息内容：" + msg);
                        if (e != null)
                        {
                            sw.WriteLine("异常信息：" + e.Message);
                            sw.WriteLine(e.StackTrace);
                        }
                        sw.WriteLine();
                    }
                    catch (Exception ex)
                    {
                        EventLog.WriteEntry("AlatinClient", ex + "写入日志失败，检查！", EventLogEntryType.Warning);
                        //throw new System.Exception(ex + "写入日志失败，检查！");
                    }
                    finally
                    {
                        if (sw != null)
                        {
                            sw.Flush();
                            sw.Dispose();
                            sw.Close();
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 写入日志
        /// </summary>
        /// <param name="pageName">页面名称</param>
        /// <param name="voidName">方法名</param>
        /// <param name="lineNumber">报错行号，及位置</param>
        /// <param name="msg">消息</param>
        /// <param name="e">如果是错误消息，输出异常信息</param>
        public static void WriteLog(string pageName, string voidName, string lineNumber, string msg, Exception e = null)
        {
            Log.GetLog().WriteLogToFile(pageName, voidName, lineNumber, msg, e);
        }

        /// <summary>
        /// 写入日志
        /// </summary>
        /// <param name="pageName">页面名称</param>
        /// <param name="voidName">方法名</param>
        /// <param name="lineNumber">报错行号，及位置</param>
        /// <param name="msg">消息</param>
        /// <param name="e">如果是错误消息，输出异常信息</param>
        public static void WriteLog(string msg, Exception e = null)
        {
            StackTrace st = new StackTrace(true);
            Log.GetLog().WriteLogToFile(st.GetFrame(1).GetMethod().ReflectedType.Name, st.GetFrame(1).GetMethod().Name, st.GetFrame(1).GetFileLineNumber().ToString(), msg, e);
        }

        /// <summary>
        /// 写入日志2
        /// </summary>
        /// <param name="pageName">页面名称</param>
        /// <param name="voidName">方法名</param>
        /// <param name="lineNumber">报错行号，及位置</param>
        /// <param name="msg">消息</param>
        /// <param name="e">如果是错误消息，输出异常信息</param>
        public static void WriteLog(string msg, string errorMessage, Exception e = null)
        {
            StackTrace st = new StackTrace(true);
            Log.GetLog().WriteLogToFile(st.GetFrame(1).GetMethod().ReflectedType.Name, st.GetFrame(1).GetMethod().Name, st.GetFrame(1).GetFileLineNumber().ToString(), msg, e, errorMessage);
        }
    }
}
