using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Paradox_Mod_Editor.ParadoxSyntax;

namespace Paradox_Mod_Editor.Models
{
    public class ScriptPBool : ScriptValue<PBool>
    {
        public ScriptPBool(string text) : base(PBool.Default, text) { }

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

        public override void SetValue(object newValue)
        {
            // TODO: see if this type can be folded directly into ScriptValue w/ TypeConverter/EnumConverter/etc
            if (newValue.GetType() == typeof(PBool))
            {
                Value = (PBool)newValue;
                return;
            }
            switch (newValue.ToString().ToLower())
            {
                case "yes":
                    Value = PBool.yes;
                    break;
                case "no":
                    Value = PBool.no;
                    break;
                default:
                    throw new ArgumentException(String.Format("cannot store a {0} in a ScriptValue for PBools", newValue.GetType().ToString()));
            }
        }
    }
}
