using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhyous.SimpleArgs;

namespace SimpleArgs.Tests.Model
{
    [TestClass]
    public class ArgumentsDefaultValueTests
    {
        [TestMethod]
        public void SettingDefaultValueSetsValueTest()
        {
            var arg = new Argument();
            arg.DefaultValue = "a";
            Assert.AreEqual("a", arg.Value);
        }

        [TestMethod]
        public void DefaultValueCanMakeArgValueInvalid()
        {
            var arg = new Argument
            {
                AllowedValues = {"a"}
            };
            arg.DefaultValue = "b";
            Assert.IsFalse(arg.IsValueValid);
        }

        [TestMethod]
        public void DefaultValueCannotMakeArgValueInvalidIfAlreadySet()
        {
            var arg = new Argument
            {
                AllowedValues = { "a" },
                Value = "a"
            };
            arg.DefaultValue = "b";
            Assert.IsTrue(arg.IsValueValid);
        }
    }
}
