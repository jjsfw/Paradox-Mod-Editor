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

    public class ReligionGroupScriptFactory : IScriptFactory
    {
        // Use constructor to assign params of created Religions

        public IScriptObject GetScriptObject()
        {
            return new ReligionGroup();
        }

        public bool AppliesTo(Type type)
        {
            return typeof(ReligionGroup).Equals(type);
        }
    }
}
