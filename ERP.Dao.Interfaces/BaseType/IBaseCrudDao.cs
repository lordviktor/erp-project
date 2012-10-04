#region Using

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ERP.Domain.BasicEntity;
using ERP.Domain.Util;

#endregion

namespace ERP.Dao.Interfaces.BaseType
{
    public interface IBaseCrudDao<T> : IBaseDao where T : BaseEntity
    {
        T Get(Guid Id);
        void Save(T item);
        void Update(T item);
        void Delete(T item);
        T VerifyIfAlreadyRegistred(T item);
        IEnumerable<T> FetchAll();
        PaginatedResult<T> FetchAll(PaginatedInfo pageInfo);
        IEnumerable<T> FetchByCustomCriteria(Expression<Func<T, bool>> criterion);
        PaginatedResult<T> FetchByCustomCriteria(Expression<Func<T, bool>> criterion, PaginatedInfo pageInfo);
    }
}