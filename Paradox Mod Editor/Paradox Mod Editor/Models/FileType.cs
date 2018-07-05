using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paradox_Mod_Editor.Models
{
    public class FileType
    {
        public List<Type> ScriptTypes { get; set; } = new List<Type>();
        public List<string> ExcludedStrings { get; set; } = new List<string>();

        public FileType(List<string> scriptTypes)
        {
            foreach (string scriptType in scriptTypes)
            {
                this.ScriptTypes.Add(Type.GetType(scriptType));
            }
        }

        public FileType(List<string> scriptTypes, List<string> excludedStrings)
            : this(scriptTypes)
        {
            this.ExcludedStrings = excludedStrings;
        }

        public FileType(List<Type> scriptTypes)
        {
            this.ScriptTypes = scriptTypes;
        }

        public FileType(List<Type> scriptTypes, List<string> excludedStrings)
            : this(scriptTypes)
        {
            this.ExcludedStrings = excludedStrings;
        }
    }
}
