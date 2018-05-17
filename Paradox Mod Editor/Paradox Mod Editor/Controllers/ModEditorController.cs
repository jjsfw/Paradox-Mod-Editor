using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Paradox_Mod_Editor.Views;
using FastColoredTextBoxNS;
using System.Xml.Linq;
using System.Windows.Forms;
using Paradox_Mod_Editor.Models;

namespace Paradox_Mod_Editor.Controllers
{
    class ModEditorController : TextEditorController
    {
        private ParadoxTitle game;
        private OpenFile currentFile;
        private string modDirectory;
        private string filePath;

        public ModEditorController(ITextEditorView view, ParadoxTitle game, string modDirectory)
            : base(view)
        {
            this.game = game;
            this.modDirectory = modDirectory.Substring(0, modDirectory.LastIndexOf("\\") + 1);
        }

        public List<AutocompleteItem> LoadAutocompleteItems()
        {
            List<AutocompleteItem> items = new List<AutocompleteItem>();
            string xmlTestPath = @"..\..\CrusaderKingsScripts.xml"; ;
            switch (game)
            {
                case ParadoxTitle.CrusaderKings:
                    xmlTestPath = @"..\..\CrusaderKingsScripts.xml";
                    break;
                case ParadoxTitle.EuropaUniversalis:
                    xmlTestPath = @"..\..\EuropaUniversalisScripts.xml";
                    break;
                case ParadoxTitle.HeartsOfIron:
                    xmlTestPath = @"..\..\HeartsOfIronScripts.xml";
                    break;
                case ParadoxTitle.Stellaris:
                    xmlTestPath = @"..\..\StellarisScripts.xml";
                    break;
            }

            XDocument scripts = XDocument.Load(xmlTestPath);

            IEnumerable<XElement> names = from c in scripts.Root.Descendants("script")
                                          select c.Element("name");

            IEnumerable<XElement> desc = from c in scripts.Root.Descendants("script")
                                         select c.Element("desc");

            IEnumerable<XElement> types = from c in scripts.Root.Descendants("script")
                                          select c.Element("type");

            for (int i = 0; i < names.Count(); i++)
            {
                items.Add(new AutocompleteItem(names.ElementAt(i).Value, -1, names.ElementAt(i).Value, types.ElementAt(i).Value, desc.ElementAt(i).Value));
            }
            // TODO: add autocompletion of commands with additional parameters e.g. create_unit
            // See examples below for how to implement
            // items.Add(new AutocompleteItem("test_param = {\r\n\tvalue = \r\n}", -1, "test_param", "test object", "used for testing autocomplete"));

            items.Add(new InsertSpaceSnippet());
            items.Add(new InsertSpaceSnippet(@"^(\w+)([=<>!:]+)(\w+)$"));
            items.Add(new InsertEnterSnippet());

            return items;
        }

        public void LoadSelectedFile(FastColoredTextBox textBox, TreeNode node)
        {
            filePath = modDirectory + node.FullPath;
            if (!files.ContainsKey(filePath))
            {
                OpenNewFile(filePath);
                //textBox.SyntaxHighlighter.HighlightSyntax();
            }
            currentFile = files[filePath];
            textBox.Text = currentFile.GetContents();
        }

        public void UpdateFile(string contents)
        {
            if (filePath != null && filePath.Contains(modDirectory))
            {
                base.UpdateFile(filePath, contents);
            }
        }
    }
}
