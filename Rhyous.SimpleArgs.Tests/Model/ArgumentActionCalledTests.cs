using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhyous.SimpleArgs;

namespace Rhyous.SimpleArgs.Tests.Model
{
    [TestClass]
    public class ArgumentActionCalledTests
    {
        [TestMethod]
        public void ActionCalledTest()
        {
            var arg = new Argument();
            bool wasCalled = false;
            arg.Action = value => { wasCalled = true; };
            arg.Value = "a";
            Assert.IsTrue(wasCalled);
        }
    }
}
