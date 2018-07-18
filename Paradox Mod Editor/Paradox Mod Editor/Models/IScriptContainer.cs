using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paradox_Mod_Editor.Models
{
    interface IScriptContainer
    {
        // TODO: is this interface really needed?
        string ScriptText { get; }
        dynamic GetValue();
        void SetValue(object newValue);
        // SetValue w/ T input - not possible in interface
    }
}
