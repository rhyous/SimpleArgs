using System.Collections.Generic;

namespace SimpleArgs.Handlers
{
    public class ArgsHandlerCollection : List<IArgumentHandler>
    {
        #region Constructor and Singleton
        private ArgsHandlerCollection()
        {
        }

        public static ArgsHandlerCollection Instance
        {
            get { return _Instance ?? (_Instance = new ArgsHandlerCollection()); }
            set { _Instance = value; }
        } private static ArgsHandlerCollection _Instance;
        #endregion

        new public void Add(IArgumentHandler inArgsHandler)
        {
            base.Add(inArgsHandler);
            foreach (var arg in inArgsHandler.Args)
            {
                ArgumentList.Instance.Args.Add(arg);
            }
        }

        public void HandleArgs(IReadArgs argsReader)
        {
            foreach (var handler in this)
            {
                if (!handler.Handled)
                    handler.HandleArgs(argsReader);
            }
        }
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