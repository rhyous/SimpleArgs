using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleArgs
{
    public class ArgumentDictionary : Dictionary<string, Argument>
    {
        private readonly Dictionary<string, Argument> _ShortNameDictionary = new Dictionary<string, Argument>(StringComparer.OrdinalIgnoreCase);
        private readonly Dictionary<int, Argument> _SequenceDictionary = new Dictionary<int, Argument>();
        /// <summary>
        /// Argument dictionary default constructor. Key ignores case by default.
        /// </summary>
        public ArgumentDictionary()
            : this(StringComparer.OrdinalIgnoreCase)
        {
        }

        /// <summary>
        /// Argument dictionary comparer constructor. Allows you to determine the 
        /// comparer. By default it is StringComparer.OrdinalIgnoreCase.
        /// </summary>
        /// <param name="comparer"></param>
        public ArgumentDictionary(IEqualityComparer<string> comparer)
            : base(comparer)
        {
        }

        public event ArgumentAddedEventHandler ArgumentAdded;

        public void Add(Argument inArgument)
        {
            base.Add(inArgument.Name, inArgument);
            if (!string.IsNullOrWhiteSpace(inArgument.ShortName))
                _ShortNameDictionary.Add(inArgument.ShortName, inArgument);
            if (inArgument.SequenceId > 0)
            {
                _SequenceDictionary.Add(inArgument.SequenceId, inArgument);
                AllowSequenceIds = true;
            }
            OnArgumentAdded(inArgument);
        }

        /// <summary>
        /// This is to hide this method so Add(Argument inArgument) is used instead.
        /// </summary>
        // ReSharper disable once UnusedMember.Local
        // ReSharper disable UnusedParameter.Local
        new private void Add(string property, Argument inArgument)
        {
            throw new NotSupportedException("Use this method instead: Add(Argument inArgument).");
        }

        public delegate void ArgumentAddedEventHandler(object sender, ArgumentAddedEventArgs e);
        
        protected virtual void OnArgumentAdded(Argument inArgument)
        {
            // Raise the event by using the () operator. 
            if (ArgumentAdded != null)
                ArgumentAdded(this, new ArgumentAddedEventArgs(inArgument));
        }

        public bool AllowSequenceIds { get; set; }

        new public Argument this[string key]
        {
            get
            {
                Argument value;
                if (TryGetValue(key, out value))
                    return value;
                return _ShortNameDictionary.TryGetValue(key, out value) ? value : null;
            }
        }

        public Argument this[int key]
        {
            get
            {
                Argument value;
                return _SequenceDictionary.TryGetValue(key, out value) ? value : null;
            }
        }

        public new bool ContainsKey(string inKeyNameOrShortName)
        {
            return base.ContainsKey(inKeyNameOrShortName) || _ShortNameDictionary.ContainsKey(inKeyNameOrShortName);
        }
        /// <summary>
        /// Get the Groups from the list of args. If an argument has a group greater than 0,
        /// then at  least one argument from that group is required.
        /// </summary>
        public IEnumerable<int> Groups
        {
            get { return from arg in Values where arg.Group > 0 select arg.Group; }
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