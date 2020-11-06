using GalaSoft.MvvmLight;
using Sw.Template.Interfaces;

namespace Sw.Template.Web.ViewModel
{

    public class MainViewModel : ViewModelBase
    {
        private readonly ISysUsersService sysUsersService;
        public MainViewModel(ISysUsersService sysUsersService)
        {
            this.sysUsersService = sysUsersService;
        }
    }
}