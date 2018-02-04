using System.Collections;
using System.Collections.Generic;

namespace Rhyous.SimpleArgs
{
    public class ArgsHandlerList : IArgsHandlerList
    {
        public ArgsHandlerList(ArgumentDictionary argumentDictionary) { _ArgumentDictionary = argumentDictionary; }

        public int MinimumRequiredArgs { get; set; }

        public ArgumentDictionary ArgumentDictionary
        {
            get { return _ArgumentDictionary ?? (_ArgumentDictionary = new ArgumentDictionary()); }
            private set { _ArgumentDictionary = value; }
        } private static ArgumentDictionary _ArgumentDictionary;

        public void HandleArgs(IReadArgs argsReader)
        {
            foreach (var handler in this)
            {
                if (!handler.Handled)
                    handler.HandleArgs(argsReader);
            }
        }

        #region IList
        internal List<IArgumentsHandler> _List = new List<IArgumentsHandler>();

        public void Add(IArgumentsHandler inArgsHandler)
        {
            if (_List.Contains(inArgsHandler))
                return;
            _List.Add(inArgsHandler);
            foreach (var arg in inArgsHandler.Arguments)
            {
                ArgumentDictionary.Add(arg);
            }
            MinimumRequiredArgs += inArgsHandler.MinimumRequiredArgs;
        }


        public int IndexOf(IArgumentsHandler item)
        {
            return _List.IndexOf(item);
        }

        public void Insert(int index, IArgumentsHandler item)
        {
            _List.Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            _List.RemoveAt(index);
        }

        public void Clear()
        {
            _List.Clear();
        }

        public bool Contains(IArgumentsHandler item)
        {
            return _List.Contains(item);
        }

        public void CopyTo(IArgumentsHandler[] array, int arrayIndex)
        {
            _List.CopyTo(array, arrayIndex);
        }

        public bool Remove(IArgumentsHandler item)
        {
            return _List.Remove(item);
        }

        public IEnumerator<IArgumentsHandler> GetEnumerator()
        {
            return _List.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _List.GetEnumerator();
        }

        public void AddRange(IEnumerable<IArgumentsHandler> handlers)
        {
            _List.AddRange(handlers);
        }

        public int Count { get { return _List.Count; } }

        public bool IsReadOnly { get { return ((IList<IArgumentsHandler>)_List).IsReadOnly; } }

        public IArgumentsHandler this[int index]
        {
            get { return _List[index]; }
            set { _List[index] = value; }
        }
        #endregion
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