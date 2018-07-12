using System.ComponentModel;

namespace Paradox_Mod_Editor.ParadoxSyntax
{
    [Description("A boolean value that allows for keeping the default yes/no setting of an attribute without explicitly stating whether that default is yes or no.")]
    public enum PBool
    {
        Default,
        yes,
        no
    }

    public enum ConvertReligion
    {
        Never = 0,
        HighZeal = 1,
        Always = 2
    }
}