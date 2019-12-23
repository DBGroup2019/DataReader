using MDKDataReader.Kernel.Basic.Data;
using MDKDataReader.Kernel.Basic.Logger;
using MDKDataReader.Kernel.Core.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MDKDataReader.Kernel
{
    /// <summary>
    /// 开发接口
    /// </summary>
    public class NetInterface
    {
        /// <summary>
        /// 图文数据库接口
        /// </summary>
        public static IDataAccess DataAccess_AnyImage { get; protected set; }
        
        /// <summary>
        /// 配置文件接口
        /// </summary>
        public static ISettingIniOperation SettingIniOperation { get; protected set; }
    }
}
