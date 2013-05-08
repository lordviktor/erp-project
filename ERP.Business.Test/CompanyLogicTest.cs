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

        #region Save

        [TestMethod]
        public void SaveEntityTestCase()
        {
            Company company = null;
            var target = new CompanyLogic(new StubICompanyDao()
            {
                SaveCompany = x => company = x
            });
            target.Save(new Company());
            Assert.IsNotNull(company, "O metodo salvar nao executou a operacao de salvar do repositorio.");
            Assert.AreEqual(company, new Company(), "O metodo salvar nao salvou a mesma entidade informada.");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "O metodo save nao pode tentar salvar um valor nulo")]
        public void TryToSaveNullEntity()
        {
            Company company = null;
            var companyLogic = new CompanyLogic(new StubICompanyDao());
            companyLogic.Save(company);
        }

        [TestMethod]
        [ExpectedException(typeof(AlreadyRegistredEntityException), "O metodo save nao pode tentar salvar um valor já existente no banco")]
        public void TryToSaveAlreadySavedEntity()
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
        public void ErrorWhileTryToSaveEntityTest()
        {
            Company company = new Company();
            var companyLogic = new CompanyLogic(new StubICompanyDao()
            {
                SaveCompany = (x) => { throw new DatabaseOperationException(); }
            });
            companyLogic.Save(company);
        }

        #endregion

        #region Update


        [TestMethod]
        public void UpdateEntityTestCase()
        {
            Company company = new Company();
            var target = new CompanyLogic(new StubICompanyDao()
                {
                    UpdateCompany = (x) => { company = x; }
                }
            );
            target.Update(new Company());
            Assert.IsNotNull(company, "O método salvar não executou a operacao de atualizar entidade no repositorio.");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "O método update não pode tentar atualizar um valor nulo")]
        public void TryToUpdateNullEntity()
        {
            var target = new CompanyLogic(new StubICompanyDao());
            target.Update(null);
        }

        [TestMethod]
        [ExpectedException(typeof(DatabaseOperationException), "O metodo update deve notificar problemas ao tenta atualizar a entidade no banco de dados")]
        public void ErrorWhileTryToUpdateNewEntity()
        {
            Company company = new Company();
            var target = new CompanyLogic(new StubICompanyDao()
                {
                    UpdateCompany = (x) => { throw new DatabaseOperationException(); }
                });
            target.Update(company);
        }

    #endregion

        #region Delete

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "O metodo delete não pode tentar deletar do banco um dado nulo.")]
        public void TryToDeleteNullEntity()
        {
            Company company = null;
            var companyLogic = new CompanyLogic(new StubICompanyDao());
            
            companyLogic.Delete(company);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "O metodo delete não pode tentar deletar do banco um dado já marcado como excluido.")]
        public void TryToDeleteAlreadyDeletedEntity()
        {
            Company company = new Company() { Excluded = true };
            var companyLogic = new CompanyLogic(new StubICompanyDao());
            
            companyLogic.Delete(company);
        }
        
        [TestMethod]
        public void DeleteEntityTestCase()
        {
            Company company = new Company();
            var companyLogic = new CompanyLogic(new StubICompanyDao());
            
            companyLogic.Delete(company);
        }

        [TestMethod]
        [ExpectedException(typeof(DatabaseOperationException), "O metodo delete deve notificar problemas ao tenta deletar a entidade no banco de dados")]
        public void ErrorWhileTryToDeleteEntity()
        {
            Company company = new Company();
            var companyLogic = new CompanyLogic(new StubICompanyDao()
            {
                UpdateCompany = (x) => { throw new DatabaseOperationException(); }
            });

            companyLogic.Delete(company);
        }

        #endregion
    }
}
