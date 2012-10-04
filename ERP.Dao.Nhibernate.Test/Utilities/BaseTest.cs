using NDbUnit.Core;
using NDbUnit.Core.MySqlClient;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERP.Dao.Nhibernate.Test.Utilities
{
    public class BaseTest
    {


        internal MySqlDbUnitTest SetupDatabase(String connectionString, System.IO.Stream xsdStream, DbOperationFlag operation)
        {
            Assert.IsNotNull(xsdStream);
            MySqlDbUnitTest dbUnitTest = new MySqlDbUnitTest(connectionString);
            dbUnitTest.ReadXmlSchema(xsdStream);;
            dbUnitTest.PerformDbOperation(operation);
            return dbUnitTest;
        }
    }
}
