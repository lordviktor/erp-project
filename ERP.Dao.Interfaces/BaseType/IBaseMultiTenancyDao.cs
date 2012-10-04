#region Using

using ERP.Domain.BasicEntity;

#endregion

namespace ERP.Dao.Interfaces.BaseType
{
    public interface IBaseMultiTenancyDao<T> : IBaseLogicExclusionDao<T> where T : BaseMultiTenancyEntity
    {
    }
}