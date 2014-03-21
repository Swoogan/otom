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

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtGeneratedCode.SelectedText);
        }

        private void CodeMapping_Load(object sender, EventArgs e)
        {
            Clipboard.SetText(txtGeneratedCode.Text);
        }
    }
}
