using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paradox_Mod_Editor.Models
{
    class CommentBlock : ScriptObject
    {
        public string Name { get; }

        public CommentBlock(string name) : base(name) { }
    }
}
