namespace SimpleArgs.Extensions
{
    public static class ArgumentExtensions
    {
        public static bool IsEnabled(this Argument argument)
        {
            return argument.Value.AsBool();
        }
    }
}
