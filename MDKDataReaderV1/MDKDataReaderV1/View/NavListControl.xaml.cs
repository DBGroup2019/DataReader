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
        public event Action<PatientModel> ChanngePatient = null;
        QueryManager qryModel = null;
        public NavListControl()
        {
            InitializeComponent();
            qryModel = new QueryManager();
            qryModel.Init();
            this.DataContext = qryModel;
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dg = sender as DataGrid;
            PatientModel mo = dg.CurrentItem as PatientModel;
            if (ChanngePatient != null)
            {
                ChanngePatient((sender as DataGrid).CurrentItem as PatientModel);
            }
        }
    }
}
