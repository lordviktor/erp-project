#region Using

using System;
using ERP.Domain.BasicEntity;

#endregion

namespace ERP.Domain.SubEntity
{
    public class Bairro : BaseEntity
    {
        public String Name { get; set; }

        public City City { get; set; }
    }
}