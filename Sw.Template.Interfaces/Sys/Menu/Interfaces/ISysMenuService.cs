using Sw.Template.DataAccess.Base;
using Sw.Template.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sw.Template.Interfaces
{
    public interface ISysMenuService : IBaseService<Sys_Menu>
    {

        /// <summary>
        /// 根据菜单Id获取到菜单信息
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        List<Sys_Menu> MenuIdGetMenuList(List<int> MenuIds);
    }
}
