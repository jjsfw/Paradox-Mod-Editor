using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Paradox_Mod_Editor.Views;
using System.Windows.Forms;
using FastColoredTextBoxNS;
using Paradox_Mod_Editor.Models;

namespace Paradox_Mod_Editor.Controllers
{
    public class TextEditorController
    {
        protected ITextEditorView view;
        internal Dictionary<string, OpenFile> files;

        public TextEditorController(ITextEditorView view)
        {
            view.SetController(this);
            files = new Dictionary<string, OpenFile>();
        }

        protected void OpenNewFile(string path)
        {
            files.Add(path, new OpenFile(path));
        }

        protected void UpdateFile(string path, string contents)
        {
            files[path].UpdateContents(contents);
        }
    }
}
