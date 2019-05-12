﻿using System.Collections.Generic;
using System.Diagnostics;

namespace roslyn_uml
{
    [DebuggerDisplay("Constructor {Name}")]
    public class ConstructorDescription : MemberDescription, IHaveAMethodBody
    {
        public List<ParameterDescription> Parameters { get; } = new List<ParameterDescription>();
        public List<InvocationDescription> InvokedMethods { get; } = new List<InvocationDescription>();

        public ConstructorDescription(string name)
            : base(MemberType.Constructor, name)
        {
        }
    }
}