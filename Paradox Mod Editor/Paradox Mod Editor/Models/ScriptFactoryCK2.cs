using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Paradox_Mod_Editor.Models.CrusaderKings;

namespace Paradox_Mod_Editor.Models
{
    public sealed class ScriptFactoryCK2 : ScriptFactory
    {
        static readonly ScriptFactoryCK2 factory = new ScriptFactoryCK2();

        public override IScriptObject GetScriptObject(string scriptObject)
        {
            switch (scriptObject)
            {
                case "Religion":
                    return new Religion();
                case "ReligionGroup":
                    return new ReligionGroup();
                case "CommentBlock":
                    return new CommentBlock();
                default:
                    throw new ApplicationException(string.Format("'{0}' is not a valid script object!", scriptObject));
            }
        }

        public new static ScriptFactory GetFactory()
        {
            return factory;
        }
    }
}
