#region Using

using System;
using ERP.Domain.BasicEntity;
using NHibernate;

#endregion

namespace ERP.Dao.Nhibernate.Dao.Base
{
    public class BaseLogicExclusionDao<T> : BaseCrudDao<T> where T : BaseLogicExclusionEntity
    {
        protected override IQueryOver<T, T> GetQueryOver()
        {
            return base.GetQueryOver().Where(x => x.Excluded == false);
        }

        public override void Delete(T item)
        {
            throw new NotSupportedException("Can't exclude logic exclusion entity.");
        }
    }
}