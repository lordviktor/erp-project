#region Using

using System.Data;
using ERP.Dao.Nhibernate.Dao;
using ERP.Dao.Nhibernate.NUnit.Util;
using NDbUnit.Core;
using NUnit.Framework;

#endregion

namespace ERP.Dao.Nhibernate.NUnit.Dao.Company
{
    [TestFixture]
    public class CompanyDaoSaveTest : TestBase
    {
        private CompanyDaoNhibernate CompanyDao = new CompanyDaoNhibernate();

        [TestFixtureSetUp]
        public void SetUpFixture()
        {
            SetUpDatabase(DbOperationFlag.CleanInsertIdentity);
        }

        public void SaveCompanyTestCase()
        {
            var targetCompany = new Domain.Company
                                    {
                                        Excluded = false,
                                        LegalPersonDetail = new Domain.SubEntity.LegalPersonDetail
                                                                {
                                                                    Cnpj = new Domain.SubEntity.Cnpj
                                                                               {
                                                                                   CheckNumber = 12,
                                                                                   Root = 12345,
                                                                                   Suffix = 12
                                                                               },
                                                                    CompanyName = "Bad Cat Corporation S/A",
                                                                    TradingName = "BadCat SA",
                                                                    IE = 123456
                                                                }
                                    };
            CompanyDao.Save(targetCompany);

            ResultInspector.AreEqual(ResultInspector.GetExpectedTable(
                "Schemas.ErpSchema.xsd",
                "Dataset.InsertedCompany.xml",
                "tb_company"
                                         ),
                                     GetCompanies()
                );
        }


        private DataTable GetCompanies()
        {
            string fields = " * ";
            string query = "SELECT * \r\n" +
                           "FROM Customers " + "\r\n" +
                           "JOIN Orders ON (Customers.CustomerID = Orders.CustomerID )" + "\r\n" +
                           "JOIN Employees ON (Orders.EmployeeID = Employees.EmployeeID)" + "\r\n" +
                           "ORDER BY " + fields;
            return ResultInspector.Load(ConnectionString, query);
        }
    }
}