using System.Collections.Generic;

namespace SimpleArgs
{
    public class ArgsManager
    {
        #region Singleton
        public static ArgsManager Instance
        {
            get { return _Instance ?? (_Instance = new ArgsManager()); }
        } private static ArgsManager _Instance;

        private ArgsManager()
        {
        }
        #endregion

        public IReadArgs ArgsReader { get; private set; }

        public void Start(string[] args)
        {
            ArgsReader = new ArgsReader(ArgumentList.Instance);
            ArgsReader.ParseArgs(args);
            ArgsHandlerCollection.Instance.HandleArgs(ArgsReader);
        }

        public void Start(IArgumentsHandler handler, string[] args)
        {
            ArgsHandlerCollection.Instance.Add(handler);
            Start(args);
        }

        public void Start(List<IArgumentsHandler> handlers, string[] args)
        {
            ArgsHandlerCollection.Instance.AddRange(handlers);
            Start(args);
        }
    }
}
