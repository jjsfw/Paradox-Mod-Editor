using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Paradox_Mod_Editor.Controllers;
using System.Windows.Forms;
using FastColoredTextBoxNS;

namespace Paradox_Mod_Editor.Views
{
    public interface ITextEditorView
    {
        void SetController(TextEditorController controller);
        FastColoredTextBox GetTextBox();
    }
}
