#region Using

using System;
using System.ComponentModel.Composition;
using ERP.Business.Interfaces;
using ERP.Business.Interfaces.Base;

#endregion

namespace ERP.Core.Metadata
{
    [MetadataAttribute]
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class BusinessExportAttribute : ExportAttribute, ERP.Core.Metadata.IBusinessExportAttribute
    {
        public BusinessExportAttribute(Type ExportType, BusinessModule Module)
            : base(typeof (ILogic))
        {
            this.ExportType = ExportType;
            this.Module = Module;
        }

        public Type ExportType { get; private set; }

        public BusinessModule Module { get; private set; }
    }

    public interface IBusinessExportAttribute
    {
        Type ExportType { get; }
        BusinessModule Module { get; }
    }
}