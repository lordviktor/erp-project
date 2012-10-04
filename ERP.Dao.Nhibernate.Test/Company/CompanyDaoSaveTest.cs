using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit;
using NUnit.Framework;
using ERP.Dao.Nhibernate.Dao;
using ERP.Dao.Nhibernate.Test.Utilities;
using NDbUnit.Core;
using ERP.Dao.Nhibernate.Test.Schema;
using System.Data;

namespace ERP.Dao.Nhibernate.Test.Company
{
    [TestFixture]
    public class CompanyDaoSaveTest:BaseTest
    {
        [SetUp]
        public void Setup()
        {
            base.SetupDatabase( Properties.Resources.ConnectionString, Utilities.Util.AssemblyResourceStream("Schema.MyDataset.xsd"), 
                DbOperationFlag.DeleteAll );
        }

        [Test]
        public void SaveCompanyTest()
        {
            CompanyDaoNhibernate target = new CompanyDaoNhibernate();

        }
    }
}
