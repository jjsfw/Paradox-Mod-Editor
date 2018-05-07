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

namespace Paradox_Mod_Editor
{
    public partial class frmModSelect : Form
    {
        private ParadoxTitle game;

        public frmModSelect(ParadoxTitle game)
        {
            InitializeComponent();
            this.game = game;
            switch (game)
            {
                case ParadoxTitle.CrusaderKings:
                    this.Text = "Crusader Kings II";
                    break;
                case ParadoxTitle.EuropaUniversalis:
                    this.Text = "Europa Universalis IV";
                    break;
                case ParadoxTitle.HeartsOfIron:
                    this.Text = "Hearts of Iron IV";
                    break;
                case ParadoxTitle.Stellaris:
                    this.Text = "Stellaris";
                    break;
            }
            this.Text += " Mod Editor";
        }

        private void frmModSelect_Load(object sender, EventArgs e)
        {

        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            fbdModDirectory.ShowNewFolderButton = radNew.Checked;
            fbdModDirectory.ShowDialog();
            txtModDirectory.Text = fbdModDirectory.SelectedPath;
        }

        private void radNew_CheckedChanged(object sender, EventArgs e)
        {
            if (radNew.Checked)
            {
                btnCreateLoad.Text = "Create Mod";
            }
            else
            {
                btnCreateLoad.Text = "Load Mod";
            }
        }

        private void btnCreateLoad_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(txtModDirectory.Text))
            {
                
            }
            else
            {
                MessageBox.Show("The input directory does not exist.", "Directory Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
