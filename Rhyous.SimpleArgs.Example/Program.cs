using Rhyous.SimpleArgs;
using SimpleArgs.Example.Arguments;

namespace SimpleArgs.Example
{
    class Program
    {
        static void Main(string[] args)
        {
            ArgsManager.Instance.Start(new ArgsHandler(), args);
        }
    }
}
