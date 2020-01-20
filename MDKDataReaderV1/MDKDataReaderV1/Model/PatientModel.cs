using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MDKDataReaderV1.Model
{
    public class PatientModel
    {
        /// <summary>
        /// 序号
        /// </summary>
        public int Index { set; get; }

        /// <summary>
        /// 病人ID
        /// </summary>
        public int PatientID { set; get; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { set; get; }

        /// <summary>
        /// 性别
        /// </summary>
        public string Sex { set; get; }

        /// <summary>
        /// 年龄
        /// </summary>
        public int Age { set; get; }

        /// <summary>
        /// 检查类别
        /// </summary>
        public string CheckType { set; get; }

        /// <summary>
        /// 检查项目
        /// </summary>
        public string CheckItem { set; get; }

        /// <summary>
        /// 住院号
        /// </summary>
        public int ZhuYuanNo { set; get; }

        /// <summary>
        /// 检查日期
        /// </summary>
        public string CheckDate { set; get; }

        public PatientModel(int nIndex, int nPaintenID, string sName, string sSex, int nAge, string sCheckType, string sCheckItem, int nZYNo, string sCheckDate)
        {
            Index = nIndex;
            PatientID = nPaintenID;
            Name = sName;
            Sex = sSex;
            Age = nAge;
            CheckType = sCheckType;
            CheckItem = sCheckItem;
            ZhuYuanNo = nZYNo;
            CheckDate = sCheckDate;
        }
    }
}
