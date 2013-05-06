#region Using

using System;
using System.Collections.Generic;
using ERP.Domain.BasicEntity;

#endregion

namespace ERP.Domain.SubEntity
{
    public class State : BaseEntity
    {
        public String Name { get; set; }

        public String Uf { get; set; }

        public IList<City> Cities { get; set; }
    }
}