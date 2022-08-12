using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhyous.SimpleArgs;
using System.IO;

namespace Rhyous.SimpleArgs.Tests.EndToEndTests
{
    [TestClass]
    public class EndToEndConfig
    {
        [TestMethod]
        public void TestEndToEndWithConfigArg()
        {
            // Arrange
            var testValues = new TestValues();
            ArgumentMessageBuilder.Instance.ExeName = "test.exe";

            var args = new[] { "ArgsFile=file.config" };
            ArgumentMessageBuilder.Instance.ExeName = "test.exe";
            var config = "A=1" + Environment.NewLine
                       + "B=2";
            Func<string, TextReader> textReaderFunc = (string s) => { return new StringReader(config); };

            // Act
            var handler = new ArgsHandlerConfig(testValues, textReaderFunc);
            var manager = new ArgsManager<ArgsHandlerConfig>(handler, "ArgsConfig");
            manager.Start(args);

            // Assert
            Assert.AreEqual(1, testValues.ArgFileSetActionCallCount);
            Assert.AreEqual(1, testValues.Arg1SetActionCallCount);
            Assert.AreEqual(1, testValues.Arg2SetActionCallCount);
            Assert.AreEqual(0, testValues.Arg3SetActionCallCount);
            Assert.AreEqual(1, testValues.HandleArgsCallCount);
        }
    }
}
