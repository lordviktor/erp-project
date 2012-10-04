#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using ERP.Core.Metadata;
using ERP.Dao.Interfaces;
using ERP.Dao.Interfaces.BaseType;

#endregion

namespace ERP.Core.Factory
{
    [Export(typeof (IDaoFactory))]
    public class DaoFactory : IDaoFactory
    {
        [ImportMany(AllowRecomposition = true)] public List<Lazy<IBaseDao, IDaoExportAttribute>> DaoInstances;

        public T GetReference<T>(PersistenceType PersistenceType) where T : IBaseDao
        {
            return (T) (from item in DaoInstances
                        where item.Metadata.PersistenceType == PersistenceType
                              && item.Metadata.ExportType == typeof (T)
                        select item).FirstOrDefault().Value;
        }
    }
}