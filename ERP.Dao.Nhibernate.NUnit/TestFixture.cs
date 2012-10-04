#region Using

using NUnit.Framework;

#endregion

namespace ERP.Dao.Nhibernate.NUnit
{
    [TestFixture]
    public class TestFixture1
    {
        [Test]
        public void TestTrue()
        {
            Assert.IsTrue(true);
        }

        // This test fail for example, replace result or delete this test to see all tests pass
        [Test]
        public void TestFault()
        {
            Assert.IsTrue(false);
        }
    }
}