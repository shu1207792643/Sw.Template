using Sw.Template.DataAccess.Base;
using Sw.Template.Entity;
using System.Collections.Generic;

namespace Sw.Template.Interfaces
{
    public class SysUsersService : BaseService<Sys_User>, ISysUsersService
    {
        /// <summary>
        /// 查询用户集合
        /// </summary>
        /// <returns></returns>
        public List<Sys_User> GetList()
        {
            return Db.Queryable<Sys_User>().ToList();    
        }
    }
}
