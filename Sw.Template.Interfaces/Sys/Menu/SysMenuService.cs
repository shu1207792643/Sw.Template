using Sw.Template.DataAccess.Base;
using Sw.Template.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sw.Template.Interfaces
{
    public class SysMenuService : BaseService<Sys_Menu>, ISysMenuService
    {
        /// <summary>
        /// 根据菜单Id获取到菜单信息
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public List<Sys_Menu> MenuIdGetMenuList(List<int> MenuIds)
        {
            var menuList = Db.Queryable<Sys_Menu>().Where(s => MenuIds.Contains(s.Id) && s.IsEnabled != 0).ToList();
            if (menuList.Count > 0)
            {
                return menuList;
            }
            return null;
        }
    }
}
