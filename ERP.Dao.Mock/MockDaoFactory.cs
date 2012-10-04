#region Using

using ERP.Dao.Interfaces;
using ERP.Dao.Interfaces.BaseType;
using ERP.Dao.Mock.Dao;

#endregion

namespace ERP.Dao.Mock
{
    public class MockDaoFactory
    {
        /// <summary>
        /// Factory para recuperar instancias da DAO`s mock.
        /// </summary>
        /// <typeparam name="T">Interface que voce deseja uma instancia que a implemente.</typeparam>
        /// <returns>Uma instancia que implementa a interface <typeparamref name="T"/></returns>
        public T GetReference<T>() where T : IBaseDao
        {
            if (typeof (T).GetType().Equals(typeof (ITestDao).GetType()))
                return (T) (IBaseDao) new TestDaoMock();
            return default(T);
        }
    }
}