using System;
using System.Collections.Generic;

namespace SimpleArgs.Example.Arguments
{
    /// <summary>
    /// A class that implements IArgumentHandler where command line
    /// arguments are defined.
    /// </summary>
    public class ArgsHandler : IArgumentHandler
    {
        public ArgsHandler()
        {
            Args = new List<Argument>
            {
                new Argument
                {
                    Name = "Echo",
                    ShortName = "E",
                    Description = "I echo to the console whater you put after Echo=",
                    Example = "Echo=\"Hello, World!\"",
                    Action = (value) => { Console.WriteLine(value);}
                },
                // Add more args here
            };
        }

        public List<Argument> Args { get; set; }

        public void HandleArgs(IReadArgs inArgsHandler)
        {
            Handled = true;
            Console.WriteLine("I handled the args!!!");
        }

        public bool Handled { get; set; }
    }
}
