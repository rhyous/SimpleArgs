using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SimpleArgs.Tests.Business
{
    [TestClass]
    public class ArgsReaderTests
    {
        [ClassInitialize()]
        public static void ClassInit(TestContext context)
        {
            ArgumentList.Instance.MessageBuilder = new FakeMessageBuilder();
            ArgsHandlerCollection.Instance.Add(new ArgsHandler());
        }

        public sealed class ArgsHandler : ArgsHandlerBase
        {
            public ArgsHandler()
            {
                Arguments = new List<Argument>
                {
                    new Argument
                    {
                        Name = "File",
                        ShortName = "f",
                        Description = "This is an example of a file path parameter.",
                        Example = @"{name}=""C:\some\path\to\a\file.txt""",
                        DefaultValue = @"C:\path\to\a\file.txt",
                    },
                    new Argument
                    {
                        Name = "Param",
                        ShortName = "p",
                        Description = "This is an example parameter.",
                        Example = @"{name}=value",
                    }
                    // Add more args here
                };
            }
        }

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
            IReadArgs argsReader = new ArgsReader(ArgumentList.Instance) { IgnoreUnknownParams = true };
            argsReader.ParseArgs(new[] { @"File=""C:\some\Awesome\File.txt""" });
            const string expected = @"C:\some\Awesome\File.txt";
            Assert.AreEqual(expected, Args.Value("File"));
        }

        [TestMethod]
        public void TestFilePathAsParameterColon()
        {
            IReadArgs argsReader = new ArgsReader(ArgumentList.Instance) { IgnoreUnknownParams = true };
            argsReader.ParseArgs(new[] { @"File:""C:\some\Awesome\File.txt""" });
            const string expected = @"C:\some\Awesome\File.txt";
            Assert.AreEqual(expected, Args.Value("File"));
        }

        [TestMethod]
        public void TestEqualSignInParameter()
        {
            IReadArgs argsReader = new ArgsReader(ArgumentList.Instance) { IgnoreUnknownParams = true };
            argsReader.ParseArgs(new[] { @"Param=""a=b""" });
            const string expected = "a=b";
            Assert.AreEqual(expected, Args.Value("Param"));
        }
    }
}
