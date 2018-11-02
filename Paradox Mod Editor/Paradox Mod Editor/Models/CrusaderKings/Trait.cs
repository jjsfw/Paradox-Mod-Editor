using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Paradox_Mod_Editor.ParadoxSyntax;

namespace Paradox_Mod_Editor.Models.CrusaderKings
{
    class Trait : ScriptObject
    {
        [Category("*General"), DisplayName("Name")]
        [Description("The name of the trait as it appears in script".)]
        public override string NameValue
        {
            get { return Name.Value; }
            set
            {
                Name.Value = value;
            }
        }
        [Browsable(false)]
        [ScriptValue(true)]
        public ScriptValue<string> Name { get; } = new ScriptValue<string>("%ls");
        [Category("Inheritance"), DisplayName("Agnatic")]
        [Description("Children of a father with this trait will always inherit the trait")]
        public bool AgnaticValue
        {
            get
        }
        [Browsable(false)]
        [ScriptValue(true)]
        public 
    }
}
