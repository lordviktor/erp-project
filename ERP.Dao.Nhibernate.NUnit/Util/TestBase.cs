#region Using

using System;
using System.IO;
using NDbUnit.Core;
using NDbUnit.Core.SqlClient;
using NUnit.Framework;

#endregion

namespace ERP.Dao.Nhibernate.NUnit.Util
{
    public abstract class TestBase
    {
        public NhibernateSession NhibernateSession { get; set; }

        protected string ConnectionString
        {
            get { return Properties.Settings.Default.erpConnectionString; }
        }

        protected virtual Stream DatabaseSchema
        {
            get { return NDbunitUtilities.AssemblyResourceStream("Schema.DatabaseSchema.xsd"); }
        }

        protected INDbUnitTest SetUpDatabase(DbOperationFlag operation, Stream datasetStream = null)
        {
            Assert.IsNotNull(DatabaseSchema);

            SetUpNhibernateSession();
            
            INDbUnitTest dbUnitTest = new SqlDbUnitTest(this.ConnectionString);
            dbUnitTest.ReadXmlSchema(this.DatabaseSchema);
            if(datasetStream != null) dbUnitTest.ReadXml(datasetStream);
            
            dbUnitTest.PerformDbOperation(operation);
            
            return dbUnitTest;
        }

        private void SetUpNhibernateSession()
        {
            NhibernateSession nhibernateSession = new NhibernateSession();
            nhibernateSession.BuildSession(Guid.NewGuid(), Properties.Settings.Default.erpConnectionString);

            this.NhibernateSession = nhibernateSession;
        }
    }
}