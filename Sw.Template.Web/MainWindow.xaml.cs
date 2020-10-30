using MahApps.Metro.Controls;
using Sw.Template.Common;
using Sw.Template.Interfaces;
using Sw.Template.Web.Helper;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Sw.Template.Web
{

    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        private readonly ISysUsersService sysUsersService;
        private readonly ISysMenuService sysMenuService;
        private readonly ISysUserMenuService sysUserMenuService;

        public MainWindow(ISysUsersService sysUsersService, ISysMenuService sysMenuService, ISysUserMenuService sysUserMenuService)
        {
            this.sysUsersService = sysUsersService;
            this.sysMenuService = sysMenuService;
            this.sysUserMenuService = sysUserMenuService;
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var userMenuList = sysUserMenuService.UserIdGetUserMenu(1);
            if (userMenuList != null)
            {
                List<int> menuIds = new List<int>();
                foreach (var item in userMenuList)
                {
                    menuIds.Add((int)item.MenuId);
                }
                var menuList = sysMenuService.MenuIdGetMenuList(menuIds);
                if (menuList != null)
                {

                }
            }
            sysUsersService.GetList();
        }


    }
}
