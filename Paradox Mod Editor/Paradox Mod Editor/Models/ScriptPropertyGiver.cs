using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Paradox_Mod_Editor.Models.CrusaderKings;

namespace Paradox_Mod_Editor.Models
{
    abstract class ScriptPropertyGiver
    {
        public PropertyInfo[] GetScriptProperties()
        {
            int i = 1;
            PropertyInfo[] properties = this.GetType().GetProperties().Where(
                prop => Attribute.IsDefined(prop, typeof(ScriptValueAttribute))).ToArray();

            return properties;
        }
    }
}
