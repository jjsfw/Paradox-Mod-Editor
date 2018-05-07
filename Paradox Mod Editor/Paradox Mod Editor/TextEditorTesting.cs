using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paradox_Mod_Editor
{
    public partial class frmTextEditorTesting : Form
    {
        private TextEditor textEditor;

        public frmTextEditorTesting()
        {
            InitializeComponent();
        }

        private void TextEditorTesting_Load(object sender, EventArgs e)
        {
            textEditor = new TextEditor(rtbTest);
        }
    }
}
