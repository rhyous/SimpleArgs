using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace SimpleArgs
{
    /// <summary>
    /// A representation of a command line argument.
    /// </summary>
    public class Argument
    {
        /// <summary>
        /// In a command line argument such as this:
        /// FirstName=John
        /// Name is "FirstName".
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// In a command line argument such as this:
        /// FirstName=John
        /// There may be a shorter option for FirstName
        /// such as this:
        /// FN=John
        /// FN is the ShortName 
        /// </summary>
        public string ShortName { get; set; }

        /// <summary>
        /// In a command line argument such as this:
        /// FirstName=John
        /// The value is the string "John".
        /// </summary>
        public string Value
        {
            get { return _Value; }
            set { SafeSetValue(value); }
        } private string _Value;

        /// <summary>
        /// Only allow set if the value is an allowed value.
        /// If the value is required, deny set if value is 
        /// null, empty, or whitespace.
        /// </summary>
        /// <param name="value"></param>
        private void SafeSetValue(string value)
        {
            if (IsValueAllowed(value))
            {
                _Value = value;
                if (Action != null)
                    Action(value);
            }
        }

        private bool IsValueAllowed(string value)
        {
            return (AllowedValues.Count == 0
                || AllowedValues.Contains(value))
                   && (!IsRequired || (IsRequired && !string.IsNullOrWhiteSpace(value)))
                   && (string.IsNullOrWhiteSpace(Pattern) || Regex.IsMatch(value, Pattern));
        }

        /// <summary>
        /// This is a the description of the command
        /// line parameter that is seen when a user
        /// runs the exe with a /?.
        /// Use {Name} to reference an argument name so 
        /// you don't have to update the output when you
        /// change the name of an argument, it will
        /// be updated for you.
        /// </summary>
        public string Description
        {
            get { return Regex.Replace(_Description, @"\{Name\}", Name, RegexOptions.IgnoreCase); }
            set { _Description = value; }
        } private string _Description;

        /// <summary>
        /// This is an Example usage of the command 
        /// line parameter. For example if the parameter
        /// name is FirstName, the example string would
        /// be this:
        /// "FirstName=John"
        /// {Name} = FirstName
        /// Use {Name} so you don't have to update the output
        /// when you change the name of an argument, it will
        /// be updated for you.
        /// </summary>
        public string Example
        {
            get { return Regex.Replace(_Example, @"\{Name\}", Name, RegexOptions.IgnoreCase); }
            set { _Example = value; }
        } private string _Example;

        /// <summary>
        /// This is a setting for the command line
        /// parameter. This setting determines if 
        /// this command is required or not. However,
        /// This setting doesn't enforce this. The 
        /// enforcement is likely elsewhere in your
        /// code. This is just a representation of
        /// the fact that somewhere in your code, 
        /// this parameter is required. 
        /// 
        /// This value is seen when a user runs the
        /// exe with a /?.
        /// </summary>
        public bool IsRequired { get; set; }

        /// <summary>
        /// A list of allowed values. If this is empty,
        /// any value is allowed.
        /// For example, if true or false is expected, 
        /// the allowed values might be: 
        ///     true, false
        /// Any other value is ignored and the default 
        /// value, is used.
        /// </summary>
        public List<string> AllowedValues
        {
            get { return _AllowedValues ?? (_AllowedValues = new List<string>()); }
            set { _AllowedValues = value; }
        } private List<string> _AllowedValues;

        /// <summary>
        /// A regular expresion defining the pattern of
        /// the  of allowed values. If this is empty,
        /// any value is allowed.
        /// For example, if a single digit is expected, 
        /// the aPattern might be: 
        ///     [0-9]
        /// If multiple digits are expected:
        ///     [0-9]+
        /// Any other value is ignored and the default 
        /// value, is used.
        /// </summary>
        public string Pattern { get; set; }

        /// <summary>
        /// An action to take when setting this parameter
        /// </summary>
        public Action<string> Action { get; set; }
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