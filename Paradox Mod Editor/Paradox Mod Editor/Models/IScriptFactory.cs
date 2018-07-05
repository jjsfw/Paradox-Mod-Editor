﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paradox_Mod_Editor.Models
{
    public interface IScriptFactory
    {
        IScriptObject GetScriptObject();
        bool AppliesTo(Type type);
    }
}