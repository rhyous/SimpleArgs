using System;
using System.IO;

namespace Rhyous.SimpleArgs
{
    public class ConfigFileArgument : Argument
    {
        internal IArgumentsHandler ArgsHandler;

        public ConfigFileArgument(IArgsManager agsManager)
        {
            ArgsManager = agsManager;
            Name = "ArgumentsFile";
            ShortName = "ArgsFile";
            Description = "Enter all your arguments in a file.";
            Example = @"{name}=""path\to\some config.cfg""";
            Action = BaseAction;
        }

        internal IArgsManager ArgsManager { get; set; }

        public Action<string> BaseAction
        {
            get
            {
                return (string value) =>
                {
                    var filereader = GetTextReaderMethod(value);
                    if (filereader == null)
                    {
                        ArgsManager.ArgsReader.PrintUsage("Invalid file: " + value + Environment.NewLine);                        
                    }
                    var dictionary = ConfigParser.Parse(filereader, ArgsManager.ArgsReader.PrintUsage);
                    ArgsManager.Start(dictionary.ToArgs());
                };
            }
        }

        internal Func<string,TextReader> GetTextReaderMethod
        {
            get { return _GetTextReaderMethod ?? (_GetTextReaderMethod = FileOpener.Open); }
            set { _GetTextReaderMethod = value; }
        } private Func<string,TextReader> _GetTextReaderMethod;

        public IFileOpener FileOpener
        {
            get { return _FileOpener ?? (_FileOpener = new FileOpener()); }
            set { _FileOpener = value; }
        } private IFileOpener _FileOpener;
    }
}