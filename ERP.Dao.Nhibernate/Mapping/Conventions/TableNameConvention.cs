using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.AcceptanceCriteria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ERP.Dao.Nhibernate.Mapping.Conventions
{
    public class TableNameConvention : IClassConvention, IClassConventionAcceptance
    {
        public void Apply(FluentNHibernate.Conventions.Instances.IClassInstance instance)
        {
            var tableName = instance.EntityType.Name;
            tableName = Regex.Replace(tableName, "(.)([A-Z][a-z]+)", "_");
            tableName = Regex.Replace(tableName, "([a-z0-9])([A-Z])", "_");
            tableName = "TB_" + tableName;
            instance.Table(tableName.Trim().ToUpper());
        }

        public void Accept(FluentNHibernate.Conventions.AcceptanceCriteria.IAcceptanceCriteria<FluentNHibernate.Conventions.Inspections.IClassInspector> criteria)
        {
            criteria.Expect(x => x.TableName, Is.Not.Set);
        }
    }
}
