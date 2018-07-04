using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paradox_Mod_Editor.Models
{
    class CommentBlock : IScriptObject
    {
        public string Name { get; }
        public static List<string> ExcludedStrings { get; } = new List<string>();
        public List<string> GetExcludedStrings()
        {
            return ExcludedStrings;
        }
    }
}
