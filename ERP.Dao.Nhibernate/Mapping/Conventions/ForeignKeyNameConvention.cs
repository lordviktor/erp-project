using ERP.Dao.Nhibernate.Util;
using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERP.Dao.Nhibernate.Mapping.Conventions
{
    public class ForeignKeyNameConvention : IHasManyConvention
    {
        public void Apply(IOneToManyCollectionInstance instance)
        {
            var originName = ConventionsUtilities
                .CamelCaseToUpperCaseWithUnderscoreSeparator(instance.EntityType.Name);
            instance.Key.Column(originName + "_ID");
        }
    }
}
