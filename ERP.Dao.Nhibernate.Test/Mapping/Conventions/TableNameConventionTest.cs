using ERP.Dao.Nhibernate.Mapping.Conventions;
using FluentNHibernate.Conventions.Instances;
using FluentNHibernate.Conventions.Instances.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERP.Dao.Nhibernate.Test.Mapping.Conventions
{
    [TestClass]
    public class TableNameConventionTest
    {
        [TestMethod]
        public void SingleNameTableNamegenerationTestCase()
        {
            var target = new TableNameConvention();
            String tableName = null;
            var argument = new StubIClassInstance()
            {
                EntityTypeGet = () => typeof(ERP.Domain.Company),
                TableString = x=> tableName = x
            };
            target.Apply(argument);
            Assert.AreEqual("TB_COMPANY", tableName);
        }

        [TestMethod]
        public void ComplexNameTableNamegenerationTestCase()
        {
            var target = new TableNameConvention();
            String tableName = null;
            var argument = new StubIClassInstance()
            {
                EntityTypeGet = () => typeof(ERP.Domain.BasicEntity.BaseMultiTenancyEntity),
                TableString = x => tableName = x
            };
            target.Apply(argument);
            Assert.AreEqual("TB_BASE_MULTI_TENANCY_ENTITY", tableName);
        }
    }
}
