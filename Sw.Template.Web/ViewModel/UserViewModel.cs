using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Sw.Template.Entity;
using Sw.Template.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sw.Template.Web.ViewModel
{
    public class UserViewModel : ViewModelBase
    {
        public virtual List<Sys_User> UserList { get; set; }

        private readonly ISysUserService sysUserService;
        public UserViewModel(ISysUserService sysUserService)
        {
            this.sysUserService = sysUserService;
            UserList = GetUserList();
            UserListCommand = new RelayCommand(GetUser);

        }

        public RelayCommand UserListCommand { get; private set; }

        public List<Sys_User> GetUserList()
        {
            var userList = sysUserService.GetAll();
            if (userList.Count > 0)
            {
                return userList;
            }
            return null;
        }

        public void GetUser()
        {
            UserList = GetUserList();
        }
    }
}
