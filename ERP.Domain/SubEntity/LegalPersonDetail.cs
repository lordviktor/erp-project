#region Using

using System;
using ERP.Domain.BasicEntity;

#endregion

namespace ERP.Domain.SubEntity
{
    public class LegalPersonDetail : BaseEntity
    {
        public Cnpj Cnpj { get; set; }

        public String CompanyName { get; set; }

        public String TradingName { get; set; }

        public UInt64 IE { get; set; }
    }

    public class Cnpj
    {
        public UInt32 Root { get; set; }

        public Int16 Suffix { get; set; }

        public Int16 CheckNumber { get; set; }
    }
}