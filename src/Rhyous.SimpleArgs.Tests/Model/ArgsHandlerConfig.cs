using System;
using System.Collections.Generic;
using System.Linq;
using Rhyous.SimpleArgs;
using System.IO;

namespace Rhyous.SimpleArgs.Tests.EndToEndTests
{
    /// <summary>
    /// A class that implements IArgumentsHandler where command line
    /// arguments are defined.
    /// </summary>
    public sealed class ArgsHandlerConfig : ArgsHandlerBase
    {
        private TestValues _TestValues;
        private readonly Func<string, TextReader> _GetTextReaderMethod;

        public ArgsHandlerConfig() { }
        public ArgsHandlerConfig(TestValues testValues, Func<string, TextReader> getTextReaderMethod)
        {
            _TestValues = testValues;
            _GetTextReaderMethod = getTextReaderMethod;
        }
        public override void InitializeArguments(IArgsManager argsManager)
        { 
            var configFileArg = new ConfigFileArgument(argsManager) { GetTextReaderMethod = _GetTextReaderMethod };
            configFileArg.Action = (val) =>
            {
                configFileArg.BaseAction(val);
                _TestValues.ArgFileSetActionCallCount++;
            };
            Arguments = new List<Argument>
            {
                new Argument
                {
                    Name = "Arg1",
                    ShortName = "A",
                    Description = "I am the first arg.",
                    Example = "{name}=value",
                    Action = value => { _TestValues.Arg1SetActionCallCount++; }
                },
                new Argument
                {
                    Name = "Arg2",
                    ShortName = "B",
                    Description = "I am the second arg.",
                    Example = "{name}=value",
                    Action = value => { _TestValues.Arg2SetActionCallCount++; }
                },
                new Argument
                {
                    Name = "Arg3",
                    ShortName = "C",
                    Description = "I am the third arg.",
                    Example = "{name}=value",
                    Action = value => { _TestValues.Arg2SetActionCallCount++; }
                },
                configFileArg
            };
        }

        public override int MinimumRequiredArgs
        {
            get { return 1; } // At least one argument is required
        }

        public override void HandleArgs(IReadArgs inArgsHandler)
        {
            base.HandleArgs(inArgsHandler);
            _TestValues.HandleArgsCallCount++;
        }
    }
}