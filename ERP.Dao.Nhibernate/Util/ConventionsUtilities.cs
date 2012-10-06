using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ERP.Dao.Nhibernate.Util
{
    public static class ConventionsUtilities
    {
        public static string CamelCaseToUpperCaseWithUnderscoreSeparator(string value)
        {
            value = Regex.Replace(value, @"(\p{Ll})(\p{Lu})", "$1_$2").ToUpper();
            return value.ToUpper();
        }
    }
}
