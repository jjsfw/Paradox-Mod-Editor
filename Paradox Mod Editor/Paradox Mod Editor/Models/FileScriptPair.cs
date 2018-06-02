using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paradox_Mod_Editor.Models
{
    class FileScriptPair
    {
        public List<ScriptObject> ScriptObjects { get; }

        public FileScriptPair(string fileType, List<ScriptObject> scriptObjects)
        {
            this.ScriptObjects = scriptObjects; // TODO: build file-script pairs
        }
    }
}
