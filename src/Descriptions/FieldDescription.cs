using System.Diagnostics;

namespace roslyn_uml
{
    [DebuggerDisplay("Field {Type} {Name}")]
    public class FieldDescription : MemberDescription
    {
        public string Type { get; }
        public bool HasInitializer => this.Initializer != null;
        public string Initializer { get; internal set; }

        public FieldDescription(string type, string name)
            : base(MemberType.Field, name)
        {
            this.Type = type;
        }
    }
}