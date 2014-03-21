using System;
using System.Windows.Forms;

namespace Otom
{
    public partial class GeneratedCodeForm : Form
    {
        public GeneratedCodeForm(string codeMapping)
        {
            InitializeComponent();
            codeRichTextBox.Text = codeMapping;
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(codeRichTextBox.SelectedText);
        }

        private void GeneratedCodeForm_Load(object sender, EventArgs e)
        {
            Clipboard.SetText(codeRichTextBox.Text);
        }
    }
}
