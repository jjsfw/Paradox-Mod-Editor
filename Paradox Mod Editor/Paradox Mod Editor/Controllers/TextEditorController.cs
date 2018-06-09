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
        protected OpenFile currentFile;
        internal Dictionary<string, OpenFile> files;

        public TextEditorController(ITextEditorView view)
        {
            view.SetController(this);
            this.view = view;
            files = new Dictionary<string, OpenFile>();
        }

        protected void OpenNewFile(string path)
        {
            files.Add(path, new OpenFile(path, MakeTextBox()));
        }

        protected void UpdateFile(string path, string contents)
        {
            files[path].UpdateContents(contents);
        }

        protected virtual List<AutocompleteItem> LoadAutocompleteItems()
        {
            throw new NotImplementedException();
        }

        public FastColoredTextBox MakeTextBox()
        {
            FastColoredTextBox newTextBox =  (FastColoredTextBox)TextBoxFactory.GetFactory().GetControl(LoadAutocompleteItems());

            view.AddTextBoxToView(newTextBox);

            return newTextBox;
        }

        public void CheckFileForChanges(TreeNode fileNode)
        {
            if (currentFile.IsChanged())
            {
                fileNode.BackColor = System.Drawing.Color.Yellow;
            }
        }
    }
}
