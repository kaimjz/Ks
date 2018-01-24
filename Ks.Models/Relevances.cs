using System;

namespace Ks.Models
{
    /// <summary>
    /// 表名
    /// </summary>
    public partial class Relevances : Entity
    {
        public Relevances()
        {
            Description = string.Empty;
            KeyName = string.Empty;
            Status = 1;
            OperateTime = DateTime.Now;
        }

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 关系Key
        /// </summary>
        public string KeyName { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// 授权时间
        /// </summary>
        public DateTime OperateTime { get; set; }

        /// <summary>
        /// 授权人
        /// </summary>
        public Guid OperatorId { get; set; }

        /// <summary>
        /// 第一个表主键ID
        /// </summary>
        public Guid FirstId { get; set; }

        /// <summary>
        /// 第二个表主键ID
        /// </summary>
        public Guid SecondId { get; set; }
    }
}