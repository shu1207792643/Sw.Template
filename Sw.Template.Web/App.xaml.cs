using Sw.Template.Web.Helper;
using System.Windows;

namespace Sw.Template.Web
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            InitAutofac.InitAutofacs();
            base.OnStartup(e);
        }
    }
}
