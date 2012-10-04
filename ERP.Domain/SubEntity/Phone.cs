#region Using

using System;
using ERP.Domain.BasicEntity;

#endregion

namespace ERP.Domain.SubEntity
{
    public class Phone : BaseEntity
    {
        public Int16 AreaCode { get; set; }

        public Int32 Number { get; set; }
    }
}