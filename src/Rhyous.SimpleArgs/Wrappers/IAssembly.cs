namespace Rhyous.SimpleArgs
{
    /// <summary>An interface to represent an Assembly.</summary>
    public interface IAssembly
    {
        /// <summary>The assembly's location or the exe the assembly launched from.</summary>
        string Location { get; }
    }
}
