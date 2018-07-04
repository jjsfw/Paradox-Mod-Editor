using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Paradox_Mod_Editor.Models
{
    public class ScriptValue<T> : IScriptContainer
    {
        public T Value;
        public string ScriptText { get; }

        public ScriptValue(string text)
        {
            this.ScriptText = text;
        }

        public ScriptValue(T value, string text)
        {
            this.Value = value;
            this.ScriptText = text;
        }

        public virtual string WriteScript()
        {
            return ScriptText + " = " + Value;
        }

        public dynamic GetValue()
        {
            return Value;
        }

        public virtual void SetValue(object newValue)
        {
            try
            {
                Value = (T)newValue;
            }
            catch (InvalidCastException)
            {
                throw new ArgumentException(String.Format("cannot store a {0} in a ScriptValue for {1}", newValue.GetType().ToString(), typeof(T).ToString()));
            }
        }
    }
}
