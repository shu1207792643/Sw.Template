using SqlSugar;

namespace Sw.Template.Entity
{
    /// <summary>
    /// 
    /// </summary>
    public class Sys_User
    {
        /// <summary>
        /// 
        /// </summary>
        public Sys_User()
        {
        }

        /// <summary>
        /// 用户账号
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public System.Int32 UserID { get; set; }

        /// <summary>
        /// 用户名称
        /// </summary>
        public System.String UserName { get; set; }

        /// <summary>
        /// 用户昵称
        /// </summary>
        public System.String NickName { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        public System.String Email { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public System.String Password { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public System.String Sex { get; set; }

        /// <summary>
        /// 头像
        /// </summary>
        public System.String AvatarUrl { get; set; }

        /// <summary>
        /// QQ
        /// </summary>
        public System.String QQ { get; set; }

        /// <summary>
        /// 手机
        /// </summary>
        public System.String Phone { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        public System.String Address { get; set; }

        /// <summary>
        /// 身份证号码
        /// </summary>
        public System.String IdentityCard { get; set; }

        /// <summary>
        /// 是否启用
        /// </summary>
        public System.Int32? IsEnabled { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public System.DateTime? CreateTime { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        public System.Int32? CreateID { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        public System.DateTime? UpdateTime { get; set; }

        /// <summary>
        /// 修改人
        /// </summary>
        public System.DateTime? UpdateID { get; set; }

        /// <summary>
        /// 删除人
        /// </summary>
        public System.Int32? DeleteID { get; set; }

        /// <summary>
        /// 删除时间
        /// </summary>
        public System.DateTime? DeleteTime { get; set; }

        /// <summary>
        /// 是否删除
        /// </summary>
        public System.Int32? IsDel { get; set; }
    }
}
