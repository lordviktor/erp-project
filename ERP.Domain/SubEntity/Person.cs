#region Using

using System.Collections.Generic;
using ERP.Domain.BasicEntity;

#endregion

namespace ERP.Domain.SubEntity
{
    public class Person : BaseMultiTenancyEntity
    {
        public IList<Address> Address { get; set; }

        public IList<Phone> Phone { get; set; }

        public IList<Email> Email { get; set; }
    }
}