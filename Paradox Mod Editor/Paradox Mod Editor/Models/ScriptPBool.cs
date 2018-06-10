using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Paradox_Mod_Editor.ParadoxSyntax;

namespace Paradox_Mod_Editor.Models
{
    class ScriptPBool : ScriptValue<PBool>
    {
        public ScriptPBool(PBool value, string text) : base(value, text) { }

        public override string WriteScript()
        {
            if ((PBool)Value != PBool.Default)
            {
                return base.WriteScript();
            }
            else
            {
                return null;
            }
        }
    }
}
