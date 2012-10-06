using ERP.Dao.Nhibernate.Util;
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
        private const String TABLE_PREFIX = "TB_";

        public void Apply(FluentNHibernate.Conventions.Instances.IClassInstance instance)
        {
            var tableName = instance.EntityType.Name;
            tableName = ConventionsUtilities.CamelCaseToUpperCaseWithUnderscoreSeparator(tableName);
            instance.Table(TABLE_PREFIX + tableName);
        }

        public void Accept(FluentNHibernate.Conventions.AcceptanceCriteria.IAcceptanceCriteria<FluentNHibernate.Conventions.Inspections.IClassInspector> criteria)
        {
        //    criteria.Expect(x => x.TableName, Is.Not.Set);
        }
    }
}
