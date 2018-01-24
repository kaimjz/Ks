using System;

namespace Ks.Models
{
    /// <summary>
    /// 表名
    /// </summary>
    public partial class Modules : Entity
    {
        public Modules()
        {
            CascadeId = string.Empty;
            Name = string.Empty;
            Url = string.Empty;
            IsAutoExpand = false;
            Icon = string.Empty;
            Status = 1;
            Sort = 0;
            ParentName = string.Empty;
        }

        /// <summary>
        /// 节点语义ID
        /// </summary>
        public string CascadeId { get; set; }

        /// <summary>
        /// 功能模块名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 主页面URL
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 是否自动展开
        /// </summary>
        public bool IsAutoExpand { get; set; }

        /// <summary>
        /// 节点图标文件名称
        /// </summary>
        public string Icon { get; set; }

        /// <summary>
        /// 当前状态
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// 排序号
        /// </summary>
        public int Sort { get; set; }

        /// <summary>
        /// 父节点名称
        /// </summary>
        public string ParentName { get; set; }

        /// <summary>
        /// 父节点Id
        /// </summary>
        public Guid? ParentId { get; set; }
    }
}