using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Sw.Template.Web.View
{
    /// <summary>
    /// MenuWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MenuWindow : UserControl
    {
        public MenuWindow()
        {
            InitializeComponent();
        }

        private void HamburgerMenu_OptionsItemClick(object sender, MahApps.Metro.Controls.ItemClickEventArgs args)
        {
            //var menuItem = args.ClickedItem as MenuItem;
            //contentFrame.Navigate(menuItem.PageType);
        }
    }
}
