using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MDKDataReader.Kernel.Basic.Logger
{
    /// <summary>
    /// 日志库接口
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// 当前日志名称（用于区分不同日志）
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// 是否启用Info记录
        /// </summary>
        bool IsInfoEnabled { get; set; }

        /// <summary>
        /// 是否启用Trace记录
        /// </summary>
        bool IsTraceEnabled { get; set; }

        /// <summary>
        /// 是否启用Debug记录
        /// </summary>
        bool IsDebugEnabled { get; set; }

        /// <summary>
        /// 是否启用Warn记录
        /// </summary>
        bool IsWarnEnabled { get; set; }

        /// <summary>
        /// 是否启用Fatal记录
        /// </summary>
        bool IsErrorEnabled { get; set; }

        /// <summary>
        /// 是否启用Fatal记录
        /// </summary>
        bool IsFatalEnabled { get; set; }

        /// <summary>
        /// 初始化相关参数
        /// </summary>
        void Initialize();

        /// <summary>
        /// 普通信息，对运维工程师来说这些信息有价值的，info指明程序的运行是否符合正确的业务逻辑。
        /// </summary>
        /// <param name="sMessage">消息内容</param>
        /// <param name="ex">异常错误</param>
        void Info(string sMessage, Exception ex = null);

        /// <summary>
        /// 帮助您跟踪代码执行情况,将消息写入 System.Diagnostics.Trace.Listeners 集合中的跟踪侦听器。
        /// </summary>
        /// <param name="sMessage">消息内容</param>
        /// <param name="ex">异常错误</param>
        void Trace(string sMessage, Exception ex = null);

        /// <summary>
        /// 程序内部的信息，对于外部使用的人是没有意义,对于调式程序是非常有用的。
        /// </summary>
        /// <param name="sMessage">消息内容</param>
        /// <param name="ex">异常错误</param>
        void Debug(string sMessage, Exception ex = null);

        /// <summary>
        /// 警告信息，程序运行发生错误，但是内部可以处理。
        /// </summary>
        /// <param name="sMessage">消息内容</param>
        /// <param name="ex">异常错误</param>
        void Warn(string sMessage, Exception ex = null);

        /// <summary>
        /// 非致命错误消息，程序运行发生错误，内部无法处理，但是程序仍然可以继续运行。
        /// </summary>
        /// <param name="sMessage">消息内容</param>
        /// <param name="ex">异常错误</param>
        void Error(string sMessage, Exception ex = null);

        /// <summary>
        /// 致命错误消息，错误可能会导致应用崩溃。
        /// </summary>
        /// <param name="sMessage">消息内容</param>
        /// <param name="ex">异常错误</param>
        void Fatal(string sMessage, Exception ex = null);

        /// <summary>
        /// 记录日志（需要自己构建LogMessage对象）,不建议直接使用
        /// </summary>
        /// <param name="log">LogMessage对象</param>
        void Log(LogMessage log);
    }

    /// <summary>
    /// 日志消息级别（枚举）
    /// </summary>
    public enum LogMessageLevels
    {
        /// <summary>
        /// 普通信息，对运维工程师来说这些信息有价值的，info指明程序的运行是否符合正确的业务逻辑。
        /// </summary>
        Info = 0,
        /// <summary>
        /// 帮助您跟踪代码执行情况,将消息写入 System.Diagnostics.Trace.Listeners 集合中的跟踪侦听器。
        /// </summary>
        Trace = 1,
        /// <summary>
        /// 程序内部的信息，对于外部使用的人是没有意义,对于调式程序是非常有用的。
        /// </summary>
        Debug = 2,
        /// <summary>
        /// 警告信息，程序运行发生错误，但是内部可以处理。
        /// </summary>
        Warn = 3,
        /// <summary>
        /// 非致命错误消息，程序运行发生错误，内部无法处理，但是程序仍然可以继续运行。
        /// </summary>
        Error = 4,
        /// <summary>
        /// 致命错误消息，错误可能会导致应用崩溃。
        /// </summary>
        Fatal = 5
    }
}