#region Using

using System.Collections.Generic;
using System.Linq;
using ERP.Core.Metadata;
using ERP.Dao.Interfaces;
using ERP.Dao.Mock.Dao.Base;
using ERP.Domain;

#endregion

namespace ERP.Dao.Mock.Dao
{
    [DaoExport(typeof (ITestDao), PersistenceType.Mock)]
    internal class TestDaoMock : BaseCrudDao<Test>, ITestDao
    {
        public IEnumerable<Test> FetchAlredyTested()
        {
            return from item in data
                   where item.Tested
                   select item;
        }
    }
}