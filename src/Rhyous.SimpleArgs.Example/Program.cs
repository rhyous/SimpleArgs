namespace Rhyous.SimpleArgs.Example
{
    class Program
    {
        static void Main(string[] args)
        {
           new ArgsManager<ArgsHandler>().Start(args);
        }
    }
}