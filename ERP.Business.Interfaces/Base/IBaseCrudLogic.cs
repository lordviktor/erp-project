namespace ERP.Business.Interfaces.Base
{
    public interface IBaseCrudLogic<T> : ILogic where T : ERP.Domain.BasicEntity.BaseEntity
    {
        void Delete(T data);
        System.Collections.Generic.IEnumerable<T> FetchAll();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <exception cref="AlreadyRegistredEntityException">Occurs when try to save an entity already saved in database.</exception>
        void Save(T data);
        void Update(T data);
    }
}