using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleArgs.Extensions;
using SimpleArgs.Tests.MsTestHelpers;

namespace SimpleArgs.Tests.Extensions
{
    [TestClass]
    public class StringExtensionsTests
    {
        public const string CsvDataSource = "Microsoft.VisualStudio.TestTools.DataSource.CSV";
        public const string XmlDataSource = "Microsoft.VisualStudio.TestTools.DataSource.XML";

        public TestContext TestContext { get; set; }

        #region string.AsInt() Tests
        /// <summary>
        /// Valid integer strings should convert to integers.
        /// </summary>
        [TestMethod]
        [DataSource(CsvDataSource, @"Data\Integers.csv", "Integers#csv", DataAccessMethod.Sequential)]
        public void TestAsInt()
        {
            // Arrange
            var data = TestContext.DataRow.Data();

            // Act
            var actual = data.Value.AsInt();

            // Assert
            Assert.AreEqual(data.Value, actual.ToString(), data.Message);
        }

        /// <summary>
        /// Invalid integer strings should convert to 0.
        /// </summary>
        [TestMethod]
        [DataSource(CsvDataSource, @"Data\Strings.csv", "Strings#csv", DataAccessMethod.Sequential)]
        public void TestAsIntInvalidStrings()
        {
            // Arrange
            var data = TestContext.DataRow.Data();

            // Act
            var actual = data.Value.AsInt();

            // Assert
            Assert.AreEqual(0, actual, data.Message); // Fail test if expected exception is not found
        }
        #endregion

        #region string.AsLong() tests
        [TestMethod]
        //[DataSource(CsvDataSource, @"Data\Longs.csv", "Longs#csv", DataAccessMethod.Sequential)]
        [DataSource(XmlDataSource, @"Data\Longs.xml", "Row", DataAccessMethod.Sequential)]
        public void TestAsLong()
        {
            // Arrange
            var data = TestContext.DataRow.Data();

            // Act
            var actual = data.Value.AsLong();

            // Assert
            Assert.AreEqual(data.Value, actual.ToString(), data.Message);
        }

        [TestMethod]
        [DataSource(CsvDataSource, @"Data\Strings.csv", "Strings#csv", DataAccessMethod.Sequential)]
        public void TestAsLongInvalidStrings()
        {
            // Arrange
            var data = TestContext.DataRow.Data();

            // Act
            var actual = data.Value.AsLong();

            // Assert
            Assert.AreEqual(0, actual, data.Message); // Fail test if expected exception is not found
        }

        #endregion

        #region string.AsBool() Tests
        [TestMethod]
        public void TestAsBoolTrue()
        {
            // Arrange
            const string boolAsString = "true";
            const bool expected = true;

            // Act
            var actual = boolAsString.AsBool();

            // Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestAsBoolFalse()
        {
            // Arrange
            const string boolAsString = "false";
            const bool expected = false;

            // Act
            var actual = boolAsString.AsBool();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestAsBoolTrueUpperCase()
        {
            // Arrange
            const string boolAsString = "True";
            const bool expected = true;

            // Act
            var actual = boolAsString.AsBool();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestAsBoolFalseUpperCase()
        {
            // Arrange
            const string boolAsString = "False";
            const bool expected = false;

            // Act
            var actual = boolAsString.AsBool();

            // Assert
            Assert.AreEqual(expected, actual);
        }
        #endregion

    }
}
