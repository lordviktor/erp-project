#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using ERP.Business.Interfaces;
using ERP.Business.Interfaces.Base;
using ERP.Core.Metadata;

#endregion

namespace ERP.Core.Factory
{
    [Export(typeof (IBusinessFactory))]
    public class BusinessFactory : ERP.Core.Factory.IBusinessFactory
    {
        [ImportMany(AllowRecomposition = true)] public List<Lazy<ILogic, IBusinessExportAttribute>> BusinessInstances;

        public T GetReference<T>() where T : ILogic
        {
            return (T) (from item in BusinessInstances
                        where item.Metadata.ExportType == typeof (T)
                        select item).FirstOrDefault().Value;
        }
    }
}