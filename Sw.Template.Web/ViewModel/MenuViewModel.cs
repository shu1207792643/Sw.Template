using GalaSoft.MvvmLight;
using MahApps.Metro.Controls;
using Sw.Template.Common;
using Sw.Template.Interfaces;
using Sw.Template.Web.Helper;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace Sw.Template.Web.ViewModel
{
    public class MenuViewModel : ViewModelBase
    {
        private readonly ISysMenuService sysMenuService;
        private readonly ISysUserMenuService sysUserMenuService;
        public MenuViewModel(ISysMenuService sysMenuService, ISysUserMenuService sysUserMenuService)
        {
            this.sysMenuService = sysMenuService;
            this.sysUserMenuService = sysUserMenuService;
            // 获取当前用户权限模块
            HamburgerMenuItems = GetUserPower();
        }
        /// <summary>
        /// 当前显示的模块
        /// </summary>
        public virtual UserControl SelectedView { get; set; }
        /// <summary>
        /// 所有菜单项目
        /// </summary>
        public virtual ObservableCollection<HamburgerMenuGlyphItem> HamburgerMenuItems { get; set; }

        private HamburgerMenuGlyphItem selectedMenuItem;
        /// <summary>
        /// 选中的菜单项目
        /// </summary>
        public HamburgerMenuGlyphItem SelectedMenuItem
        {
            get { return selectedMenuItem; }
            set { selectedMenuItem = value; ChangeContent(); }
        }

        private void ChangeContent()
        {
            //获取到页面信息
            SelectedView = InitAutofac.GetFromFac<UserControl>(SelectedMenuItem.Label);
            //通知UI 页面已经改变
            this.RaisePropertyChanged(nameof(SelectedView));
        }

        private ObservableCollection<HamburgerMenuGlyphItem> GetUserPower()
        {
            ObservableCollection<HamburgerMenuGlyphItem> items = new ObservableCollection<HamburgerMenuGlyphItem>();
            //根据当前用户Id获取到当前用户菜单信息
            //var userMenuList = sysUserMenuService.UserIdGetUserMenu(UserHelper.UserModel.UserID);
            var userMenuList = sysUserMenuService.UserIdGetUserMenu(1);
            List<int> menuIds = new List<int>();

            foreach (var item in userMenuList)
            {
                menuIds.Add((int)item.MenuId);
            }

            var menuList = sysMenuService.MenuIdGetMenuList(menuIds);

            foreach (var item in menuList)
            {
                HamburgerMenuGlyphItem it = new HamburgerMenuGlyphItem()
                {
                    Tag = item.MenuIcon,
                    Label = item.MenuName,
                };
                items.Add(it);
            }

            return items;
        }
    }
}
