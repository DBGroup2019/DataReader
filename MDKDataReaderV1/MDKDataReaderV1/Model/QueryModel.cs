using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MDKDataReaderV1.Model
{
    public class QueryModel
    {
        /// <summary>
        /// 开始日期
        /// </summary>
        public string StartDate { get; set; }
        /// <summary>
        /// 结束日期
        /// </summary>
        public string EndDate { get; set; }
        /// <summary>
        /// 日期索引字段
        /// </summary>
        public string DateType { get; set; }

        /// <summary>
        /// 自定义查询参数1字段名
        /// </summary>
        public string QueryParam1Name { get; set; }
        /// <summary>
        /// 自定义查询参数1值
        /// </summary>
        public string QueryParam1Value { get; set; }
        /// <summary>
        /// 是否以包含方式将自定义参数1作为查询条件
        /// </summary>
        public bool QueryParam1IsContain { get; set; }

        /// <summary>
        /// 自定义查询参数2字段名
        /// </summary>
        public string QueryParam2Name { get; set; }
        /// <summary>
        /// 自定义查询参数2值
        /// </summary>
        public string QueryParam2Value { get; set; }
        /// <summary>
        /// 是否以包含方式将自定义参数2作为查询条件
        /// </summary>
        public bool QueryParam2IsContain { get; set; }

        /// <summary>
        /// 检查类型
        /// </summary>
        public List<string> CheckType
        {
            get { return _CheckType; }
            set { value = CheckType; }
        }

        private List<string> _CheckType = new List<string>();

    }
}
