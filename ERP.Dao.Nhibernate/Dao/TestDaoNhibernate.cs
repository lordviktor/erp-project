#region Using

using System.Collections.Generic;
using ERP.Core.Metadata;
using ERP.Dao.Interfaces;
using ERP.Dao.Nhibernate.Dao.Base;
using ERP.Domain;
using NHibernate;

#endregion

namespace ERP.Dao.Nhibernate.Dao
{
    [DaoExport(typeof (ITestDao), PersistenceType.Nhibernate)]
    internal class TestDaoNhibernate : BaseCrudDao<Test>, ITestDao
    {
        public IEnumerable<Test> FetchAlredyTested()
        {
            IEnumerable<Test> result = null;
            using (ISession session = NhibernateSession.CreateSession())
            {
                result = session.QueryOver<Test>()
                    .Where(x => x.Tested).List();
            }
            return result;
        }
    }
}