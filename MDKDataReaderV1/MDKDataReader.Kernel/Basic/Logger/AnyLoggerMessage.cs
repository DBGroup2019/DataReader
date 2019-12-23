using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace MDKDataReader.Kernel.Basic.Logger
{
    /// <summary>
    /// 日志消息（从参数创建）
    /// </summary>
    public static class AnyLoggerMessage
    {
        public static string CreateMessage<T>(T t)
        {
            if (t == null)
            {
                return "(NULL)";
            }
            else if (t is Dictionary<string, List<string>>)
            {
                Dictionary<string, List<string>> args = t as Dictionary<string, List<string>>;

                string sInfo = string.Empty;
                args.Keys.ToList().ForEach(item =>
                {
                    string sValue = string.Empty;
                    if (args[item] != null)
                        args[item].ForEach(value => sValue += value + ";");

                    sInfo += "Key=" + item + ",Value={" + sValue + "};";
                });
                return sInfo;
            }
            else if (t is List<string>)
            {
                List<string> args = t as List<string>;

                string sValue = string.Empty;
                args.ForEach(value => sValue += value + ";");

                return sValue;
            }
            else if (t is IDataParameter[])
            {
                IDataParameter[] args = t as IDataParameter[];

                string sValue = string.Empty;
                args.ToList().ForEach(value => sValue += value.ParameterName + "=" + value.Value.ToString() + ";");

                return sValue;
            }

            return t.ToString();
        }

        public static string CreateMessage<T, Y>(T t, Y y)
        {
            return CreateMessage(t) + ";" + CreateMessage(y);
        }

        public static string CreateMessage<T, Y, U>(T t, Y y, U u)
        {
            return CreateMessage(t, y) + ";" + CreateMessage(u);
        }

        public static string CreateMessage<T, Y, U, I>(T t, Y y, U u, I i)
        {
            return CreateMessage(t, y, u) + ";" + CreateMessage(i);
        }

        public static string CreateMessage<T, Y, U, I, O>(T t, Y y, U u, I i, O o)
        {
            return CreateMessage(t, y, u, i) + ";" + CreateMessage(o);
        }

        public static string CreateMessage<T, Y, U, I, O, P>(T t, Y y, U u, I i, O o, P p)
        {
            return CreateMessage(t, y, u, i, o) + ";" + CreateMessage(p);
        }
    }
}
