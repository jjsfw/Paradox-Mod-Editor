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
        public string type = "Cancel";

        public frmNewScriptObjectDialog(List<string> types)
        {
            InitializeComponent();
            int i = 0;
            foreach (string obj in types)
            {
                RadioButton newRadioButton = new RadioButton();
                newRadioButton.Text = obj;
                newRadioButton.Location = new Point(12, 12 + 23 * i);
                if (i == 0)
                {
                    newRadioButton.Checked = true;
                }

                this.Controls.Add(newRadioButton);
                this.Height = newRadioButton.Height + newRadioButton.Location.Y + 12 * (i + 1) + 38;
                this.Width = newRadioButton.Location.X + newRadioButton.Width + 6;
                i++;
            }
        }

        private void frmNewScriptObjectDialog_Load(object sender, EventArgs e)
        {
            
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            RadioButton checkedButton = this.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);
            type = checkedButton.Text;
            this.Close();
        }
    }
}
