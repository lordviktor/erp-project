using ERP.Dao.Nhibernate.Util;
using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERP.Dao.Nhibernate.Mapping.Conventions
{
    class ReferenceConvention : IReferenceConvention
    {
        public void Apply(IManyToOneInstance instance)
        {
            var originName = ConventionsUtilities
                .CamelCaseToUpperCaseWithUnderscoreSeparator(instance.Property.MemberInfo.Name);
            instance.Column(originName + "_ID");
        }
    }
}
