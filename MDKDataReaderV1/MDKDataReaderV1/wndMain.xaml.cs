using MDK.KitV5.Controls;
using MDKDataReaderV1.Model;
using MDKDataReaderV1.View;
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

namespace MDKDataReaderV1
{
    /// <summary>
    /// 数据浏览主窗口
    /// </summary>
    public partial class wndMain : MDKWindow
    {
        public wndMain()
        {
            InitializeComponent();
            NavListControl nav = new NavListControl();
            gNavList.Children.Add(nav);
            nav.ChangePatient += ChangePatient;
            
        }
        
        /// <summary>
        /// 当前病人信息
        /// </summary>
        public PatientModel CurrentPatient { set; get; }

        void ChangePatient(PatientModel dCurrentPatient)
        {
            CurrentPatient = dCurrentPatient;
            if(this.DataContext != null)
                this.DataContext = null;
            this.DataContext = this;
        }
    }
}
