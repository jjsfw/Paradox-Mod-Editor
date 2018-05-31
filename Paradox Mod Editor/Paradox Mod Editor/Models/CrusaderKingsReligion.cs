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
        // TODO: update types
        [Category("*General")]
        public string Name { get; set; }
        [Category("Graphical")]
        public string GraphicalCulture { get; set; }
        [Category("Graphical")]
        public int Icon { get; set; }
        [Category("Graphical")]
        public Color Color { get; set; }
        [Category("Names")]
        public string CrusadeName { get; set; }
        [Category("Names")]
        public string ScriptureName { get; set; }
        [Category("Names")]
        public string HighGodName { get; set; }
        [Category("Names")]
        public List<string> GodNames { get; set; }
        [Category("Names")]
        public List<string> EvilGodNames { get; set; }
        [Category("Names")]
        public string PietyName { get; set; }
        [Category("Names")]
        public string PriestTitle { get; set; }
        [Category("Marriage")]
        public bool BrotherSisterMarriage { get; set; }
        [Category("Marriage")]
        public bool ParentChildMarriage { get; set; }
        [Category("Marriage")]
        public bool NiblingMarriage { get; set; }
        [Category("Marriage")]
        public bool CousinMarriage { get; set; }
        [Category("Marriage")]
        public bool MatrilinealMarriage { get; set; }
        [Category("Marriage")]
        public List<string> Intermarry { get; set; }
        [Category("Marriage")]
        public int MaxWives { get; set; }
        [Category("Marriage")]
        public int MaxConsorts { get; set; }
        [Category("Marriage")]
        public bool DivineBlood { get; set; }
        //[Category("Religious Head")]
        //[Category("Priests")]
    }
}
