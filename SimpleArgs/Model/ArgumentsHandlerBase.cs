using System.Collections.Generic;

namespace SimpleArgs
{
    public abstract class ArgsHandlerBase : IArgumentsHandler
    {
        public virtual List<Argument> Arguments { get; set; }

        public virtual bool Handled { get; set; }

        public virtual int MinimumRequiredArgs
        {
            get { return 0; }
        }

        public virtual void HandleArgs(IReadArgs inArgsHandler)
        {
            Handled = true;
        }
    }
}
