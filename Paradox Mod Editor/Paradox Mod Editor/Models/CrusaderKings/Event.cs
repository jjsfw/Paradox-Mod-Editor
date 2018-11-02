using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Paradox_Mod_Editor.ParadoxSyntax;

namespace Paradox_Mod_Editor.Models.CrusaderKings
{
    public class Event : ScriptObject
    {
        [Category("*General"), DisplayName("ID")]
        [Description("The unique ID of this event.")]
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
        public ScriptValue<string> Name { get; } = new ScriptValue<string>("id");

        [Category("*General"), DisplayName("Description")]
        [Description("The description of this event as shown in its pop-up.")]
        public string DescValue
        {
            get { return Desc.Value; }
            set
            {
                Desc.Value = value;
            }
        }
        [Browsable(false)]
        [ScriptValue(true)]
        public ScriptValue<string> Desc { get; } = new ScriptValue<string>("desc");

        [Category("*General"), DisplayName("Picture")]
        [Description("The id of the picture shown in this event's pop-up.")]
        public string PictureValue
        {
            get { return Picture.Value; }
            set
            {
                Picture.Value = value;
            }
        }
        [Browsable(false)]
        [ScriptValue(true)]
        public ScriptValue<string> Picture { get; } = new ScriptValue<string>("picture");

        public Event(string name) : base(name) { }

        public Event(string space, int id) : base(space + id.ToString()) { }
        public Event(string space, string id) : base(space + id) { }
    }
}
