using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Sw.Template.Interfaces;

namespace Sw.Template.Web.ViewModel
{

    public class ViewModelLocator
    {

        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            //if (ViewModelBase.IsInDesignModeStatic)
            //{
            //    // Create design time view services and models
            //    SimpleIoc.Default.Register<ISysUsersService, SysUsersService>();
            //}
            //else
            //{
            //    // Create run time view services and models
            //    //SimpleIoc.Default.Register<IDataService, DataService>();
            //}
            #region �ӿ�
            SimpleIoc.Default.Register<ISysUserService, SysUserService>();

            SimpleIoc.Default.Register<ISysMenuService, SysMenuService>();

            SimpleIoc.Default.Register<ISysUserMenuService, SysUserMenuService>();
            #endregion

            #region View����ViewModel
            SimpleIoc.Default.Register<MainViewModel>();

            SimpleIoc.Default.Register<LoginViewModel>();

            SimpleIoc.Default.Register<MenuViewModel>();

            SimpleIoc.Default.Register<UserViewModel>();
            #endregion
        }
        //��ҳ
        public MainViewModel MainViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }
        //��¼
        public LoginViewModel LoginViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<LoginViewModel>();
            }
        }
        //�˵�
        public MenuViewModel MenuViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MenuViewModel>();
            }
        }
        //�û�����
        public UserViewModel UserViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<UserViewModel>();
            }
        }
        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}