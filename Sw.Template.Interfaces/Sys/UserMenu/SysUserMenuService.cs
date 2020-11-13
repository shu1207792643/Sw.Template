using Sw.Template.DataAccess.Base;
using Sw.Template.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sw.Template.Interfaces
{
    public class SysUserMenuService : BaseService<Sys_UserMenu>, ISysUserMenuService
    {
        /// <summary>
        /// 根据用户ID获取到用户菜单权限
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public List<Sys_UserMenu> UserIdGetUserMenu(int UserId)
        {
            var userMenuList = Db.Queryable<Sys_UserMenu>().Where(s => s.MenuId == UserId).ToList();
            if (userMenuList.Count > 0)
            {
                return userMenuList;
            }
            return null;
        }
    }
}
