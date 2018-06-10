﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paradox_Mod_Editor.Models
{
    class ScriptValue<T>
    {
        public T Value { get; set; }
        public string ScriptText { get; }

        public ScriptValue(T value, string text)
        {
            this.Value = value;
            this.ScriptText = text;
        }

        public virtual string WriteScript()
        {
            return ScriptText + " = " + Value;
        }
    }
}
