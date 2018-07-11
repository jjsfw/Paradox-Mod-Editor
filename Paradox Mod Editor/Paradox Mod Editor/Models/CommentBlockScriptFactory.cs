using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paradox_Mod_Editor.Models
{
    class CommentBlockScriptFactory : IScriptFactory
    {
        // Use constructor to assign params of created Religions

        public ScriptObject GetScriptObject(string name)
        {
            return new CommentBlock(name);
        }

        public bool AppliesTo(Type type)
        {
            return typeof(CommentBlock).Equals(type);
        }
    }
}
