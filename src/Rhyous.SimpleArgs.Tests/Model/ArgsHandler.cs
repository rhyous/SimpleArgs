using System.Collections.Generic;

namespace Rhyous.SimpleArgs.Tests
{
    public sealed class ArgsHandler : ArgsHandlerBase
    {
        public override void InitializeArguments(IArgsManager argsManager)
        {
            Arguments.AddRange(new List<Argument>
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
            });
        }
    }
}