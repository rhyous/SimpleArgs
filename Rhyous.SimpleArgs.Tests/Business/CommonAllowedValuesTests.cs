using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhyous.SimpleArgs.Tests.Data;
using Rhyous.SimpleArgs.Tests.MsTestHelpers;

namespace Rhyous.SimpleArgs.Tests.Business
{
    [TestClass]
    public class CommonAllowedValuesTests
    {
        public TestContext TestContext { get; set; }

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
        [DataSource(DataSources.CsvDataSource, @"Data\Integers.csv", "Integers#csv", DataAccessMethod.Sequential)]
        public void CommonAllowedValuesParamterValueCoverage()
        {
            var data = TestContext.DataRow.Data();

            var arg = new Argument
            {
                AllowedValues = CommonAllowedValues.TrueFalse
            };
            arg.Value = data.Value;
            Assert.IsFalse(arg.IsValueValid);
        }


    }
}
