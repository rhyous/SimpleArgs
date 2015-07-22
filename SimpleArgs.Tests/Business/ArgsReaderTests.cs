using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SimpleArgs.Tests.Business
{
    [TestClass]
    public class ArgsReaderTests
    {
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
        public void TestMethod1()
        {
            ArgumentList.Instance.MessageBuilder = new FakeMessageBuilder();
            ArgsHandlerCollection.Instance.Add(new ArgsHandler());
            IReadArgs argsReader = new ArgsReader(ArgumentList.Instance) { IgnoreUnknownParams = true };
            argsReader.ParseArgs(new[] { @"File=""C:\some\Awesome\File.txt""" });
        }
    }
}
