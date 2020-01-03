using MDK.KitV5.MDKMessageBox;
using MDKDataReader.Kernel;
using MDKDataReaderV1.Instance;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;

namespace MDKDataReaderV1
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            try
            {
                base.OnStartup(e);

                MDK.KitV5.Theme.InitTheme();
                NetInterfaceRegCenter.RegAllInterface();

                AnyLoggerManager.Info("开始启动...");
            }
            catch (Exception ex)
            {
                new MdcException(ex.Message).Show();
                App.Current.Shutdown();
            }
        }
    }
}
