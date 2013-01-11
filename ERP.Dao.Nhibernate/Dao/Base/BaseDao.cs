#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Linq.Expressions;
using ERP.Dao.Interfaces;
using ERP.Dao.Interfaces.BaseType;
using ERP.Domain.BasicEntity;
using ERP.Domain.Util;
using NHibernate;

#endregion

namespace ERP.Dao.Nhibernate.Dao.Base
{
    public abstract class BaseCrudDao<T> : IBaseCrudDao<T> where T : BaseEntity
    {
        [Import(typeof(IDatabaseManager))]
        public NhibernateSession NhibernateSession { get; set; }

        protected virtual IQueryOver<T, T> GetQueryOver()
        {
            ISession session = NhibernateSession.CreateSession();
            return session.QueryOver<T>();
        }

        public virtual T Get(Guid Id)
        {
            try
            {
                return this.GetQueryOver().Where(x => x.Id == Id).SingleOrDefault();
            }
            catch (DatabaseOperationException ex)
            {
                throw new DatabaseOperationException("Error while try to get entity with especified identifier.", ex);
            }
        }

        public virtual void Save(T item)
        {
            using (ISession session = NhibernateSession.CreateSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Save(item);
                    transaction.Commit();
                }
            }
        }

        public virtual void Update(T item)
        {
            using (ISession session = NhibernateSession.CreateSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Update(item);
                    transaction.Commit();
                }
            }
        }

        public virtual void Delete(T item)
        {
            using (ISession session = NhibernateSession.CreateSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Delete(item);
                    transaction.Commit();
                }
            }
        }

        public virtual IEnumerable<T> FetchAll()
        {
            IEnumerable<T> result = null;
            result = this.GetQueryOver().List();
            return result;
        }


        public virtual IEnumerable<T> FetchByCustomCriteria(Expression<Func<T, bool>> criterion)
        {
            IEnumerable<T> result = null;
            result = this.GetQueryOver().Where(criterion).List();
            return result;
        }


        public virtual T VerifyIfAlreadyRegistred(T item)
        {
            T result = null;
            result = this.GetQueryOver().Where(x => x.Id == item.Id).List().FirstOrDefault();
            return result;
        }

        public Domain.Util.PaginatedResult<T> FetchAll(Domain.Util.PaginatedInfo pageInfo)
        {
            var query = GetQueryOver();
            var result = new PaginatedResult<T>
                             {
                                 Count = query.RowCount(),
                                 Data = query.Skip(pageInfo.PageNumber * pageInfo.PageSize).Take(pageInfo.PageSize).List(),
                                 Page = pageInfo.PageNumber,
                                 PageSize = pageInfo.PageSize
                             };
            return result;
        }

        public Domain.Util.PaginatedResult<T> FetchByCustomCriteria(Expression<Func<T, bool>> criterion,
                                                                    Domain.Util.PaginatedInfo pageInfo)
        {
            var query = GetQueryOver();
            var result = new PaginatedResult<T>
                             {
                                 Count = query.Where(criterion).RowCount(),
                                 Data = query.Where(criterion).Skip(pageInfo.PageNumber * pageInfo.PageSize).Take(
                                         pageInfo.PageSize).List(),
                                 Page = pageInfo.PageNumber,
                                 PageSize = pageInfo.PageSize
                             };
            return result;
        }
    }
}