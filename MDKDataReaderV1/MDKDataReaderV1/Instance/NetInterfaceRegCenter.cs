using MDKDataReader.KernelInstance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace MDKDataReaderV1.Instance
{
    /// <summary>
    /// 接口注册中心
    /// </summary>
    class NetInterfaceRegCenter
    {
        /// <summary>
        /// 注册所有接口
        /// </summary>
        public static void RegAllInterface()
        {
            NetKernelManager.Init();
        }
    }
}
