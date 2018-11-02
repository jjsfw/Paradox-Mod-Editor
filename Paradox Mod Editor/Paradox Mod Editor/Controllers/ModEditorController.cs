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
using Paradox_Mod_Editor.Basic_Forms;
using Paradox_Mod_Editor.Models.CrusaderKings;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Paradox_Mod_Editor.Controllers
{
    class ModEditorController : TextEditorController
    {
        private ParadoxTitle game;
        private string modDirectory;
        private string filePath;
        private ScriptObject scriptObject;
        private List<string> scriptPairs;
        private Dictionary<string, List<string>> fileScriptPairs;
        private Dictionary<ParadoxTitle, Dictionary<string, List<string>>> gameFilePairs;
        private ScriptParser parser;
        private IScriptStrategy strategy;

        public ModEditorController(ITextEditorView view, ParadoxTitle game, string modDirectory)
            : base(view)
        {
            this.game = game;
            this.modDirectory = modDirectory.Substring(0, modDirectory.LastIndexOf("\\") + 1);

            gameFilePairs = new Dictionary<ParadoxTitle, Dictionary<string, List<string>>>();
            foreach (ParadoxTitle title in Enum.GetValues(typeof(ParadoxTitle)))
            {
                gameFilePairs.Add(title, new Dictionary<string, List<string>>());
            }

            switch(game)
            {
                case ParadoxTitle.EuropaUniversalis:
                    break;
                case ParadoxTitle.HeartsOfIron:
                    break;
                case ParadoxTitle.Stellaris:
                    break;
                default:
                    strategy = new CrusaderKingsStrategy(GetCrusaderKingsFactories());
                    break;
            }

            parser = new ScriptParser(strategy);

            LoadScriptPairs();
        }

        private IScriptFactory[] GetCrusaderKingsFactories()
        {
            return new IScriptFactory[] { new ReligionGroupScriptFactory(), new ReligionScriptFactory(), new CommentBlockScriptFactory(), new EventFactory() };
        }

        private void BuildCK2Scripts()
        {

        }

        protected override List<AutocompleteItem> LoadAutocompleteItems()
        {
            List<AutocompleteItem> items = new List<AutocompleteItem>();
            string xmlPath = @"..\..\ParadoxSyntax\CrusaderKingsScripts.xml";
            switch (game)
            {
                case ParadoxTitle.CrusaderKings:
                    xmlPath = @"..\..\ParadoxSyntax\CrusaderKingsScripts.xml";
                    break;
                case ParadoxTitle.EuropaUniversalis:
                    xmlPath = @"..\..\ParadoxSyntax\EuropaUniversalisScripts.xml";
                    break;
                case ParadoxTitle.HeartsOfIron:
                    xmlPath = @"..\..\ParadoxSyntax\HeartsOfIronScripts.xml";
                    break;
                case ParadoxTitle.Stellaris:
                    xmlPath = @"..\..\ParadoxSyntax\StellarisScripts.xml";
                    break;
            }

            XDocument scripts = XDocument.Load(xmlPath);

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

        protected void SetFileHistory(LimitedStack<UndoableCommand> history, Stack<UndoableCommand> redoStack)
        {
            // TODO: set file history in mod editor controller
        }

        public void CreateNewScriptObject()
        {
            frmNewScriptObjectDialog newScriptDialog = new frmNewScriptObjectDialog(scriptPairs);
            newScriptDialog.ShowDialog();
            if (newScriptDialog.type != "Cancel")
            {
                // TODO: update this with strategy
                //IScriptObject newScript = ((ScriptFactoryCK2)ScriptFactoryCK2.GetFactory()).GetScriptObject(newScriptDialog.type);
                //view.AddNewScriptObject(newScript);
            }
        }

        private void LoadScriptPairs()
        {
            string xmlPath = @"..\..\ParadoxSyntax\FileScriptPairs.xml";

            XDocument scripts = XDocument.Load(xmlPath);
            IEnumerable<XElement> names;
            IEnumerable<XElement> games;
            IEnumerable<XElement> rawScriptObjects;

            switch (game)
            {
                case ParadoxTitle.CrusaderKings:
                    names = from c in scripts.Root.Descendants("fileType")
                            select c.Element("name");
                    games = from c in scripts.Root.Descendants("fileType")
                            select c.Element("game");
                    rawScriptObjects = from c in scripts.Root.Descendants("fileType")
                            select c.Element("scriptObjects");
                    break;
                default:
                    names = from c in scripts.Root.Descendants("fileType")
                            select c.Element("name");
                    games = from c in scripts.Root.Descendants("fileType")
                            select c.Element("game");
                    rawScriptObjects = from c in scripts.Root.Descendants("fileType")
                                    select c.Element("scriptObjects");
                    break;
            }

            for (int i = 0; i < names.Count(); i++)
            {
                // TODO: replace this with factory pattern
                List<string> scriptObjectNames = rawScriptObjects.ElementAt(i).Value.Trim().Split(' ').ToList();
                gameFilePairs[game].Add(names.ElementAt(i).Value, scriptObjectNames);
            }

            // debug
            scriptPairs = gameFilePairs[ParadoxTitle.CrusaderKings]["religion"];
        }

        public void DebugParse()
        {
            // TODO: continuous parsing doesn't seem to be *too* much of a time consumer. Leave it in for now
            // TODO: in future, try to have it only parse the changed sections
            try
            {
                currentFile.SetScriptObjects(
                // Events
                //parser.Split(currentFile.GetCurrentText(), new FileType(
                //    new List<string> { "Paradox_Mod_Editor.Models.CrusaderKings.Event", "Paradox_Mod_Editor.Models.CrusaderKings.CommandBlock", "Paradox_Mod_Editor.Models.CrusaderKings.CommentBlock" },
                //    null)));
                // Religions
                parser.Split(currentFile.GetCurrentText(), new FileType(
                    new List<string> { "Paradox_Mod_Editor.Models.CrusaderKings.ReligionGroup", "Paradox_Mod_Editor.Models.CrusaderKings.Religion", "Paradox_Mod_Editor.Models.CrusaderKings.CommentBlock" },
                    new List<string> { "secret_religion_visibility_trigger" })));
                view.SetScriptObjects(currentFile.GetScriptObjects());
            }
            catch { }
        }

        public void DebugWrite()
        {
            string newText = "";
            foreach (ScriptObject scriptObject in view.GetScriptObjects())
            {
                if (scriptObject.ReplaceWrite)
                {
                    string replaceKey = "%%" + scriptObject.NameValue + "%%";
                    string init = newText.Substring(0, newText.IndexOf(replaceKey));
                    string end = newText.Substring(newText.IndexOf(replaceKey) + replaceKey.Length);
                    newText = init + scriptObject.RawText + end;
                }
                else
                {
                    newText += scriptObject.RawText;
                }
            }
            view.GetTextBox().Text = newText;
        }

        public void UpdateObjectText(ScriptObject scriptObject, string propertyName, object value)
        {
            PropertyInfo[] properties = scriptObject.GetType().GetProperties().Where(
                prop => Attribute.IsDefined(prop, typeof(ScriptValueAttribute))).ToArray();
            foreach (PropertyInfo property in properties)
            {
                if (propertyName == property.Name)
                {
                    IScriptContainer scriptContainer = (IScriptContainer)property.GetValue(scriptObject);
                    string scriptText = scriptContainer.ScriptText;
                    scriptObject.RawText = Regex.Replace(scriptObject.RawText, scriptText + @"\s*=\s*[^\s#]+", scriptText + " = " + value);
                    break;
                }
            }
        }
    }
}
