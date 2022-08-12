using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhyous.SimpleArgs;

namespace Rhyous.SimpleArgs.Tests.EndToEndTests
{
    [TestClass]
    public class EndToEnd1
    {
        [TestMethod]
        public void TestEndToEndWithOneArg()
        {
            // Arrange
            var args = new[] {"A=1" };
            ArgumentMessageBuilder.Instance.ExeName = "test.exe";
            var manager = new ArgsManager<ArgsHandler1>("EndToEndOneArg");
            var handler = manager.ArgsHandlerList.FirstOrDefault();
            var testValues = ((ArgsHandler1)handler).TestValues;

            // Act
            manager.Start(args);

            // Assert
            Assert.AreEqual(1, testValues.Arg1SetActionCallCount);
            Assert.AreEqual(1, testValues.HandleArgsCallCount);
        }
        
    }
}
