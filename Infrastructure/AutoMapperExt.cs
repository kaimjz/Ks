using System.Collections;
using System.Collections.Generic;
using System.Data;
using AutoMapper;

namespace Infrastructure
{
    /// <summary>
    /// 4.1
    /// </summary>
    public static class AutoMapperExt
    {
        /// <summary>
        ///  类型映射
        /// </summary>
        public static TDestination MapTo<TDestination>(this object source)
            where TDestination : class
        {
            if (source == null) return default(TDestination);
            Mapper.CreateMap(source.GetType(), typeof(TDestination));
            return Mapper.Map<TDestination>(source);
        }

        /// <summary>
        /// 类型映射
        /// </summary>
        public static TDestination MapTo<TSource, TDestination>(this TSource source, TDestination destination)
            where TSource : class
            where TDestination : class
        {
            if (source == null) return destination;
            Mapper.CreateMap<TSource, TDestination>();
            return Mapper.Map(source, destination);
        }

        /// <summary>
        /// 集合列表类型映射
        /// </summary>
        public static List<TDestination> MapToList<TDestination>(this IEnumerable source)
        {
            if (source == null) return default(List<TDestination>);
            foreach (var first in source)
            {
                var type = first.GetType();
                Mapper.CreateMap(type, typeof(TDestination));
                break;
            }
            return Mapper.Map<List<TDestination>>(source);
        }

        /// <summary>
        /// 集合列表类型映射
        /// </summary>
        public static List<TDestination> MapToList<TSource, TDestination>(this IEnumerable<TSource> source)
        {
            if (source == null) return default(List<TDestination>);
            //IEnumerable<TDestination> 类型需要创建元素的映射
            Mapper.CreateMap<TSource, TDestination>();
            return Mapper.Map<List<TDestination>>(source);
        }


        /// <summary>
        /// DataReader映射
        /// </summary>
        public static IEnumerable<TDestination> MapToList<TDestination>(this IDataReader source)
        {
            if (source == null) return default(List<TDestination>);
            Mapper.Reset();
            Mapper.CreateMap<IDataReader, IEnumerable<TDestination>>();
            return Mapper.Map<IDataReader, IEnumerable<TDestination>>(source);
        }
    }
}