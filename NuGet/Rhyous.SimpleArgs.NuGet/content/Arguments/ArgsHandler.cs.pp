using Rhyous.SimpleArgs;
using System;
using System.Collections.Generic;

namespace $rootnamespace$.Arguments
{
    // Add this line of code to Main() in Program.cs
    //
    //   ArgsManager.Instance.Start(new ArgsHandler(), args);
    //

    /// <summary>
    /// A class that implements IArgumentsHandler where command line
    /// arguments are defined.
    /// </summary>
    public sealed class ArgsHandler : ArgsHandlerBase
    {
        public ArgsHandler()
        {
            Arguments = new List<Argument>
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
                }
                // Add more args here
            };
        }

        public override void HandleArgs(IReadArgs inArgsHandler)
        {
            Handled = true;
            Console.WriteLine("I handled the args!!!");
        }
    }
}
