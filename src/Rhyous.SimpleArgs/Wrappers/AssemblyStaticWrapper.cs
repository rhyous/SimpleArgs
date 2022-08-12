using System;
using System.Reflection;

namespace Rhyous.SimpleArgs
{
    internal class AssemblyStaticWrapper : IAssemblyStatic
    {
        #region Singleton

        private static readonly Lazy<AssemblyStaticWrapper> Lazy = new Lazy<AssemblyStaticWrapper>(() => new AssemblyStaticWrapper());

        public static IAssemblyStatic Instance => _Instance ?? (_Instance = Lazy.Value);
        private static IAssemblyStatic _Instance;
        public static void OverwriteInstance(IAssemblyStatic newInstance) { _Instance = newInstance; }

        internal AssemblyStaticWrapper()
        {
        }

        #endregion
        public IAssembly GetEntryAssembly() => new AssemblyWrapper(Assembly.GetEntryAssembly());
    }
}
