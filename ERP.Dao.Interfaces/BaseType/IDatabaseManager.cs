#region Using

using System;

#endregion

namespace ERP.Dao.Interfaces.BaseType
{
    public interface IDatabaseManager
    {
        void BuildSession(Guid company, String connectionString);
    }
}