using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Sw.Template.Common;
using Sw.Template.Entity;
using Sw.Template.Interfaces;
using Sw.Template.Web.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Sw.Template.Web.ViewModel
{
    public class LoginViewModel : ViewModelBase
    {
        private bool toClose = false;
        /// <summary>
        /// 是否要关闭窗口
        /// </summary>
        public bool ToClose
        {
            get
            {
                return toClose;
            }
            set
            {
                toClose = value;
                if (toClose)
                {
                    this.RaisePropertyChanged("ToClose");
                }
            }
        }

        public string UserName { get; set; }

        public string PassWord { get; set; }

        private readonly ISysUserService sysUsersService;
        public LoginViewModel(ISysUserService sysUsersService)
        {
            this.sysUsersService = sysUsersService;
            LoginCommand = new RelayCommand(Login);
        }

        public RelayCommand LoginCommand { get; private set; }

        public void Login()
        {
            UserLoginModel userLoginModel = new UserLoginModel()
            {
                UserName = UserName,
                UserPassword = PassWord
            };
            var ser = sysUsersService.Login(userLoginModel);
            if (ser.StatusCode == 200)
            {
                UserHelper.UserModel = ser.Result as Sys_User;

                MainWindow main = new MainWindow();
                main.Show();
                ToClose = true;
            }
        }
    }
}
