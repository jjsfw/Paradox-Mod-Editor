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
        public virtual string NameValue { get; set; }
        protected static Dictionary<Type, Type> scriptChildren = new Dictionary<Type, Type>(); // maps ScriptObjects to their possible children e.g. ReligionGroup -> Religion
        protected static Dictionary<Type, string[]> excludedStrings = new Dictionary<Type, string[]>();
        public List<ScriptObject> Children { get; set; } = new List<ScriptObject>();
        public string RawText { get => rawText; set => rawText = value; }
        // whether to write this object as-is or replace %%name%% with its RawText when writing
        public bool ReplaceWrite { get => replaceWrite; set => replaceWrite = value; }
        private bool replaceWrite;

        private string rawText = "";

        public ScriptObject(string name)
        {
            NameValue = name;
            replaceWrite = false;
        }

        public ScriptObject(string name, bool replace)
        {
            NameValue = name;
            replaceWrite = replace;
        }

        public PropertyInfo[] GetScriptProperties()
        {
            PropertyInfo[] properties = this.GetType().GetProperties().Where(
                prop => Attribute.IsDefined(prop, typeof(ScriptValueAttribute))).ToArray();

            return properties;
        }

        public override string ToString()
        {
            return NameValue;
        }

        protected void RegisterNewScriptType(Type childType, string[] scriptExcludedStrings)
        {
            Type myType = this.GetType();
            if (!scriptChildren.ContainsKey(myType))
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
