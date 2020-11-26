using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Sw.Template.Entity;
using Sw.Template.Interfaces;
using Sw.Template.Web.Helper;
using Sw.Template.Web.View.Dialog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Sw.Template.Web.ViewModel
{
    public class UserViewModel : ViewModelBase
    {
        public string UserTitle { get; set; }

        public List<Sys_User> UserList { get; set; }

        public Sys_User UserModel { get; set; }

        public string Q { get; set; }

        public ICommand QueryCommand => new CommandBase(GetUserList);

        public ICommand ResetCommand => new CommandBase(ResetUserList);

        public ICommand SysUserDialogCommand => new CommandBase(UserDialog);

        public ICommand UserAddOrUpdateCommand => new CommandBase(UserAddOrUpdate);

        public ICommand Edit => new RelayCommand<object>((userModel) =>
        {
            Sys_User userModels = userModel as Sys_User;
            UserDialog(userModels);
        });


        private readonly ISysUserService sysUserService;
        public UserViewModel(ISysUserService sysUserService)
        {
            this.sysUserService = sysUserService;

            GetUserList();
        }
        /// <summary>
        /// 查询
        /// </summary>
        public void GetUserList()
        {
            if (Q != null)
            {
                UserList = sysUserService.GetWhere(s => s.IsDel != 0 && s.UserName.Contains(Q) && s.NickName.Contains(Q)).ToList();
                this.RaisePropertyChanged(nameof(UserList));
            }
            else
            {
                UserList = sysUserService.GetWhere(s => s.IsDel != 0).ToList();
                this.RaisePropertyChanged(nameof(UserList));
            }
        }
        /// <summary>
        /// 重置
        /// </summary>
        public void ResetUserList()
        {
            Q = null;
            UserList = sysUserService.GetWhere(s => s.IsDel != 0).ToList();
            this.RaisePropertyChanged(nameof(UserList));
            this.RaisePropertyChanged(nameof(Q));
        }
        /// <summary>
        /// 修改弹窗
        /// </summary>
        /// <param name="User"></param>
        public void UserDialog(Sys_User User)
        {
            UserTitle = "用户修改";
            UserModel = User;
            SysUserDialog dialog = new SysUserDialog();
            dialog.ShowDialog();
        }
        /// <summary>
        /// 新增弹窗
        /// </summary>
        public void UserDialog()
        {
            UserTitle = "用户新增";
            UserModel = new Sys_User();
            SysUserDialog dialog = new SysUserDialog();
            dialog.ShowDialog();
        }
        /// <summary>
        /// 用户修改OR新增
        /// </summary>
        public void UserAddOrUpdate()
        {
            if (UserModel.UserID > 0)
            {
                UserModel.UpdateTime = DateTime.Now;
                sysUserService.Update(UserModel);
            }
            else
            {
                UserModel.CreateTime = DateTime.Now;
                UserModel.IsDel = 1;
                sysUserService.Add(UserModel);
            }
            ResetUserList();
        }
    }
}
