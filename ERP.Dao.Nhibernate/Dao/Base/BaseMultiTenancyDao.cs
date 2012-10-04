#region Using

using ERP.Domain.BasicEntity;
using NHibernate;

#endregion

namespace ERP.Dao.Nhibernate.Dao.Base
{
    internal class BaseMultiTenancyDao<T> : BaseLogicExclusionDao<T> where T : BaseMultiTenancyEntity
    {
        protected override IQueryOver<T, T> GetQueryOver()
        {
            return base.GetQueryOver().Where(x => x.TenancyCompany.Id == NhibernateSession.Company);
        }
    }
}