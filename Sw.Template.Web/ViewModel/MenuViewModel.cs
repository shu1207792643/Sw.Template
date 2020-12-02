using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Sw.Template.Common.Entity;
using Sw.Template.Entity;
using Sw.Template.Interfaces;
using Sw.Template.Web.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace Sw.Template.Web.ViewModel
{
    public class MenuViewModel : ViewModelBase
    {
        public virtual List<TreeNode> ChildNodes { get; set; }

        public ICommand SelectedCommand => new RelayCommand<TreeNode>((node) =>
        {
            ExcuteSendCommand(node);
        });
    

       
        private readonly ISysMenuService sysMenuService;
        private readonly ISysUserMenuService sysUserMenuService;
        public MenuViewModel(ISysMenuService sysMenuService, ISysUserMenuService sysUserMenuService)
        {
           
            this.sysMenuService = sysMenuService;
            this.sysUserMenuService = sysUserMenuService;
            ChildNodes = GetListMenu();
        }

        /// <summary>
        /// 当前显示的模块
        /// </summary>
        public virtual UserControl SelectedView { get; set; }

        private void ExcuteSendCommand(TreeNode NodeName)
        {
            if (NodeName.ParentID > 0)
            {
                SelectedView = InitAutofac.GetFromFac<UserControl>(NodeName.NodeName);
                this.RaisePropertyChanged(nameof(SelectedView));
            }
        }
        /// <summary>
        /// 获取到菜单列表
        /// </summary>
        /// <returns></returns>
        public List<TreeNode> GetListMenu()
        {
            var userMenuList = sysUserMenuService.GetWhere(s => s.RoleId == 1);
            List<int> menuId = userMenuList.Select(s => s.MenuId).ToList();

            var menuList = sysMenuService.GetWhere(s => menuId.Contains(s.Id) && s.IsEnabled == 1);
            //menuList.Add(new Sys_Menu()
            //{
            //    MenuName = "首页",
            //    MenuFather = 0,
            //    Id = 0
            //});

            List<TreeNode> cTreeSysMenuList = null;

            if (menuList != null)
                cTreeSysMenuList = GetNodes(menuList, 0);
            return cTreeSysMenuList;
        }

        /// <summary>
        /// 递归获取到菜单合计
        /// </summary>
        /// <param name="menuList"></param>
        /// <param name="parentID"></param>
        /// <returns></returns>
        private List<TreeNode> GetNodes(List<Sys_Menu> menuList, int parentID)
        {
            List<TreeNode> treeSysMenuList = new List<TreeNode>();
            if (menuList.Any(m => m.MenuFather == parentID))
            {
                var sysMenuListItem = menuList.Where(m => m.MenuFather == parentID).ToList();
                if (sysMenuListItem.Count > 0)
                {
                    sysMenuListItem.ForEach(s =>
                    {
                        var treeSysMenu = new TreeNode()
                        {
                            NodeID = s.Id,
                            NodeName = s.MenuName,
                            ParentID = parentID,
                            Icon = s.MenuIcon
                        };
                        if (treeSysMenu.NodeID > 0 && menuList.Any(m => m.MenuFather == treeSysMenu.NodeID))
                        {
                            treeSysMenu.Children = GetNodes(menuList, treeSysMenu.NodeID);
                        }
                        treeSysMenuList.Add(treeSysMenu);
                    });
                }
            }
            return treeSysMenuList;
        }

    }
}
