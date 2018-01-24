using System;

namespace Ks.Models
{
    /// <summary>
    /// 表名
    /// </summary>
    public partial class Users : Entity
    {
        public Users()
        {
            Account = string.Empty;
            Password = string.Empty;
            Name = string.Empty;
            Sex = 1;
            Status = 1;
            Type = 0;
            CreateTime = DateTime.Now;
        }

        /// <summary>
        /// 账号
        /// </summary>
        public string Account { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 性别 1男
        /// </summary>
        public int Sex { get; set; }

        /// <summary>
        /// 状态 0停用 1启用
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// 类型 0
        /// </summary>
        public int Type { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        public Guid CreateId { get; set; }
    }
}