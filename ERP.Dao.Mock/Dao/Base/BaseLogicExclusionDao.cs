#region Using

using System;
using ERP.Domain.BasicEntity;

#endregion

namespace ERP.Dao.Mock.Dao.Base
{
    internal class BaseLogicExclusionDao<T> : BaseCrudDao<T> where T : BaseLogicExclusionEntity
    {
        public override void Delete(T item)
        {
            throw new NotSupportedException("Can't excluse logic exclusion entity.");
        }
    }
}