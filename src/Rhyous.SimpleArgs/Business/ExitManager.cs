using System;

namespace Rhyous.SimpleArgs
{
    public class ExitManager : IExitManager
    { 
        /// <summary>
        /// <inheritDoc/>
        /// </summary>
        public void PrintUsage(string message)
        {
            Console.WriteLine();
            Console.Write(message);
            Console.WriteLine();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public void ExitWithInvalidParams(string message)
        {
            if (!string.IsNullOrWhiteSpace(message))
                PrintUsage(message);
            Environment.Exit(0);
        }
    }
}
