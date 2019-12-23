using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MDKDataReader.Kernel.Core.Config
{
    public interface ISettingIniOperation
    {
        AnyDataConfigModel AnyData { get; }

        bool ReadValue(string sSection, string sKey, out string sValue, string sIniFile = null);

        bool WriteValue(string sSection, string sKey, string sValue, string sIniFile = null);
    }
}
