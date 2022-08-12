using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhyous.UnitTesting;

namespace Rhyous.SimpleArgs.Tests.Business
{
    [TestClass]
    public class CommonAllowedValuesTests
    {
        [TestMethod]
        public void TrueFalseCommonAllowedValuesTrueIsTrueTest()
        {
            var arg = new Argument
            {
                AllowedValues = CommonAllowedValues.TrueFalse
            };
            arg.Value = "true";
            Assert.IsTrue(arg.IsValueValid);
        }

        [TestMethod]
        public void TrueFalseCommonAllowedValuesFalseIsTrueTest()
        {
            var arg = new Argument
            {
                AllowedValues = CommonAllowedValues.TrueFalse
            };
            arg.Value = "false";
            Assert.IsTrue(arg.IsValueValid);
        }

        [TestMethod]
        [Int32TestValues()]
        public void CommonAllowedValuesParamterValueCoverage(int value)
        {
            var arg = new Argument
            {
                AllowedValues = CommonAllowedValues.TrueFalse
            };
            arg.Value = value.ToString();
            Assert.IsFalse(arg.IsValueValid);
        }
    }
}
