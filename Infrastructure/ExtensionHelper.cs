using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Text;

namespace Infrastructure
{
    public static class ExtensionHelper
    {
        #region 操作枚举返回注释

        /// <summary>
        /// 操作枚举返回注释
        /// </summary>
        /// <param name="enumValue">枚举</param>
        /// <returns></returns>
        public static string GetEnumValue(this Enum enumValue)
        {
            Type t = enumValue.GetType();
            foreach (MemberInfo mInfo in t.GetMembers())
            {
                if (mInfo.Name == t.GetEnumName(enumValue))
                {
                    foreach (Attribute attr in Attribute.GetCustomAttributes(mInfo))
                    {
                        if (attr.GetType() == typeof(DescriptionAttribute))
                        {
                            return ((DescriptionAttribute)attr).Description;
                        }
                    }
                }
            }
            return "";
        }

        #endregion
    }
}
