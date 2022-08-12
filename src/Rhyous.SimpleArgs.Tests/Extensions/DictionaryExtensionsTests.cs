using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhyous.SimpleArgs;
using System.Collections.Generic;

namespace Rhyous.SimpleArgs.Tests.Extensions
{
    [TestClass]
    public class DictionaryExtensionsTests
    {
        [TestMethod]
        public void TestToArgs()
        {
            // arrange
            var expectedA = "A=1";
            var expectedB = "B=2";
            var expectedC = "C=True";
            var expectedD = "\"D D\"=\"value 1\"";
            var expectedE = "E=True";
            var expectedF = "F=True";
            var dict = new Dictionary<string, string>
            {
                {"A","1" },
                {"B","2" },
                { "/C", null },
                { "D D", "value 1" },
                { "-E", null },
                { "--F", null },
            };

            // Act
            var args = dict.ToArgs();

            // Assert
            Assert.AreEqual(expectedA, args[0]);
            Assert.AreEqual(expectedB, args[1]);
            Assert.AreEqual(expectedC, args[2]);
            Assert.AreEqual(expectedD, args[3]);
            Assert.AreEqual(expectedE, args[4]);
            Assert.AreEqual(expectedF, args[5]);
        }
    }
}
