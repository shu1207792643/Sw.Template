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
using static Sw.Template.Common.EnumHelper;

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
                UserList = sysUserService.GetWhere(s => s.IsDel == (int)IsDel.Yes && s.UserName.Contains(Q) && s.NickName.Contains(Q)).ToList();
                this.RaisePropertyChanged(nameof(UserList));
            }
            else
            {
                UserList = sysUserService.GetWhere(s => s.IsDel == (int)IsDel.Yes).ToList();
                this.RaisePropertyChanged(nameof(UserList));
            }
        }
        /// <summary>
        /// 重置
        /// </summary>
        public void ResetUserList()
        {
            Q = null;
            UserList = sysUserService.GetWhere(s => s.IsDel == (int)IsDel.Yes).ToList();
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
            DialogHelper.DialogOpen("员工管理弹窗", OpenType.ShowDialog);
        }
        /// <summary>
        /// 新增弹窗
        /// </summary>
        public void UserDialog()
        {
            UserTitle = "用户新增";
            UserModel = new Sys_User();
            DialogHelper.DialogOpen("员工管理弹窗", OpenType.ShowDialog);
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
                UserModel.IsDel = (int)IsDel.Yes;
                sysUserService.Add(UserModel);
            }
            ResetUserList();
            DialogHelper.DialogClose("员工管理弹窗");
        }
    }
}
