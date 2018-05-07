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
    public partial class frmGameSelection : Form
    {
        public frmGameSelection()
        {
            InitializeComponent();
        }

        private void frmGameSelection_Load(object sender, EventArgs e)
        {
            // Testing
            /*this.Hide();
            Form testForm = new frmTextEditorTesting();
            testForm.ShowDialog();*/
            //
        }

        private void btnCK2_Click(object sender, EventArgs e)
        {
            showModSelect(ParadoxTitle.CrusaderKings);
        }

        private void btnEU4_Click(object sender, EventArgs e)
        {
            showModSelect(ParadoxTitle.EuropaUniversalis);
        }

        private void btnHOI4_Click(object sender, EventArgs e)
        {
            showModSelect(ParadoxTitle.HeartsOfIron);
        }

        private void btnStellaris_Click(object sender, EventArgs e)
        {
            showModSelect(ParadoxTitle.Stellaris);
        }

        private void showModSelect(ParadoxTitle game)
        {
            Form modSelect = new frmModSelect(game);
            this.Hide();
            modSelect.ShowDialog();
            this.Show();
        }
    }

    public enum ParadoxTitle
    {
        CrusaderKings,
        EuropaUniversalis,
        HeartsOfIron,
        Stellaris
    }
}
