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

            // TODO: add autocomplete
            // TODO: add hints
            // TODO: add context highlighting
            // TODO: add indentation after brackets
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
            //  textBox.FoldingIndicatorColor = testingColorBright;

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
            //autoCompleteMenu.Items.ImageList = imlAutoComplete;
            autoCompleteMenu.SearchPattern = @"[\w\.:=!<>]";

            List<AutocompleteItem> items = new List<AutocompleteItem>();

            //items.Add(new AutocompleteItem("AND", -1, "AND", "AND", "Returns true if all enclosed conditions return true. This is the default operator."));
            //items.Add(new AutocompleteItem("OR"));
            //items.Add(new AutocompleteItem("NOT"));
            //items.Add(new AutocompleteItem("NOR"));
            //items.Add(new AutocompleteItem("NAND"));

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
                items.Add(new AutocompleteItem(names.ElementAt(i).Value, -1, names.ElementAt(i).Value, names.ElementAt(i).Value, desc.ElementAt(i).Value));
            }

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

        /// <summary>
        /// This item appears when any part of snippet text is typed
        /// </summary>
        class DeclarationSnippet : SnippetAutocompleteItem
        {
            public DeclarationSnippet(string snippet)
                : base(snippet)
            {
            }

            public override CompareResult Compare(string fragmentText)
            {
                var pattern = Regex.Escape(fragmentText);
                if (Regex.IsMatch(Text, "\\b" + pattern, RegexOptions.IgnoreCase))
                    return CompareResult.Visible;
                return CompareResult.Hidden;
            }
        }

        /// <summary>
        /// Divides numbers and words: "123AND456" -> "123 AND 456"
        /// Or "i=2" -> "i = 2"
        /// </summary>
        class InsertSpaceSnippet : AutocompleteItem
        {
            string pattern;

            public InsertSpaceSnippet(string pattern) : base("")
            {
                this.pattern = pattern;
            }

            public InsertSpaceSnippet()
                : this(@"^(\d+)([a-zA-Z_]+)(\d*)$")
            {
            }

            public override CompareResult Compare(string fragmentText)
            {
                if (Regex.IsMatch(fragmentText, pattern))
                {
                    Text = InsertSpaces(fragmentText);
                    if (Text != fragmentText)
                        return CompareResult.Visible;
                }
                return CompareResult.Hidden;
            }

            public string InsertSpaces(string fragment)
            {
                var m = Regex.Match(fragment, pattern);
                if (m == null)
                    return fragment;
                if (m.Groups[1].Value == "" && m.Groups[3].Value == "")
                    return fragment;
                return (m.Groups[1].Value + " " + m.Groups[2].Value + " " + m.Groups[3].Value).Trim();
            }

            public override string ToolTipTitle
            {
                get
                {
                    return Text;
                }
            }
        }

        /// <summary>
        /// Inerts line break after '}'
        /// </summary>
        class InsertEnterSnippet : AutocompleteItem
        {
            Place enterPlace = Place.Empty;

            public InsertEnterSnippet()
                : base("[Line break]")
            {
            }

            public override CompareResult Compare(string fragmentText)
            {
                var r = Parent.Fragment.Clone();
                while (r.Start.iChar > 0)
                {
                    if (r.CharBeforeStart == '}')
                    {
                        enterPlace = r.Start;
                        return CompareResult.Visible;
                    }

                    r.GoLeftThroughFolded();
                }

                return CompareResult.Hidden;
            }

            public override string GetTextForReplace()
            {
                //extend range
                Range r = Parent.Fragment;
                Place end = r.End;
                r.Start = enterPlace;
                r.End = r.End;
                //insert line break
                return Environment.NewLine + r.Text;
            }

            public override void OnSelected(AutocompleteMenu popupMenu, SelectedEventArgs e)
            {
                base.OnSelected(popupMenu, e);
                if (Parent.Fragment.tb.AutoIndent)
                    Parent.Fragment.tb.DoAutoIndent();
            }

            public override string ToolTipTitle
            {
                get
                {
                    return "Insert line break after '}'";
                }
            }
        }
    }
}
