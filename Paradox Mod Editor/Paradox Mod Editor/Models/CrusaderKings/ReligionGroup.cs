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
    class ReligionGroup : IScriptObject
    {
        [Browsable(false)]
        public List<String> ExcludedStrings { get; } = new List<string>(new string[] { "secret_religion_visibility_trigger" });
        [Category("*General"), DisplayName("Name")]
        [Description("The name of the religion group as it appears in script.")]
        public string Name { get; set; }
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
        private ScriptPBool Playable = new ScriptPBool("playable");
        [Category("Graphical"), DisplayName("Color")]
        [Description("The color used for the coalitions -per religion group- map mode.")]
        public Color ColorValue
        {
            get { return Color.Value; }
            set
            {
                Color.Value = value;
            }
        }
        [Browsable(false)]
        private ScriptValue<Color> Color = new ScriptValue<Color>("color");
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
        private ScriptValue<string> GraphicalCulture = new ScriptValue<string>("graphical_culture");
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
        private ScriptPBool HasCoaOnBaronyOnly = new ScriptPBool("has_coa_on_barony_only");
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
        private ScriptPBool Peaceful = new ScriptPBool("ai_peaceful");
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
        private ScriptPBool FabricateClaims = new ScriptPBool("ai_fabricate_claims");
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
        private ScriptPBool HostileWithinGroup = new ScriptPBool("hostile_within_group");
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
        private ScriptValue<string> CrusadeCasusBelli = new ScriptValue<string>("crusade_cb");
        [Browsable(false)]
        private List<Religion> religions = new List<Religion>();
    }
}
