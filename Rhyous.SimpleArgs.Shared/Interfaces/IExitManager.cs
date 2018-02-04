namespace Rhyous.SimpleArgs
{
    public interface IExitManager
    {
        void ExitWithInvalidParams(string message);
        void PrintUsage(string message);
    }
}