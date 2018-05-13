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

namespace Paradox_Mod_Editor.Views
{
    public partial class frmModEditor : Form
    {
        private string modDirectory;

        public frmModEditor(string modDirectory)
        {
            InitializeComponent();
            this.modDirectory = modDirectory;
        }

        private void frmModEditor_Load(object sender, EventArgs e)
        {
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
    }
}
