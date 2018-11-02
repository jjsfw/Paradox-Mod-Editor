using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Paradox_Mod_Editor.Controllers;
using System.Windows.Forms;
using FastColoredTextBoxNS;
using Paradox_Mod_Editor.Models;

namespace Paradox_Mod_Editor.Views
{
    public interface ITextEditorView
    {
        void SetController(TextEditorController controller);
        void AddTextBoxToView(FastColoredTextBox newTextBox);
        FastColoredTextBox GetTextBox();
        void AddNewScriptObject(ScriptObject scriptObject);
        void SetScriptObjects(List<ScriptObject> scriptObjects);
        List<ScriptObject> GetScriptObjects();
    }
}
