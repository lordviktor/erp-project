using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ERP.Domain;
using ERP.Dao.Interfaces.Fakes;
using ERP.Business.Base;
using ERP.Business.Interfaces.Base;

namespace ERP.Business.Test
{
    [TestClass]
    public class CompanyLogicTest
    {
        [TestMethod]
        public void SaveCompanyTestCase()
        {
            Company company = null;
            var asd = new CompanyLogic(new StubICompanyDao()
            {
                SaveCompany = x => company = x
            });
            asd.Save(new Company());
            Assert.IsNotNull(company, "O metodo salvar nao executou a operacao de salvar do repositorio.");
            Assert.AreEqual(company, new Company(), "O metodo salvar nao salvou o mesmo método informado.");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "O metodo save nao pode tentar salvar um valor nulo")]
        public void TryToSaveNullCompany()
        {
            Company company = null;
            var companyLogic = new CompanyLogic(new StubICompanyDao());
            companyLogic.Save(null);
        }

        [TestMethod]
        [ExpectedException(typeof(AlreadyRegistredEntityException), "O metodo save nao pode tentar salvar um valor já existente no banco")]
        public void TryToSaveAlreadySavedCompany()
        {
            Company company = new Company();
            var companyLogic = new CompanyLogic(new StubICompanyDao()
            {
                VerifyIfAlreadyRegistredCompany = (x) => company
            });
            companyLogic.Save(company);
        }

        [TestMethod]
        [ExpectedException(typeof(DatabaseOperationException), "O metodo save deve notificar problemas ao tenta salvar a entidade no banco de dados")]
        public void ErrorWhileTryToSaveCompanyTest()
        {
            Company company = new Company();
            var companyLogic = new CompanyLogic(new StubICompanyDao()
            {
                SaveCompany = (x) => { throw new DatabaseOperationException(); }
            });
            companyLogic.Save(company);
        }

        [TestMethod]
        public void UpdateCompanyTestCase()
        {
        }
    }
}
