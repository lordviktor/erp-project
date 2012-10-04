#region Using

using System;
using ERP.Dao.Nhibernate.Dao;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NDbUnit.Core;
using NDbUnit.Core.MySqlClient;
using System.Reflection;

#endregion

namespace ERP.Dao.Nhibernate.Test.Company
{
    /// <summary>
    ///This is a test class for CompanyDaoNhibernateTest and is intended
    ///to contain all CompanyDaoNhibernateTest Unit Tests
    ///</summary>
    [TestClass]
    public class CompanyDaoSaaveTest
    {
        #region Additional test attributes

        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public void MyClassInitialize(TestContext testContext)
        //{
        //}
        ////
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //

        #endregion

        [TestMethod]
        public void SaveTest()
        {
            var Database = new MySqlDbUnitTest(Properties.Resources.ConnectionString);
            Database.ReadXmlSchema(@"..\..\Schema\MyDataset.xsd");
            Database.PerformDbOperation(DbOperationFlag.DeleteAll);
            var session = new NhibernateSession();
            session.BuildSession(new Guid(), Properties.Resources.ConnectionString);
            CompanyDaoNhibernate target = new CompanyDaoNhibernate() { NhibernateSession = session };
            var company = new Domain.Company()
                {
                    LegalPersonDetail = new Domain.SubEntity.LegalPersonDetail()
                        {
                            Cnpj = new Domain.SubEntity.Cnpj()
                                    { Root = 123123, Suffix = 12345, CheckNumber = 12 },
                            CompanyName = "CompanyName",
                            IE = 123123123
                        }
                };

            target.Save(company);
            Assert.AreEqual(company,  target.Get(company.Id) );
        }
    }
}