using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paradox_Mod_Editor.Models
{
    public interface IScriptFactory<T> where T : IScriptObject
    {
        T GetScriptObject();
        bool AppliesTo(Type type);
    }

    public interface IScriptStrategy<T> where T : IScriptObject
    {
        T GetScriptObject(Type type);
    }
}
