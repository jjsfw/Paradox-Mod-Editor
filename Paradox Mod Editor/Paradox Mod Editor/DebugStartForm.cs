using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Paradox_Mod_Editor.Controllers;
using Paradox_Mod_Editor.Views;

namespace Paradox_Mod_Editor
{
    public partial class DebugStartForm : Form
    {
        public DebugStartForm()
        {
            InitializeComponent();
        }

        private void DebugStartForm_Load(object sender, EventArgs e)
        {
            var modEditor = new frmModEditor(@"D:\Users\jjsfw\Documents\Paradox Interactive\Crusader Kings II\mod\Editor Testing");
            ModEditorController controller = new ModEditorController(modEditor, ParadoxTitle.CrusaderKings, @"D:\Users\jjsfw\Documents\Paradox Interactive\Crusader Kings II\mod\Editor Testing");
            this.Hide();
            modEditor.ShowDialog();
            this.Close();
        }
    }
}
