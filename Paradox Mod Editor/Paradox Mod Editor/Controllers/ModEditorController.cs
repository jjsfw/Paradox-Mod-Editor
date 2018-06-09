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
        private string modDirectory;
        private string filePath;

        public ModEditorController(ITextEditorView view, ParadoxTitle game, string modDirectory)
            : base(view)
        {
            this.game = game;
            this.modDirectory = modDirectory.Substring(0, modDirectory.LastIndexOf("\\") + 1);
        }

        protected override List<AutocompleteItem> LoadAutocompleteItems()
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

            //IEnumerable<XElement> texts = from c in scripts.Root.Descendants("script")
            //                              select c.Element("fillText");

            for (int i = 0; i < 7; i++)//names.Count(); i++)
            {
                // Replace newlines and tabs with proper characters
                names.ElementAt(i).Value = names.ElementAt(i).Value.Replace("\\n", "\n");
                desc.ElementAt(i).Value = desc.ElementAt(i).Value.Replace("\\n", "\n");
                types.ElementAt(i).Value = types.ElementAt(i).Value.Replace("\\n", "\n");
                //texts.ElementAt(i).Value = texts.ElementAt(i).Value.Replace("\\n", "\n");

                names.ElementAt(i).Value = names.ElementAt(i).Value.Replace("\\t", "\t");
                desc.ElementAt(i).Value = desc.ElementAt(i).Value.Replace("\\t", "\t");
                types.ElementAt(i).Value = types.ElementAt(i).Value.Replace("\\t", "\t");
                //texts.ElementAt(i).Value = texts.ElementAt(i).Value.Replace("\\t", "\t");

                items.Add(new AutocompleteItem(names.ElementAt(i).Value, -1, names.ElementAt(i).Value, types.ElementAt(i).Value, desc.ElementAt(i).Value));
            }
            // TODO: add autocompletion of commands with additional parameters e.g. create_unit using the texts tags
            // See examples below for how to implement
            // items.Add(new AutocompleteItem("test_param = {\r\n\tvalue = \r\n}", -1, "test_param", "test object", "used for testing autocomplete"));

            items.Add(new InsertSpaceSnippet());
            items.Add(new InsertSpaceSnippet(@"^(\w+)([=<>!:]+)(\w+)$"));
            items.Add(new InsertEnterSnippet());

            return items;
        }

        public FastColoredTextBox LoadSelectedFileTextBox(TreeNode node)
        {
            filePath = modDirectory + node.FullPath;
            if (currentFile == null || filePath != currentFile.GetPath())
            {
                if (!files.ContainsKey(filePath))
                {
                    OpenNewFile(filePath);
                    //textBox.SyntaxHighlighter.HighlightSyntax();
                }
                currentFile = files[filePath];
                return currentFile.textBox;
                //textBox.Text = currentFile.GetContents();
                //currentFile.UpdateContentsIgnoreSave(textBox.Text);
            }
            return null;
        }

        public void UpdateFile(string contents)
        {
            if (filePath != null && filePath.Contains(modDirectory))
            {
                base.UpdateFile(filePath, contents);
            }
        }

        public string ReadFile()
        {
            if (currentFile == null)
            {
                return "";
            }
            return currentFile.GetContents();
        }
    }
}
