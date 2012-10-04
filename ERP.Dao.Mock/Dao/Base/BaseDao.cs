#region Using

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ERP.Dao.Interfaces.BaseType;
using ERP.Domain.BasicEntity;

#endregion

namespace ERP.Dao.Mock.Dao.Base
{
    /// <summary>
    /// Base dao com operacoes basicas da dao. Implementado as operacoes basicas descritas na interface
    /// IBaseDao.
    /// </summary>
    /// <typeparam name="T">A entidade à ser persistida</typeparam>
    internal abstract class
        BaseCrudDao<T> : IBaseCrudDao<T> where T : BaseEntity
    {
        protected static IList<T> data;

        static BaseCrudDao()
        {
            data = new List<T>();
        }

        public T Get(Guid Id)
        {
            return (from item in data
                    where item.Id == Id
                    select item).FirstOrDefault();
        }

        public virtual void Save(T item)
        {
            data.Add(item);
        }

        public virtual void Update(T item)
        {
            data.Remove(item);
            data.Add(item);
        }

        public virtual void Delete(T item)
        {
            data.Remove(item);
        }

        public virtual IEnumerable<T> FetchAll()
        {
            return data.AsEnumerable();
        }

        public virtual IEnumerable<T> FetchByCustomCriteria(Expression<Func<T, bool>> criterion)
        {
            return data.Where(criterion.Compile()).AsEnumerable();
        }


        public virtual T VerifyIfAlreadyRegistred(T item)
        {
            return (from asd in data
                    where asd.Id == item.Id
                    select asd).FirstOrDefault();
        }


        public Domain.Util.PaginatedResult<T> FetchAll(Domain.Util.PaginatedInfo pageInfo)
        {
            return new Domain.Util.PaginatedResult<T>
                       {
                           Count = data.Count,
                           Data = data.Skip(pageInfo.PageNumber*pageInfo.PageSize).Take(pageInfo.PageSize),
                           Page = pageInfo.PageNumber,
                           PageSize = pageInfo.PageSize
                       };
        }


        public Domain.Util.PaginatedResult<T> FetchByCustomCriteria(Expression<Func<T, bool>> criterion,
                                                                    Domain.Util.PaginatedInfo pageInfo)
        {
            return new Domain.Util.PaginatedResult<T>
                       {
                           Count = data.Where(criterion.Compile()).Count(),
                           Data =
                               data.Where(criterion.Compile()).Skip(pageInfo.PageNumber*pageInfo.PageSize).Take(
                                   pageInfo.PageSize),
                           Page = pageInfo.PageNumber,
                           PageSize = pageInfo.PageSize
                       };
        }
    }
}