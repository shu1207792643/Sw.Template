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

        private System.Int32 _UserID;
        /// <summary>
        /// 用户账号
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public System.Int32 UserID { get { return this._UserID; } set { this._UserID = value; } }

        private System.String _UserName;
        /// <summary>
        /// 用户名称
        /// </summary>
        public System.String UserName { get { return this._UserName; } set { this._UserName = value?.Trim(); } }

        private System.String _NickName;
        /// <summary>
        /// 用户昵称
        /// </summary>
        public System.String NickName { get { return this._NickName; } set { this._NickName = value?.Trim(); } }

        private System.String _Email;
        /// <summary>
        /// 邮箱
        /// </summary>
        public System.String Email { get { return this._Email; } set { this._Email = value?.Trim(); } }

        private System.String _Password;
        /// <summary>
        /// 密码
        /// </summary>
        public System.String Password { get { return this._Password; } set { this._Password = value?.Trim(); } }

        private System.String _Sex;
        /// <summary>
        /// 性别
        /// </summary>
        public System.String Sex { get { return this._Sex; } set { this._Sex = value?.Trim(); } }

        private System.String _AvatarUrl;
        /// <summary>
        /// 头像
        /// </summary>
        public System.String AvatarUrl { get { return this._AvatarUrl; } set { this._AvatarUrl = value?.Trim(); } }

        private System.String _QQ;
        /// <summary>
        /// QQ
        /// </summary>
        public System.String QQ { get { return this._QQ; } set { this._QQ = value?.Trim(); } }

        private System.String _Phone;
        /// <summary>
        /// 手机
        /// </summary>
        public System.String Phone { get { return this._Phone; } set { this._Phone = value?.Trim(); } }

        private System.String _Address;
        /// <summary>
        /// 地址
        /// </summary>
        public System.String Address { get { return this._Address; } set { this._Address = value?.Trim(); } }

        private System.String _IdentityCard;
        /// <summary>
        /// 身份证号码
        /// </summary>
        public System.String IdentityCard { get { return this._IdentityCard; } set { this._IdentityCard = value?.Trim(); } }

        private System.Int32? _Enabled;
        /// <summary>
        /// 是否启用
        /// </summary>
        public System.Int32? Enabled { get { return this._Enabled; } set { this._Enabled = value ?? default(System.Int32); } }

        private System.DateTime? _CreateTime;
        /// <summary>
        /// 创建时间
        /// </summary>
        public System.DateTime? CreateTime { get { return this._CreateTime; } set { this._CreateTime = value ?? default(System.DateTime); } }

        private System.Int32? _CreateID;
        /// <summary>
        /// 创建人
        /// </summary>
        public System.Int32? CreateID { get { return this._CreateID; } set { this._CreateID = value ?? default(System.Int32); } }

        private System.DateTime? _UpdateTime;
        /// <summary>
        /// 修改时间
        /// </summary>
        public System.DateTime? UpdateTime { get { return this._UpdateTime; } set { this._UpdateTime = value ?? default(System.DateTime); } }

        private System.DateTime? _UpdateID;
        /// <summary>
        /// 修改人
        /// </summary>
        public System.DateTime? UpdateID { get { return this._UpdateID; } set { this._UpdateID = value ?? default(System.DateTime); } }

        private System.Int32? _DeleteID;
        /// <summary>
        /// 删除人
        /// </summary>
        public System.Int32? DeleteID { get { return this._DeleteID; } set { this._DeleteID = value ?? default(System.Int32); } }

        private System.DateTime? _DeleteTime;
        /// <summary>
        /// 删除时间
        /// </summary>
        public System.DateTime? DeleteTime { get { return this._DeleteTime; } set { this._DeleteTime = value ?? default(System.DateTime); } }
    }
}
