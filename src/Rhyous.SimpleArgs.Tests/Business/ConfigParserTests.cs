using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Collections.Generic;
using Rhyous.SimpleArgs;

namespace Rhyous.SimpleArgs.Tests.Business
{
    [TestClass]
    public class ConfigParserTests
    {
        [TestMethod]
        public void ConfigParserBasicTest()
        {
            // Arrange
            var key1 = "a";
            var key2 = "b";
            var key3 = "c";
            var value1 = "true";
            var value2 = "false";
            var value3 = "1";
            var expected = new Dictionary<string, string>
            {
                { key1, value1 },
                { key2, value2 },
                { key3, value3 }
            };
            var config = $"{key1}={value1}" + Environment.NewLine
                       + $"{key2}={value2}" + Environment.NewLine
                       + $"{key3}={value3}" + Environment.NewLine;
            TextReader reader = new StringReader(config);
            Action a = new Action(() => { });

            // Act
            var actual = ConfigParser.Parse(reader, a);

            // Assert
            Assert.AreEqual(expected[key1], actual[key1]);
            Assert.AreEqual(expected[key2], actual[key2]);
            Assert.AreEqual(expected[key3], actual[key3]);
        }

        [TestMethod]
        public void ConfigParserSpacesNoQuotesTest()
        {
            // Arrange
            var key1 = "a b";
            var key2 = "b c";
            var key3 = "c d";
            var value1 = "true";
            var value2 = "false";
            var value3 = "1 and 2";
            var expected = new Dictionary<string, string>
            {
                { key1, value1 },
                { key2, value2 },
                { key3, value3 }
            };
            var config = $"{key1}={value1}" + Environment.NewLine
                       + $"{key2}={value2}" + Environment.NewLine
                       + $"{key3}={value3}" + Environment.NewLine;
            TextReader reader = new StringReader(config);
            Action a = new Action(() => { });

            // Act
            var actual = ConfigParser.Parse(reader, a);

            // Assert
            Assert.AreEqual(expected[key1], actual[key1]);
            Assert.AreEqual(expected[key2], actual[key2]);
            Assert.AreEqual(expected[key3], actual[key3]);
        }

        [TestMethod]
        public void ConfigParserSpacesQuotesWorkTest()
        {
            // Arrange
            var key1 = "a=b";
            var key2 = "b c";
            var key3 = "c d";
            var value1 = "true";
            var value2 = "false!=true";
            var value3 = "1 and 2";
            var expected = new Dictionary<string, string>
            {
                { key1, value1 },
                { key2, value2 },
                { key3, value3 }
            };
            var config = $@"""{key1}""=""{value1}""" + Environment.NewLine
                       + $@"""{key2}""=""{value2}""" + Environment.NewLine
                       + $@"""{key3}""=""{value3}""" + Environment.NewLine;
            TextReader reader = new StringReader(config);
            Action a = new Action(() => { });

            // Act
            var actual = ConfigParser.Parse(reader, a);

            // Assert
            Assert.AreEqual(expected[key1], actual[key1]);
            Assert.AreEqual(expected[key2], actual[key2]);
            Assert.AreEqual(expected[key3], actual[key3]);
        }

        [TestMethod]
        public void ConfigParserBlankLineIgnoredTest()
        {
            // Arrange
            var key1 = "a";
            var key2 = "b";
            var key3 = "c";
            var value1 = "true";
            var value2 = "false";
            var value3 = "1";
            var expected = new Dictionary<string, string>
            {
                { key1, value1 },
                { key2, value2 },
                { key3, value3 }
            };
            var config = $"{key1}={value1}" + Environment.NewLine
                       + $"{key2}={value2}" + Environment.NewLine
                       + "" + Environment.NewLine
                       + $"{key3}={value3}" + Environment.NewLine;
            TextReader reader = new StringReader(config);
            Action a = new Action(() => { });

            // Act
            var actual = ConfigParser.Parse(reader, a);

            // Assert
            Assert.AreEqual(expected[key1], actual[key1]);
            Assert.AreEqual(expected[key2], actual[key2]);
            Assert.AreEqual(expected[key3], actual[key3]);
        }


        [TestMethod]
        public void ConfigParserCommentsIgnoredTest()
        {
            // Arrange
            var key1 = "a";
            var key2 = "b";
            var key3 = "c";
            var value1 = "true";
            var value2 = "false";
            var value3 = "1";
            var expected = new Dictionary<string, string>
            {
                { key1, value1 },
                { key2, value2 },
                { key3, value3 }
            };
            var config = "// Param 1" + Environment.NewLine
                       + $"{key1}={value1}" + Environment.NewLine
                       + "// Param 2" + Environment.NewLine
                       + $"{key2}={value2}" + Environment.NewLine
                       + "// Param 3" + Environment.NewLine
                       + $"{key3}={value3}" + Environment.NewLine;
            TextReader reader = new StringReader(config);
            Action a = new Action(() => { });

            // Act
            var actual = ConfigParser.Parse(reader, a);

            // Assert
            Assert.AreEqual(expected[key1], actual[key1]);
            Assert.AreEqual(expected[key2], actual[key2]);
            Assert.AreEqual(expected[key3], actual[key3]);
        }

        [TestMethod]
        public void ConfigParserSlashOrDashTest()
        {
            // Arrange
            var key1 = "a";
            var key2 = "b";
            var key3 = "c";
            var key4 = "d";
            var expected = new Dictionary<string, string>
            {
                { key1, true.ToString() },
                { key2, true.ToString() },
                { key3, true.ToString() },
                { key4, false.ToString() }
            };
            var config = $"/{key1}" + Environment.NewLine
                       + $"-{key2}" + Environment.NewLine
                       + $"--{key3}" + Environment.NewLine
                       + $"/{key4}" + "=" + false.ToString() + Environment.NewLine;
            TextReader reader = new StringReader(config);
            Action a = new Action(() => { });

            // Act
            var actual = ConfigParser.Parse(reader, a);

            // Assert
            Assert.AreEqual(expected[key1], actual[key1]);
            Assert.AreEqual(expected[key2], actual[key2]);
            Assert.AreEqual(expected[key3], actual[key3]);
            Assert.AreEqual(expected[key4], actual[key4]);
        }
    }
}
