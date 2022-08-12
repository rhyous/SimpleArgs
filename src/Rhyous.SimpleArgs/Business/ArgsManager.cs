namespace Rhyous.SimpleArgs
{
    public class ArgsManager<T> : IArgsManager
        where T: IArgumentsHandler, new()
    {
        private string _ArgsListName;

        #region Constructors
        public ArgsManager() { Init(new T()); }

        public ArgsManager(IArgumentsHandler argsHandler, string argsListName = null) { Init(argsHandler, argsListName); }        

        public ArgsManager(string argsListName) { Init(new T(), argsListName); }

        public ArgsManager(IReadArgs argsReader, ArgumentList argsList, ArgsHandlerList argsHandlerList)
        {
            _ArgsReader = argsReader;
            _ArgsList = argsList;
            _ArgsListName = ArgsList.Name;
            ArgsHandlerList = argsHandlerList;
            Init(new T());
        }
        #endregion

        internal void Init(IArgumentsHandler argsHandler = null, string argsListName = null)
        {
            _ArgsListName = argsListName;
            argsHandler.InitializeArguments(this);
            ArgsHandlerList.Add(argsHandler);
        }
        public IReadArgs ArgsReader
        {
            get { return _ArgsReader ?? (_ArgsReader = new ArgsReader(ArgsHandlerList, ArgsList.Message)); }
            set { _ArgsReader = value; }
        } private IReadArgs _ArgsReader;

        public IArgsHandlerList ArgsHandlerList
        {
            get { return _ArgsHanderList ?? (_ArgsHanderList = new ArgsHandlerList(ArgsList.Args)); }
            internal set { _ArgsHanderList = value; }
        } private IArgsHandlerList _ArgsHanderList;

        public ArgumentList ArgsList
        {
            get { return _ArgsList ?? (_ArgsList = new ArgumentList(_ArgsListName)); }
            set { _ArgsList = value; }
        } private ArgumentList _ArgsList;


        public void Start(string[] args)
        {;
            ArgsReader.ParseArgs(args);
            ArgsHandlerList.HandleArgs(ArgsReader);
        }
        public void Start(string[] args, ArgsReader argsReader = null)
        {
            if (argsReader != null)
                _ArgsReader = argsReader;
            ArgsReader.ParseArgs(args);
            ArgsHandlerList.HandleArgs(ArgsReader);
        }

        public void Start(IArgumentsHandler handler, string[] args, ArgsReader argsReader = null)
        {
            ArgsHandlerList.Add(handler);
            Start(args, argsReader);
        }

        public void Start(IArgsHandlerList handlers, string[] args, ArgsReader argsReader = null)
        {
            ArgsHandlerList.AddRange(handlers);
            Start(args, argsReader);
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