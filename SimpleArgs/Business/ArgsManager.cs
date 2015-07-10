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

        public void Start(IArgumentsHandler handler, string[] args)
        {
            ArgsHandlerCollection.Instance.Add(handler);
            IReadArgs argsReader = new ArgsReader(ArgumentList.Instance);
            argsReader.ParseArgs(args);
            ArgsHandlerCollection.Instance.HandleArgs(argsReader);
        }

    }
}
