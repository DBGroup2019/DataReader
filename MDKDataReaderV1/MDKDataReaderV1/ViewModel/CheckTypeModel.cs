using MDKDataReaderV1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MDKDataReaderV1.ViewModel
{
    /// <summary>
    /// 检查类型 CheckBox 数据模型
    /// </summary>
    public class CheckTypeModel : ViewModelBase
    {
        /// <summary>
        /// 显示文本
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// 是否选中
        /// </summary>
        public bool IsChecked { get; set; }
    }
}
