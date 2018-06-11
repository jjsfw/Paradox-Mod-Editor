using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using Paradox_Mod_Editor.ParadoxSyntax;

namespace Paradox_Mod_Editor.Models.CrusaderKings
{
    class Religion : IScriptObject
    {
        // TODO: update types (modifiers, graphical cultures (?), etc)
        // TODO: finish descriptions, display names
        // TODO: custom script property class containing raw data, script as it appears in file (?)
        [Category("*General"), DisplayName("Name"), DefaultValue("new_religion")]
        [Description("The name of the religion as it appears in script.")]
        public string Name { get; set; }
        [Category("*General"), DisplayName("Parent Religion")]
        [Description("Makes the religion a heresy of its parent religion. The parent religion must be defined before. Note: reformed pagans can have heresies, but they need to be defined after both reformed and unreformed religions.")]
        public string ParentValue
        {
            get { return Parent.Value; }
            set
            {
                Parent.Value = value;
            }
        }
        [Browsable(false)]
        public ScriptValue<string> Parent { get; set; } = new ScriptValue<string>("parent");
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
        public ScriptValue<string> GraphicalCulture = new ScriptValue<string>("graphical_culture");
        [Category("Graphical"), DisplayName("Icon")]
        [Description("Defines which icon will be used for the religion in-game. The value is ignored for heresies (unless the heresy becomes mainstream religion), and the heresy_icon of the parent religion will be used instead.")]
        public int IconValue
		{
			get { return Icon.Value; }
			set
			{
                Icon.Value = value;
			}
		}
        [Browsable(false)]
        public ScriptValue<int> Icon = new ScriptValue<int>("icon");
        [Category("Graphical"), DisplayName("Colour")]
        [Description("The color used when drawing the religion map mode.\nRGB format with a range of 0.0–1.0.To determine a value from the RGB, simply divide by 255, e.g. 180 ÷ 255 = 0.7")]
        public Color ColorValue
		{
			get { return Color.Value; }
			set
			{
                Color.Value = value;
			}
		}
        [Browsable(false)]
        public ScriptValue<Color> Color = new ScriptValue<Color>("color");
        [Category("Graphical"), DisplayName("Heresy Icon")]
        [Description("Heresy icon. Note that this has to be set in the parent religion, not at heresy level.")]
        public int HeresyIconValue
		{
			get { return HeresyIcon.Value; }
			set
			{
                HeresyIcon.Value = value;
			}
		}
        [Browsable(false)]
        public ScriptValue<int> HeresyIcon = new ScriptValue<int>("heresy_icon");
        [Category("Graphical"), DisplayName("Secondary Event Pictures")]
        [Description("Undocumented")]
        public string SecondaryEventPicturesValue
		{
			get { return SecondaryEventPictures.Value; }
			set
			{
                SecondaryEventPictures.Value = value;
			}
		}
        [Browsable(false)]
        public ScriptValue<string> SecondaryEventPictures = new ScriptValue<string>("secondary_event_pictures");
        [Category("Names"), DisplayName("Crusade Name")]
        [Description("Defines a localization key for the name of the religion's crusade. Only applicable to religion group groups with crusade_cb = crusade defined.")]
        public string CrusadeNameValue
		{
			get { return CrusadeName.Value; }
			set
			{
                CrusadeName.Value = value;
			}
		}
        [Browsable(false)]
        public ScriptValue<string> CrusadeName = new ScriptValue<string>("crusade_name");
        [Category("Names"), DisplayName("Scripture Name")]
        [Description("Defines a localization key for the religion's holy text.")]
        public string ScriptureNameValue
		{
			get { return ScriptureName.Value; }
			set
			{
                ScriptureName.Value = value;
			}
		}
        [Browsable(false)]
        public ScriptValue<string> ScriptureName = new ScriptValue<string>("scripture_name");
        [Category("Names"), DisplayName("High God Name")]
        [Description("Localization key for high god.")]
        public string HighGodNameValue
        {
			get { return HighGodName.Value; }
			set
			{
                HighGodName.Value = value;
			}
		}
        [Browsable(false)]
        public ScriptValue<string> HighGodName = new ScriptValue<string>("high_god_name");
        [Category("Names"), DisplayName("God Names")]
		[Description("Defines localization keys for the religion's deity or deities, within curly brackets and separated by spaces.")]
        public List<string> GodNamesValue
		{
			get { return GodNames.Value; }
			set
			{
                GodNames.Value = value;
			}
		}
        [Browsable(false)]
        public ScriptValue<List<string>> GodNames = new ScriptValue<List<string>>("god_names");
        [Category("Names"), DisplayName("Evil God Names")]
		[Description("Defines localization keys for the religion's evil deity or deities, within curly brackets and separated by spaces.")]
        public List<string> EvilGodNamesValue
        {
			get { return EvilGodNames.Value; }
			set
			{
                EvilGodNames.Value = value;
			}
		}
        [Browsable(false)]
        public ScriptValue<List<string>> EvilGodNames = new ScriptValue<List<string>>("evil_god_names");
        [Category("Names"), DisplayName("")]
		[Description("")]
        public string PietyNameValue
        {
			get { return PietyName.Value; }
			set
			{
                PietyName.Value = value;
			}
		}
        [Browsable(false)]
        public ScriptValue<string> PietyName = new ScriptValue<string>("piety_name");
        [Category("Names"), DisplayName("Priest Title")]
		[Description("Defines localization key for temple holders")]
        public string PriestTitleValue
        {
			get { return PriestTitle.Value; }
			set
			{
                PriestTitle.Value = value;
			}
		}
        [Browsable(false)]
        public ScriptValue<string> PriestTitle = new ScriptValue<string>("priest_title");
        [Category("Marriage"), DisplayName("Brother-Sister Marriage")]
		[Description("Allows brother-sister marriages.")]
        public PBool BrotherSisterMarriageValue
		{
			get { return BrotherSisterMarriage.Value; }
			set
			{
                BrotherSisterMarriage.Value = value;
			}
		}
        [Browsable(false)]
        public ScriptPBool BrotherSisterMarriage = new ScriptPBool("bs_marriage");
        [Category("Marriage"), DisplayName("Parent-Child Marriages")]
		[Description("Allows parent-child marriages.")]
        public PBool ParentChildMarriageValue
        {
			get { return ParentChildMarriage.Value; }
			set
			{
                ParentChildMarriage.Value = value;
			}
		}
        [Browsable(false)]
        public ScriptPBool ParentChildMarriage = new ScriptPBool("pc_marriage");
        [Category("Marriage"), DisplayName("Nibling Marriages")]
		[Description("Disallow uncle-niece and aunt-nephew marriages.")]
        public PBool NiblingMarriageValue
        {
			get { return NiblingMarriage.Value; }
			set
			{
                NiblingMarriage.Value = value;
			}
		}
        [Browsable(false)]
        public ScriptPBool NiblingMarriage = new ScriptPBool("psc_marriage");
        [Category("Marriage"), DisplayName("Cousin Marriages")]
		[Description("Disallow cousin marriages.")]
        public PBool CousinMarriageValue
        {
			get { return CousinMarriage.Value; }
			set
			{
                CousinMarriage.Value = value;
			}
		}
        [Browsable(false)]
        public ScriptPBool CousinMarriage = new ScriptPBool("cousin_marriage");
        [Category("Marriage"), DisplayName("Matrilineal Marriages.")]
		[Description("Disallow matrilineal marriages.")]
        public PBool MatrilinealMarriageValue
        {
			get { return MatrilinealMarriage.Value; }
			set
			{
                MatrilinealMarriage.Value = value;
			}
		}
        [Browsable(false)]
        public ScriptPBool MatrilinealMarriage = new ScriptPBool("matrilineal_marriages");
        [Category("Marriage"), DisplayName("Intermarry")]
		[Description("Specifies if members tend to marry those of specific other religions/religion group.")]
        public List<string> IntermarryValue
        {
			get { return Intermarry.Value; }
			set
			{
                Intermarry.Value = value;
			}
		}
        [Browsable(false)]
        public ScriptValue<List<string>> Intermarry = new ScriptValue<List<string>>("intermarry");
        [Category("Marriage"), DisplayName("Max Wives")]
		[Description("Determines the max number of wives members of the religion can have. As well as the number of potential wives automatically generated for the court.")]
        public int MaxWivesValue
        {
			get { return MaxWives.Value; }
			set
			{
                MaxWives.Value = value;
			}
		}
        [Browsable(false)]
        public ScriptValue<int> MaxWives = new ScriptValue<int>("max_wives");
        [Category("Marriage"), DisplayName("Max Consorts")]
		[Description("Max number of consorts / concubines.")]
        public int MaxConsortsValue
        {
			get { return MaxConsorts.Value; }
			set
			{
                MaxConsorts.Value = value;
			}
		}
        [Browsable(false)]
        public ScriptValue<int> MaxConsorts = new ScriptValue<int>("max_consorts");
        [Category("Marriage"), DisplayName("Sacred Blood")]
		[Description("Sacred Xwedodah close-kin marriage mechanics.")]
        public PBool DivineBloodValue
        {
			get { return DivineBlood.Value; }
			set
			{
                DivineBlood.Value = value;
			}
		}
        [Browsable(false)]
        public ScriptPBool DivineBlood = new ScriptPBool("divine_blood");
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
        public ScriptValue<ConvertReligion> ConvertSameGroup = new ScriptValue<ConvertReligion>("ai_convert_same_group");
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
        public ScriptValue<ConvertReligion> ConvertOtherGroup = new ScriptValue<ConvertReligion>("ai_convert_other_group");
        [Category("AI"), DisplayName("Aggression")]
		[Description("AI aggression factor.")]
        public double AggressionValue
        {
			get { return Aggression.Value; }
			set
			{
                Aggression.Value = value;
			}
		}
        [Browsable(false)]
        public ScriptValue<double> Aggression = new ScriptValue<double>("aggression");
        [Category("Religious Head"), DisplayName("Excommunication")]
		[Description("Determines if the religious head can excommunicate members of the religion.")]
        public PBool ExcommunicationValue
		{
			get { return Excommunication.Value; }
			set
			{
                Excommunication.Value = value;
			}
		}
        [Browsable(false)]
        public ScriptPBool Excommunication = new ScriptPBool("can_excommunicate");
        [Category("Religious Head"), DisplayName("Grant Divorces")]
		[Description("Determines if the religious head can grant divorces to members of the religion.")]
        public PBool GrantDivorceValue
		{
			get { return GrantDivorce.Value; }
			set
			{
                GrantDivorce.Value = value;
			}
		}
        [Browsable(false)]
        public ScriptPBool GrantDivorce = new ScriptPBool("can_grant_divorce");
        [Category("Religious Head"), DisplayName("Grant Invasion")]
		[Description("Determines if the religious head can grant the invasion Casus Belli.")]
        public PBool GrantInvasionValue
		{
			get { return GrantInvasion.Value; }
			set
			{
                GrantInvasion.Value = value;
			}
		}
        [Browsable(false)]
        public ScriptPBool GrantInvasion = new ScriptPBool("can_grant_invasion_cb");
        [Category("Religious Head"), DisplayName("Grant Claims")]
		[Description("Determines if the religious head can grant claims (actually not working).")]
        public PBool GrantClaimValue
		{
			get { return GrantClaim.Value; }
			set
			{
                GrantClaim.Value = value;
			}
		}
        [Browsable(false)]
        public ScriptPBool GrantClaim = new ScriptPBool("can_grant_claim");
        [Category("Religious Head"), DisplayName("Call Crusades")]
		[Description("Determines if the religious head can call crusades")]
        public PBool CallCrusadeValue
		{
			get { return CallCrusade.Value; }
			set
			{
                CallCrusade.Value = value;
			}
		}
        [Browsable(false)]
        public ScriptPBool CallCrusade = new ScriptPBool("can_call_crusade");
        [Category("Religious Head"), DisplayName("Antipopes")]
		[Description("Activates Antipope mechanics.")]
        public PBool AntipopesValue
		{
			get { return Antipopes.Value; }
			set
			{
                Antipopes.Value = value;
			}
		}
        [Browsable(false)]
        public ScriptPBool Antipopes = new ScriptPBool("can_have_antipopes");
        [Category("Religious Head"), DisplayName("Autocephaly")]
		[Description("Activates autocephaly mechanics.")]
        public PBool AutocephalyValue
		{
			get { return Autocephaly.Value; }
			set
			{
                Autocephaly.Value = value;
			}
		}
        [Browsable(false)]
        public ScriptPBool Autocephaly = new ScriptPBool("autocephaly");
        [Category("Religious Head"), DisplayName("Religious Head Clothing")]
		[Description("Index of frames to use for the religious head cloths & headgear. See portrait modding.")]
        public int ReligiousHeadClothingValue
		{
			get { return ReligiousHeadClothing.Value; }
			set
			{
                ReligiousHeadClothing.Value = value;
			}
		}
        [Browsable(false)]
        public ScriptValue<int> ReligiousHeadClothing = new ScriptValue<int>("religious_clothing_head");
        [Category("Temple Holders"), DisplayName("Investiture")]
		[Description("Determines if it is possible to appoint bishops. Is modified by Investiture law. Only works for christian group, cannot be combined with autocephaly.")]
        public PBool InvestitureValue
		{
			get { return Investiture.Value; }
			set
			{
                Investiture.Value = value;
			}
		}
        [Browsable(false)]
        public ScriptPBool Investiture = new ScriptPBool("investiture");
        [Category("Temple Holders"), DisplayName("Clerical Marriage")]
		[Description("Determines if the clergy can get married.")]
        public PBool CanMarryValue
		{
			get { return CanMarry.Value; }
			set
			{
                CanMarry.Value = value;
			}
		}
        [Browsable(false)]
        public ScriptPBool CanMarry = new ScriptPBool("priests_can_marry");
        [Category("Temple Holders"), DisplayName("Clerical Inheritance")]
		[Description("Whether priests are excluded from succession.")]
        public PBool CanInheritValue
		{
			get { return CanInherit.Value; }
			set
			{
                CanInherit.Value = value;
			}
		}
        [Browsable(false)]
        public ScriptPBool CanInherit = new ScriptPBool("priests_can_inherit");
        [Category("Temple Holders"), DisplayName("Female Temple Holders")]
        [Description("Allows female temple holders.")]
        public PBool FemaleHoldersValue
		{
			get { return FemaleHolders.Value; }
			set
			{
                FemaleHolders.Value = value;
			}
		}
        [Browsable(false)]
        public ScriptPBool FemaleHolders = new ScriptPBool("female_temple_holders");
        [Category("Temple Holders"), DisplayName("Feudal Temple Holders")]
		[Description("Feudal characters can hold temple holdings without penalty.")]
        public PBool FeudalTempleHoldersValue
		{
			get { return FemaleHolders.Value; }
			set
			{
                FemaleHolders.Value = value;
			}
		}
        [Browsable(false)]
        public ScriptPBool FeudalTempleHolders = new ScriptPBool("can_hold_temples");
        [Category("Temple Holders"), DisplayName("Priest Clothing")]
		[Description("Index of frames to use for priest cloths & headgear. See portrait modding.")]
        public int PriestClothingValue
		{
			get { return PriestClothing.Value; }
			set
			{
                PriestClothing.Value = value;
			}
		}
        [Browsable(false)]
        public ScriptValue<int> PriestClothing = new ScriptValue<int>("religious_clothing_priest");
        [Category("War"), DisplayName("Viking Invasion")]
		[Description("Allows the \"Prepare Invasion\" diplo action")]
        public PBool VikingInvasionValue
		{
			get { return VikingInvasion.Value; }
			set
			{
                VikingInvasion.Value = value;
			}
		}
        [Browsable(false)]
        public ScriptPBool VikingInvasion = new ScriptPBool("allow_viking_invasion");
        [Category("War"), DisplayName("Looting")]
		[Description("Allows looting.")]
        public PBool LootingValue
		{
			get { return Looting.Value; }
			set
			{
                Looting.Value = value;
			}
		}
        [Browsable(false)]
        public ScriptPBool Looting = new ScriptPBool("allow_looting");
        [Category("AI"), DisplayName("Seafarer")] // Any non-ai effects?
		[Description("A.I. will prefer coastal provinces when raiding.")]
        public PBool SeafarerValue
		{
			get { return Seafarer.Value; }
			set
			{
                Seafarer.Value = value;
			}
		}
        [Browsable(false)]
        public ScriptPBool Seafarer = new ScriptPBool("seafarer");
        [Category("War"), DisplayName("River Movement")]
		[Description("Allows river navigation.")]
        public PBool RiverNavigationValue
		{
			get { return RiverNavigation.Value; }
			set
			{
                RiverNavigation.Value = value;
			}
		}
        [Browsable(false)]
        public ScriptPBool RiverNavigation = new ScriptPBool("allow_rivermovement");
        [Category("War"), DisplayName("Defensive Attrition")]
		[Description("Defensive attrition in provinces.")]
        public PBool DefensiveAttritionValue
		{
			get { return DefensiveAttrition.Value; }
			set
			{
                DefensiveAttrition.Value = value;
			}
		}
        [Browsable(false)]
        public ScriptPBool DefensiveAttrition = new ScriptPBool("defensive_attrition");
        [Category("War"), DisplayName("Ignores Defensive Attrition")]
		[Description("Used for religions that do not have defensive attrition, but will still not get the penalty towards such religions.")]
        public PBool IgnoresDefensiveAttritionValue
		{
			get { return IgnoresDefensiveAttrition.Value; }
			set
			{
                IgnoresDefensiveAttrition.Value = value;
            }
		}
        [Browsable(false)]
        public ScriptPBool IgnoresDefensiveAttrition = new ScriptPBool("ignores_defensive_attrition");
        [Category("War"), DisplayName("Independence Warscore Bonus")]
		[Description("Overrides define CONTESTED_TITLE_OCCUPIED_WARSCORE_BONUS_INDEP.")]
        public int IdependenceWarScoreBonusValue
		{
			get { return IndependenceWarScoreBonus.Value; }
			set
			{
                IndependenceWarScoreBonus.Value = value;
			}
		}
        [Browsable(false)]
        public ScriptValue<int> IndependenceWarScoreBonus = new ScriptValue<int>("independence_war_score_bonus");
        [Category("War"), DisplayName("Same Religion Piety Loss")]
		[Description("Lose piety when attacking a ruler of the same religion.")]
        public PBool AttackingSameReligionPietyLossValue
        {
			get { return AttackingSameReligionPietyLoss.Value; }
			set
			{
                AttackingSameReligionPietyLoss.Value = value;

            }
		}
        [Browsable(false)]
        public ScriptPBool AttackingSameReligionPietyLoss = new ScriptPBool("attacking_same_religion_piety_loss");
        [Category("War"), DisplayName("Peace Prestige Loss")]
		[Description("Lose Prestige while at peace.")]
        public PBool PeacePrestigeLossValue
		{
			get { return PeacePrestigeLoss.Value; }
			set
			{
                PeacePrestigeLoss.Value = value;
			}
		}
        [Browsable(false)]
        public ScriptPBool PeacePrestigeLoss = new ScriptPBool("peace_prestige_loss");
        [Category("War"), DisplayName("Peace Piety Gain")]
		[Description("Gain piety while at peace (piety per month).")]
        public double PeacePietyGainValue
		{
			get { return PeacePietyGain.Value; }
			set
			{
                PeacePietyGain.Value = value;
			}
		}
        [Browsable(false)]
        public ScriptValue<double> PeacePietyGain = new ScriptValue<double>("peace_piety_gain");
        [Category("Reformation"), DisplayName("Reformed")]
        [Description("The name of the reformed form of this religion. Note: the reformed religion needs to rpecede the unreformed religion in the file.")]
        public string ReformedValue
		{
			get { return Reformed.Value; }
			set
			{
                Reformed.Value = value;
			}
		}
        [Browsable(false)]
        public ScriptValue<string> Reformed = new ScriptValue<string>("reformed");
        [Category("Reformation"), DisplayName("Reformer Head of Religion")]
        [Description("Make the character that reforms this religion the head of the new reformed faith. Must be set on the non-reformed religion.The title of the reformed religion (d_<religion_reformed>) must NOT have primary = yes, otherwise it will cause game over. landless = yes may not be an issue [?] You also need to do some government modding otherwise character will get nogovernment. In government potentials replace NOT = { religion = norse_pagan_reformed } into the more generic NOT = { primary_title = { is_landless_type_title = no }")]
        public PBool ReformerHeadOfReligionValue
		{
			get { return ReformerHeadOfReligion.Value; }
			set
			{
                ReformerHeadOfReligion.Value = value;
			}
		}
        [Browsable(false)]
        public ScriptPBool ReformerHeadOfReligion = new ScriptPBool("reformer_head_of_religion");
        [Category("Reformation"), DisplayName("Pre-Reformed")]
        [Description("Makes the pagan religion pre-reformed. Note that these religions won't appear in the ledger.")]
        public PBool PreReformedValue
		{
			get { return PreReformed.Value; }
			set
			{
                PreReformed.Value = value;
			}
		}
        [Browsable(false)]
        public ScriptPBool PreReformed = new ScriptPBool("pre_reformed");
        [Category("Modifiers"), DisplayName("Unit Modifiers")]
        [Description("Modifiers for units.")]
        public string UnitModifiersValue
		{
			get { return UnitModifiers.Value; }
			set
			{
                UnitModifiers.Value = value;
			}
		}
        [Browsable(false)]
        public ScriptValue<string> UnitModifiers = new ScriptValue<string>("unit_modifier");
        [Category("Modifiers"), DisplayName("Unit Home Modifiers")]
        [Description("Modifiers for units on home territoy.")]
        public string UnitHomeModifiersValue
		{
			get { return UnitHomeModifiers.Value; }
			set
			{
                UnitHomeModifiers.Value = value;
			}
		}
        [Browsable(false)]
        public ScriptValue<string> UnitHomeModifiers = new ScriptValue<string>("unit_home_modifier");
        [Category("Modifiers"), DisplayName("Short Reign Opinion Year Mult")]
        [Description("Opinion penalty multiplier to short reign years. Override the define SHORT_REIGN_OPINION_MULT = 2.")]
        public int ShortReignOpinionYearMultValue
		{
			get { return ShortReignOpinionYearMult.Value; }
			set
			{
                ShortReignOpinionYearMult.Value = value;
			}
		}
        [Browsable(false)]
        public ScriptValue<int> ShortReignOpinionYearMult = new ScriptValue<int>("short_reign_opinion_year_mult");
        [Category("Modifiers"), DisplayName("Character Modifiers")]
        [Description("Modifier for all characters of this religion.")]
        public string CharacterModifiersValue
		{
			get { return CharacterModifiers.Value; }
			set
			{
                CharacterModifiers.Value = value;
			}
		}
        [Browsable(false)]
        public ScriptValue<string> CharacterModifiers = new ScriptValue<string>("character_modifier");
        [Category("Modifiers"), DisplayName("Raised Vassal Opinion Loss")]
        [Description("Determines whether raised vassal levies cause negative opinion overtime against the liege.")]
        public PBool RaisedVassalOpinionLossValue
		{
			get { return RaisedVassalOpinionLoss.Value; }
			set
			{
                RaisedVassalOpinionLoss.Value = value;
			}
		}
        [Browsable(false)]
        public ScriptPBool RaisedVassalOpinionLoss = new ScriptPBool("raised_vassal_opinion_loss");
        [Category("Modifiers"), DisplayName("Landed Kin Prestige Bonus")]
        [Description("Gives a prestige bonus for having landed 'kings [sic] as vassal.")]
        public PBool LandedKinPrestigeBonusValue
		{
			get { return LandedKinPrestigeBonus.Value; }
			set
			{
                LandedKinPrestigeBonus.Value = value;
			}
		}
        [Browsable(false)]
        public ScriptPBool LandedKinPrestigeBonus = new ScriptPBool("landed_kin_prestige_bonus");
        [Category("Modifiers"), DisplayName("Expel Modifier")]
        [Description("The modifier related to expelling this religion. e.g. expelled_jewish")]
        public string ExpelModifierValue
		{
			get { return ExpelModifier.Value; }
			set
			{
                ExpelModifier.Value = value;
			}
		}
        [Browsable(false)]
        public ScriptValue<string> ExpelModifier = new ScriptValue<string>("expel_modifier");
        [Category("Special Features"), DisplayName("Retire To Monastery")]
        [Description("Activates order to take the vows diplomatic action.")]
        public PBool CanRetireToMonasteryValue
		{
			get { return CanRetireToMonastery.Value; }
			set
			{
                CanRetireToMonastery.Value = value;
			}
		}
        [Browsable(false)]
        public ScriptPBool CanRetireToMonastery = new ScriptPBool("can_retire_to_monastery");
        [Category("Special Features"), DisplayName("Feminist")]
        [Description("Nullifies the negative opinion modifier that vassals normally get if the ruler is female or has female heir.")]
        public PBool FeministValue
		{
			get { return Feminist.Value; }
			set
			{
                Feminist.Value = value;
			}
		}
        [Browsable(false)]
        public ScriptPBool Feminist = new ScriptPBool("feminist");
        [Category("Special Features"), DisplayName("Pacifist")]
        [Description("Denotes religions with decreased aggression and stable realms. Only works on Jain religion if player does not own Rajas of India.")]
        public PBool PacifistValue
		{
			get { return Pacifist.Value; }
			set
			{
                Pacifist.Value = value;
			}
		}
        [Browsable(false)]
        public ScriptPBool Pacifist = new ScriptPBool("pacifist");
        [Category("Special Features"), DisplayName("Heir Designation")]
        [Description("Allows the designation of heirs.")]
        public PBool HasHeirDesignationValue
		{
			get { return HasHeirDesignation.Value; }
			set
			{
                HasHeirDesignation.Value = value;
			}
		}
        [Browsable(false)]
        public ScriptPBool HasHeirDesignation = new ScriptPBool("has_heir_designation");
        [Category("Special Features"), DisplayName("Dislikes Tribal Organization")]
        [Description("Vassals of this religion will disapprove and form factions if their liege increases tribal organization. Typically used for unreformed pagans, that should first convert to a Monotheistic religion before attempting to go feudal.")]
        public PBool DislikesTribalOrgValue
		{
			get { return DislikesTribalOrg.Value; }
			set
			{
                DislikesTribalOrg.Value = value;
			}
		}
        [Browsable(false)]
        public ScriptPBool DislikesTribalOrg = new ScriptPBool("dislikes_tribal_organization");
        [Category("Special Features"), DisplayName("Decadence")]
        [Description("Decadence will be used if the religion AND government of a character is scripted to use decadence.")]
        public PBool UsesDecadenceValue
		{
			get { return UsesDecadence.Value; }
			set
			{
                UsesDecadence.Value = value;
			}
		}
        [Browsable(false)]
        public ScriptPBool UsesDecadence = new ScriptPBool("uses_decadence");
        [Category("Special Features"), DisplayName("Jizya Tax")]
        [Description("Provinces of other religions will pay the jizya tax.")]
        public PBool UsesJizyaTaxValue
		{
			get { return UsesJizyaTax.Value; }
			set
			{
                UsesJizyaTax.Value = value;
			}
		}
        [Browsable(false)]
        public ScriptPBool UsesJizyaTax = new ScriptPBool("uses_jizya_tax");
        [Category("Special Features"), DisplayName("Hard to Convert")]
        [Description("Checked via is_hard_to_convert character/province trigger.")]
        public PBool IsHardToConvertValue
		{
			get { return IsHardToConvert.Value; }
			set
			{
                IsHardToConvert.Value = value;
			}
		}
        [Browsable(false)]
        public ScriptPBool IsHardToConvert = new ScriptPBool("hard_to_convert");
        [Category("Special Features"),DisplayName("Allow in Ruler Designer")]
        [Description("Prevents the religion from appearing in Ruler Designer, typically pagan reformed religions.")]
        public PBool AllowInRulerDesignerValue
		{
			get { return AllowInRulerDesigner.Value; }
			set
			{
                AllowInRulerDesigner.Value = value;
			}
		}
        [Browsable(false)]
        public ScriptPBool AllowInRulerDesigner = new ScriptPBool("allow_in_ruler_designer");

        public enum ConvertReligion
        {
            Never = 0,
            HighZeal = 1,
            Always = 2
        }
    }
}
