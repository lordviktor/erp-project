#region Using

using System;

#endregion

namespace ERP.Domain.BasicEntity
{
    public abstract class BaseLogicExclusionEntity : BaseEntity
    {
        public Boolean Excluded { get; set; }
    }
}