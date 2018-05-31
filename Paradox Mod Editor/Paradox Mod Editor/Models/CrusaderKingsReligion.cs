using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Drawing;

namespace Paradox_Mod_Editor.Models
{
    class CrusaderKingsReligion : ScriptObject
    {
        // TODO: update types (modifiers, graphical cultures (?), etc)
        // TODO: finish descriptions, display names
        [Category("*General"), Description("The name of the religion as it appears in script."), DisplayName("Name")]
        public string Name { get; set; }
        [Category("*General"), Description("Makes the religion a heresy of its parent religion. The parent religion must be defined before. Note: reformed pagans can have heresies, but they need to be defined after both reformed and unreformed religions."), DisplayName("Parent Religion")]
        public string Parent { get; set; }
        [Category("Graphical"), Description("Only used for the display of CoA frames on the map."), DisplayName("Graphical Culture")]
        public string GraphicalCulture { get; set; }
        [Category("Graphical"), Description("Defines which icon will be used for the religion in-game. The value is ignored for heresies (unless the heresy becomes mainstream religion), and the heresy_icon of the parent religion will be used instead."), DisplayName("Icon")]
        public int Icon { get; set; }
        [Category("Graphical"), Description("The color used when drawing the religion map mode.\nRGB format with a range of 0.0–1.0.To determine a value from the RGB, simply divide by 255, e.g. 180 ÷ 255 = 0.7"), DisplayName("Colour")]
        public Color Color { get; set; }
        [Category("Graphical"), Description("Heresy icon. Note that this has to be set in the parent religion, not at heresy level."), DisplayName("Heresy Icon")]
        public int HeresyIcon { get; set; }
        [Category("Graphical"), Description("Undocumented"), DisplayName("Secondary Event Pictures")]
        public string SecondaryEventPictures { get; set; }
        [Category("Names"), Description(""), DisplayName("")]
        public string CrusadeName { get; set; }
        [Category("Names"), Description(""), DisplayName("")]
        public string ScriptureName { get; set; }
        [Category("Names"), Description(""), DisplayName("")]
        public string HighGodName { get; set; }
        [Category("Names"), Description(""), DisplayName("")]
        public List<string> GodNames { get; set; }
        [Category("Names"), Description(""), DisplayName("")]
        public List<string> EvilGodNames { get; set; }
        [Category("Names"), Description(""), DisplayName("")]
        public string PietyName { get; set; }
        [Category("Names"), Description(""), DisplayName("")]
        public string PriestTitle { get; set; }
        [Category("Marriage"), Description(""), DisplayName("")]
        public PBool BrotherSisterMarriage { get; set; }
        [Category("Marriage"), Description(""), DisplayName("")]
        public PBool ParentChildMarriage { get; set; }
        [Category("Marriage"), Description(""), DisplayName("")]
        public PBool NiblingMarriage { get; set; }
        [Category("Marriage"), Description(""), DisplayName("")]
        public PBool CousinMarriage { get; set; }
        [Category("Marriage"), Description(""), DisplayName("")]
        public PBool MatrilinealMarriage { get; set; }
        [Category("Marriage"), Description(""), DisplayName("")]
        public List<string> Intermarry { get; set; }
        [Category("Marriage"), Description(""), DisplayName("")]
        public int MaxWives { get; set; }
        [Category("Marriage"), Description(""), DisplayName("")]
        public int MaxConsorts { get; set; }
        [Category("Marriage"), Description(""), DisplayName("")]
        public PBool DivineBlood { get; set; }
        [Category("AI"), Description(""), DisplayName("")]
        public ConvertReligion ConvertSameGroup { get; set; }
        [Category("AI"), Description(""), DisplayName("")]
        public ConvertReligion ConvertOtherGroup { get; set; }
        [Category("AI"), Description(""), DisplayName("")]
        public double Aggression { get; set; }
        [Category("Religious Head"), Description(""), DisplayName("")]
        public PBool Excommunication { get; set; }
        [Category("Religious Head"), Description(""), DisplayName("")]
        public PBool GrantDivorce { get; set; }
        [Category("Religious Head"), Description(""), DisplayName("")]
        public PBool GrantInvasion { get; set; }
        [Category("Religious Head"), Description(""), DisplayName("")]
        public PBool GrantClaim { get; set; }
        [Category("Religious Head"), Description(""), DisplayName("")]
        public PBool CallCrusade { get; set; }
        [Category("Religious Head"), Description(""), DisplayName("")]
        public PBool Antipopes { get; set; }
        [Category("Religious Head"), Description(""), DisplayName("")]
        public PBool Autocephaly { get; set; }
        [Category("Religious Head"), Description(""), DisplayName("")]
        public int ReligiousHeadClothing { get; set; }
        [Category("Temple Holders"), Description(""), DisplayName("")]
        public PBool Investitute { get; set; }
        [Category("Temple Holders"), Description(""), DisplayName("")]
        public PBool CanMarry { get; set; }
        [Category("Temple Holders"), Description(""), DisplayName("")]
        public PBool CanInherit { get; set; }
        [Category("Temple Holders"), Description(""), DisplayName("")]
        public PBool FemaleHolders { get; set; }
        [Category("Temple Holders"), Description(""), DisplayName("")]
        public PBool FeudalTempleHolders { get; set; }
        [Category("Temple Holders"), Description(""), DisplayName("")]
        public int PriestClothing { get; set; }
        [Category("War"), Description(""), DisplayName("")]
        public PBool VikingInvasion { get; set; }
        [Category("War"), Description(""), DisplayName("")]
        public PBool Looting { get; set; }
        [Category("War"), Description(""), DisplayName("")]
        public PBool Seafarer { get; set; }
        [Category("War"), Description(""), DisplayName("")]
        public PBool RiverNavigation { get; set; }
        [Category("War"), Description(""), DisplayName("")]
        public PBool DefensiveAttrition { get; set; }
        [Category("War"), Description(""), DisplayName("")]
        public PBool IgnoresDefensiveAttrition { get; set; }
        [Category("War"), Description(""), DisplayName("")]
        public int IdependenceWarScoreBonus { get; set; }
        [Category("War"), Description(""), DisplayName("")]
        public PBool AttackingSameReligionPietyLoss { get; set; }
        [Category("War"), Description(""), DisplayName("")]
        public PBool PeacePrestigeLoss { get; set; }
        [Category("War"), Description(""), DisplayName("")]
        public double PeacePrestigeGain { get; set; }
        [Category("Reformation"), Description("Note: the reformed religion needs to rpecede the unreformed religion in the file."), DisplayName("Reformed")]
        public string Reformed { get; set; }
        [Category("Reformation"), Description("Make the character that reforms this religion the head of the new reformed faith. Must be set on the non-reformed religion.The title of the reformed religion (d_<religion_reformed>) must NOT have primary = yes, otherwise it will cause game over. landless = yes may not be an issue [?] You also need to do some government modding otherwise character will get nogovernment. In government potentials replace NOT = { religion = norse_pagan_reformed }into the more generic NOT = { primary_title = { is_landless_type_title = no } }"), DisplayName("Reformer Head of Religion")]
        public PBool ReformerHeadOfReligion { get; set; }
        [Category("Reformation"), Description("Makes the pagan religion pre-reformed. Note that these religions won't appear in the ledger."), DisplayName("Pre-Reformed")]
        public PBool PreReformed { get; set; }
        [Category("Modifiers"), Description("Modifiers for units."), DisplayName("Unit Modifiers")]
        public string UnitModifiers { get; set; }
        [Category("Modifiers"), Description("Modifiers for units on home territoy."), DisplayName("Unit Home Modifiers")]
        public string UnitHomeModifiers { get; set; }
        [Category("Modifiers"), Description("Opinion penalty multiplier to short reign years. Override the define SHORT_REIGN_OPINION_MULT = 2."), DisplayName("Short Reign Opinion Year Mult")]
        public int ShortReignOpinionYearMult { get; set; }
        [Category("Modifiers"), Description("Modifier for all characters of this religion."), DisplayName("Character Modifiers")]
        public string CharacterModifiers { get; set; }
        [Category("Modifiers"), Description("Determines whether raised vassal levies cause negative opinion overtime against the liege."), DisplayName("Raised Vassal Opinion Loss")]
        public PBool RaisedVassalOpinionLoss { get; set; }
        [Category("Modifiers"), Description("Gives a prestige bonus for having landed 'kings [sic] as vassal."), DisplayName("Landed Kin Prestige Bonus")]
        public PBool LandedKinPrestigeBonus { get; set; }
        [Category("Modifiers"), Description("The modifier related to expelling this religion. e.g. expelled_jewish"), DisplayName("Expel Modifier")]
        public string ExpelModifier { get; set; }
        [Category("Special Features"), Description("Activates order to take the vows diplomatic action."), DisplayName("Retire To Monastery")]
        public PBool CanRetireToMonastery { get; set; }
        [Category("Special Features"), Description("Nullifies the negative opinion modifier that vassals normally get if the ruler is female or has female heir."), DisplayName("Feminist")]
        public PBool Feminist { get; set; }
        [Category("Special Features"), Description("Denotes religions with decreased aggression and stable realms. Only works on Jain religion if player does not own Rajas of India."), DisplayName("Pacifist")]
        public PBool Pacifist { get; set; }
        [Category("Special Features"), Description("Allows the designation of heirs."), DisplayName("Heir Designation")]
        public PBool HasHeirDesignation { get; set; }
        [Category("Special Features"), Description("Vassals of this religion will disapprove and form factions if their liege increases tribal organization. Typically used for unreformed pagans, that should first convert to a Monotheistic religion before attempting to go feudal."), DisplayName("Dislikes Tribal Organization")]
        public PBool DislikesTribalOrg { get; set; }
        [Category("Special Features"), Description("Decadence will be used if the religion AND government of a character is scripted to use decadence."), DisplayName("Decadence")]
        public PBool UsesDecadence { get; set; }
        [Category("Special Features"), Description("Provinces of other religions will pay the jizya tax."), DisplayName("Jizya Tax")]
        public PBool UsesJizyaTax { get; set; }
        [Category("Special Features"), Description("Checked via is_hard_to_convert character/province trigger."), DisplayName("Hard to Convert")]
        public PBool IsHardToConvert { get; set; }
        [Category("Special Features"), Description("Prevents the religion from appearing in Ruler Designer, typically pagan reformed religions."), DisplayName("Allow in Ruler Designer")]
        public PBool AllowInRulerDesigner { get; set; }


        public enum ConvertReligion
        {
            Never = 0,
            HighZeal = 1,
            Always = 2
        }
        
        [Description("A boolean value that allows for keeping the default yes/no setting of an attribute without explicitly stating whether that default is yes or no.")]
        public enum PBool
        {
            Default,
            yes,
            no
        }
    }
}
