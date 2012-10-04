#region Using

using System;
using System.IO;
using NDbUnit.Core;
using NDbUnit.Core.MySqlClient;
using NUnit.Framework;

#endregion

namespace ERP.Dao.Nhibernate.NUnit.Util
{
    public abstract class TestBase
    {
        protected const string rootNamespace = "NDbUnitXPath";

        protected string ConnectionString
        {
            get { return Properties.Settings.Default.erpConnectionString; }
        }


        internal INDbUnitTest SetUpDatabase(string connectionString, Stream xsdStream, Stream dataStream,
                                            DbOperationFlag operation)
        {
            NhibernateSession nhibernateSession = new NhibernateSession();
            nhibernateSession.BuildSession(Guid.NewGuid(), Properties.Settings.Default.erpConnectionString);

            Assert.IsNotNull(xsdStream);
            Assert.IsNotNull(dataStream);

            INDbUnitTest dbUnitTest = new MySqlDbUnitTest(connectionString);
            dbUnitTest.ReadXmlSchema(xsdStream);
            dbUnitTest.ReadXml(dataStream);
            dbUnitTest.PerformDbOperation(operation);
            return dbUnitTest;
        }
    }
}