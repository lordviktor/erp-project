#region Using

using System;
using ERP.Domain.BasicEntity;

#endregion

namespace ERP.Domain.SubEntity
{
    public class Email : BaseEntity
    {
        public String EmailAddress { get; set; }
    }
}