using MahApps.Metro.Controls;
using Sw.Template.Common;
using Sw.Template.Interfaces;
using System.Windows;

namespace Sw.Template.Web
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        private readonly ISysUsersService sysUsersService;
        public MainWindow(ISysUsersService sysUsersService)
        {
            this.sysUsersService = sysUsersService;
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            sysUsersService.GetList();
        }
    }
}
