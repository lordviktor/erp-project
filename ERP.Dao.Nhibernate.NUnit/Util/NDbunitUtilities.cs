#region Using

using System.IO;
using System.Reflection;
using NUnit.Framework;

#endregion

namespace ERP.Dao.Nhibernate.NUnit.Util
{
    internal class NDbunitUtilities
    {
        private const string rootNamespace = "ERP.Dao.Nhibernate.NUnit";

        internal static Stream ResourceStream(string resourceName)
        {
            return Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName);
        }

        internal static Stream AssemblyResourceStream(string relativeResourceName)
        {
            Stream stream =
                Assembly.GetExecutingAssembly().GetManifestResourceStream(rootNamespace + "." + relativeResourceName);
            Assert.IsNotNull(stream);
            return stream;
        }
    }
}