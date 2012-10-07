using ERP.Dao.Nhibernate.Util;
using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.AcceptanceCriteria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERP.Dao.Nhibernate.Mapping.Conventions
{
    public class ColumnNameConvention : IPropertyConvention, IPropertyConventionAcceptance
    {
        public void Apply(FluentNHibernate.Conventions.Instances.IPropertyInstance instance)
        {
            var columnName = ConventionsUtilities.CamelCaseToUpperCaseWithUnderscoreSeparator(instance.Property.Name);
            instance.Column(columnName);
        }

        public void Accept(FluentNHibernate.Conventions.AcceptanceCriteria.IAcceptanceCriteria<FluentNHibernate.Conventions.Inspections.IPropertyInspector> criteria)
        {
            criteria.Expect(x => x.Name, Is.Not.Set);
        }
    }
}
