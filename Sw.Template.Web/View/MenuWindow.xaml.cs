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
        public bool Visibilitys { get; set; } = false;
        public MenuWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Visibilitys)
            {
                stackPanelLeft.Visibility = Visibility.Visible;
                Visibilitys = false;
            }
            else
            {
                stackPanelLeft.Visibility = Visibility.Collapsed;
                Visibilitys = true;
            }

        }
    }
}
