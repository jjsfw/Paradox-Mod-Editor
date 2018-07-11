using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Paradox_Mod_Editor.Models.CrusaderKings;

namespace Paradox_Mod_Editor.Models.CrusaderKings
{
    // Revised based on solution by NightOwl888
    // https://stackoverflow.com/questions/31950362/factory-method-with-di-and-ioc

    public class ReligionScriptFactory : IScriptFactory
    {
        // Use constructor to assign params of created Religions

        public ScriptObject GetScriptObject(string name)
        {
            return new Religion(name);
        }

        public bool AppliesTo(Type type)
        {
            return typeof(Religion).Equals(type);
        }
    }
}
