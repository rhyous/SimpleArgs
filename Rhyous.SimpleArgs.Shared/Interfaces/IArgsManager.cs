using System.Collections.Generic;

namespace Rhyous.SimpleArgs
{
    public interface IArgsManager
    {
        IReadArgs ArgsReader { get; }
        IArgsHandlerList ArgsHandlerList { get; }
        void Start(string[] args, ArgsReader argsReader = null);
        void Start(IArgumentsHandler handler, string[] args, ArgsReader argsReader = null);
        void Start(IArgsHandlerList handlers, string[] args, ArgsReader argsReader = null);
    }
}