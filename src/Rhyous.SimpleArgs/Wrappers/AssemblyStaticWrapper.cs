using System;
using System.Reflection;

namespace Rhyous.SimpleArgs
{
    internal class AssemblyStaticWrapper : IAssemblyStatic
    {
        #region Singleton

        private static readonly Lazy<AssemblyStaticWrapper> Lazy = new Lazy<AssemblyStaticWrapper>(() => new AssemblyStaticWrapper());

        internal static IAssemblyStatic Instance
        {
            get { return _Instance ?? (_Instance = Lazy.Value); }
            set { _Instance = value; }
        }

        private static IAssemblyStatic _Instance;

        internal AssemblyStaticWrapper() { }

        #endregion

        public IAssembly GetEntryAssembly() => new AssemblyWrapper(Assembly.GetEntryAssembly());
    }
}
