using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FastColoredTextBoxNS;
using System.Drawing;

namespace Paradox_Mod_Editor.Models
{
    public sealed class TextBoxFactory : ControlFactory
    {
        static readonly TextBoxFactory factory = new TextBoxFactory();

        public override Control GetControl()
        {
            throw new NotImplementedException();
        }

        public Control GetControl(IEnumerable<AutocompleteItem> autocompleteItems)
        {
            FastColoredTextBox textBox = new FastColoredTextBox();
            AutocompleteMenu autocompleteMenu = new AutocompleteMenu(textBox);

            textBox = new FastColoredTextBox();
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

            autocompleteMenu.Items.SetAutocompleteItems(autocompleteItems);

            return textBox;
        }

        public new static TextBoxFactory GetFactory()
        {
            return factory;
        }
    }
}
