using System.Collections.Generic;

namespace Rhyous.SimpleArgs
{
    public interface IArgsHandlerList : IList<IArgumentsHandler>
    {
        int MinimumRequiredArgs { get; set; }
        void HandleArgs(IReadArgs argsReader);
        void AddRange(IEnumerable<IArgumentsHandler> handlers);
        ArgumentDictionary ArgumentDictionary { get; }
    }
}