using System.IO;

namespace Rhyous.SimpleArgs
{
    public interface IFileOpener
    {
        string ExeDirectory { get; }

        TextReader Open(string file);
    }
}