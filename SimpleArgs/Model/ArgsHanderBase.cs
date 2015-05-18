using System.Collections.Generic;

namespace SimpleArgs
{
    public abstract class ArgsHanderBase : IArgumentHandler
    {
        public List<Argument> Args { get; set; }

        public bool Handled { get; set; }

        public virtual void HandleArgs(IReadArgs inArgsHandler)
        {
            Handled = true;
        }
    }
}
