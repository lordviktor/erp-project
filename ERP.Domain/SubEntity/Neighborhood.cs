#region Using

using System;
using ERP.Domain.BasicEntity;

#endregion

namespace ERP.Domain.SubEntity
{
    public class Neighborhood : BaseEntity
    {
        public String Name { get; set; }

        public City City { get; set; }
    }
}