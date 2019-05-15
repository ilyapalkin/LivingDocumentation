﻿using System.Diagnostics;

namespace roslyn_uml
{
    [DebuggerDisplay("AttributeArgument {Name} {Type} {Value}")]
    public class AttributeArgumentDescription
    {
        public string Name { get; }
        public string Type { get; }
        public string Value { get; }

        public AttributeArgumentDescription(string name, string type, string value)
        {
            this.Name = name;
            this.Type = type;
            this.Value = value;
        }
    }
}
