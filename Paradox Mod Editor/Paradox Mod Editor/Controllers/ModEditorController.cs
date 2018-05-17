using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Paradox_Mod_Editor.Views;

namespace Paradox_Mod_Editor.Controllers
{
    class ModEditorController : TextEditorController
    {
        private ITextEditorView view;

        public ModEditorController(ITextEditorView view)
            : base(view) { }
    }
}
