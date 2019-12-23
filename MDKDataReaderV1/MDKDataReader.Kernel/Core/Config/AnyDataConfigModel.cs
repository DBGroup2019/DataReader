using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MDKDataReader.Kernel.Core.Config
{
    /// <summary>
    /// AnyData配置
    /// </summary>
    public class AnyDataConfigModel
    {
        public string DbServer_HostName { get; protected set; }
        public string DbServer_Database { get; protected set; }

        public string PacsServer_HostName { get; protected set; }
        public string PacsServer_Database { get; protected set; }
        public string PacsServer_SerIP { get; protected set; }
        public int PacsServer_SerPortNo { get; protected set; }

        public string Schedule_HostName { get; protected set; }
        public string Schedule_Database { get; protected set; }

        public string MessageServer_IP { get; protected set; }

        public string NetValidate_IP { get; protected set; }
        public int NetValidate_PortNo { get; protected set; }

        /// <summary>
        /// 2017-9-25 临时授权
        /// </summary>
        public string NetValidata_SNo { get;protected set; }
    }
}
