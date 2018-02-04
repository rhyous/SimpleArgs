using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhyous.SimpleArgs.Tests;

namespace Rhyous.SimpleArgs.Tests
{
    [TestClass]
    public class ArgsManagerTests
    {
        [TestMethod]
        public void EmptyConstuctorTests()
        {
            // Arrange
            ArgumentMessageBuilder.Instance.ExeName = "test.exe";

            // Act
            var argsManager = new ArgsManager<ArgsHandler>();

            // Assert
            Assert.AreEqual(1, argsManager.ArgsHandlerList.Count);
        }
    }
}
