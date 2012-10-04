#region Using

using System;
using System.Collections.Generic;
using ERP.Business.Interfaces.Base;
using ERP.Dao.Interfaces;
using ERP.Dao.Interfaces.BaseType;
using ERP.Domain.BasicEntity;

#endregion

namespace ERP.Business.Base
{
    public abstract class BaseCrudLogic<T> : IBaseCrudLogic<T> where T : BaseEntity
    {
        protected IBaseCrudDao<T> Repository { get; set; }

        public BaseCrudLogic(IBaseCrudDao<T> repository)
        {
            this.Repository = repository;
        }

        /// <inheritdoc />
        public virtual void Save(T data)
        {
            if (data == null)
                throw new ArgumentNullException("Parameter data cannot be null.");

            var itemFromDatabase = Repository.VerifyIfAlreadyRegistred(data);

            if (itemFromDatabase != null)
                throw new AlreadyRegistredEntityException
                          {
                              ItemAtDatabase = data
                          };

            try
            {
                Repository.Save(data);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public virtual void Update(T data)
        {
            if (data == null)
                throw new ArgumentNullException("Parameter data cannot be null.");

            try
            {
                Repository.Update(data);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public virtual void Delete(T data)
        {
            if (data == null)
                throw new ArgumentNullException("Parameter data cannot be null.");

            try
            {
                Repository.Delete(data);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public virtual IEnumerable<T> FetchAll()
        {
            IEnumerable<T> ListResult;
            try
            {
                ListResult = Repository.FetchAll();
            }
            catch (Exception)
            {
                throw;
            }
            return ListResult;
        }
    }
}