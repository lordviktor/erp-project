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
    public class DatabaseManagerAttribute : ExportAttribute, IDatabaseExportAttribute
    {
        public DatabaseManagerAttribute()
            : base(typeof (IDatabaseManager))
        {
        }
    }

    public interface IDatabaseExportAttribute
    {
    }
}