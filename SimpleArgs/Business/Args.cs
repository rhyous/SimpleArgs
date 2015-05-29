namespace SimpleArgs
{
    public static class Args
    {
        public static string Value(string key)
        {
            return ArgumentList.Instance.Args[key].Value;
        }

        public static Argument Get(string key)
        {
            return ArgumentList.Instance.Args[key];
        }
    }
}
