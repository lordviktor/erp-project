#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using ERP.Core.Factory;
using ERP.Core.Metadata;
using ERP.Dao.Interfaces;
using ERP.Dao.Interfaces.BaseType;
using ERP.Domain;
using ERP.Domain.SubEntity;

#endregion

namespace ERP.Core
{
    public class ModuleHandler
    {
        [Import(typeof (IDaoFactory))] public IDaoFactory DaoFactory;

        [Import(typeof (IBusinessFactory))] public IBusinessFactory BusinessFactory;

        [Import(typeof (IDatabaseManager))] public IDatabaseManager DatabaseManager;

        public void ComposeCatalog()
        {
            var catalog = new AggregateCatalog();
            CompositionContainer cc;

            catalog.Catalogs.Add(new AssemblyCatalog(System.Reflection.Assembly.GetAssembly(typeof (ModuleHandle))));
            catalog.Catalogs.Add(
                new DirectoryCatalog(
                    System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) +
                    "\\Modules", "*.dll"));
            cc = new CompositionContainer(catalog);
            cc.ComposeParts(this);
            String Server = "127.0.0.1";
            String Port = "3306";
            String Schema = "ERP";
            String Login = "root";
            String Password = "viktorjose";
            String connectionString = String.Format("Server={0};Port={1};Database={2};Uid={3};Pwd={4};", Server, Port,
                                                    Schema, Login, Password);

            DatabaseManager.BuildSession(Guid.NewGuid(), connectionString);

            //DaoFactory.GetReference<ICompanyDao>(PersistenceType.Nhibernate).Save(new Domain.Company() { CompanyName = "DClick", CNPJ = "12345678", Excluded = false });
            //DaoFactory.GetReference<ICompanyDao>(PersistenceType.Nhibernate).Save(new Domain.Company() { CompanyName = "Test2", CNPJ = "87654321", Excluded = false });

            var asd = DaoFactory.GetReference<ICompanyDao>(PersistenceType.Mock);
            var com = asd.FetchAll().First();
            com.LegalPersonDetail.CompanyName = "Batatinha";
            asd.Update(com);

            DaoFactory.GetReference<ICompanyDao>(PersistenceType.Nhibernate)
                .Save(new Company
                          {
                              Excluded = false,
                              Email = new List<Email> {new Email {EmailAddress = "Victor@victor.com"}},
                              LegalPersonDetail = new LegalPersonDetail
                                                      {
                                                          Cnpj =
                                                              new Cnpj {CheckNumber = 12, Root = 1212312, Suffix = 0001},
                                                          CompanyName = "Bad Cat SA",
                                                          TradingName = "Bad cat",
                                                          IE = 123123
                                                      }
                          }
                );
        }
    }
}