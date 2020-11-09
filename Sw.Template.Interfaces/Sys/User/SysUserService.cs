using Sw.Template.Common;
using Sw.Template.DataAccess.Base;
using Sw.Template.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sw.Template.Interfaces
{
    public class SysUserService : BaseService<Sys_User>, ISysUserService
    {
        /// <summary>
        /// 查询用户集合
        /// </summary>
        /// <returns></returns>
        public ReturnResults GetList()
        {
            var userList = Db.Queryable<Sys_User>().ToList();
            return new ReturnResults()
            {
                StatusCode = 200,
                Result = userList
            };
        }

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ReturnResults Login(UserLoginModel model)
        {
            var userModel = Db.Queryable<Sys_User>().First(s => s.UserName == model.UserName && s.Password == model.UserPassword);
            if (userModel != null)
            {
                return new ReturnResults()
                {
                    Result = userModel,
                    StatusCode = 200
                };
            }
            else
            {
                return new ReturnResults()
                {
                    StatusCode = -1
                };
            }
        }
    }
}
