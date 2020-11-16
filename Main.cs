using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mononucleosis_pro
{
    public partial class Main : Form
    {
        Keygen keygen = new Keygen();

        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            this.cbxVersion.SelectedIndex = Keygen.SUBLIME_TEXT;
            btnGenerate.PerformClick();
        }

        private void txtEmail_Enter(object sender, EventArgs e)
        {
            txtEmail.SelectAll();
        }

        private void txtEmail_Click(object sender, EventArgs e)
        {
            txtEmail.SelectAll();
        }

        private void txtLicense_Click(object sender, EventArgs e)
        {
            txtLicense.SelectAll();
        }

        private void cbxVersion_SelectedIndexChanged(object sender, EventArgs e)
        {
            generate();
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            generate();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            generate();
            txtLicense.SelectAll();
        }

        private void generate()
        {
            txtLicense.Text = keygen.Generate(cbxVersion.SelectedIndex, txtEmail.Text);
        }

    }
}
