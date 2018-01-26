using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using EntityFramework.Extensions;
using Infrastructure;
using Ks.Models;
using Ks.Repository.Interface;
using Ks.Repository.Models;

namespace Ks.Repository.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : Entity
    {
        protected KsDBContext Context = new KsDBContext();

        /// <summary>
        /// 添加单个
        /// </summary>
        public void Add(T entity)
        {
            Context.Set<T>().Add(entity);
            Save();
        }

        /// <summary>
        /// 添加多个
        /// </summary>
        public void BatchAdd(List<T> entities)
        {
            Context.Set<T>().AddRange(entities);
            Save();
        }

        /// <summary>
        /// 删除单个
        /// </summary>
        public void Delete(T entity)
        {
            Context.Set<T>().Remove(entity);
            Save();
        }

        /// <summary>
        /// 根据条件删除单个或多个
        /// </summary>
        public void Delete(Expression<Func<T, bool>> where)
        {
            Context.Set<T>().Where(where).Delete();
        }

        /// <summary>
        /// 更新单个
        /// </summary>
        /// <param name="entity"></param>
        public void Update(T entity)
        {
            var entry = this.Context.Entry(entity);
            //如果状态没有任何更改，会报错
            entry.State = EntityState.Modified;
            Save();
        }

        /// <summary>
        /// 按指定id更新实体,会更新整个实体
        /// </summary>
        public void Update(Expression<Func<T, object>> where, T entity)
        {
            Context.Set<T>().AddOrUpdate(where, entity);
            Save();
        }

        /// <summary>
        /// 根据条件进行部分更新
        /// </summary>
        public void Update(Expression<Func<T, bool>> where, Expression<Func<T, T>> entity)
        {
            Context.Set<T>().Where(where).Update(entity);
            Save();
        }

        /// <summary>
        /// 根据条件判断是否存在
        /// </summary>
        /// <returns></returns>
        public bool IsExist(Expression<Func<T, bool>> where)
        {
            return Context.Set<T>().Any(where);
        }

        /// <summary>
        /// 根据条件获取第一个
        /// </summary>
        /// <returns></returns>
        public T FindSingle(Expression<Func<T, bool>> where)
        {
            return Context.Set<T>().AsNoTracking().FirstOrDefault(where);
        }

        /// <summary>
        /// 根据条件获取记录条数
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public int GetCount(Expression<Func<T, bool>> where = null)
        {
            return Filter(where).Count();
        }

        /// <summary>
        /// 根据条件获取记录
        /// </summary>
        /// <returns></returns>
        public IQueryable<T> Find(Expression<Func<T, bool>> where)
        {
            return Filter(where);
        }

        /// <summary>
        /// 根据条件获取分页记录
        /// </summary>
        /// <param name="pageIndex">当前页码</param>
        /// <param name="pageSize">每页大小</param>
        /// <param name="orderBy">排序</param>
        /// <param name="where">条件</param>
        /// <returns></returns>
        public IQueryable<T> Find(int pageIndex, int pageSize, string orderBy = "", Expression<Func<T, bool>> where = null)
        {
            if (pageIndex < 1)
            {
                pageIndex = 1;
            }
            if (string.IsNullOrEmpty(orderBy))
            {
                orderBy = "id descending";
            }
            return Filter(where).OrderBy(orderBy).Skip(pageIndex * (pageIndex - 1)).Take(pageSize);
        }

        /// <summary>
        /// 保存到数据库
        /// </summary>
        public void Save()
        {
            try
            {
                Context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                throw new Exception(e.EntityValidationErrors.First().ValidationErrors.First().ErrorMessage);
            }
        }

        /// <summary>
        /// 过滤条件为空
        /// </summary>
        /// <returns></returns>
        private IQueryable<T> Filter(Expression<Func<T, bool>> where)
        {
            var dbSet = Context.Set<T>().AsQueryable();
            if (where != null)
            {
                dbSet = dbSet.Where(where);
            }
            return dbSet;
        }
    }
}