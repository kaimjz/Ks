using System;

namespace Ks.Models
{
    /// <summary>
    /// 表名
    /// </summary>
    public partial class Orgs : Entity
    {
        public Orgs()
        {
            CascadeId = string.Empty;
            Name = string.Empty;
            IsAutoExpand = false;
            IconName = string.Empty;
            Status = 1;
            Type = 0;
            Sort = 0;
            CreateTime = DateTime.Now;
            ParentName = string.Empty;
        }

        /// <summary>
        /// 节点语义ID
        /// </summary>
        public string CascadeId { get; set; }

        /// <summary>
        /// 组织名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 是否自动展开
        /// </summary>
        public bool IsAutoExpand { get; set; }

        /// <summary>
        /// 节点图标文件名称
        /// </summary>
        public string IconName { get; set; }

        /// <summary>
        /// 当前状态
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// 组织类型
        /// </summary>
        public int Type { get; set; }

        /// <summary>
        /// 排序号
        /// </summary>
        public int Sort { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 创建人ID
        /// </summary>
        public int CreateId { get; set; }

        /// <summary>
        /// 父节点名称
        /// </summary>
        public string ParentName { get; set; }

        /// <summary>
        /// 父节点ID
        /// </summary>
        public Guid? ParentId { get; set; }
    }
}