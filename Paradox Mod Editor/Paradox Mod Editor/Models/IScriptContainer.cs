﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paradox_Mod_Editor.Models
{
    interface IScriptContainer
    {
        string ScriptText { get; }
        dynamic GetValue();
        void SetValue(object newValue);
    }
}