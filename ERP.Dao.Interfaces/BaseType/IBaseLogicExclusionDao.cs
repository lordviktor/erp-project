#region Using

using ERP.Domain.BasicEntity;

#endregion

namespace ERP.Dao.Interfaces.BaseType
{
    public interface IBaseLogicExclusionDao<T> : IBaseCrudDao<T> where T : BaseLogicExclusionEntity
    {
    }
}