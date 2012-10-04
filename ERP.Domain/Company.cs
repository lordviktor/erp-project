#region Using

using System.Collections.Generic;
using ERP.Domain.BasicEntity;
using ERP.Domain.SubEntity;

#endregion

namespace ERP.Domain
{
    public class Company : BaseLogicExclusionEntity
    {
        public Company HeadCompany { get; set; }

        public LegalPersonDetail LegalPersonDetail { get; set; }

        public IList<Company> BranchCompany { get; set; }

        public IList<Address> Address { get; set; }

        public IList<Phone> Phone { get; set; }

        public IList<Email> Email { get; set; }
    }
}