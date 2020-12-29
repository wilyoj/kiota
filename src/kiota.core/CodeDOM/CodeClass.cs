﻿using System.Linq;

namespace kiota.core
{
    /// <summary>
    /// CodeClass represents an instance of a Class to be generated in source code
    /// </summary>
    public class CodeClass : CodeBlock
    {
        private string name;

        public CodeClass()
        {
            StartBlock = new Declaration();
            EndBlock = new End();
        }

        /// <summary>
        /// Name of Class
        /// </summary>
        public override string Name
        {
            get => name;
            set
            {
                name = value;
                StartBlock = new Declaration() { Name = name };
            }
        }

        public void SetIndexer(CodeIndexer indexer)
        {
            this.InnerChildElements.Add(indexer);
        }

        public void AddProperty(CodeProperty property)
        {
            this.InnerChildElements.Add(property);
        }

        public bool ContainsMember(string name)
        {
            return this.InnerChildElements.Any(e => e.Name == name);
        }

        public void AddMethod(CodeMethod method)
        {
            this.InnerChildElements.Add(method);
        }

        public void AddInnerClass(CodeClass codeClass)
        {
            this.InnerChildElements.Add(codeClass);
        }

        public class Declaration : CodeTerminal
        {
            /// <summary>
            /// Class name
            /// </summary>
            public override string Name
            {
                get; set;
            }

            public CodeType Type;
        }

        public class End : CodeTerminal
        {
        }
    }
}