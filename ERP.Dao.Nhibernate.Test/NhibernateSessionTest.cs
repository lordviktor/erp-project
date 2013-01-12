using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ERP.Dao.Nhibernate.Test
{
    [TestClass]
    public class NhibernateSessionTest
    {
        [TestMethod]
        public void InitializeConnection()
        {
            new Nhibernate.NhibernateSession().BuildSession(Guid.NewGuid(), Properties.Resources.ConnectionString);
        }

    }
}
