using System.IO;

namespace Rhyous.SimpleArgs
{
    public class FileOpener : IFileOpener
    {
        public string ExeDirectory
        {
            get { return _ExeDirectory ?? (_ExeDirectory = Path.GetDirectoryName(AssemblyStaticWrapper.Instance.GetEntryAssembly().Location)); }
            internal set { _ExeDirectory = value; }
        } private string _ExeDirectory;

        public TextReader Open(string file)
        {
            if (Path.IsPathRooted(file) && File.Exists(file))
                return File.OpenText(file);
            var relativePath = Path.Combine(ExeDirectory, file);
            if (File.Exists(relativePath))
                return File.OpenText(relativePath);
            return null;
        }
    }
}