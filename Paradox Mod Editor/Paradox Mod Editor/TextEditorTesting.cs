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

namespace Paradox_Mod_Editor
{
    public partial class frmTextEditorTesting : Form, ITextEditorView
    {
        private FastColoredTextBox textBox;
        private TextEditorController controller;

        public frmTextEditorTesting()
        {
            InitializeComponent();
        }

        private void TextEditorTesting_Load(object sender, EventArgs e)
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
            // TODO: add bookmarking (?)
            // TODO: add diffmerge (put this elsewhere, its own tool/section)


            textBox.AutoCompleteBrackets = true;
            textBox.AutoIndentChars = true;

            // End Custom Properties

            this.Controls.Add(textBox);

            textBox.TextChangedDelayed += textBox_TextChangedDelayed;
            textBox.AutoIndentNeeded += textBox_AutoIndentNeeded;

            textBox.OnTextChangedDelayed(textBox.Range);
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

        public void SetController(TextEditorController controller)
        {
            this.controller = controller;
        }

        public FastColoredTextBox GetTextBox()
        {
            return textBox;
        }
    }
}
