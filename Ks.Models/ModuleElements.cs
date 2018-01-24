using System;

namespace Ks.Models
{
    /// <summary>
    /// 表名
    /// </summary>
    public partial class ModuleElements : Entity
    {
        public ModuleElements()
        {
            DomId = string.Empty;
            Name = string.Empty;
            Type = string.Empty;
            Script = string.Empty;
            Icon = string.Empty;
            Class = string.Empty;
            Description = string.Empty;
            Sort = 0;
        }

        /// <summary>
        /// 元素Id
        /// </summary>
        public string DomId { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 类型
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// 元素调用脚本
        /// </summary>
        public string Script { get; set; }

        /// <summary>
        /// 元素图标
        /// </summary>
        public string Icon { get; set; }

        /// <summary>
        /// 元素样式
        /// </summary>
        public string Class { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 排序号
        /// </summary>
        public int Sort { get; set; }

        /// <summary>
        /// FK
        /// </summary>
        public Guid ModuleId { get; set; }
    }
}