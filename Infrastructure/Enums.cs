using System.ComponentModel;

namespace Infrastructure
{
    public enum EnumResult
    {
        /// <summary>
        /// 操作失败!
        /// </summary>
        [Description("操作失败!")]
        Fail = 0,

        /// <summary>
        /// 操作成功!
        /// </summary>
        [Description("操作成功!")]
        Success = 1,

        /// <summary>
        /// 操作失败!
        /// </summary>
        [Description("操作错误!")]
        Error = 2,

        /// <summary>
        /// 资源已不存在,请刷新重试!
        /// </summary>
        [Description("资源已不存在,请刷新重试!")]
        NoData = 3
    }
}