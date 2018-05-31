using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using FastColoredTextBoxNS;
using System.Xml.Linq;
using Paradox_Mod_Editor.Controllers;
using System.Text.RegularExpressions;

namespace Paradox_Mod_Editor.Views
{
    public partial class frmModEditor : Form, ITextEditorView
    {
        private string modDirectory;
        private FastColoredTextBox textBox;
        private AutocompleteMenu autocompleteMenu;
        private ModEditorController controller;
        private TreeNode currentNode;

        public frmModEditor(string modDirectory)
        {
            InitializeComponent();
            this.modDirectory = modDirectory;
        }

        private void frmModEditor_Load(object sender, EventArgs e)
        {
            CreateTextBox();
            DirectoryInfo rootInfo = new DirectoryInfo(modDirectory);
            trvModFolderStructure.Nodes.Add(buildModTree(rootInfo));
        }

        private TreeNode buildModTree(DirectoryInfo folderInfo)
        {
            TreeNode folderNode = new TreeNode(folderInfo.Name);
            foreach (DirectoryInfo directory in folderInfo.GetDirectories())
            {
                folderNode.Nodes.Add(buildModTree(directory));
            }
            foreach (FileInfo file in folderInfo.GetFiles())
            {
                folderNode.Nodes.Add(new TreeNode(file.Name));
            }

            return folderNode;
        }

        public FastColoredTextBox GetTextBox()
        {
            return textBox;
        }

        public void SetController(TextEditorController controller)
        {
            this.controller = (ModEditorController)controller;
        }

        public void CreateTextBox()
        {
            textBox = new FastColoredTextBox();
            textBox.Parent = pnlRawEdit;
            textBox.Location = new Point(0, 0);
            textBox.Dock = DockStyle.Fill;
            textBox.Show();
            // TODO: add diffmerge (put this elsewhere, its own tool/section)
            // TODO: make comments always override non-comment patterns
            textBox.SyntaxHighlighter = new SyntaxHighlighter(textBox);
            textBox.AutoCompleteBrackets = true;
            textBox.AutoIndentChars = false;
            textBox.AutoIndentExistingLines = true;
            textBox.AutoIndent = true;
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
            textBox.BringToFront();

            autocompleteMenu = new AutocompleteMenu(textBox);
            autocompleteMenu.ForeColor = Color.White;
            autocompleteMenu.BackColor = Color.Gray;
            autocompleteMenu.SelectedColor = Color.Purple;
            autocompleteMenu.SearchPattern = @"[\w\.]";
            autocompleteMenu.AllowTabKey = true;
            autocompleteMenu.AlwaysShowTooltip = true;
            autocompleteMenu.SearchPattern = @"[\w\.:=!<>]";

            autocompleteMenu.Items.SetAutocompleteItems(controller.LoadAutocompleteItems());
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
            if (textBox.Text != controller.ReadFile())
            {
                controller.UpdateFile(textBox.Text);
                if (currentNode != null)
                {
                    currentNode.BackColor = Color.Yellow;
                }
            }
            else
            {
                if (currentNode != null)
                {
                    currentNode.BackColor = Color.White;
                }
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

        private void trvModFolderStructure_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (Regex.IsMatch(e.Node.Text, @"^[^\\\.\s]+\.[^\\\.\s]+$")) {
                controller.LoadSelectedFile(textBox, e.Node);
                currentNode = e.Node;
            }
        }
    }
}
