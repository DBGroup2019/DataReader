using MDKDataReader.Kernel.Basic.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MDKDataReader.Kernel
{
    /// <summary>
    /// 日志管理器
    /// </summary>
    public static class AnyLoggerManager
    {
        private static Dictionary<string, ILogger> m_dic = new Dictionary<string, ILogger>();

        /// <summary>
        /// 注册日志库
        /// </summary>
        /// <param name="controlName">类型名称</param>
        /// <param name="instance">实例</param>
        /// <returns></returns>
        public static bool RegisterLogger(string controlName, ILogger instance)
        {
            if (instance == null)
                return false;

            m_dic[controlName] = instance;
            return true;
        }

        /// <summary>
        /// 取得所有日志库
        /// </summary>
        /// <returns></returns>
        public static List<ILogger> GetAllInterface()
        {
            return m_dic.Values.ToList();
        }

        /// <summary>
        /// 获取指定契约的日志库
        /// </summary>
        /// <param name="sContractName">契约</param>
        /// <returns>接口</returns>
        public static ILogger GetInterface(string sContractName)
        {
            if (m_dic.ContainsKey(sContractName))
                return m_dic[sContractName];
            else
                return null;
        }

        /// <summary>
        /// 普通信息，对运维工程师来说这些信息有价值的，info指明程序的运行是否符合正确的业务逻辑。xuan
        /// </summary>
        /// <param name="sMessage">消息内容</param>
        /// <param name="ex">异常错误</param>
        public static void Info(string sMessage, Exception ex = null)
        {
            m_dic.Values.ToList().ForEach(item => item.Info(sMessage, ex));
        }

        /// <summary>
        /// 帮助您跟踪代码执行情况,将消息写入 System.Diagnostics.Trace.Listeners 集合中的跟踪侦听器。
        /// </summary>
        /// <param name="sMessage">消息内容</param>
        /// <param name="ex">异常错误</param>
        public static void Trace(string sMessage, Exception ex = null)
        {
            //if (ex != null)
            //    System.Diagnostics.Trace.WriteLine(sMessage + ":" + ex.Message);
            //else
            //    System.Diagnostics.Trace.WriteLine(sMessage);
            m_dic.Values.ToList().ForEach(item => item.Trace(sMessage, ex));
        }

        /// <summary>
        /// 程序内部的信息，对于外部使用的人是没有意义,对于调式程序是非常有用的。
        /// </summary>
        /// <param name="sMessage">消息内容</param>
        /// <param name="ex">异常错误</param>
        public static void Debug(string sMessage, Exception ex = null)
        {
            m_dic.Values.ToList().ForEach(item => item.Debug(sMessage, ex));
        }

        /// <summary>
        /// 警告信息，程序运行发生错误，但是内部可以处理。
        /// </summary>
        /// <param name="sMessage">消息内容</param>
        /// <param name="ex">异常错误</param>
        public static void Warn(string sMessage, Exception ex = null)
        {
            m_dic.Values.ToList().ForEach(item => item.Warn(sMessage, ex));
        }

        /// <summary>
        /// 非致命错误消息，程序运行发生错误，内部无法处理，但是程序仍然可以继续运行。
        /// </summary>
        /// <param name="sMessage">消息内容</param>
        /// <param name="ex">异常错误</param>
        public static void Error(string sMessage, Exception ex = null)
        {
            m_dic.Values.ToList().ForEach(item => item.Error(sMessage, ex));
        }

        /// <summary>
        /// 致命错误消息，错误可能会导致应用崩溃。
        /// </summary>
        /// <param name="sMessage">消息内容</param>
        /// <param name="ex">异常错误</param>
        public static void Fatal(string sMessage, Exception ex = null)
        {
            m_dic.Values.ToList().ForEach(item => item.Fatal(sMessage, ex));
        }

        /// <summary>
        /// 记录日志（需要自己构建LogMessage对象）,不建议直接使用
        /// </summary>
        /// <param name="log">LogMessage对象</param>
        public static void Log(LogMessage log)
        {
            m_dic.Values.ToList().ForEach(item => item.Log(log));
        }
    }
}
