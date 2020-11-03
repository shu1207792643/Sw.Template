using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Sw.Template.Common;
using Sw.Template.Interfaces;
using Sw.Template.Web.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows;

namespace Sw.Template.Web.ViewModel
{
    public class EntranceViewModel : ViewModelBase
    {
        private readonly ISysUsersService sysUsersService;
        public EntranceViewModel(ISysUsersService sysUsersService)
        {
            this.sysUsersService = sysUsersService;
        }
        private string userName;

        public string UserName
        {
            get { return userName; }
            set { userName = value; RaisePropertyChanged(); }
        }

        private string userPassword;

        public string UserPassword
        {
            get { return userPassword; }
            set { userPassword = value; RaisePropertyChanged(); }
        }
        private RelayCommand entrance;

        public RelayCommand Entrance
        {
            get
            {
                if (entrance == null)
                    entrance = new RelayCommand(() => Login());
                return entrance;
            }
        }

        private void Login()
        {
            UserLoginModel userLoginModel = new UserLoginModel()
            {
                UserName = UserName,
                UserPassword = userPassword
            };
            var ser = sysUsersService.Login(userLoginModel);
            if (ser.StatusCode == 200)
            {
                MainWindow window = new MainWindow();
                window.Show();//无模式，弹出！
            }
            else
            {
                MessageBox.Show("账号或密码错误！");
            }
        }
    }
}
