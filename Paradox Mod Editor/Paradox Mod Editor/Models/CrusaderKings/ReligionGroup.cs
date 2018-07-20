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
        //public override string Name { get; set; } = "new_religion_group";
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
        [Category("AI"), DisplayName("Convert Same Group")]
        [Description("Determines if AI sends court chaplain to proselytize on religions of same religious group:0: never try to convert 1: try to convert if ai_zeal is high 2: always try to convert.")]
        public ConvertReligion ConvertSameGroupValue
        {
            get { return ConvertSameGroup.Value; }
            set
            {
                ConvertSameGroup.Value = value;
            }
        }
        [Browsable(false)]
        [ScriptValue(true)]
        public ScriptValue<ConvertReligion> ConvertSameGroup { get; } = new ScriptValue<ConvertReligion>("ai_convert_same_group");
        [Category("AI"), DisplayName("Convert Other Group")]
        [Description("Determines if AI sends court chaplain to proselytize on religions of other religious groups:0: never try to convert 1: try to convert if ai_zeal is high 2: always try to convert")]
        public ConvertReligion ConvertOtherGroupValue
        {
            get { return ConvertOtherGroup.Value; }
            set
            {
                ConvertOtherGroup.Value = value;
            }
        }
        [Browsable(false)]
        [ScriptValue(true)]
        public ScriptValue<ConvertReligion> ConvertOtherGroup { get; } = new ScriptValue<ConvertReligion>("ai_convert_other_group");
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
        [Category("Names"), DisplayName("Male Names")]
        [Description("Names given to male followers of this religion group.")]
        public List<string> MaleNamesValue
        {
            get { return MaleNames.Value; }
            set
            {
                MaleNames.Value = value;
            }
        }
        [Browsable(false)]
        [ScriptValue(true)]
        public ScriptValue<List<string>> MaleNames { get; } = new ScriptValue<List<string>>("male_names");
        [Category("Names"), DisplayName("Female Names")]
        [Description("Names given to female followers of this religion group.")]
        public List<string> FemaleNamesValue
        {
            get { return FemaleNames.Value; }
            set
            {
                FemaleNames.Value = value;
            }
        }
        [Browsable(false)]
        [ScriptValue(true)]
        public ScriptValue<List<string>> FemaleNames { get; } = new ScriptValue<List<string>>("female_names");

        public ReligionGroup(string name) : base(name)
        {
            RegisterNewScriptType(typeof(Religion), new[] { "color" });
        }
    }
}
