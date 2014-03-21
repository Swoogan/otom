namespace Otom
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.txtAssemblySource = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOpenSourceAssembly = new System.Windows.Forms.Button();
            this.btnOpenDestinationAssembly = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAssemblyDestination = new System.Windows.Forms.TextBox();
            this.lbClassSource = new System.Windows.Forms.ListBox();
            this.lbClassDestination = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbPropertyDestination = new System.Windows.Forms.ListBox();
            this.lbPropertySource = new System.Windows.Forms.ListBox();
            this.btnAddMapping = new System.Windows.Forms.Button();
            this.btnRemoveMapping = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.lbPairs = new System.Windows.Forms.ListBox();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.cbIncludeReverseMapping = new System.Windows.Forms.CheckBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSaveMapping = new System.Windows.Forms.Button();
            this.saveMappingDialog = new System.Windows.Forms.SaveFileDialog();
            this.openMappingDialog = new System.Windows.Forms.OpenFileDialog();
            this.sourceAssemblyDialog = new System.Windows.Forms.OpenFileDialog();
            this.destAssemblyDialog = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtAssemblySource
            // 
            this.txtAssemblySource.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAssemblySource.Location = new System.Drawing.Point(6, 32);
            this.txtAssemblySource.Name = "txtAssemblySource";
            this.txtAssemblySource.Size = new System.Drawing.Size(754, 20);
            this.txtAssemblySource.TabIndex = 0;
            this.txtAssemblySource.Text = "C:\\";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Assembly Containing Source Type";
            // 
            // btnOpenSourceAssembly
            // 
            this.btnOpenSourceAssembly.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenSourceAssembly.Location = new System.Drawing.Point(766, 29);
            this.btnOpenSourceAssembly.Name = "btnOpenSourceAssembly";
            this.btnOpenSourceAssembly.Size = new System.Drawing.Size(30, 23);
            this.btnOpenSourceAssembly.TabIndex = 2;
            this.btnOpenSourceAssembly.Text = "...";
            this.btnOpenSourceAssembly.UseVisualStyleBackColor = true;
            this.btnOpenSourceAssembly.Click += new System.EventHandler(this.btnOpenSourceAssembly_Click);
            // 
            // btnOpenDestinationAssembly
            // 
            this.btnOpenDestinationAssembly.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenDestinationAssembly.Location = new System.Drawing.Point(766, 75);
            this.btnOpenDestinationAssembly.Name = "btnOpenDestinationAssembly";
            this.btnOpenDestinationAssembly.Size = new System.Drawing.Size(30, 23);
            this.btnOpenDestinationAssembly.TabIndex = 5;
            this.btnOpenDestinationAssembly.Text = "...";
            this.btnOpenDestinationAssembly.UseVisualStyleBackColor = true;
            this.btnOpenDestinationAssembly.Click += new System.EventHandler(this.btnOpenDestinationAssembly_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(187, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Assembly Containing Destination Type";
            // 
            // txtAssemblyDestination
            // 
            this.txtAssemblyDestination.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAssemblyDestination.Location = new System.Drawing.Point(6, 77);
            this.txtAssemblyDestination.Name = "txtAssemblyDestination";
            this.txtAssemblyDestination.Size = new System.Drawing.Size(754, 20);
            this.txtAssemblyDestination.TabIndex = 3;
            this.txtAssemblyDestination.Text = "C:\\";
            // 
            // lbClassSource
            // 
            this.lbClassSource.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lbClassSource.FormattingEnabled = true;
            this.lbClassSource.Location = new System.Drawing.Point(12, 191);
            this.lbClassSource.Name = "lbClassSource";
            this.lbClassSource.Size = new System.Drawing.Size(242, 212);
            this.lbClassSource.TabIndex = 6;
            this.lbClassSource.SelectedIndexChanged += new System.EventHandler(this.cbClassSource_SelectedIndexChanged);
            // 
            // lbClassDestination
            // 
            this.lbClassDestination.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbClassDestination.FormattingEnabled = true;
            this.lbClassDestination.Location = new System.Drawing.Point(278, 191);
            this.lbClassDestination.Name = "lbClassDestination";
            this.lbClassDestination.Size = new System.Drawing.Size(199, 212);
            this.lbClassDestination.TabIndex = 7;
            this.lbClassDestination.SelectedIndexChanged += new System.EventHandler(this.cbClassDestination_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 175);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Source Class";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(275, 175);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Destination Class";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(275, 419);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Destination Properties";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 419);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Source Properties";
            // 
            // lbPropertyDestination
            // 
            this.lbPropertyDestination.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbPropertyDestination.FormattingEnabled = true;
            this.lbPropertyDestination.Location = new System.Drawing.Point(278, 435);
            this.lbPropertyDestination.Name = "lbPropertyDestination";
            this.lbPropertyDestination.Size = new System.Drawing.Size(199, 225);
            this.lbPropertyDestination.TabIndex = 11;
            // 
            // lbPropertySource
            // 
            this.lbPropertySource.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbPropertySource.FormattingEnabled = true;
            this.lbPropertySource.Location = new System.Drawing.Point(12, 435);
            this.lbPropertySource.Name = "lbPropertySource";
            this.lbPropertySource.Size = new System.Drawing.Size(242, 225);
            this.lbPropertySource.TabIndex = 10;
            // 
            // btnAddMapping
            // 
            this.btnAddMapping.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddMapping.Location = new System.Drawing.Point(483, 435);
            this.btnAddMapping.Name = "btnAddMapping";
            this.btnAddMapping.Size = new System.Drawing.Size(45, 93);
            this.btnAddMapping.TabIndex = 15;
            this.btnAddMapping.Text = ">";
            this.btnAddMapping.UseVisualStyleBackColor = true;
            this.btnAddMapping.Click += new System.EventHandler(this.btnAddMapping_Click);
            // 
            // btnRemoveMapping
            // 
            this.btnRemoveMapping.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveMapping.Location = new System.Drawing.Point(483, 563);
            this.btnRemoveMapping.Name = "btnRemoveMapping";
            this.btnRemoveMapping.Size = new System.Drawing.Size(45, 97);
            this.btnRemoveMapping.TabIndex = 16;
            this.btnRemoveMapping.Text = "<";
            this.btnRemoveMapping.UseVisualStyleBackColor = true;
            this.btnRemoveMapping.Click += new System.EventHandler(this.btnRemoveMapping_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(9, 103);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(147, 25);
            this.btnLoad.TabIndex = 17;
            this.btnLoad.Text = "Load Assemblies";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // lbPairs
            // 
            this.lbPairs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbPairs.FormattingEnabled = true;
            this.lbPairs.Location = new System.Drawing.Point(534, 191);
            this.lbPairs.Name = "lbPairs";
            this.lbPairs.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbPairs.Size = new System.Drawing.Size(280, 394);
            this.lbPairs.TabIndex = 18;
            // 
            // btnGenerate
            // 
            this.btnGenerate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenerate.Location = new System.Drawing.Point(534, 625);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(136, 35);
            this.btnGenerate.TabIndex = 19;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // cbIncludeReverseMapping
            // 
            this.cbIncludeReverseMapping.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cbIncludeReverseMapping.AutoSize = true;
            this.cbIncludeReverseMapping.Checked = true;
            this.cbIncludeReverseMapping.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbIncludeReverseMapping.Location = new System.Drawing.Point(534, 602);
            this.cbIncludeReverseMapping.Name = "cbIncludeReverseMapping";
            this.cbIncludeReverseMapping.Size = new System.Drawing.Size(154, 17);
            this.cbIncludeReverseMapping.TabIndex = 20;
            this.cbIncludeReverseMapping.Text = "Include Reverse Mapping?";
            this.cbIncludeReverseMapping.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(824, 24);
            this.menuStrip1.TabIndex = 21;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.loadToolStripMenuItem.Text = "Load Mapping";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // btnSaveMapping
            // 
            this.btnSaveMapping.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveMapping.Location = new System.Drawing.Point(678, 625);
            this.btnSaveMapping.Name = "btnSaveMapping";
            this.btnSaveMapping.Size = new System.Drawing.Size(136, 35);
            this.btnSaveMapping.TabIndex = 22;
            this.btnSaveMapping.Text = "Save Mapping";
            this.btnSaveMapping.UseVisualStyleBackColor = true;
            this.btnSaveMapping.Click += new System.EventHandler(this.btnSaveMapping_Click);
            // 
            // saveMappingDialog
            // 
            this.saveMappingDialog.Filter = "OTOM Map File|*.map";
            // 
            // openMappingDialog
            // 
            this.openMappingDialog.Filter = this.saveMappingDialog.Filter;
            // 
            // sourceAssemblyDialog
            // 
            this.sourceAssemblyDialog.Filter = "Assemblies|*.exe;*.dll|All files|*.*";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtAssemblySource);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnOpenSourceAssembly);
            this.groupBox1.Controls.Add(this.txtAssemblyDestination);
            this.groupBox1.Controls.Add(this.btnLoad);
            this.groupBox1.Controls.Add(this.btnOpenDestinationAssembly);
            this.groupBox1.Location = new System.Drawing.Point(12, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(802, 135);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Assemblies";
            // 
            // ObjectToObjectMapper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 669);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSaveMapping);
            this.Controls.Add(this.cbIncludeReverseMapping);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.lbPairs);
            this.Controls.Add(this.btnRemoveMapping);
            this.Controls.Add(this.btnAddMapping);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lbPropertyDestination);
            this.Controls.Add(this.lbPropertySource);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbClassDestination);
            this.Controls.Add(this.lbClassSource);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(800, 640);
            this.Name = "ObjectToObjectMapper";
            this.Text = "Object To Object Mapper";
            this.Load += new System.EventHandler(this.ObjectToObjectMapper_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtAssemblySource;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOpenSourceAssembly;
        private System.Windows.Forms.Button btnOpenDestinationAssembly;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAssemblyDestination;
        private System.Windows.Forms.ListBox lbClassSource;
        private System.Windows.Forms.ListBox lbClassDestination;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListBox lbPropertyDestination;
        private System.Windows.Forms.ListBox lbPropertySource;
        private System.Windows.Forms.Button btnAddMapping;
        private System.Windows.Forms.Button btnRemoveMapping;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.ListBox lbPairs;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.CheckBox cbIncludeReverseMapping;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Button btnSaveMapping;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveMappingDialog;
        private System.Windows.Forms.OpenFileDialog openMappingDialog;
        private System.Windows.Forms.OpenFileDialog sourceAssemblyDialog;
        private System.Windows.Forms.OpenFileDialog destAssemblyDialog;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

