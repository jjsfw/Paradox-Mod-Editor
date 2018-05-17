using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Paradox_Mod_Editor.Models
{
    class OpenFile
    {
        private string path;
        private string contents;
        private FileState state = FileState.Saved;

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
    }

    public enum FileState
    {
        Unsaved,
        Saved
    }
}
