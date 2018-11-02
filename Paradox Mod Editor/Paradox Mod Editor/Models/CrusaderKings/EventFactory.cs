using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paradox_Mod_Editor.Models.CrusaderKings
{
    class EventFactory : IScriptFactory
    {
        public ScriptObject GetScriptObject(string name)
        {
            return new Event(name);
        }

        public bool AppliesTo(Type type)
        {
            return typeof(Event).Equals(type);
        }
    }
}
