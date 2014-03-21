using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

using OTOM;
using OTOMUI.Properties;

namespace OTOMUI
{
    public partial class ObjectToObjectMapper : Form
    {
        public ObjectToObjectMapper()
        {
            InitializeComponent();

            if (Environment.GetCommandLineArgs().Length <= 0) return;

            var args = Environment.GetCommandLineArgs();

            foreach (var arg in args.Where(arg => arg.Contains(OtomConstants.FileExtention)))
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

            if (txtAssemblyDestination.Text.Equals(txtAssemblySource.Text))
            {
                var classes = ClassInfo.GetTypesFromAssembly(txtAssemblySource.Text).ToList();
                BindListBox(lbClassSource, classes, "Name");
                BindListBox(lbClassDestination, classes, "Name");
            }
            else
            {
                BindListBox(lbClassSource, ClassInfo.GetTypesFromAssembly(txtAssemblySource.Text), "Name");
                BindListBox(lbClassDestination, ClassInfo.GetTypesFromAssembly(txtAssemblyDestination.Text), "Name");
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
            BindListBox(lbPropertySource, ((Type)lbClassSource.SelectedItem).GetProperties(), "Name");
        }

        private void cbClassDestination_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindListBox(lbPropertyDestination, ((Type)lbClassDestination.SelectedItem).GetProperties(), "Name");
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
                var mapping = ObjectMapper.Map(pairs, (Type)lbClassSource.SelectedItem, (Type)lbClassDestination.SelectedItem, cbIncludeReverseMapping.Checked);
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
            new AboutOTOM().Show(this);
        }

        #region Loading and Saving

        private void btnSaveMapping_Click(object sender, EventArgs e)
        {
            if (lbPairs.Items.Count > 0)
            {
                var mapping = CreateMapping();

                saveMappingDialog.FileName = GenerateFileName();

                if (saveMappingDialog.ShowDialog(this) != DialogResult.OK) return;
                var filename = saveMappingDialog.FileName;
                mapping.SaveToDisk(filename);
            }
            else
            {
                const string message = "You must specifiy at least one property mapping before you can save.";
                MessageBox.Show(message, @"Unable to save mapping.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private string GenerateFileName()
        {
            return string.Format("{0}To{1}{2}", ((Type)lbClassSource.SelectedItem).Name, ((Type)lbClassDestination.SelectedItem).Name, OtomConstants.FileExtention);
        }

        private Mapping CreateMapping()
        {
            var propertyPair = (PropertyPair)lbPairs.Items[0];

            var mapping = new Mapping
            {
                SourceAssembly = propertyPair.Source.DeclaringType.Assembly.Location, 
                DestinationAssembly = propertyPair.Destination.DeclaringType.Assembly.Location
            };

            foreach (PropertyPair pair in lbPairs.Items)
            {
                mapping.PropertyMappings.Add(new PropertyMapping(pair));
            }

            return mapping;
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

            lbClassSource.SelectedItem = ClassInfo.GetTypeByName(mapping.SourceAssembly, mapping.PropertyMappings[0].SourceType);
            lbClassDestination.SelectedItem = ClassInfo.GetTypeByName(mapping.DestinationAssembly, mapping.PropertyMappings[0].DestinationType);

            foreach (var propMapping in mapping.PropertyMappings)
            {
                var pair = new PropertyPair
                {
                    Source =
                        ClassInfo.GetPropertyByName(mapping.SourceAssembly, propMapping.SourceType,
                            propMapping.SourceName),
                    Destination =
                        ClassInfo.GetPropertyByName(mapping.DestinationAssembly, propMapping.DestinationType,
                            propMapping.DestinationName)
                };

                lbPairs.Items.Add(pair);
            }
        }

        #endregion
    }
}