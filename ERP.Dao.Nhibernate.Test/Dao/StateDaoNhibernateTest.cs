using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ERP.Dao.Nhibernate.Dao;
using ERP.Domain.SubEntity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ERP.Dao.Nhibernate.Test.Dao
{
    [TestClass]
    public class StateDaoNhibernateTest
    {
        NhibernateSession session = new NhibernateSession();

        readonly State validState = new State() { Name = "Rio de Janeiro"};
        readonly City validCity1 = new City() { Name = "Rio de Janeiro" };
        readonly City validCity2 = new City() { Name = "Niterói" };
        readonly City validCity3 = new City() { Name = "Nova Friburgo" };
        readonly City validCity4 = new City() { Name = "Angra dos Reis" };


        [TestMethod]
        public void SaveStateTest()
        {
            session.BuildSession(Guid.NewGuid(), Properties.Resources.ConnectionString);

            var target = new StateDaoNhibernate();
            target.NhibernateSession = session;

            var state = new State();
            state.Name = "Rio de Janeiro";

            target.Save(state);
        }

        [TestMethod]
        public void SaveStateAndInsertCities()
        {
            session.BuildSession(Guid.NewGuid(), Properties.Resources.ConnectionString);

            var target = new StateDaoNhibernate();
            target.NhibernateSession = session;

            var state = new State();
            state.Name = "Rio de Janeiro";
            state.Cities = new List<City>() { validCity1, validCity2, validCity3, validCity4 };

            target.Save(state);
        }

        [TestMethod]
        public void FetchAllStates()
        {
            session.BuildSession(Guid.NewGuid(), Properties.Resources.ConnectionString);

            var target = new StateDaoNhibernate();
            target.NhibernateSession = session;
            var result = target.FetchAll();

            Assert.IsNotNull(result);
        }
    }
}
