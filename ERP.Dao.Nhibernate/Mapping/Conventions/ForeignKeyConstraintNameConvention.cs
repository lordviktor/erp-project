using ERP.Dao.Nhibernate.Util;
using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERP.Dao.Nhibernate.Mapping.Conventions
{
    public class ForeignKeyConstraintNameConvention
        : IHasManyConvention
    {
        public void Apply(IOneToManyCollectionInstance instance)
        {
            var originName = ConventionsUtilities
                .CamelCaseToUpperCaseWithUnderscoreSeparator(instance.Member.Name);
            var targetName = ConventionsUtilities
                .CamelCaseToUpperCaseWithUnderscoreSeparator(instance.EntityType.Name);
            instance.Key.ForeignKey(String.Format("FK_{0}_{1}", 
                originName, targetName));
        }
    }
}
