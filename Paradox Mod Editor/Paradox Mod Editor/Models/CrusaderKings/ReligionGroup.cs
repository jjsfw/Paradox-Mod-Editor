using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Drawing;
using Paradox_Mod_Editor.ParadoxSyntax;

namespace Paradox_Mod_Editor.Models.CrusaderKings
{
    public class ReligionGroup : ScriptObject
    {
        [Category("*General"), DisplayName("Name")]
        [Description("The name of the religion group as it appears in script.")]
        [ScriptValue(true)]
        public string Name { get; set; } = "new_religion_group";
        [Category("*General"), DisplayName("Playable")]
        [Description("Defines whether characters of this religion are playable.")]
        public PBool PlayableValue
        {
            get { return Playable.Value; }
            set
            {
                Playable.Value = value;
            }
        }
        [Browsable(false)]
        [ScriptValue(true)]
        public ScriptPBool Playable { get; } = new ScriptPBool("playable");
        [Category("Graphical"), DisplayName("Color")]
        [Description("The color used for the coalitions -per religion group- map mode.")]
        public string ColorValue
        {
            get { return Color.Value; }
            set
            {
                Color.Value = value;
            }
        }
        [Browsable(false)]
		[ScriptValue(true)]
        public ScriptValue<string> Color { get; } = new ScriptValue<string>("color");
        [Category("Graphical"), DisplayName("Graphical Culture")]
        [Description("Only used for the display of CoA frames on the map.")]
        public string GraphicalCultureValue
		{
			get { return GraphicalCulture.Value; }
			set
			{
                GraphicalCulture.Value = value;
			}
		}
        [Browsable(false)]
		[ScriptValue(true)]
        public ScriptValue<string> GraphicalCulture { get; } = new ScriptValue<string>("graphical_culture");
        [Category("Graphical"), DisplayName("CoA on Barony Only")]
        [Description("This line determines whether or not the religion will utilise random graphics for their COAs above barony level:\nhas_coa_on_barony_only = yes: Generate random CoA for baronies, but use gfx / flags / for higher tiers.\nhas_coa_on_barony_only = no: Generate random CoA for all tiers, and ignore completely gfx / flags /.\nNote that this only works on religion group, and cannot be overriden for a specific religion.")]
        public PBool HasCoaOnBaronyOnlyValue
		{
			get { return HasCoaOnBaronyOnly.Value; }
			set
			{
                HasCoaOnBaronyOnly.Value = value;
			}
		}
        [Browsable(false)]
		[ScriptValue(true)]
        public ScriptPBool HasCoaOnBaronyOnly { get; } = new ScriptPBool("has_coa_on_barony_only");
        [Category("AI"), DisplayName("Peaceful")]
        [Description("Will make Hordes lose their super aggressiveness, upon conversion to this religion group.")]
        public PBool PeacefulValue
		{
			get { return Peaceful.Value; }
			set
			{
                Peaceful.Value = value;
			}
		}
        [Browsable(false)]
		[ScriptValue(true)]
        public ScriptPBool Peaceful { get; } = new ScriptPBool("ai_peaceful");
        [Category("AI"), DisplayName("Fabricate Claims")]
        [Description("Determines whether or not the AI will fabricate claims.")]
        public PBool FabricateClaimsValue
		{
			get { return FabricateClaims.Value; }
			set
			{
                FabricateClaims.Value = value;
			}
		}
        [Browsable(false)]
		[ScriptValue(true)]
        public ScriptPBool FabricateClaims { get; } = new ScriptPBool("ai_fabricate_claims");
        [Category("War"), DisplayName("Hostile Within Group")]
        [Description("Decides if holy orders will fight other religions within the same group, also blocks interfaith marriage within group.")]
        public PBool HostileWithinGroupValue
		{
			get { return HostileWithinGroup.Value; }
			set
			{
                HostileWithinGroup.Value = value;
			}
		}
        [Browsable(false)]
		[ScriptValue(true)]
        public ScriptPBool HostileWithinGroup { get; } = new ScriptPBool("hostile_within_group");
        [Category("War"), DisplayName("Crusade CB")]
        [Description("Defines whether a religion group can have crusades/jihads.")]
        public string CrusadeCasusBelliValue
		{
			get { return CrusadeCasusBelli.Value; }
			set
			{
                CrusadeCasusBelli.Value = value;
			}
		}
        [Browsable(false)]
		[ScriptValue(true)]
        public ScriptValue<string> CrusadeCasusBelli { get; } = new ScriptValue<string>("crusade_cb");
        [Browsable(false)]
		[ScriptValue(true)]
        public List<Religion> religions = new List<Religion>();

        public ReligionGroup(string name) : base(name) { }
    }
}
