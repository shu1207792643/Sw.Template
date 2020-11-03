using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;

namespace Sw.Template.Web.ViewModel
{
    /// <summary>
    /// 此类包含对中所有视图模型的静态引用
    /// 应用程序，并提供绑定的入口点。
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// 初始化ViewModelLocator类的新实例。
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register<MainViewModel>();
        }

        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }
        
        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}