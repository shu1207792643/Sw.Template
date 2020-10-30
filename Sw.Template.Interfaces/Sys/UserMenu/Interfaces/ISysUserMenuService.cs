using Sw.Template.DataAccess.Base;
using Sw.Template.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sw.Template.Interfaces
{
    public interface ISysUserMenuService : IBaseService<Sys_UserMenu>
    {
        /// <summary>
        /// 根据用户ID获取到用户菜单权限
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        List<Sys_UserMenu> UserIdGetUserMenu(int UserId);
    }
}
