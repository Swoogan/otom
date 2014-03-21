using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

using OTOM;
using Otom.Properties;

namespace Otom
{
    public partial class MainForm : Form
    {
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
            lbPairs.Items.Clear();

            var classInfo = new AssemblyInfo(txtAssemblySource.Text);

            if (txtAssemblyDestination.Text.Equals(txtAssemblySource.Text))
            {
                var classes = classInfo.GetClassesFromAssembly().ToList();
                BindListBox(lbClassSource, classes, "Name");
                BindListBox(lbClassDestination, classes, "Name");
            }
            else
            {
                BindListBox(lbClassSource, classInfo.GetClassesFromAssembly(), "Name");
                var destInfo = new AssemblyInfo(txtAssemblyDestination.Text);
                BindListBox(lbClassDestination, destInfo.GetClassesFromAssembly(), "Name");
            }
        }

        private static void BindListBox(ListControl listBox, IEnumerable<Type> collection, String displayName)
        {
            listBox.DataSource = collection.OrderBy(p => p.Name).ToList();
            listBox.DisplayMember = displayName;
        }

        private static void BindListBox(ListControl listBox, IEnumerable<PropertyInfo> collection, String displayName)
        {
            listBox.DataSource = collection.OrderBy(p => p.Name).ToList();
            listBox.DisplayMember = displayName;
        }

        private void cbClassSource_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindListBox(lbPropertySource, SourceClass.GetProperties(), "Name");
        }

        private void cbClassDestination_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindListBox(lbPropertyDestination, DestClass.GetProperties(), "Name");
        }

        private void btnAddMapping_Click(object sender, EventArgs e)
        {
            if (lbPropertySource.SelectedItem == null || lbPropertyDestination.SelectedItem == null) return;
            var pair = new PropertyPair((PropertyInfo)lbPropertySource.SelectedItem, (PropertyInfo)lbPropertyDestination.SelectedItem);
            lbPairs.Items.Add(pair);
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if (lbPairs.Items.Count > 0)
            {
                var pairs = new List<PropertyPair>(lbPairs.Items.Count);
                pairs.AddRange(lbPairs.Items.Cast<PropertyPair>());
                var mapping = ObjectMapper.Map(pairs, SourceClass, DestClass, cbIncludeReverseMapping.Checked);
                new CodeMapping(mapping).ShowDialog(this);
            }
            else
            {
                const string message = "You must specifiy at least one property mapping before you can generate.";
                MessageBox.Show(message, @"Unable to generate mapping.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

        #region Loading and Saving

        private void btnSaveMapping_Click(object sender, EventArgs e)
        {
            if (lbPairs.Items.Count > 0)
            {
                saveMappingDialog.FileName = GenerateFileName();
                if (saveMappingDialog.ShowDialog() != DialogResult.OK) return;
                var filename = saveMappingDialog.FileName;

                var mapping = new Mapping(lbPairs.Items);
                mapping.SaveToDisk(filename);
            }
            else
            {
                const string message = "You must specifiy at least one property mapping before you can save.";
                MessageBox.Show(message, @"Unable to save mapping.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private Type SourceClass
        {
            get { return (Type)lbClassSource.SelectedItem; }
        }

        private Type DestClass
        {
            get { return (Type)lbClassDestination.SelectedItem; }
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

        private void LoadMapping(String filename)
        {
            var mapping = Mapping.LoadFromDisk(filename);

            txtAssemblyDestination.Text = mapping.DestinationAssembly;
            txtAssemblySource.Text = mapping.SourceAssembly;

            btnLoad_Click(null, null);

            var sourceInfo = new AssemblyInfo(mapping.SourceAssembly);
            lbClassSource.SelectedItem = sourceInfo.GetTypeByName(mapping.PropertyMappings[0].SourceType);

            var destInfo = new AssemblyInfo(mapping.DestinationAssembly);
            lbClassDestination.SelectedItem = destInfo.GetTypeByName(mapping.PropertyMappings[0].DestinationType);

            foreach (var propMapping in mapping.PropertyMappings)
            {
                var pair = new PropertyPair
                {
                    Source = sourceInfo.GetPropertyByName(propMapping.SourceType, propMapping.SourceName),
                    Destination = destInfo.GetPropertyByName(propMapping.DestinationType, propMapping.DestinationName)
                };

                lbPairs.Items.Add(pair);
            }
        }

        #endregion
    }
}