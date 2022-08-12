namespace Rhyous.SimpleArgs
{
    /// <summary>Allows for injecting an instance of IAssemblyStatic.</summary>
    /// <remarks>Usually used for unit tests.</remarks>
    public class ArgsAssemblyInjector
    {
        /// <summary>Replaces the instance of IAssemblyStatic with a new one.</summary>
        public static void OverwriteInstance(IAssemblyStatic newInstance)
            => AssemblyStaticWrapper.Instance = newInstance;
    }
}