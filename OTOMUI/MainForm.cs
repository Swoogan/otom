using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using Otom.Core;
using Otom.Properties;

namespace Otom
{
    public partial class MainForm : Form
    {
        private Mapping _mapping;

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

            Settings.Default.LastSourceAssembly = sourceAssemblyDialog.FileName;
            Settings.Default.SourceInitialDir = Path.GetDirectoryName(sourceAssemblyDialog.FileName);
            Settings.Default.Save();
        }

        private void btnOpenDestinationAssembly_Click(object sender, EventArgs e)
        {
            destAssemblyDialog.InitialDirectory = Settings.Default.DestInitialDir;
            if (destAssemblyDialog.ShowDialog() != DialogResult.OK) return;
            txtAssemblyDestination.Text = destAssemblyDialog.FileName;

            Settings.Default.LastDestinationAssembly = sourceAssemblyDialog.FileName;
            Settings.Default.DestInitialDir = Path.GetDirectoryName(destAssemblyDialog.FileName);
            Settings.Default.Save();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadAssemblies();
        }

        private void LoadAssemblies()
        {
            lbPairs.Items.Clear();

            var source = new AssemblyInfo(txtAssemblySource.Text);
            
            if (txtAssemblyDestination.Text.Equals(txtAssemblySource.Text))
            {
                var classes = source.GetClasses();
                BindClassListBox(lbClassSource, classes, "Name");
                BindClassListBox(lbClassDestination, classes, "Name");
                _mapping = new Mapping(source, source);
            }
            else
            {
                BindClassListBox(lbClassSource, source.GetClasses(), "Name");
                var destination = new AssemblyInfo(txtAssemblyDestination.Text);
                BindClassListBox(lbClassDestination, destination.GetClasses(), "Name");
                _mapping = new Mapping(source, destination);
            }
        }

        private static void BindClassListBox(ListControl listBox, IEnumerable<ClassInfo> collection, String displayName)
        {
            listBox.DataSource = collection.OrderBy(c => c.Name).ToList();
            listBox.DisplayMember = displayName;
        }

        private void cbClassSource_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindPropertyListBox(lbPropertySource, SourceClass.Properties, "Name");
        }

        private void cbClassDestination_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindPropertyListBox(lbPropertyDestination, DestClass.Properties, "Name");
        }

        private static void BindPropertyListBox(ListControl listBox, IEnumerable<PropertyInfo> collection, String displayName)
        {
            listBox.DataSource = collection.OrderBy(p => p.Name).ToList();
            listBox.DisplayMember = displayName;
        }

        private void btnAddMapping_Click(object sender, EventArgs e)
        {
            if (lbPropertySource.SelectedItem == null || lbPropertyDestination.SelectedItem == null) return;

            var source = (PropertyInfo) lbPropertySource.SelectedItem;
            var dest = (PropertyInfo) lbPropertyDestination.SelectedItem;
            var pair = new PropertyMapping(source, dest);
            lbPairs.Items.Add(pair);
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if (lbPairs.Items.Count > 0)
            {
                var pairs = new List<PropertyMapping>(lbPairs.Items.Count);
                pairs.AddRange(lbPairs.Items.Cast<PropertyMapping>());
                var generatedCode = ObjectMapper.Map(pairs, SourceClass, DestClass, cbIncludeReverseMapping.Checked);
                new CodeMapping(generatedCode).ShowDialog(this);
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

                _mapping.SetPairs(lbPairs.Items);
                _mapping.SaveToDisk(filename);
            }
            else
            {
                const string message = "You must specifiy at least one property mapping before you can save.";
                MessageBox.Show(message, @"Unable to save mapping.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openMappingDialog.ShowDialog() != DialogResult.OK) return;
            var filename = openMappingDialog.FileName;
            LoadMapping(filename);
        }

        private string GenerateFileName()
        {
            return string.Format("{0}To{1}{2}", SourceClass.Name, DestClass.Name, Constants.FileExtention);
        }

        private void LoadMapping(string filename)
        {
            var mapping = Mapping.LoadFromDisk(filename);

            txtAssemblyDestination.Text = mapping.DestinationAssembly;
            txtAssemblySource.Text = mapping.SourceAssembly;

            LoadAssemblies();

            lbClassSource.SelectedItem = mapping.GetFirstSource();
            lbClassDestination.SelectedItem = mapping.GetFirstDest();
            lbPairs.Items.AddRange(GetPairs(mapping).ToArray());
        }

        private static IEnumerable<Object> GetPairs(Mapping mapping)
        {
            return mapping.PropertyMappings.Select(p => p);
        }
    }
}

