using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Rhyous.SimpleArgs.Tests.Business
{
    [TestClass]
    public partial class ArgsReaderTests
    {

        public class FakeMessageBuilder : IArgumentMessageBuilder
        {
            public string CreateMessage(ArgumentDictionary args)
            {
                return "";
            }
        }
        
        [TestMethod]
        public void TestFilePathAsParameter()
        {
            // Arrange
            var listName = "PathAsParamter";
            ArgumentMessageBuilder.Instance.ExeName = "test.exe";
            var argsList = new ArgumentList(listName) { MessageBuilder = new FakeMessageBuilder() };
            var argsHandlerList = new ArgsHandlerList(argsList.Args);
            IReadArgs argsReader = new ArgsReader(argsHandlerList, argsList.Message) { IgnoreUnknownParams = true };
            new ArgsManager<ArgsHandler>(argsReader, argsList, argsHandlerList);
            const string expected = @"C:\some\Awesome\File.txt";

            // Act
            argsReader.ParseArgs(new[] { @"File=""C:\some\Awesome\File.txt""" });

            // Assert
            Assert.AreEqual(expected, Args.Value("File", listName));
        }

        [TestMethod]
        public void TestFilePathAsParameterColon()
        {
            var listName = "FileColon";
            ArgumentMessageBuilder.Instance.ExeName = "test.exe";
            var argsList = new ArgumentList(listName) { MessageBuilder = new FakeMessageBuilder() };
            var argsHandlerList = new ArgsHandlerList(argsList.Args);
            IReadArgs argsReader = new ArgsReader(argsHandlerList, argsList.Message);
            new ArgsManager<ArgsHandler>(argsReader, argsList, argsHandlerList);
            argsReader.ParseArgs(new[] { @"File:""C:\some\Awesome\File.txt""" });
            const string expected = @"C:\some\Awesome\File.txt";
            Assert.AreEqual(expected, Args.Value("File", listName));
        }

        [TestMethod]
        public void TestEqualSignInParameter()
        {
            // Arrange
            ArgumentMessageBuilder.Instance.ExeName = "test.exe";
            var listName = "EqualsSignInValue";
            var argsList = new ArgumentList(listName) { MessageBuilder = new FakeMessageBuilder() };
            var argsHandlerList = new ArgsHandlerList(argsList.Args);
            IReadArgs argsReader = new ArgsReader(argsHandlerList, argsList.Message);
            new ArgsManager<ArgsHandler>(argsReader, argsList, argsHandlerList);
            const string expected = "a=b";

            // Act
            argsReader.ParseArgs(new[] { @"Param=""a=b""" });
            
            // Assert
            Assert.AreEqual(expected, Args.Value("Param", listName));
        }
    }
}