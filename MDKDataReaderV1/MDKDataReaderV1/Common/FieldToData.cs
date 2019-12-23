using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace MDKDataReaderV1.Common
{
    /// <summary>
    /// 字段取值辅助类
    /// </summary>
    class FieldToData
    {
        static public int ToInt(DataRow dr, string sCol)
        {
            if (dr.IsNull(sCol))
                return -1;
            int nresult;
            if (!Int32.TryParse(dr[sCol].ToString(), out nresult))
                nresult = -1;
            return nresult;
        }

        static public Int64 ToInt64(DataRow dr, string sCol)
        {
            if (dr.IsNull(sCol))
                return -1;
            Int64 nresult;
            if (!Int64.TryParse(dr[sCol].ToString(), out nresult))
                nresult = -1;
            return nresult;
        }

        static public string ToString(DataRow dr, string sCol)
        {
            if (dr.IsNull(sCol))
                return string.Empty;
            return dr[sCol].ToString();
        }

        static public bool ToBool(DataRow dr, string sCol)
        {
            if (dr.IsNull(sCol))
                return false;

            return (dr[sCol].ToString() == "T" || dr[sCol].ToString() == "1");
        }

        static public byte[] ToByteArray(DataRow dr, string sCol)
        {
            if (dr.IsNull(sCol))
                return null;
            return (byte[])(dr[sCol]);
        }
    }
}
