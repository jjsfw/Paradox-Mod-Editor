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
        protected static Dictionary<Type, Type> scriptChildren = new Dictionary<Type, Type>(); // maps ScriptObjects to their possible children e.g. ReligionGroup -> Religion
        protected static Dictionary<Type, string[]> excludedStrings = new Dictionary<Type, string[]>();

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

        protected void RegisterNewScriptType(Type childType, string[] scriptExcludedStrings)
        {
            Type myType = this.GetType();
            if (scriptChildren.ContainsKey(myType))
            {
                scriptChildren.Add(myType, childType);
                excludedStrings.Add(myType, scriptExcludedStrings);
            }
        }

        public Type GetChildType()
        {
            if (scriptChildren.ContainsKey(this.GetType()))
            {
                return scriptChildren[this.GetType()];
            }
            return null;
        }

        public string[] GetExcludedStrings()
        {
            if (excludedStrings.ContainsKey(this.GetType()))
            {
                return excludedStrings[this.GetType()];
            }
            return null;
        }
    }
}
