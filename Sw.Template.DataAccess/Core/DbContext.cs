using SqlSugar;
using Sw.Template.Common;
using Sw.Template.Entity;
using System;
using System.Configuration;
using System.Diagnostics;

namespace Sw.Template.DataAccess
{
    /// <summary>
    /// 数据库上下文
    /// </summary>
    public class DbContext
    {
        public SqlSugarClient Db;   //用来处理事务多表查询和复杂的操作
        public static DbContext Current
        {
            get
            {
                return new DbContext();
            }
        }

        public DbContext()
        {
            Db = new SqlSugarClient(new ConnectionConfig()
            {
                ConnectionString = "Server=.;Database=Sw_Template;UID=sa;Password=123",//AppSettings.Configuration["DbConnection:ConnectionString"],
                DbType = DbType.SqlServer,//(DbType)Convert.ToInt32(AppSettings.Configuration["DbConnection:DbType"]),
                IsAutoCloseConnection = true,
                IsShardSameThread = true,
                InitKeyType = InitKeyType.Attribute,
                ConfigureExternalServices = new ConfigureExternalServices()
                {
                    DataInfoCacheService = new RedisCache()
                },
                MoreSettings = new ConnMoreSettings()
                {
                    IsAutoRemoveDataCache = true
                }
            }); 
            //调式代码 用来打印SQL 
            Db.Aop.OnLogExecuting = (sql, pars) =>
            {
                Debug.WriteLine(sql);
            };
        }

        public DbSet<T> DbTable<T>() where T : class, new()
        {
            return new DbSet<T>(Db);
        }


        //添加上下文
        public DbSet<Sys_User> SysUserRelationDb => new DbSet<Sys_User>(Db);
        public DbSet<Sys_Menu> SysMenuRelationDb => new DbSet<Sys_Menu>(Db);
        public DbSet<Sys_UserMenu> SysUserMenuRelationDb => new DbSet<Sys_UserMenu>(Db);
        /// <summary>
        /// 扩展ORM
        /// </summary>
        public class DbSet<T> : SimpleClient<T> where T : class, new()
        {
            public DbSet(SqlSugarClient context) : base(context)
            {

            }
        }

    }
}
