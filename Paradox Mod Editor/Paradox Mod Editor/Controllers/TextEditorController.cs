using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Paradox_Mod_Editor.Views;
using System.Windows.Forms;
using FastColoredTextBoxNS;

namespace Paradox_Mod_Editor.Controllers
{
    public class TextEditorController
    {
        private ITextEditorView view;

        public TextEditorController(ITextEditorView view)
        {
            view.SetController(this);
        }
    }
}
