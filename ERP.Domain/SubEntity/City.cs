#region Using

using System;
using System.Collections.Generic;
using ERP.Domain.BasicEntity;

#endregion

namespace ERP.Domain.SubEntity
{
    public class City : BaseEntity
    {
        public String Name { get; set; }

        public State State { get; set; }

        public IList<Neighborhood> Neighborhoods { get; set; }
    }
}