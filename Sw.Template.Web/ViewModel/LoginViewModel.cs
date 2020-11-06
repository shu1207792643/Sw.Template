using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Sw.Template.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sw.Template.Web.ViewModel
{
    public class LoginViewModel : ViewModelBase
    {
        private readonly ISysUsersService sysUsersService;
        public LoginViewModel(ISysUsersService sysUsersService)
        {
            this.sysUsersService = sysUsersService;
            LoginCommand = new RelayCommand(Login);
        }

        public RelayCommand LoginCommand { get; private set; }

        public void Login()
        {
            MainWindow main = new MainWindow();
            main.Show();
        }
    }
}
