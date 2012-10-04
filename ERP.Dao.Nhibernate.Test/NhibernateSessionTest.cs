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
            String Server = "127.0.0.1";
            String Port = "3306";
            String Schema = "erp_test";
            String Login = "root";
            String Password = "1234";
            String connectionString = String.Format("Server={0};Port={1};Database={2};Uid={3};Pwd={4};",
                Server, Port, Schema, Login, Password);

            new Nhibernate.NhibernateSession().BuildSession(Guid.NewGuid(), connectionString);
        }

    }
}
