using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.AcceptanceCriteria;
using FluentNHibernate.Conventions.Inspections;
using FluentNHibernate.Conventions.Instances;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERP.Dao.Nhibernate.Mapping.Conventions
{
    public class ColumnNullabilityConvention
        : IPropertyConvention, IPropertyConventionAcceptance
    {
        public void Accept(IAcceptanceCriteria<IPropertyInspector> criteria)
        {
            criteria.Expect(x => x.Nullable, Is.Not.Set);
        }

        public void Apply(IPropertyInstance instance)
        {
            instance.Not.Nullable();
        }
    }
}
