using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paradox_Mod_Editor.Models
{
    public abstract class ControlFactory
    {
        public abstract Control GetScriptObject(string scriptObject);

        public static ControlFactory GetFactory()
        {
            throw new NotImplementedException();
        }
    }
}
