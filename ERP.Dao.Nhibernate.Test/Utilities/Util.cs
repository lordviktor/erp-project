using System.IO;
using System.Reflection;
using NUnit.Framework;

namespace ERP.Dao.Nhibernate.Test.Utilities
{
    internal class Util
    {
        private const string rootNamespace = "ERP.Dao.Nhibernate.Test";
        
        internal static Stream ResourceStream(string resourceName)
        {
            return Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName);
        }

        internal static Stream AssemblyResourceStream(string relativeResourceName)
        {
            Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream( rootNamespace + "." + relativeResourceName);
            Assert.IsNotNull(stream);
            return stream;
        }
    }
}
