using Ayx.AvalonDI;
using Ninject;
using Sw.Template.Interfaces;
using Sw.Template.Web.Helpers;
using Sw.Template.Web.ViewModel;
using Sw.Template.Web.Views;
using System.Windows;

namespace Sw.Template.Web
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        //View和ViewModel的容器
        public static AvalonContainer VM;
        //Ninject容器
        public static StandardKernel Ninject;

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            //初始化服务依赖
            InitDependency();
            //显示主窗口
            VM.GetView<EntranceWindow>()?.Show();
        }
        private void InitDependency()
        {
            //配置Ninject依赖
            Ninject = new StandardKernel();

            #region 注入接口
            Ninject.Bind<ISysUsersService>().To<SysUsersService>().InSingletonScope();
            Ninject.Bind<ISysUserMenuService>().To<SysUserMenuService>().InSingletonScope();
            Ninject.Bind<ISysMenuService>().To<SysMenuService>().InSingletonScope();
            #endregion

            //使用Ninject容器创建View和ViewModel依赖容器
            VM = new AvalonContainer(new NinjectContainer(Ninject));
            //配置View和ViewModel依赖
            VM.WireVM<MainWindow, MainViewModel>();
            VM.WireVM<EntranceWindow, EntranceViewModel>();
        }
    }
}
