using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paradox_Mod_Editor.Models.CrusaderKings
{
    class CrusaderKingsStrategy : IScriptStrategy
    {
        private readonly IScriptFactory[] scriptFactories;

        public CrusaderKingsStrategy(IScriptFactory[] scriptFactories)
        {
            this.scriptFactories = scriptFactories ?? throw new ArgumentNullException("scriptFactories");
        }

        public IScriptObject GetScriptObject(Type type)
        {
            IScriptFactory scriptFactory = scriptFactories.FirstOrDefault(factory => factory.AppliesTo(type));

            return scriptFactory.GetScriptObject() ?? throw new Exception(String.Format("type {0} has no factory", type));
        }
    }
}
