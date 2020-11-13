using SqlSugar;

namespace Sw.Template.Entity
{
    /// <summary>
    /// 用户菜单权限
    /// </summary>
    public class Sys_UserMenu
    {
        /// <summary>
        /// 
        /// </summary>
        public Sys_UserMenu()
        {
        }

        /// <summary>
        /// 权限Id
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public System.Int32 Id { get; set; }

        /// <summary>
        /// 角色Id
        /// </summary>
        public System.Int32 RoleId { get; set; }

        /// <summary>
        /// 菜单Id
        /// </summary>
        public System.Int32 MenuId { get; set; }
    }
}
