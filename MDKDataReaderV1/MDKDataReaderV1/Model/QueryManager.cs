using MDKDataReader.KernelInstance.DataBase;
using MDKDataReaderV1.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace MDKDataReaderV1.Model
{
    public class QueryManager
    {
        /// <summary>
        /// 查询日期类型
        /// </summary>
        public ObservableCollection<KeyValuePair<string, string>> DateType { get; set; }
        /// <summary>
        /// 自定义查询1字段名称
        /// </summary>
        public ObservableCollection<KeyValuePair<string, string>> QueryParam1Name { get; set; }
        /// <summary>
        /// 自定义查询2字段名称
        /// </summary>
        public ObservableCollection<KeyValuePair<string, string>> QueryParam2Name { get; set; }
        /// <summary>
        /// 病人信息
        /// </summary>
        public ObservableCollection<PatientModel> lstPatient { set; get; }
        /// <summary>
        /// 检查类型
        /// </summary>
        public ObservableCollection<CheckTypeModel> lstCheckType { set; get; }

        // db初始化
        private MdcDatabase _db = new MdcDatabase("192.168.2.6", "AnyImageQL");

        public void Init()
        {
            lstPatient = new ObservableCollection<PatientModel>();
            LoadComboBox();

            lstCheckType = new ObservableCollection<CheckTypeModel>();
            GetCheckType();
        }

        /// <summary>
        /// 初始化 ComboBox 数据
        /// </summary>
        public void LoadComboBox()
        {
            DateType = new ObservableCollection<KeyValuePair<string, string>>();
            DateType.Add(new KeyValuePair<string, string>("检查日期", "ExamDate"));

            QueryParam1Name = new ObservableCollection<KeyValuePair<string, string>>();
            QueryParam1Name.Add(new KeyValuePair<string, string>("姓名", "Name1"));
            QueryParam1Name.Add(new KeyValuePair<string, string>("性别", "Sex1"));
            QueryParam1Name.Add(new KeyValuePair<string, string>("年龄", "Age1"));

            QueryParam2Name = new ObservableCollection<KeyValuePair<string, string>>();
            QueryParam2Name.Add(new KeyValuePair<string, string>("住院号", "MID"));
        }

        /// <summary>
        /// 获取检查类别
        /// </summary>
        public void GetCheckType()
        {
            try
            {
                string sSql = "select t.Name from grid.BZ_ES_ExamType t";
                DataTable dt = _db.GetDataTable(sSql);
                if (dt != null && dt.Rows.Count > 0)
                {
                    int nCount = dt.Rows.Count;
                    for (int i = 0; i < nCount; i++)
                    {
                        lstCheckType.Add(new CheckTypeModel() { Text = dt.Rows[i]["Name"].ToString(), IsChecked = false });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 获取病人信息
        /// </summary>
        /// <param name="queries"></param>
        public void GetPatient(QueryModel queries)
        {
            try
            {
                string sSql = "select t.ID, t.Name1, t.Sex1, t.Age1, t.Eq, t.ExamItems, t.MID, t.ExamDate from grid.BHosCheckES t ";

                List<string> wheres = new List<string>();
                string sWhere = "";
                List<SqlParameter> sqlPars = new List<SqlParameter>();

                if (!string.IsNullOrEmpty(queries.DateType))
                {
                    if (!string.IsNullOrEmpty(queries.StartDate))
                    {
                        sWhere = $"t.{queries.DateType} >= @StartDate ";
                        sqlPars.Add(new SqlParameter("@StartDate", queries.StartDate + " 0:00:00"));
                        wheres.Add(sWhere);
                    }
                    if (!string.IsNullOrEmpty(queries.EndDate))
                    {
                        sWhere = $"t.{queries.DateType} < @EndDate";
                        sqlPars.Add(new SqlParameter("@EndDate", queries.EndDate + " 23:59:59"));
                        wheres.Add(sWhere);
                    }
                }

                if (!string.IsNullOrEmpty(queries.QueryParam1Name))
                {
                    if (!string.IsNullOrEmpty(queries.QueryParam1Value))
                    {
                        if (!queries.QueryParam1IsContain)
                        {
                            sWhere = $"t.{queries.QueryParam1Name} = @QueryParam1Value";
                            sqlPars.Add(new SqlParameter("@QueryParam1Value", queries.QueryParam1Value));
                            wheres.Add(sWhere);
                        }
                        else
                        {
                            sWhere = $"t.{queries.QueryParam1Name} like @QueryParam1Value";
                            sqlPars.Add(new SqlParameter("@QueryParam1Value", "%" + queries.QueryParam1Value + "%"));
                            wheres.Add(sWhere);
                        }
                    }
                }

                if (!string.IsNullOrEmpty(queries.QueryParam2Name))
                {
                    if (!string.IsNullOrEmpty(queries.QueryParam2Value))
                    {
                        if (!queries.QueryParam2IsContain)
                        {
                            sWhere = $"t.{queries.QueryParam2Name} = @QueryParam2Value";
                            sqlPars.Add(new SqlParameter("@QueryParam2Value", queries.QueryParam2Value));
                            wheres.Add(sWhere);
                        }
                        else
                        {
                            sWhere = $"t.{queries.QueryParam2Name} like @QueryParam2Value";
                            sqlPars.Add(new SqlParameter("@QueryParam2Value", "%" + queries.QueryParam2Value + "%"));
                            wheres.Add(sWhere);
                        }
                    }
                }

                int nCheckType = queries.CheckType.Count;
                string sSql_CheckType = "";
                if (nCheckType > 0)
                {
                    List<string> lsCheckTypes = new List<string>();
                    string sCheckType = "";

                    for (int i = 0; i < nCheckType; i++)
                    {
                        sCheckType = $"t.Eq = @CheckType_{i}";
                        sqlPars.Add(new SqlParameter($"@CheckType_{i}", queries.CheckType[i]));
                        lsCheckTypes.Add(sCheckType);
                    }

                    sSql_CheckType = string.Join(" or ", lsCheckTypes);
                    sSql_CheckType = $"({sSql_CheckType})";

                    wheres.Add(sSql_CheckType);
                }

                if (wheres.Count > 0)
                {
                    sSql += "where " + string.Join(" and ", wheres);
                }

                DataTable dt = _db.GetDataTable(sSql, sqlPars.ToArray());
                if (dt != null && dt.Rows.Count > 0)
                {
                    lstPatient.Clear();
                    int nCount = dt.Rows.Count;
                    for (int i = 0; i < nCount; i++)
                    {
                        int nPId = int.Parse(dt.Rows[i]["ID"]?.ToString());
                        string sName = dt.Rows[i]["Name1"]?.ToString();
                        string sSex = dt.Rows[i]["Sex1"]?.ToString();
                        int nAge = int.Parse(dt.Rows[i]["Age1"]?.ToString());
                        string sEq = dt.Rows[i]["Eq"]?.ToString();
                        string sExamItems = dt.Rows[i]["ExamItems"]?.ToString();
                        int nMId = int.Parse(dt.Rows[i]["MID"]?.ToString());
                        string sExamDate = dt.Rows[i]["ExamDate"]?.ToString();

                        lstPatient.Add(new PatientModel(i, nPId, sName, sSex, nAge, sEq, sExamItems, nMId, sExamDate));
                    }
                }
                else
                {
                    lstPatient.Clear();
                }
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
