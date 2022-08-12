using System.Reflection;

namespace Rhyous.SimpleArgs
{

    internal class AssemblyWrapper : IAssembly
    {
        private readonly Assembly _Assembly;

        public AssemblyWrapper(Assembly assembly)
        {
            _Assembly = assembly;
        }
        public string Location => _Assembly.Location;
    }
}
