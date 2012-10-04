#region Using

using ERP.Business.Interfaces.Base;
using ERP.Domain;

#endregion

namespace ERP.Business.Interfaces
{
    public interface ICompanyLogic : IBaseLogicExclusionCrud<Company>
    {
    }
}