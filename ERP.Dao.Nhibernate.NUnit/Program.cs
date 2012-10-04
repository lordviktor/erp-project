#region Using

using System;
using System.Reflection;

#endregion

namespace ERP.Dao.Nhibernate.NUnit
{
    internal class Program
    {
        [STAThread]
        private static void Main()
        {
            string[] myArgs = {Assembly.GetExecutingAssembly().Location};

            var returnCode = global::NUnit.ConsoleRunner.Runner.Main(myArgs);

            if (returnCode != 0)
                Console.Beep();
        }
    }
}