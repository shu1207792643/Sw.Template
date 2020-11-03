using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;

namespace Sw.Template.Web.ViewModel
{
    /// <summary>
    /// �����������������ͼģ�͵ľ�̬����
    /// Ӧ�ó��򣬲��ṩ�󶨵���ڵ㡣
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// ��ʼ��ViewModelLocator�����ʵ����
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