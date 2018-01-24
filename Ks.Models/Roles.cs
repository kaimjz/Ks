using System;

namespace Ks.Models
{
    /// <summary>
    /// 表名
    /// </summary>
    public partial class Roles : Entity
    {
        public Roles()
        {
            Name = string.Empty;
            Status = 1;
            Type = 0;
            CreateTime = DateTime.Now;
        }

        /// <summary>
        /// 角色名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 角色状态
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// 角色类型
        /// </summary>
        public int Type { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 创建人ID
        /// </summary>
        public Guid CreateId { get; set; }
    }
}