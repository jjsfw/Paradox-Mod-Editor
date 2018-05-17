using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Paradox_Mod_Editor.Views;
using Paradox_Mod_Editor.Controllers;
using FastColoredTextBoxNS;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Linq;
using System.IO;

namespace Paradox_Mod_Editor
{
    public partial class frmTextEditorTesting : Form, ITextEditorView
    {
        private FastColoredTextBox textBox;
        private TextEditorController controller;
        private AutocompleteMenu autoCompleteMenu;
        private Place selectionStart;

        public frmTextEditorTesting()
        {
            InitializeComponent();
        }

        private void TextEditorTesting_Load(object sender, EventArgs e)
        {
            CreateTextBox();
        }

        public void CreateTextBox()
        {
            textBox = new FastColoredTextBox();
            textBox.Location = new Point(0, 0);
            textBox.Dock = DockStyle.Fill;
            textBox.Show();

            // Custom Properties

            // TODO: add diffmerge (put this elsewhere, its own tool/section)
            textBox.SyntaxHighlighter = new SyntaxHighlighter(textBox);

            textBox.AutoCompleteBrackets = true;
            textBox.AutoIndentChars = true;
            textBox.BracketsHighlightStrategy = BracketsHighlightStrategy.Strategy1;
            textBox.LeftBracket = '{';
            textBox.LeftBracket2 = '(';
            textBox.RightBracket = '}';
            textBox.RightBracket2 = ')';
            textBox.DelayedTextChangedInterval = 400;
            textBox.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            textBox.WordWrap = true;
            textBox.LeftPadding = 17;

            Color textColor = ColorTranslator.FromHtml("#A9B7C6");
            Color backColor = ColorTranslator.FromHtml("#2B2B2B");
            Color neutralGrey = ColorTranslator.FromHtml("#808080");

            Color testingColorBright = ColorTranslator.FromHtml("#CB772F");

            // Colours - IntelliJ Darcula
            textBox.ForeColor = textColor;
            textBox.BackColor = backColor;
            textBox.SelectionColor = textColor;
            textBox.IndentBackColor = backColor;
            textBox.LineNumberColor = textColor;
            // End Colours
            textBox.DescriptionFile = @"..\..\ParadoxFormat.xml";
            textBox.Language = Language.Custom;
            // End Custom Properties

            this.Controls.Add(textBox);

            textBox.TextChangedDelayed += textBox_TextChangedDelayed;
            textBox.AutoIndentNeeded += textBox_AutoIndentNeeded;
            textBox.MouseDoubleClick += textBox_MouseDoubleClick;
            textBox.OnTextChangedDelayed(textBox.Range);

            autoCompleteMenu = new AutocompleteMenu(textBox);
            autoCompleteMenu.ForeColor = Color.White;
            autoCompleteMenu.BackColor = Color.Gray;
            autoCompleteMenu.SelectedColor = Color.Purple;
            autoCompleteMenu.SearchPattern = @"[\w\.]";
            autoCompleteMenu.AllowTabKey = true;
            autoCompleteMenu.AlwaysShowTooltip = true;
            autoCompleteMenu.SearchPattern = @"[\w\.:=!<>]";

            List<AutocompleteItem> items = new List<AutocompleteItem>();

            string xmlTestPath = @"..\..\CrusaderKingsScripts.xml";

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

            items.Add(new AutocompleteItem("test_param = {\r\n\tvalue = \r\n}", -1, "test_param", "test object", "used for testing autocomplete"));

            items.Add(new InsertSpaceSnippet());
            items.Add(new InsertSpaceSnippet(@"^(\w+)([=<>!:]+)(\w+)$"));
            items.Add(new InsertEnterSnippet());

            autoCompleteMenu.Items.SetAutocompleteItems(items);
        }

        private void textBox_TextChangedDelayed(object sender, TextChangedEventArgs e)
        {
            //delete all markers
            textBox.Range.ClearFoldingMarkers();

            var currentIndent = 0;
            var lastNonEmptyLine = 0;

            for (int i = 0; i < textBox.LinesCount; i++)
            {
                var line = textBox[i];
                var spacesCount = line.StartSpacesCount;
                if (spacesCount == line.Count) //empty line
                    continue;

                if (currentIndent < spacesCount)
                    //append start folding marker
                    textBox[lastNonEmptyLine].FoldingStartMarker = "m" + currentIndent;
                else
                if (currentIndent > spacesCount)
                    //append end folding marker
                    textBox[lastNonEmptyLine].FoldingEndMarker = "m" + spacesCount;

                currentIndent = spacesCount;
                lastNonEmptyLine = i;
            }
        }

        private void textBox_AutoIndentNeeded(object sender, AutoIndentEventArgs e)
        {
            // we assign this handler to disable AutoIndent by folding
        }

        private void textBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.X < textBox.LeftIndent)
            {
                var place = textBox.PointToPlace(e.Location);
                if (textBox.Bookmarks.Contains(place.iLine))
                    textBox.Bookmarks.Remove(place.iLine);
                else
                    textBox.Bookmarks.Add(place.iLine);
            }
        }

        public void SetController(TextEditorController controller)
        {
            this.controller = controller;
        }

        public FastColoredTextBox GetTextBox()
        {
            return textBox;
        }

        // Snippets for AutoComplete

        
    }
}
