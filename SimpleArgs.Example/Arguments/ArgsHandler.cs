using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleArgs.Example.Arguments
{
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
                    Action = (value) => { Console.WriteLine(value);}
                },
                new Argument
                {
                    Name = "ReverseEcho",
                    ShortName = "RE",
                    Description = "I echo to the console whater you put after Echo= but I do it in reverse",
                    Example = "{name}=\"Hello, World!\"",
                    Action = (value) => { Console.WriteLine(value.Reverse());}
                },
                new Argument
                {
                    Name = "Value",
                    ShortName = "V",
                    Description = "This is an example argument with a default value.",
                    Example = "{name}=NonDefaultValue",
                    DefaultValue = "SomeDefaultValue"
                },
                new Argument
                {
                    Name = "ExampleBool",
                    ShortName = "eb",
                    Description = "This is an example of a true/false parameter.",
                    Example = "{name}=true",
                    DefaultValue = "false",
                    AllowedValues = CommonAllowedValues.TrueFalse
                }
                // Add more args here
            };
        }

        public override int MinimumRequiredArgs
        {
            get { return 1; } // At least one argument is required
        }

        public override void HandleArgs(IReadArgs inArgsHandler)
        {
            base.HandleArgs(inArgsHandler);
            Console.WriteLine("I handled the args!!!");
            if (Args.Value("Value") == Args.Get("Value").DefaultValue)
                Console.WriteLine("You left the default value of {0}", Args.Value("Value"));
            else
                Console.WriteLine("You changed the default value to {0}", Args.Value("Value"));
        }
    }
}
