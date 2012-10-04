#region Using

using ERP.Core.Metadata;
using ERP.Dao.Interfaces;
using ERP.Dao.Interfaces.BaseType;

#endregion

namespace ERP.Core.Factory
{
    public interface IDaoFactory
    {
        T GetReference<T>(PersistenceType PersistenceType) where T : IBaseDao;
    }
}