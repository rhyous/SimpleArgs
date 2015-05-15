using SimpleArgs;
using System;
using System.Collections.Generic;

namespace $rootnamespace$.Arguments
{
    // Add this line of code to Main() in Program.cs
    //
    //   ArgsManager.Instance.Start(new ArgsHandler(), args);
    //

    /// <summary>
    /// A class that implements IArgumentHandler where command line
    /// arguments are defined.
    /// </summary>
    public class ArgsHandler : ArgsHanderBase
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
                    Action = (value) => { Console.WriteLine(value); }
                },
                // Add more args here
            };
        }

        public void HandleArgs(IReadArgs inArgsHandler)
        {
            Handled = true;
            Console.WriteLine("I handled the args!!!");
        }
    }
}
