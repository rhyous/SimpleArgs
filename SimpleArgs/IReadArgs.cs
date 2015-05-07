using System.Collections.Generic;

namespace SimpleArgs
{
    /// <summary>
    /// An interface to use throught your code when calling a concrete 
    /// ArgsHandler object. By using this interface instead of the
    /// concrete args handler object, your code allows for dependency
    /// injection or inversion of control. Essentally a fake, mock, or
    /// a replacement module can implement this interface when needed.
    /// </summary>
    public interface IReadArgs
    {
        /// <summary>
        /// The list of supported command line arguments. This should 
        /// also be identical to PropertyValueArgs.Keys.
        /// </summary>
        string[] Args { get; set; }

        /// <summary>
        /// The message displayed when a user runs a command with /?
        /// </summary>
        string Message { get; set; }

        /// <summary>
        /// The method that parses the command line arguments.
        /// </summary>
        /// <param name="inArgs"></param>
        void ParseArgs(string[] inArgs);

        /// <summary>
        /// A dictionary for storing the values of the arguments.
        /// You can store default values or null initially and 
        /// then add values that are passed in.
        /// </summary>
        ArgumentDictionary ArgumentDictionary { get; }

        /// <summary>
        /// An indexer for acccessing the argument object
        /// by calling this class as follows: 
        /// myArgsHander[MyArgName]
        /// </summary>
        /// <param name="argName"></param>
        /// <returns>The Argument object.</returns>
        Argument this[string argName] { get; }

        /// <summary>
        /// This method should print the Message string to the 
        /// command line.
        /// </summary>
        void PrintUsage();
    }
}

#region Fork and Contribute License
/*
SimpleArgs - Easy coding of command line arguments.

Copyright (c) 2012, Jared Abram Barneck (Rhyous)
All rights reserved.
 
Redistribution and use in source and binary forms, with or without
modification, are permitted provided that the following conditions are met:
 
1. Redistributions of source code must retain the above copyright notice, this
   list of conditions and the following disclaimer.
2. Redistributions in binary form must reproduce the above copyright notice,
   this list of conditions and the following disclaimer in the documentation
   and/or other materials provided with the distribution.
3. Use of the source code or binaries for a competing project, whether open
   source or commercial, is prohibited unless permission is specifically
   granted under a separate license by Jared Abram Barneck (Rhyous).
4. Forking for personal or internal, or non-competing commercial use is 
   allowed. Distributing compiled releases as part of your non-competing 
   project is allowed.
5. Public copies, or forks, of source is allowed, but from such, public
   distribution of compiled releases is forbidden.
6. Source code enhancements or additions are the property of the author until
   the source code is contributed to this project. By contributing the source
   code to this project, the author immediately grants all rights to the
   contributed source code to Jared Abram Barneck (Rhyous).
 
THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND
ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED
WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE FOR
ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES
(INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;
LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND
ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
(INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS
SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
*/
#endregion