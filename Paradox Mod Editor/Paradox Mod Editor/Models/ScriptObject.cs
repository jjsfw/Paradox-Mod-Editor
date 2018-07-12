using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Paradox_Mod_Editor.Models
{
    public abstract class ScriptObject
    {
        public string Name { get; }
        public Dictionary<Type, Type> ScriptChildren { get; set; } = new Dictionary<Type, Type>(); // maps ScriptObjects to their possible children e.g. ReligionGroup -> Religion

        public ScriptObject(string name)
        {
            this.Name = name;
        }

        public PropertyInfo[] GetScriptProperties()
        {
            PropertyInfo[] properties = this.GetType().GetProperties().Where(
                prop => Attribute.IsDefined(prop, typeof(ScriptValueAttribute))).ToArray();

            return properties;
        }

        public override string ToString()
        {
            return Name;
        }

        public virtual Type GetChildType()
        {
            if (ScriptChildren.ContainsKey(this.GetType()))
            {
                return ScriptChildren[this.GetType()];
            }
            return null;
        }
    }
}
