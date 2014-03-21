using System;
using System.Windows.Forms;

namespace OTOMUI
{
    public partial class CodeMapping : Form
    {
        public CodeMapping(String codeMapping)
        {
            InitializeComponent();
            txtGeneratedCode.Text = codeMapping;
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtGeneratedCode.Text);
            MessageBox.Show("Copied to clipboard!", "Complete!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
