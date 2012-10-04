#region Using

using System.Collections.Generic;
using ERP.Dao.Interfaces.BaseType;
using ERP.Domain;

#endregion

namespace ERP.Dao.Interfaces
{
    public interface ITestDao : IBaseCrudDao<Test>
    {
        IEnumerable<Test> FetchAlredyTested();
    }
}