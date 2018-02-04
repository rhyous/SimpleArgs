using Rhyous.SimpleArgs;
using System.Collections.Generic;

namespace Rhyous.SimpleArgs.Tests.EndToEndTests
{
    /// <summary>
    /// A class that implements IArgumentsHandler where command line
    /// arguments are defined.
    /// </summary>
    public sealed class ArgsHandler1 : ArgsHandlerBase
    {
        internal TestValues TestValues = new TestValues();

        public ArgsHandler1() { TestValues = new TestValues(); }
        public override void InitializeArguments(IArgsManager manager)
        {
            Arguments = new List<Argument>
            {
                new Argument
                {
                    Name = "Arg1",
                    ShortName = "A",
                    Description = "I am the first arg.",
                    Example = "{name}=value",
                    Action = value => { TestValues.Arg1SetActionCallCount++; }
                }
            };
        }
        
        public override int MinimumRequiredArgs
        {
            get { return 1; } // At least one argument is required
        }

        public override void HandleArgs(IReadArgs inArgsHandler)
        {
            base.HandleArgs(inArgsHandler);
            TestValues.HandleArgsCallCount++;
        }
    }
}