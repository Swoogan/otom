using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Otom.Core;
using Otom.Core.Generate;
using Otom.Properties;

namespace Otom
{
    public partial class MainForm : Form
    {
        private ClassInfo SourceClass
        {
            get { return (ClassInfo)lbClassSource.SelectedItem; }
        }

        private ClassInfo DestClass
        {
            get { return (ClassInfo)lbClassDestination.SelectedItem; }
        }

        public MainForm()
        {
            InitializeComponent();

            if (Environment.GetCommandLineArgs().Length <= 0) return;

            var args = Environment.GetCommandLineArgs();

            foreach (var arg in args.Where(arg => arg.Contains(Constants.FileExtention)))
                LoadMapping(arg);
        }

        private void ObjectToObjectMapper_Load(object sender, EventArgs e)
        {
            txtAssemblySource.Text = Settings.Default.LastSourceAssembly;
            sourceAssemblyDialog.InitialDirectory = Settings.Default.SourceInitialDir;
            txtAssemblyDestination.Text = Settings.Default.LastDestinationAssembly;
            destAssemblyDialog.InitialDirectory = Settings.Default.DestInitialDir;
        }

        private void btnOpenSourceAssembly_Click(object sender, EventArgs e)
        {
            sourceAssemblyDialog.InitialDirectory = Settings.Default.SourceInitialDir;
            if (sourceAssemblyDialog.ShowDialog() != DialogResult.OK) return;
            txtAssemblySource.Text = sourceAssemblyDialog.FileName;

            Settings.Default.SourceInitialDir = Path.GetDirectoryName(sourceAssemblyDialog.FileName);
            Settings.Default.Save();
        }

        private void btnOpenDestinationAssembly_Click(object sender, EventArgs e)
        {
            destAssemblyDialog.InitialDirectory = Settings.Default.DestInitialDir;
            if (destAssemblyDialog.ShowDialog() != DialogResult.OK) return;
            txtAssemblyDestination.Text = destAssemblyDialog.FileName;

            Settings.Default.DestInitialDir = Path.GetDirectoryName(destAssemblyDialog.FileName);
            Settings.Default.Save();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadAssemblies();
        }

        private void LoadAssemblies()
        {
            if (string.IsNullOrWhiteSpace(txtAssemblySource.Text))
            {
                MessageBox.Show(Resources.SelectSource);
                return;
            }
            
            if (string.IsNullOrWhiteSpace(txtAssemblyDestination.Text))
            {
                MessageBox.Show(Resources.SelectDestination);
                return;
            }

            // TODO: This should only run if the assemblies successfully load
            Settings.Default.LastSourceAssembly = txtAssemblySource.Text;
            Settings.Default.LastDestinationAssembly = txtAssemblyDestination.Text;
            Settings.Default.Save();

            lbPairs.Items.Clear();

            var source = new AssemblyInfo(txtAssemblySource.Text);
            
            if (txtAssemblyDestination.Text.Equals(txtAssemblySource.Text))
            {
                var classes = source.GetClasses();
                BindClassListBox(lbClassSource, classes, "Name");
                BindClassListBox(lbClassDestination, classes, "Name");
            }
            else
            {
                BindClassListBox(lbClassSource, source.GetClasses(), "Name");
                var destination = new AssemblyInfo(txtAssemblyDestination.Text);
                BindClassListBox(lbClassDestination, destination.GetClasses(), "Name");
            }
        }

        private static void BindClassListBox(ListControl listBox, IEnumerable<ClassInfo> collection, String displayName)
        {
            listBox.DataSource = collection.OrderBy(c => c.Name).ToList();
            listBox.DisplayMember = displayName;
        }

        private void cbClassSource_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbPropertySource.DataSource = SourceClass.Properties;
        }

        private void cbClassDestination_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbPropertyDestination.DataSource = DestClass.Properties;
        }

        private void btnAddMapping_Click(object sender, EventArgs e)
        {
            if (lbPropertySource.SelectedItem == null || lbPropertyDestination.SelectedItem == null) return;

            var source = lbPropertySource.SelectedValue.ToString();
            var dest = lbPropertyDestination.SelectedValue.ToString();
            lbPairs.Items.Add(new PropertyPair(source, dest));
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if (lbPairs.Items.Count > 0)
            {
                var pairs = new List<PropertyPair>(lbPairs.Items.Count);
                pairs.AddRange(lbPairs.Items.Cast<PropertyPair>());

                var generatedCode = CodeGenerator.Generate(new GenerateInfo
                {
                  SourceClass = SourceClass, 
                  DestinationClass = DestClass,
                  Pairs = pairs, 
                  Reverse = cbIncludeReverseMapping.Checked
                });

                new GeneratedCodeForm(generatedCode).ShowDialog(this);
            }
            else
            {
                const string message = "You must specifiy at least one property mapping before you can generate.";
                MessageBox.Show(message, @"Unable to generate mapping.", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }
        }

        private void btnRemoveMapping_Click(object sender, EventArgs e)
        {
            switch (lbPairs.SelectionMode)
            {
                case SelectionMode.One:
                    if (lbPairs.SelectedItem != null)
                        lbPairs.Items.Remove(lbPairs.SelectedItem);
                    break;
                case SelectionMode.MultiExtended:
                case SelectionMode.MultiSimple:
                    var selection = new List<Object>(lbPairs.SelectedItems.Count);
                    selection.AddRange(lbPairs.SelectedItems.Cast<object>());

                    foreach (var o in selection)
                        lbPairs.Items.Remove(o);

                    break;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AboutForm().Show(this);
        }

        private void btnSaveMapping_Click(object sender, EventArgs e)
        {
            if (lbPairs.Items.Count > 0)
            {
                saveMappingDialog.FileName = GenerateFileName();
                if (saveMappingDialog.ShowDialog() != DialogResult.OK) return;
                var filename = saveMappingDialog.FileName;

                // TODO: Re-validate that they entered stuff
                var mapfile = new MapFile
                {
                    Destination = new MapTarget(txtAssemblySource.Text, SourceClass),
                    Source = new MapTarget(txtAssemblyDestination.Text, DestClass),
                    PropertyPairs = lbPairs.Items.Cast<PropertyPair>().ToList()
                };
                
                MapStore.SaveToDisk(filename, mapfile);
            }
            else
            {
                const string message = "You must specifiy at least one property mapping before you can save.";
                MessageBox.Show(message, @"Unable to save mapping.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private string GenerateFileName()
        {
            return string.Format("{0}To{1}{2}", SourceClass.Name, DestClass.Name, Constants.FileExtention);
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openMappingDialog.ShowDialog() != DialogResult.OK) return;
            var filename = openMappingDialog.FileName;
            LoadMapping(filename);
        }

        private void LoadMapping(string filename)
        {
            var mapping = MapStore.LoadFromDisk(filename);

            txtAssemblyDestination.Text = mapping.Destination.AssemblyPath;
            txtAssemblySource.Text = mapping.Source.AssemblyPath;

            LoadAssemblies();

            lbClassSource.SelectedIndex = lbClassSource.FindStringExact(mapping.Source.ClassType.Name);
            lbClassDestination.SelectedIndex = lbClassSource.FindStringExact(mapping.Destination.ClassType.Name);
            lbPairs.DataSource = mapping.PropertyPairs;
        }
    }
}

