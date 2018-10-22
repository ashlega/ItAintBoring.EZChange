namespace ItAintBoring.EZChange
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tbNew = new System.Windows.Forms.ToolStripMenuItem();
            this.tbOpenProject = new System.Windows.Forms.ToolStripMenuItem();
            this.tbSaveProject = new System.Windows.Forms.ToolStripMenuItem();
            this.tbSaveAsProject = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.tbExit = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.preparePackageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tcPackage = new System.Windows.Forms.TabControl();
            this.tpLogo = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.tpSource = new System.Windows.Forms.TabPage();
            this.pnlSource = new System.Windows.Forms.Panel();
            this.tbPackageName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pnlPackageControl = new System.Windows.Forms.Panel();
            this.tpSolutions = new System.Windows.Forms.TabPage();
            this.tcSolution = new System.Windows.Forms.TabControl();
            this.tpPreImportActions = new System.Windows.Forms.TabPage();
            this.btnRemovePreAction = new System.Windows.Forms.Button();
            this.btnAddPreAction = new System.Windows.Forms.Button();
            this.lbPreActions = new System.Windows.Forms.ListBox();
            this.tpPostImportActions = new System.Windows.Forms.TabPage();
            this.btnRemovePostAction = new System.Windows.Forms.Button();
            this.btnAddPostAction = new System.Windows.Forms.Button();
            this.lbPostActions = new System.Windows.Forms.ListBox();
            this.btnDeleteSolution = new System.Windows.Forms.Button();
            this.btnAddSolution = new System.Windows.Forms.Button();
            this.lbSolutions = new System.Windows.Forms.ListBox();
            this.menuStrip1.SuspendLayout();
            this.tcPackage.SuspendLayout();
            this.tpLogo.SuspendLayout();
            this.tpSource.SuspendLayout();
            this.pnlSource.SuspendLayout();
            this.tpSolutions.SuspendLayout();
            this.tcSolution.SuspendLayout();
            this.tpPreImportActions.SuspendLayout();
            this.tpPostImportActions.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.settingsToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(945, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbNew,
            this.tbOpenProject,
            this.tbSaveProject,
            this.tbSaveAsProject,
            this.toolStripMenuItem2,
            this.tbExit});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(44, 24);
            this.toolStripMenuItem1.Text = "File";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // tbNew
            // 
            this.tbNew.Name = "tbNew";
            this.tbNew.Size = new System.Drawing.Size(135, 26);
            this.tbNew.Text = "New";
            this.tbNew.Click += new System.EventHandler(this.tbNew_Click);
            // 
            // tbOpenProject
            // 
            this.tbOpenProject.Name = "tbOpenProject";
            this.tbOpenProject.Size = new System.Drawing.Size(135, 26);
            this.tbOpenProject.Text = "Open";
            this.tbOpenProject.Click += new System.EventHandler(this.tbOpenProject_Click);
            // 
            // tbSaveProject
            // 
            this.tbSaveProject.Name = "tbSaveProject";
            this.tbSaveProject.Size = new System.Drawing.Size(135, 26);
            this.tbSaveProject.Text = "Save";
            this.tbSaveProject.Click += new System.EventHandler(this.tbSaveProject_Click);
            // 
            // tbSaveAsProject
            // 
            this.tbSaveAsProject.Name = "tbSaveAsProject";
            this.tbSaveAsProject.Size = new System.Drawing.Size(135, 26);
            this.tbSaveAsProject.Text = "Save As";
            this.tbSaveAsProject.Click += new System.EventHandler(this.tbSaveAsProject_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(132, 6);
            // 
            // tbExit
            // 
            this.tbExit.Name = "tbExit";
            this.tbExit.Size = new System.Drawing.Size(135, 26);
            this.tbExit.Text = "Exit";
            this.tbExit.Click += new System.EventHandler(this.tbExit_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.preparePackageToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(74, 24);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // preparePackageToolStripMenuItem
            // 
            this.preparePackageToolStripMenuItem.Name = "preparePackageToolStripMenuItem";
            this.preparePackageToolStripMenuItem.Size = new System.Drawing.Size(247, 26);
            this.preparePackageToolStripMenuItem.Text = "Source Control Providers";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(62, 24);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // tcPackage
            // 
            this.tcPackage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tcPackage.Controls.Add(this.tpLogo);
            this.tcPackage.Controls.Add(this.tpSource);
            this.tcPackage.Controls.Add(this.tpSolutions);
            this.tcPackage.Location = new System.Drawing.Point(0, 31);
            this.tcPackage.Name = "tcPackage";
            this.tcPackage.SelectedIndex = 0;
            this.tcPackage.Size = new System.Drawing.Size(945, 354);
            this.tcPackage.TabIndex = 1;
            // 
            // tpLogo
            // 
            this.tpLogo.Controls.Add(this.label2);
            this.tpLogo.Location = new System.Drawing.Point(4, 25);
            this.tpLogo.Name = "tpLogo";
            this.tpLogo.Padding = new System.Windows.Forms.Padding(3);
            this.tpLogo.Size = new System.Drawing.Size(937, 325);
            this.tpLogo.TabIndex = 2;
            this.tpLogo.Text = "Overview";
            this.tpLogo.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(196, 152);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(566, 18);
            this.label2.TabIndex = 0;
            this.label2.Text = "Use EZ Change to create deployment packages for Power Platform / Dynamics 365. \r\n" +
    "";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // tpSource
            // 
            this.tpSource.Controls.Add(this.pnlSource);
            this.tpSource.Location = new System.Drawing.Point(4, 25);
            this.tpSource.Name = "tpSource";
            this.tpSource.Padding = new System.Windows.Forms.Padding(3);
            this.tpSource.Size = new System.Drawing.Size(937, 325);
            this.tpSource.TabIndex = 0;
            this.tpSource.Text = "Package";
            this.tpSource.UseVisualStyleBackColor = true;
            // 
            // pnlSource
            // 
            this.pnlSource.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlSource.Controls.Add(this.tbPackageName);
            this.pnlSource.Controls.Add(this.label3);
            this.pnlSource.Controls.Add(this.pnlPackageControl);
            this.pnlSource.Location = new System.Drawing.Point(0, 0);
            this.pnlSource.Name = "pnlSource";
            this.pnlSource.Size = new System.Drawing.Size(937, 329);
            this.pnlSource.TabIndex = 0;
            // 
            // tbPackageName
            // 
            this.tbPackageName.Location = new System.Drawing.Point(7, 28);
            this.tbPackageName.Name = "tbPackageName";
            this.tbPackageName.Size = new System.Drawing.Size(922, 22);
            this.tbPackageName.TabIndex = 2;
            this.tbPackageName.TextChanged += new System.EventHandler(this.tbPackageName_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 17);
            this.label3.TabIndex = 1;
            this.label3.Text = "Name";
            // 
            // pnlPackageControl
            // 
            this.pnlPackageControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlPackageControl.Location = new System.Drawing.Point(4, 56);
            this.pnlPackageControl.Name = "pnlPackageControl";
            this.pnlPackageControl.Size = new System.Drawing.Size(930, 269);
            this.pnlPackageControl.TabIndex = 0;
            // 
            // tpSolutions
            // 
            this.tpSolutions.Controls.Add(this.tcSolution);
            this.tpSolutions.Controls.Add(this.btnDeleteSolution);
            this.tpSolutions.Controls.Add(this.btnAddSolution);
            this.tpSolutions.Controls.Add(this.lbSolutions);
            this.tpSolutions.Location = new System.Drawing.Point(4, 25);
            this.tpSolutions.Name = "tpSolutions";
            this.tpSolutions.Padding = new System.Windows.Forms.Padding(3);
            this.tpSolutions.Size = new System.Drawing.Size(937, 325);
            this.tpSolutions.TabIndex = 1;
            this.tpSolutions.Text = "Solutions";
            this.tpSolutions.UseVisualStyleBackColor = true;
            // 
            // tcSolution
            // 
            this.tcSolution.AllowDrop = true;
            this.tcSolution.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tcSolution.Controls.Add(this.tpPreImportActions);
            this.tcSolution.Controls.Add(this.tpPostImportActions);
            this.tcSolution.Location = new System.Drawing.Point(255, 3);
            this.tcSolution.Name = "tcSolution";
            this.tcSolution.SelectedIndex = 0;
            this.tcSolution.Size = new System.Drawing.Size(682, 322);
            this.tcSolution.TabIndex = 3;
            // 
            // tpPreImportActions
            // 
            this.tpPreImportActions.Controls.Add(this.btnRemovePreAction);
            this.tpPreImportActions.Controls.Add(this.btnAddPreAction);
            this.tpPreImportActions.Controls.Add(this.lbPreActions);
            this.tpPreImportActions.Location = new System.Drawing.Point(4, 25);
            this.tpPreImportActions.Name = "tpPreImportActions";
            this.tpPreImportActions.Padding = new System.Windows.Forms.Padding(3);
            this.tpPreImportActions.Size = new System.Drawing.Size(674, 293);
            this.tpPreImportActions.TabIndex = 0;
            this.tpPreImportActions.Text = "Pre Import Actions";
            this.tpPreImportActions.UseVisualStyleBackColor = true;
            // 
            // btnRemovePreAction
            // 
            this.btnRemovePreAction.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRemovePreAction.Location = new System.Drawing.Point(593, 256);
            this.btnRemovePreAction.Name = "btnRemovePreAction";
            this.btnRemovePreAction.Size = new System.Drawing.Size(75, 30);
            this.btnRemovePreAction.TabIndex = 7;
            this.btnRemovePreAction.Text = "Remove";
            this.btnRemovePreAction.UseVisualStyleBackColor = true;
            this.btnRemovePreAction.Click += new System.EventHandler(this.btnRemovePreAction_Click);
            // 
            // btnAddPreAction
            // 
            this.btnAddPreAction.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddPreAction.Location = new System.Drawing.Point(512, 256);
            this.btnAddPreAction.Name = "btnAddPreAction";
            this.btnAddPreAction.Size = new System.Drawing.Size(75, 30);
            this.btnAddPreAction.TabIndex = 6;
            this.btnAddPreAction.Text = "Add";
            this.btnAddPreAction.UseVisualStyleBackColor = true;
            this.btnAddPreAction.Click += new System.EventHandler(this.btnAddPreAction_Click);
            // 
            // lbPreActions
            // 
            this.lbPreActions.AllowDrop = true;
            this.lbPreActions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbPreActions.FormattingEnabled = true;
            this.lbPreActions.ItemHeight = 16;
            this.lbPreActions.Location = new System.Drawing.Point(1, 2);
            this.lbPreActions.Name = "lbPreActions";
            this.lbPreActions.Size = new System.Drawing.Size(671, 244);
            this.lbPreActions.TabIndex = 0;
            this.lbPreActions.SelectedIndexChanged += new System.EventHandler(this.lbPreActions_SelectedIndexChanged);
            this.lbPreActions.DragDrop += new System.Windows.Forms.DragEventHandler(this.lbPreActions_DragDrop);
            this.lbPreActions.DragOver += new System.Windows.Forms.DragEventHandler(this.lbPreActions_DragOver);
            this.lbPreActions.DoubleClick += new System.EventHandler(this.lbPreActions_DoubleClick);
            this.lbPreActions.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbPreActions_MouseDown);
            // 
            // tpPostImportActions
            // 
            this.tpPostImportActions.Controls.Add(this.btnRemovePostAction);
            this.tpPostImportActions.Controls.Add(this.btnAddPostAction);
            this.tpPostImportActions.Controls.Add(this.lbPostActions);
            this.tpPostImportActions.Location = new System.Drawing.Point(4, 25);
            this.tpPostImportActions.Name = "tpPostImportActions";
            this.tpPostImportActions.Padding = new System.Windows.Forms.Padding(3);
            this.tpPostImportActions.Size = new System.Drawing.Size(674, 293);
            this.tpPostImportActions.TabIndex = 1;
            this.tpPostImportActions.Text = "Post Import Actions";
            this.tpPostImportActions.UseVisualStyleBackColor = true;
            // 
            // btnRemovePostAction
            // 
            this.btnRemovePostAction.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRemovePostAction.Location = new System.Drawing.Point(593, 256);
            this.btnRemovePostAction.Name = "btnRemovePostAction";
            this.btnRemovePostAction.Size = new System.Drawing.Size(75, 30);
            this.btnRemovePostAction.TabIndex = 9;
            this.btnRemovePostAction.Text = "Remove";
            this.btnRemovePostAction.UseVisualStyleBackColor = true;
            this.btnRemovePostAction.Click += new System.EventHandler(this.btnRemovePostAction_Click);
            // 
            // btnAddPostAction
            // 
            this.btnAddPostAction.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddPostAction.Location = new System.Drawing.Point(512, 256);
            this.btnAddPostAction.Name = "btnAddPostAction";
            this.btnAddPostAction.Size = new System.Drawing.Size(75, 30);
            this.btnAddPostAction.TabIndex = 8;
            this.btnAddPostAction.Text = "Add";
            this.btnAddPostAction.UseVisualStyleBackColor = true;
            this.btnAddPostAction.Click += new System.EventHandler(this.btnAddPostAction_Click);
            // 
            // lbPostActions
            // 
            this.lbPostActions.AllowDrop = true;
            this.lbPostActions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbPostActions.FormattingEnabled = true;
            this.lbPostActions.ItemHeight = 16;
            this.lbPostActions.Location = new System.Drawing.Point(1, 2);
            this.lbPostActions.Name = "lbPostActions";
            this.lbPostActions.Size = new System.Drawing.Size(671, 244);
            this.lbPostActions.TabIndex = 1;
            this.lbPostActions.SelectedIndexChanged += new System.EventHandler(this.lbPostActions_SelectedIndexChanged);
            this.lbPostActions.DragDrop += new System.Windows.Forms.DragEventHandler(this.lbPostActions_DragDrop);
            this.lbPostActions.DragOver += new System.Windows.Forms.DragEventHandler(this.lbPostActions_DragOver);
            this.lbPostActions.DoubleClick += new System.EventHandler(this.lbPostActions_DoubleClick);
            this.lbPostActions.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbPostActions_MouseDown);
            // 
            // btnDeleteSolution
            // 
            this.btnDeleteSolution.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDeleteSolution.Location = new System.Drawing.Point(87, 284);
            this.btnDeleteSolution.Name = "btnDeleteSolution";
            this.btnDeleteSolution.Size = new System.Drawing.Size(75, 30);
            this.btnDeleteSolution.TabIndex = 6;
            this.btnDeleteSolution.Text = "Remove";
            this.btnDeleteSolution.UseVisualStyleBackColor = true;
            this.btnDeleteSolution.Click += new System.EventHandler(this.btnDeleteSolution_Click);
            // 
            // btnAddSolution
            // 
            this.btnAddSolution.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddSolution.Location = new System.Drawing.Point(6, 284);
            this.btnAddSolution.Name = "btnAddSolution";
            this.btnAddSolution.Size = new System.Drawing.Size(75, 30);
            this.btnAddSolution.TabIndex = 5;
            this.btnAddSolution.Text = "Add";
            this.btnAddSolution.UseVisualStyleBackColor = true;
            this.btnAddSolution.Click += new System.EventHandler(this.btnAddSolution_Click);
            // 
            // lbSolutions
            // 
            this.lbSolutions.AllowDrop = true;
            this.lbSolutions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lbSolutions.FormattingEnabled = true;
            this.lbSolutions.ItemHeight = 16;
            this.lbSolutions.Location = new System.Drawing.Point(6, 3);
            this.lbSolutions.Name = "lbSolutions";
            this.lbSolutions.Size = new System.Drawing.Size(243, 276);
            this.lbSolutions.TabIndex = 4;
            this.lbSolutions.SelectedIndexChanged += new System.EventHandler(this.lbSolutions_SelectedIndexChanged);
            this.lbSolutions.DragDrop += new System.Windows.Forms.DragEventHandler(this.lbSolutions_DragDrop);
            this.lbSolutions.DragOver += new System.Windows.Forms.DragEventHandler(this.lbSolutions_DragOver);
            this.lbSolutions.DoubleClick += new System.EventHandler(this.lbSolutions_DoubleClick);
            this.lbSolutions.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbSolutions_MouseDown);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(945, 386);
            this.Controls.Add(this.tcPackage);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "EZ Change";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tcPackage.ResumeLayout(false);
            this.tpLogo.ResumeLayout(false);
            this.tpLogo.PerformLayout();
            this.tpSource.ResumeLayout(false);
            this.pnlSource.ResumeLayout(false);
            this.pnlSource.PerformLayout();
            this.tpSolutions.ResumeLayout(false);
            this.tcSolution.ResumeLayout(false);
            this.tpPreImportActions.ResumeLayout(false);
            this.tpPostImportActions.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem tbOpenProject;
        private System.Windows.Forms.ToolStripMenuItem tbSaveProject;
        private System.Windows.Forms.ToolStripMenuItem tbSaveAsProject;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem tbExit;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem preparePackageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tbNew;
        private System.Windows.Forms.TabControl tcPackage;
        private System.Windows.Forms.TabPage tpSource;
        private System.Windows.Forms.TabPage tpSolutions;
        private System.Windows.Forms.Panel pnlSource;
        private System.Windows.Forms.TabPage tpLogo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabControl tcSolution;
        private System.Windows.Forms.TabPage tpPreImportActions;
        private System.Windows.Forms.TabPage tpPostImportActions;
        private System.Windows.Forms.Button btnDeleteSolution;
        private System.Windows.Forms.Button btnAddSolution;
        private System.Windows.Forms.ListBox lbSolutions;
        private System.Windows.Forms.Button btnRemovePreAction;
        private System.Windows.Forms.Button btnAddPreAction;
        private System.Windows.Forms.ListBox lbPreActions;
        private System.Windows.Forms.Button btnRemovePostAction;
        private System.Windows.Forms.Button btnAddPostAction;
        private System.Windows.Forms.ListBox lbPostActions;
        private System.Windows.Forms.TextBox tbPackageName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel pnlPackageControl;
    }
}

