namespace Rhyous.SimpleArgs
{
    /// <summary>An interface to represent some static calls for Assembly.</summary>
    public interface IAssemblyStatic
    {
        /// <summary>The assembly from the exe that was launched.</summary>
        IAssembly GetEntryAssembly();
    }
}
