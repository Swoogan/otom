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

<<<<<<< HEAD
        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtGeneratedCode.SelectedText);
        }

        private void CodeMapping_Load(object sender, EventArgs e)
        {
            Clipboard.SetText(txtGeneratedCode.Text);
=======
        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtGeneratedCode.Text);
            MessageBox.Show("Copied to clipboard!", "Complete!", MessageBoxButtons.OK, MessageBoxIcon.Information);
>>>>>>> a811530542d78892b92fdb1deb04d17a2432e571
        }
    }
}
