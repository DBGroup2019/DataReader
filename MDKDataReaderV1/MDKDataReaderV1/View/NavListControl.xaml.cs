using MDKDataReaderV1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MDKDataReaderV1.View
{
    /// <summary>
    /// 导航列表标签项控件（可分左右两部分区分）
    /// </summary>
    public partial class NavListControl : UserControl
    {
        public event Action<PatientModel> EveChangePatient;    //选中datagrid行事件
        QueryManager m_queryMgr = new QueryManager();

        public NavListControl()
        {
            InitializeComponent();

            try
            {
                m_queryMgr.Init();
                this.DataContext = m_queryMgr;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            rdoWeek.IsChecked = true;
            btnQuery_Click(null, null);
        }


        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dg = sender as DataGrid;
            PatientModel mo = dg.CurrentItem as PatientModel;
            if (EveChangePatient != null)
            {
                EveChangePatient(mo);
            }
        }

        // 查询
        private void btnQuery_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                QueryModel queries = new QueryModel();
                if ((bool)ckbDate.IsChecked)
                {
                    queries.StartDate = DateTime.Parse(dpkStart.SelectedDate.ToString()).ToString("yyyy/MM/dd");
                    queries.EndDate = DateTime.Parse(dpkEnd.SelectedDate.ToString()).ToString("yyyy/MM/dd");
                    queries.DateType = cboDateType.SelectedValue.ToString();
                }
                if ((bool)ckbPar1.IsChecked)
                {
                    queries.QueryParam1Name = cboPar1.SelectedValue.ToString();
                    queries.QueryParam1Value = txtPar1.Text;
                    queries.QueryParam1IsContain = (bool)ckbContain1.IsChecked;
                }
                if ((bool)ckbPar2.IsChecked)
                {
                    queries.QueryParam2Name = cboPar2.SelectedValue.ToString();
                    queries.QueryParam2Value = txtPar2.Text;
                    queries.QueryParam2IsContain = (bool)ckbContain2.IsChecked;
                }

                foreach (var item in m_queryMgr.LstCheckType)
                {
                    if (item.IsChecked)
                    {
                        queries.CheckType.Add(item.Text);
                    }
                }

                m_queryMgr.GetPatient(queries);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void rdoToday_Checked(object sender, RoutedEventArgs e)
        {
            dpkStart.SelectedDate = DateTime.Today;
            dpkEnd.SelectedDate = DateTime.Today;

            ckbDate.IsChecked = true;
        }

        private void rdoWeek_Checked(object sender, RoutedEventArgs e)
        {
            DateTime nowTime = DateTime.Now;

            //星期一为第一天  
            int weeknow = Convert.ToInt32(nowTime.DayOfWeek);

            //因为是以星期一为第一天，所以要判断weeknow等于0时，要向前推6天。  
            weeknow = (weeknow == 0 ? (7 - 1) : (weeknow - 1));
            int daydiff = (-1) * weeknow;

            //本周第一天  
            DateTime startWeek = nowTime.AddDays(daydiff);

            //星期天为最后一天  
            int lastWeekDay = Convert.ToInt32(nowTime.DayOfWeek);
            lastWeekDay = lastWeekDay == 0 ? (7 - lastWeekDay) : lastWeekDay;
            int lastWeekDiff = (7 - lastWeekDay);

            //本周最后一天  
            DateTime endWeek = nowTime.AddDays(lastWeekDiff);

            dpkStart.SelectedDate = startWeek;
            dpkEnd.SelectedDate = endWeek;

            ckbDate.IsChecked = true;
        }

        private void rdoMonth_Checked(object sender, RoutedEventArgs e)
        {
            DateTime dt = DateTime.Now;
            DateTime startMonth = dt.AddDays(1 - dt.Day);             //本月初
            DateTime endMonth = startMonth.AddMonths(1).AddDays(-1);  //本月末

            dpkStart.SelectedDate = startMonth;
            dpkEnd.SelectedDate = endMonth;

            ckbDate.IsChecked = true;
        }

        private void rdoLastMonth_Checked(object sender, RoutedEventArgs e)
        {
            DateTime dt = DateTime.Now;
            dt = dt.AddMonths(-1);
            DateTime startLastMonth = dt.AddDays(1 - dt.Day);             //本月初
            DateTime endLastMonth = startLastMonth.AddMonths(1).AddDays(-1);  //本月末

            dpkStart.SelectedDate = startLastMonth;
            dpkEnd.SelectedDate = endLastMonth;

            ckbDate.IsChecked = true;
        }

        private void rdoYear_Checked(object sender, RoutedEventArgs e)
        {
            DateTime dt = DateTime.Now;
            DateTime startYear = new DateTime(dt.Year, 1, 1);  //本年初
            DateTime endYear = new DateTime(dt.Year, 12, 31);  //本年末

            dpkStart.SelectedDate = startYear;
            dpkEnd.SelectedDate = endYear;

            ckbDate.IsChecked = true;
        }

        private void rdoLastYear_Checked(object sender, RoutedEventArgs e)
        {
            DateTime dt = DateTime.Now;
            dt = dt.AddYears(-1);
            DateTime startLastYear = new DateTime(dt.Year, 1, 1);  //上年初
            DateTime endLastYear = new DateTime(dt.Year, 12, 31);  //上年末

            dpkStart.SelectedDate = startLastYear;
            dpkEnd.SelectedDate = endLastYear;

            ckbDate.IsChecked = true;
        }

        private void rdoCustom_Checked(object sender, RoutedEventArgs e)
        {
            ckbDate.IsChecked = true;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
        }

        private void txtPar1_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (!string.IsNullOrEmpty(textBox.Text))
            {
                ckbPar1.IsChecked = true;
            }
            else
            {
                ckbPar1.IsChecked = false;
            }
        }

        private void txtPar2_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (!string.IsNullOrEmpty(textBox.Text))
            {
                ckbPar2.IsChecked = true;
            }
            else
            {
                ckbPar2.IsChecked = false;
            }
        }
    }
}
