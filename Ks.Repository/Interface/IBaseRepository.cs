using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Ks.Repository.Interface
{
    public interface IBaseRepository<T> where T : class
    {
        void Add(T entity);

        void BatchAdd(List<T> entities);

        void Delete(T entity);

        void Delete(Expression<Func<T, bool>> where);

        /// <summary>
        /// 更新一个实体的所有属性
        /// </summary>
        /// <param name="entity"></param>
        void Update(T entity);

        /// <summary>
        /// 实现按需要只更新部分更新
        /// 如：Update(u =>u.Id==1,u =>new User{Name="ok"});
        /// </summary>
        /// <param name="where"></param>
        /// <param name="entity"></param>
        void Update(Expression<Func<T, bool>> where, Expression<Func<T, T>> entity);

        /// <summary>
        /// 按指定的ID进行批量更新
        /// </summary>
        /// <param name="where"></param>
        /// <param name="entity"></param>
        void Update(Expression<Func<T, object>> where, T entity);

        bool IsExist(Expression<Func<T, bool>> where);

        T FindSingle(Expression<Func<T, bool>> where = null);

        int GetCount(Expression<Func<T, bool>> where = null);

        IQueryable<T> Find(Expression<Func<T, bool>> where = null);

        IQueryable<T> Find(int pageIndex = 1, int pageSize = 10, string orderby = "",
            Expression<Func<T, bool>> where = null);

        void Save();
    }
}