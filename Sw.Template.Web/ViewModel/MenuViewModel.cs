using GalaSoft.MvvmLight;
using MahApps.Metro.Controls;
using Sw.Template.Interfaces;
using Sw.Template.Web.Helper;
using Sw.Template.Web.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            SelectedView = InitAutofac.GetFromFac<UserControl>(SelectedMenuItem.Label);
        }

        private ObservableCollection<HamburgerMenuGlyphItem> GetUserPower()
        {
            ObservableCollection<HamburgerMenuGlyphItem> items = new ObservableCollection<HamburgerMenuGlyphItem>();

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
