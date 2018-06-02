using Paradox_Mod_Editor.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paradox_Mod_Editor.Basic_Forms
{
    public partial class frmNewScriptObjectDialog : Form
    {
        private const int RadioButtonHeight = 17;

        public frmNewScriptObjectDialog(List<ScriptObject> types)
        {
            InitializeComponent();
            int i = 0;
            foreach (ScriptObject obj in types)
            {
                RadioButton newRadioButton = new RadioButton();
                newRadioButton.Text = obj.Name;
                newRadioButton.Location = new Point(12, 12 + 23 * i);
                if (i == 0)
                {
                    newRadioButton.Checked = true;
                }

                this.Controls.Add(newRadioButton);
            }
        }

        private void frmNewScriptObjectDialog_Load(object sender, EventArgs e)
        {

        }
    }
}
