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
            if (scriptFactories == null)
            {
                throw new ArgumentNullException("scriptFactories");
            }
            this.scriptFactories = scriptFactories;
        }

        public IScriptObject GetScriptObject(Type type)
        {
            IScriptFactory scriptFactory = scriptFactories.FirstOrDefault(factory => factory.AppliesTo(type));

            if (scriptFactory == null)
            {
                throw new Exception("type not registered");
            }

            return scriptFactory.GetScriptObject();
        }
    }
}
