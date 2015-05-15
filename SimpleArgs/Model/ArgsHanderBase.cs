using System.Collections.Generic;

namespace SimpleArgs
{
    public abstract class ArgsHanderBase : IArgumentHandler
    {
        public List<Argument> Args { get; set; }

        public bool Handled { get; set; }

        public void HandleArgs(IReadArgs inArgsHandler)
        {
            Handled = true;
        }
    }
}
