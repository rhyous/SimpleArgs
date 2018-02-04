using System;
using System.Collections.Generic;
using System.Linq;

namespace Rhyous.SimpleArgs
{
    /// <summary>
    /// This is a library for handling Property=Value arguments.
    /// The actual arguments a program supports should be passed in.
    /// </summary>
    public class ArgsReader : IReadArgs
    {

        public char[] IgnoreCharacters = "/-\"'".ToCharArray();
        public bool IgnoreUnknownParams = false;
        internal ArgumentDictionary ArgumentDictionary { get { return ArgsHandlerList.ArgumentDictionary; } }
        internal IArgsHandlerList ArgsHandlerList { get; set; }

        #region Constructors

        public ArgsReader(IArgsHandlerList argsHandlerList, string message)
        {
            ArgsHandlerList = argsHandlerList;
            Message = message;
        }
        #endregion

        #region Properties
        public IExitManager ExitManager
        {
            get { return _ExitManager ?? (_ExitManager = new ExitManager()); }
            internal set { _ExitManager = value; }
        } private IExitManager _ExitManager;
        
        /// <summary>
        /// <inheritDoc/>
        /// </summary>
        public string[] Args
        {
            get { return _Args; }
            set
            {
                _Args = value;
                ParseArgs(_Args);
            }
        } private string[] _Args;

        /// <summary>
        /// <inheritDoc/>
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// <inheritDoc/>
        /// </summary>
        public Argument this[string argName]
        {
            get
            {
                Argument arg;
                ArgumentDictionary.TryGetValue(argName, out arg);
                return arg;
            }
        }

        private List<int> Groups
        {
            get { return _Groups ?? (_Groups = new List<int>()); }
        } private List<int> _Groups;

        #endregion

        #region Methods
        /// <summary>
        /// <inheritDoc/>
        /// </summary>
        public void ParseArgs(string[] inArgs)
        {
            ValidateMinimumRequiredArgs(inArgs);
            SetArgValues(inArgs);
            ValidateAllRequiredArgsAreProvided();
            ValidateGroupArgs();
        }

        private void ValidateMinimumRequiredArgs(string[] inArgs)
        {
            if (inArgs == null || inArgs.Length < ArgsHandlerList.MinimumRequiredArgs)
            {
                PrintUsage();
            }
        }

        private void SetArgValues(string[] inArgs)
        {
            int sequence = 1;
            foreach (string arg in inArgs)
            {
                string key;
                string value;
                GetArgumentPropertyValue(arg, out key, out value);
                if (!ArgumentDictionary.ContainsKey(key) || ArgumentDictionary[key] == null || string.IsNullOrWhiteSpace(value))
                {
                    ReadUnnamedArgs(sequence, key, value);
                }
                else
                {
                    SetValue(key, value);
                }
                sequence++;
            }
        }

        private void GetArgumentPropertyValue(string arg, out string property, out string value)
        {
            var argSplit = arg.Split("=:".ToCharArray(), 2);
            property = string.Empty;
            value = string.Empty;
            if (argSplit.Length > 0)
                property = argSplit[0].Trim(IgnoreCharacters);
            if (argSplit.Length > 1)
                value = argSplit[1].Trim(IgnoreCharacters);
            // If they have a parameter like /a or -a then assume a is a bool and set a to true.
            else if (arg[0] == '/' || arg[0] == '-')
                value = "true";
        }

        private void ReadUnnamedArgs(int sequence, string key, string value)
        {
            if (string.IsNullOrWhiteSpace(value) && ArgumentDictionary.AllowSequenceIds)
            {
                value = key;
                key = ArgumentDictionary[sequence].Name;
                SetValue(key, value);
            }
            else if (!IgnoreUnknownParams)
            {
                PrintUsage();
            }
        }

        private void SetValue(string key, string value)
        {
            ArgumentDictionary[key].Value = value;
            if (!ArgumentDictionary[key].IsValueValid) // If not AllowedValue or doesn't pass CustomValidation
                PrintUsage();
            if (ArgumentDictionary[key].Group > 0)
                Groups.Add(ArgumentDictionary[key].Group);
        }
        
        private void ValidateAllRequiredArgsAreProvided()
        {
            foreach (var argsHandler in ArgsHandlerList)
            {
                if (argsHandler.Arguments.Any(arg => arg.IsRequired && !arg.IsValueValid))
                    PrintUsage();
            }
        }

        private void ValidateGroupArgs()
        {
            if (Groups != null)
            {
                if (ArgumentDictionary.Groups.Any(n => !Groups.Contains(n)))
                {
                    PrintUsage();
                }
            }
        }

        /// <inheritDoc />
        public void PrintUsage()
        {
            ExitManager.ExitWithInvalidParams(Message);
        }

        /// <inheritDoc/>
        public void PrintUsage(string prefix)
        {
            ExitManager.ExitWithInvalidParams(prefix + Environment.NewLine + Message);
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