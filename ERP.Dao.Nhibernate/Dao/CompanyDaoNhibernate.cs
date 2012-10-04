#region Using

using ERP.Core.Metadata;
using ERP.Dao.Interfaces;
using ERP.Domain;

#endregion

namespace ERP.Dao.Nhibernate.Dao
{
    [DaoExport(typeof (ICompanyDao), PersistenceType.Nhibernate)]
    public class CompanyDaoNhibernate : Base.BaseLogicExclusionDao<Company>, ICompanyDao
    {
    }
}