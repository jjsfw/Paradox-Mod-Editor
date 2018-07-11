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
        string Name { get; }

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
    }
}
