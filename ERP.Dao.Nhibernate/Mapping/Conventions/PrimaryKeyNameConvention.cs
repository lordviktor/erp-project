using ERP.Dao.Nhibernate.Util;
using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERP.Dao.Nhibernate.Mapping.Conventions
{
    public class PrimaryKeyNameConvention : IIdConvention
    {
        public void Apply(IIdentityInstance instance)
        {
            var originName = ConventionsUtilities
                .CamelCaseToUpperCaseWithUnderscoreSeparator(instance.EntityType.Name);
            instance.Column(originName + "_ID");
        }
    }
}
