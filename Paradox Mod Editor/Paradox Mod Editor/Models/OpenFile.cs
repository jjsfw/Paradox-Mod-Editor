using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using FastColoredTextBoxNS;

namespace Paradox_Mod_Editor.Models
{
    class OpenFile
    {
        private string path;
        private string contents;
        private FileState state = FileState.Saved;
        private LimitedStack<UndoableCommand> history;
        private Stack<UndoableCommand> redoStack;

        // TODO: store bookmarks

        public OpenFile(string path)
        {
            this.path = path;
            this.contents = File.ReadAllText(path);
        }

        public OpenFile(string path, string contents)
        {
            this.path = path;
            this.contents = contents;
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

        public void SetUndoRedo(LimitedStack<UndoableCommand> history, Stack<UndoableCommand> redoStack)
        {
            this.history = history;
            this.redoStack = redoStack;
        }

        public LimitedStack<UndoableCommand> GetHistory()
        {
            return history;
        }

        public Stack<UndoableCommand> GetRedoStack()
        {
            return redoStack;
        }
    }

    public enum FileState
    {
        Unsaved,
        Saved
    }
}
