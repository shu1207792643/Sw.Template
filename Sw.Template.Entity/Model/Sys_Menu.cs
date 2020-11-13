using SqlSugar;

namespace Sw.Template.Entity
{
    /// <summary>
    /// 系统菜单
    /// </summary>
    public class Sys_Menu
    {
        /// <summary>
        /// 
        /// </summary>
        public Sys_Menu()
        {
        }

        /// <summary>
        /// 菜单Id
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public System.Int32 Id { get; set; }

        /// <summary>
        /// 菜单名称
        /// </summary>
        public System.String MenuName { get; set; }

        /// <summary>
        /// 菜单图标
        /// </summary>
        public System.String MenuIcon { get; set; }

        /// <summary>
        /// 菜单地址
        /// </summary>
        public System.String MenuAddress { get; set; }

        /// <summary>
        /// 菜单父级
        /// </summary>
        public System.Int32 MenuFather { get; set; }

        /// <summary>
        /// 是否启用
        /// </summary>
        public int IsEnabled { get; set; }
    }
}
