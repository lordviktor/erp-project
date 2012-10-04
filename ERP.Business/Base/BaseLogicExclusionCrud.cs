#region Using

using System;
using ERP.Business.Interfaces.Base;
using ERP.Dao.Interfaces;
using ERP.Dao.Interfaces.BaseType;
using ERP.Domain.BasicEntity;

#endregion

namespace ERP.Business.Base
{
    public class BaseLogicExclusionCrud<T> : BaseCrudLogic<T>, IBaseLogicExclusionCrud<T>
        where T : BaseLogicExclusionEntity
    {

        public BaseLogicExclusionCrud(IBaseCrudDao<T> Repository)
            : base(Repository)
        {
            // Inherit documentation from the base Exception class matching
            // this constructor's signature.
        }

        public override void Delete(T data)
        {
            if (data == null)
                throw new ArgumentNullException("Parameter data cannot be null.");

            if (data.Excluded)
                throw new ArgumentException("Data to delete can't be already deleted.");

            try
            {
                data.Excluded = true;
                Repository.Update(data);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}