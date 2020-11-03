using Sw.Template.Common;
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
        ReturnResults GetList();
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        ReturnResults Login(UserLoginModel model);

    }
}
