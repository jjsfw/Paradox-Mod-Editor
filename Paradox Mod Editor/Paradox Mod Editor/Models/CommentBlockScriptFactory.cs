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

        public IScriptObject GetScriptObject()
        {
            return new CommentBlock();
        }

        public bool AppliesTo(Type type)
        {
            return typeof(CommentBlock).Equals(type);
        }
    }
}
