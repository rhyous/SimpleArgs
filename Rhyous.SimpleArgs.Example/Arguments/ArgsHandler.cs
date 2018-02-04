using Rhyous.SimpleArgs;
using System;
using System.Collections.Generic;

namespace SimpleArgs.Example.Arguments
{
    // Add this line of code to Main() in Program.cs
    //
    //   new ArgsManager<ArgsHandler>().Start(args);
    //

    /// <summary>
    /// A class that implements IArgumentsHandler where command line
    /// arguments are defined.
    /// </summary>
    public sealed class ArgsHandler : ArgsHandlerBase
    {
        public override void InitializeArguments(IArgsManager argsManager)
        {
            Arguments.AddRange(new List<Argument>
            {
                new Argument
                {
                    Name = "Echo",
                    ShortName = "E",
                    Description = "I echo to the console whater you put after Echo=",
                    Example = "{name}=\"Hello, World!\"",
                    Action = (value) => { Console.WriteLine(value); }
                },
                new Argument
                {
                    Name = "Value",
                    ShortName = "V",
                    Description = "This is an example argument with a default value.",
                    Example = "{name}=NonDefaultValue",
                    DefaultValue = "SomeDefaultValue"
                },
                // Add more args here
				// new Argument
                // {
                //     Name = "NextArg",
                //     ShortName = "N",
                //     Description = "This is the next arg you are going to add.",
                //     Example = "{name}=true",
                //     DefaultValue = "false"
                //     AllowedValues = CommonAllowedValues.TrueFalse
                // },
                new ConfigFileArgument(argsManager) // This is a special Argument type to allow for args in a file
            });
        }

        public override void HandleArgs(IReadArgs inArgsHandler)
        {
            base.HandleArgs(inArgsHandler);
            Console.WriteLine("I handled the args!!!");
        }
    }
}
