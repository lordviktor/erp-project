#region Using

using ERP.Dao.Interfaces;
using ERP.Dao.Interfaces.BaseType;
using ERP.Dao.Nhibernate.Dao;

#endregion

namespace ERP.Dao.Nhibernate
{
    internal class NhibernateDaoFactory
    {
        /// <summary>
        /// Factory para recuperar instancias da DAO`s implementadas usando o nhibernate.
        /// </summary>
        /// <typeparam name="T">Interface que voce deseja uma instancia que a implemente.</typeparam>
        /// <returns>Uma instancia que implementa a interface <typeparamref name="T"/></returns>
        public T GetReference<T>() where T : IBaseDao
        {
            if (typeof (T).Equals(typeof (ITestDao)))
                return (T) (IBaseDao) new TestDaoNhibernate();
            return default(T);
        }
    }
}