#region Using

using System;
using ERP.Domain.BasicEntity;

#endregion

namespace ERP.Domain.SubEntity
{
    public class Address : BaseEntity
    {
        public String Street { get; set; }

        public Int16? Number { get; set; }

        public String Complement { get; set; }

        public Bairro Neighborhood { get; set; }
    }
}