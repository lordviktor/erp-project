#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using ERP.Dao.Interfaces;
using ERP.Dao.Interfaces.BaseType;
using ERP.Domain.BasicEntity;
using NHibernate;
using NHibernate.Bytecode;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using FluentNHibernate.Cfg;
using ERP.Dao.Nhibernate.Mapping;
using FluentNHibernate.Cfg.Db;
using ERP.Dao.Nhibernate.Mapping.Conventions;

#endregion

namespace ERP.Dao.Nhibernate
{
    [Export(typeof(IDatabaseManager))]
    public class NhibernateSession : IDatabaseManager
    {
        private NHibernate.ISessionFactory _sessionFactory;

        internal Guid Company;

        /// <summary>
        /// Build NHibernate session. The connection with the database. 
        /// </summary>
        /// <param name="company">the tenancy company with that all queryes in the system will 
        /// be eexecuted with this company.</param>
        /// <param name="connectionString">The connection string that want to be used.</param>
        public void BuildSession(Guid company, String connectionString)
        {
            try
            {
                this.Company = company;

                var configuration = Fluently
                    .Configure()
                    //.Database(MySQLConfiguration.Standard.ConnectionString(connectionString).ShowSql())
                    .Database(MsSqlConfiguration.MsSql2008.ConnectionString(connectionString).ShowSql())
                    //SQLiteConfiguration.Standard.UsingFile("Teste.db")) 
                    //MySQLConfiguration.Standard.ConnectionString(connectionString))
                    .Mappings(x => x.FluentMappings.AddFromAssemblyOf<AddressMap>()
                        .Conventions
                            .AddFromAssemblyOf<TableNameConvention>())
                    .ExposeConfiguration(cfg =>
                        {
                            cfg.SetProperty(NHibernate.Cfg.Environment.ShowSql, true.ToString());
                            cfg.SetProperty(NHibernate.Cfg.Environment.Hbm2ddlAuto, "update");
                            cfg.SetProperty(NHibernate.Cfg.Environment.UseProxyValidator, false.ToString());
                        }
                    )
                    .BuildConfiguration();

                BuildEnversConfiguration(configuration);

                _sessionFactory = configuration.BuildSessionFactory();

                var schemaUpdate = new SchemaUpdate(configuration);
                schemaUpdate.Execute(true, true);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static void BuildEnversConfiguration(Configuration configuration)
        {
            var enversConf = new NHibernate.Envers.Configuration.Fluent.FluentConfiguration();

            IEnumerable<Type> entities = typeof(BaseEntity).Assembly.GetTypes()
                .Where(x => x.IsSubclassOf(typeof(BaseEntity)) && x.IsAbstract == false)
                .ToList();

            enversConf.Audit(entities);

            configuration.IntegrateWithEnvers(enversConf);
        }

        #region SessionSingleton
        private static ISession _currentSession;

        internal NHibernate.ISession CreateSession()
        {
            lock (this)
            {
                _currentSession = _sessionFactory.OpenSession();
            }

            return _currentSession;
        }
        #endregion
    }
}