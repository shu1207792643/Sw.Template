using Sw.Template.DataAccess.Base;
using Sw.Template.Entity;
using System.Collections.Generic;

namespace Sw.Template.Interfaces
{
    public interface ISysUsersService : IBaseService<Sys_User>
    {
        /// <summary>
        /// 查询用户集合
        /// </summary>
        /// <returns></returns>
        List<Sys_User> GetList();
    }
}
