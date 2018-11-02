using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Paradox_Mod_Editor.ParadoxSyntax;

namespace Paradox_Mod_Editor.Models.CrusaderKings
{
    class CommandBlock : ScriptObject
    {
        // Raw command blocks should never be shown in the properties window
        [Category("*General"), DisplayName("ID")]
        [Description("This block's identifier.")]
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

        public string commands = "";

        public CommandBlock(string name) : base(name) { }
    }
}
