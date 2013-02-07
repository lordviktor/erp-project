using ERP.Dao.Nhibernate.Dao;
using ERP.Dao.Nhibernate.NUnit.Schema;
using ERP.Dao.Nhibernate.NUnit.Util;
using ERP.Domain.SubEntity;
using NDbUnit.Core;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERP.Dao.Nhibernate.NUnit.Dao
{
    [TestFixture]
    public class StateDaoNhibernateTest : TestBase
    {
        [TestFixtureSetUp]
        public void setUp()
        {
            SetUpDatabase(DbOperationFlag.CleanInsertIdentity);
        }

        [Test]
        public void TestSaveState()
        {
            var target = new StateDaoNhibernate();
            target.NhibernateSession = base.NhibernateSession;
            var state = new State() { Name = "Rio de Janeiro" };
            target.Save(state);

            Assert.IsTrue( 
                ResultInspector.AreEqual(
                    ResultInspector.LoadPartial<DatabaseSchema>(ConnectionString, "TB_STATE", "SELECT NAME FROM TB_STATE").Tables["TB_STATE"],
                    ResultInspector.GetExpectedTable("Schema.DatabaseSchema.xsd", "Dataset.ExpectedInsertState.xml", "TB_STATE")
                )
            );
        }
    }
}
