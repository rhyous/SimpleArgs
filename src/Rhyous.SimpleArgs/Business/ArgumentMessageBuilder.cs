﻿using System;
using System.IO;
using System.Linq;
using System.Text;

namespace Rhyous.SimpleArgs
{
    public class ArgumentMessageBuilder : IArgumentMessageBuilder
    {
        public static ArgumentMessageBuilder Instance
        {
            get { return _Instance ?? (_Instance = new ArgumentMessageBuilder()); }
        } private static ArgumentMessageBuilder _Instance;

        private ArgumentMessageBuilder() { }

        public string ExeName
        {
            get { return _ExeName ?? (_ExeName = Path.GetFileName(AssemblyStaticWrapper.Instance.GetEntryAssembly().Location)); }
            internal set { _ExeName = value; }
        } private string _ExeName;


        public string CreateMessage(ArgumentDictionary args)
        {
            string exeName = ExeName;
            StringBuilder builder = new StringBuilder();
            builder.Append("Usage:");
            builder.Append(Environment.NewLine);
            builder.Append("  ");
            builder.Append(exeName);
            foreach (var pair in args)
            {
                builder.Append(pair.Value.IsRequired ? string.Format(" {0}", pair.Value.Example) : string.Format(" [{0}]", pair.Value.Example));
            }
            builder.Append(Environment.NewLine);
            builder.Append(Environment.NewLine);
            builder.Append("Arguments:");
            builder.Append(Environment.NewLine);
            int biggestArgNameLength = args.Keys.Aggregate("", (max, cur) => max.Length > cur.Length ? max : cur).Length;
            foreach (var pair in args)
            {
                var arg = pair.Value;
                string optionalOrRequired = arg.IsRequired ? "Required" : "Optional";
                builder.Append(string.Format("  {0}\t", pair.Key.PadRight(biggestArgNameLength)));
                    builder.Append(string.Format("({0}) {1}", optionalOrRequired, arg.Description.EndSentence()));
                if (!string.IsNullOrWhiteSpace(pair.Value.DefaultValue))
                    builder.Append(string.Format(" Default value: {0}", arg.DefaultValue));
                builder.Append(Environment.NewLine);
            }

            return builder.ToString();
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