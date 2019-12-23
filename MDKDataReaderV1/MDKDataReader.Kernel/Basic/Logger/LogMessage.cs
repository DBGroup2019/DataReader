using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MDKDataReader.Kernel.Basic.Logger
{
    /// <summary>
    /// 日志消息类
    /// </summary>
    public class LogMessage
    {
        /// <summary>
        /// 日志消息产生时间
        /// </summary>
        public DateTime DateTime { get; set; }

        /// <summary>
        /// 日志消息级别
        /// </summary>
        public LogMessageLevels Level { get; set; }

        /// <summary>
        /// 当前用户
        /// </summary>
        public string UserID { get; set; }

        /// <summary>
        /// 当前工作站
        /// </summary>
        public string WkStation { get; set; }

        /// <summary>
        /// 日志消息文本
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 代码文件
        /// </summary>
        public string CSFile { get; set; }

        /// <summary>
        /// 类名
        /// </summary>
        public string Class { get; set; }

        /// <summary>
        /// 方法名
        /// </summary>
        public string Method { get; set; }

        /// <summary>
        /// 行号
        /// </summary>
        public int LineNo { get; set; }

        /// <summary>
        /// 堆栈信息
        /// </summary>
        public string StackTrace { get; set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        public LogMessage(LogMessageLevels level, string sUserID, string sWkStation, string sMessage,
            string sCSFile, string sClass, string sMethod, int nLineNo, string sStackTrace)
        {
            DateTime = DateTime.Now;
            Level = level;
            UserID = sUserID;
            WkStation = sWkStation;
            if (String.IsNullOrEmpty(UserID))
                UserID = string.Empty;
            Message = sMessage;
            if (String.IsNullOrEmpty(Message))
                Message = string.Empty;
            CSFile = sCSFile;
            if (String.IsNullOrEmpty(CSFile))
                CSFile = string.Empty;
            Class = sClass;
            Method = sMethod;
            LineNo = nLineNo;
            StackTrace = sStackTrace;
            if (String.IsNullOrEmpty(StackTrace))
                StackTrace = string.Empty;
        }

        public override string ToString()
        {
            return string.Format("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}\t{7}\t{8}\t{9}",
                DateTime.ToString("yyyy-MM-dd HH:mm:ss.fff"), Level, Message, UserID, WkStation,
               Class, Method, CSFile, LineNo, StackTrace);
        }
    }
}
