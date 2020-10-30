using System;
using System.IO;
using System.Windows;
using System.Windows.Threading;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sw.Template.Common;
using Sw.Template.Interfaces;
using Sw.Template.Web.View;

namespace Sw.Template.Web
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        public IServiceProvider ServiceProvider { get; private set; }
        public IConfiguration Configuration { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            this.DispatcherUnhandledException += new DispatcherUnhandledExceptionEventHandler(App_DispatcherUnhandledException);



            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory());

            Configuration = builder.Build();


            var serviceCollection = new ServiceCollection();

            ConfigureServices(serviceCollection);

            ServiceProvider = serviceCollection.BuildServiceProvider();

            var mainWindow = ServiceProvider.GetRequiredService<MainWindow>();

            mainWindow.Show();
        }

        /// <summary>
        /// 全局异常
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void App_DispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            LogHelper.WriteError(e.Exception);
        }

        private void ConfigureServices(IServiceCollection services)
        {

            services.AddScoped<ISysUsersService, SysUsersService>();
            services.AddScoped<ISysUserMenuService, SysUserMenuService>();
            services.AddScoped<ISysMenuService, SysMenuService>();

            services.AddTransient(typeof(MainWindow));
        }
    }
}
