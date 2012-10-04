#region Using

using ERP.Domain.BasicEntity;

#endregion

namespace ERP.Domain
{
    public class Test : BaseEntity
    {
        public bool Tested { get; set; }

        public string Nome { get; set; }
    }
}