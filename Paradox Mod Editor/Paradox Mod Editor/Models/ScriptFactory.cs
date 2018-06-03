using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paradox_Mod_Editor.Models
{
    public abstract class ScriptFactory
    {
        public abstract IScriptObject GetScriptObject(string scriptObject);

        public static ScriptFactory GetFactory()
        {
            throw new NotImplementedException();
        }
    }
}
