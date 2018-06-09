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
        private ModEditorController controller;
        private TreeNode currentNode;

        public frmModEditor(string modDirectory)
        {
            InitializeComponent();
            this.modDirectory = modDirectory;
        }

        private void frmModEditor_Load(object sender, EventArgs e)
        {
            // TODO: starting texbox
            // CreateTextBox();
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

        public void AddTextBoxToView(FastColoredTextBox newTextBox)
        {
            newTextBox.TextChangedDelayed += textBox_TextChangedDelayed;
            newTextBox.AutoIndentNeeded += textBox_AutoIndentNeeded;
            newTextBox.MouseDoubleClick += textBox_MouseDoubleClick;

            newTextBox.Parent = pnlRawEdit;
            this.Controls.Add(newTextBox);
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
                if (textBox != null)
                {
                    textBox.Hide();
                }
                FastColoredTextBox loadedBox = controller.LoadSelectedFileTextBox(e.Node);
                if (loadedBox != null)
                {
                    textBox = loadedBox;
                }
                if (textBox != null)
                {
                    textBox.Parent = pnlRawEdit;
                    textBox.Show();
                }
                currentNode = e.Node;
            }
        }
    }
}
