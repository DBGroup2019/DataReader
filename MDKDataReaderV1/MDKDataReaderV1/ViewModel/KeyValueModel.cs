using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MDKDataReaderV1.ViewModel
{
    /// <summary>
    /// 自定义键值对
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="V"></typeparam>
    public class KeyValueModel<T, V>
    {
        /// <summary>
        /// 键
        /// </summary>
        public T Key { get; set; }
        /// <summary>
        /// 值
        /// </summary>
        public V Value { get; set; }

        public KeyValueModel(T sKey, V sValue)
        {
            Key = sKey;
            Value = sValue;
        }
    }
}
