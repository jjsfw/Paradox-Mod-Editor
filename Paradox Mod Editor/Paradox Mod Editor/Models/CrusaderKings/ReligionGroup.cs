using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Drawing;

namespace Paradox_Mod_Editor.Models.CrusaderKings
{
    class ReligionGroup : ScriptObject
    {
        [Category("*General"), Description("The name of the religion group as it appears in script."), DisplayName("Name")]
        public string Name { get; set; }
        [Category("*General"), Description("Defines whether characters of this religion are playable."), DisplayName("Playable")]
        public PBool Playable { get; set; }
        [Category("Graphical"), Description("The color used for the coalitions -per religion group- map mode."), DisplayName("Color")]
        public Color Color { get; set; }
        [Category("Graphical"), Description("Only used for the display of CoA frames on the map."), DisplayName("Graphical Culture")]
        public string GraphicalCulture { get; set; }
        [Category("Graphical"), Description("This line determines whether or not the religion will utilise random graphics for their COAs above barony level:\nhas_coa_on_barony_only = yes: Generate random CoA for baronies, but use gfx / flags / for higher tiers.\nhas_coa_on_barony_only = no: Generate random CoA for all tiers, and ignore completely gfx / flags /.\nNote that this only works on religion group, and cannot be overriden for a specific religion."), DisplayName("CoA on Barony Only")]
        public PBool HasCoaOnBaronyOnly { get; set; }
        [Category("AI"), Description("Will make Hordes lose their super aggressiveness, upon conversion to this religion group."), DisplayName("Peaceful")]
        public PBool Peaceful { get; set; }
        [Category("AI"), Description("Determines whether or not the AI will fabricate claims."), DisplayName("Fabricate Claims")]
        public PBool FabricateClaims { get; set; }
        [Category("War"), Description("Decides if holy orders will fight other religions within the same group, also blocks interfaith marriage within group."), DisplayName("Hostile Within Group")]
        public PBool HostileWithinGroup { get; set; }
        [Category("War"), Description("Defines whether a religion group can have crusades/jihads."), DisplayName("Crusade CB")]
        public string CrusadeCasusBelli { get; set; }
    }
}
