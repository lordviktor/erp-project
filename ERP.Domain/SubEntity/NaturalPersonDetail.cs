#region Using

using System;
using ERP.Domain.BasicEntity;

#endregion

namespace ERP.Domain.SubEntity
{
    public class NaturalPersonDetail : BaseEntity
    {
        public String FirstName { get; set; }

        public String LastName { get; set; }

        public Cpf Cpf { get; set; }

        public String Rg { get; set; }

        public DateTime BirthDate { get; set; }
    }

    public class Cpf
    {
        public Int64 Number { get; set; }

        public Int16 CheckNumber { get; set; }
    }
}