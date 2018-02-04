using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Rhyous.SimpleArgs
{
    public class FileOpener : IFileOpener
    {
        public string ExeDirectory
        {
            get { return _ExeDirectory ?? (_ExeDirectory = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location)); }
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
