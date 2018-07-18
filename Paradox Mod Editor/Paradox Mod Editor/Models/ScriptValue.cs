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

        public virtual void SetValue(T newValue)
        {
            Value = newValue;
        }

        private T ParseValue(object newValue)
        {


            throw new InvalidCastException(string.Format("cannot store {0} {1} in {2} for {3}", newValue.GetType(), newValue, typeof(T), ScriptText));
        }

        public virtual void SetValue(object newValue)
        {
            if (typeof(T) == newValue.GetType())
            {
                Value = (T)newValue;
            }
            else
            {
                Value = ParseValue(newValue);
            }
            TypeConverter converter = TypeDescriptor.GetConverter(newValue.GetType());
            Value = (T)converter.ConvertTo(newValue, typeof(T));
            //try
            //{
            //    Value = (T)newValue;
            //}
            //catch (InvalidCastException)
            //{
            //    throw new InvalidCastException(string.Format("cannot store {0} {1} in {2} for {3}", newValue.GetType(), newValue, typeof(T), ScriptText));
            //}
            ////
            //try
            //{
            //    Value = (T)newValue;
            //}
            //catch (InvalidCastException)
            //{
            //    if (typeof(string) == newValue.GetType())
            //    {
            //        string stringValue = newValue.ToString();
            //        if (int.TryParse(stringValue, out int ignoreInt))
            //        {
            //            SetValue(int.Parse(newValue.ToString()));
            //        }
            //        else if (decimal.TryParse(stringValue, out decimal ignoreDouble))
            //        {
            //            SetValue(decimal.Parse(newValue.ToString()));
            //        }
            //    }
            //    else
            //    {
            //        throw new ArgumentException(String.Format("cannot store a {0} in a ScriptValue for {1}", newValue.GetType().ToString(), typeof(T).ToString()));
            //    }
            //}
        }
    }
}
