#region Using

using ERP.Core.Metadata;
using ERP.Dao.Interfaces;
using ERP.Dao.Mock.Dao.Base;
using ERP.Domain;

#endregion

namespace ERP.Dao.Mock.Dao
{
    [DaoExport(typeof (ICompanyDao), PersistenceType.Mock)]
    internal class CompanyDaoMock : BaseLogicExclusionDao<Company>, ICompanyDao
    {
    }
}