#region Using



#endregion

using ERP.Domain.BasicEntity;
namespace ERP.Business.Interfaces.Base
{
    public interface IBaseLogicExclusionCrud<T> : IBaseCrudLogic<T>
        where T : BaseLogicExclusionEntity
    {

    }
}