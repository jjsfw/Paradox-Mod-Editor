﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using FastColoredTextBoxNS;

namespace Paradox_Mod_Editor.Models
{
    public class OpenFile
    {
        private string path;
        private string contents;
        private FileState state = FileState.Saved;
        public FastColoredTextBox textBox { get; }

        public OpenFile(string path, FastColoredTextBox textBox)
        {
            this.path = path;
            this.contents = File.ReadAllText(path);
            this.textBox = textBox;
            this.textBox.Text = this.contents;
            this.textBox.GetLines().Manager.ClearHistory();
        }

        public OpenFile(string path, string contents, FastColoredTextBox textBox)
        {
            this.path = path;
            this.contents = contents;
            this.textBox = textBox;
            this.textBox.Text = this.contents;
            this.textBox.GetLines().Manager.ClearHistory();
        }

        public void UpdateContents(string newContents)
        {
            this.contents = newContents;
            this.state = FileState.Unsaved;
        }

        public void UpdateContentsIgnoreSave(string newContents)
        {
            this.contents = newContents;
        }

        public string GetContents()
        {
            return contents;
        }

        public string GetPath()
        {
            return path;
        }

        public bool IsChanged()
        {
            return textBox.GetLines().Manager.GetHistory().Count > 0;
        }
    }

    public enum FileState
    {
        Unsaved,
        Saved
    }
}
