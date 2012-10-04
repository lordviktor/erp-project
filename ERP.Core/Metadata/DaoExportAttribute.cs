#region Using

using System;
using System.ComponentModel.Composition;
using ERP.Dao.Interfaces;
using ERP.Dao.Interfaces.BaseType;

#endregion

namespace ERP.Core.Metadata
{
    [MetadataAttribute]
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class DaoExportAttribute : ExportAttribute, IDaoExportAttribute
    {
        public DaoExportAttribute(Type ExportType, PersistenceType PersistenceType)
            : base(typeof (IBaseDao))
        {
            this.ExportType = ExportType;
            this.PersistenceType = PersistenceType;
        }

        public Type ExportType { get; private set; }

        public PersistenceType PersistenceType { get; private set; }
    }

    public interface IDaoExportAttribute
    {
        Type ExportType { get; }
        PersistenceType PersistenceType { get; }
    }
}