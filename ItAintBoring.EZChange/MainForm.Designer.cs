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
            this.label1 = new System.Windows.Forms.Label();
            this.tbConnectionString = new System.Windows.Forms.TextBox();
            this.tpSolutions = new System.Windows.Forms.TabPage();
            this.tcSolution = new System.Windows.Forms.TabControl();
            this.tpEntityDeleteActions = new System.Windows.Forms.TabPage();
            this.tpAttributeDeleteAction = new System.Windows.Forms.TabPage();
            this.tpDataAction = new System.Windows.Forms.TabPage();
            this.tpWorkflowAction = new System.Windows.Forms.TabPage();
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
            this.tpSource.Text = "Source";
            this.tpSource.UseVisualStyleBackColor = true;
            // 
            // pnlSource
            // 
            this.pnlSource.Controls.Add(this.label1);
            this.pnlSource.Controls.Add(this.tbConnectionString);
            this.pnlSource.Location = new System.Drawing.Point(0, 0);
            this.pnlSource.Name = "pnlSource";
            this.pnlSource.Size = new System.Drawing.Size(937, 478);
            this.pnlSource.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Connection String";
            // 
            // tbConnectionString
            // 
            this.tbConnectionString.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbConnectionString.Location = new System.Drawing.Point(8, 43);
            this.tbConnectionString.Multiline = true;
            this.tbConnectionString.Name = "tbConnectionString";
            this.tbConnectionString.Size = new System.Drawing.Size(921, 132);
            this.tbConnectionString.TabIndex = 0;
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
            this.tcSolution.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tcSolution.Controls.Add(this.tpEntityDeleteActions);
            this.tcSolution.Controls.Add(this.tpAttributeDeleteAction);
            this.tcSolution.Controls.Add(this.tpDataAction);
            this.tcSolution.Controls.Add(this.tpWorkflowAction);
            this.tcSolution.Location = new System.Drawing.Point(255, 3);
            this.tcSolution.Name = "tcSolution";
            this.tcSolution.SelectedIndex = 0;
            this.tcSolution.Size = new System.Drawing.Size(682, 322);
            this.tcSolution.TabIndex = 3;
            // 
            // tpEntityDeleteActions
            // 
            this.tpEntityDeleteActions.Location = new System.Drawing.Point(4, 25);
            this.tpEntityDeleteActions.Name = "tpEntityDeleteActions";
            this.tpEntityDeleteActions.Padding = new System.Windows.Forms.Padding(3);
            this.tpEntityDeleteActions.Size = new System.Drawing.Size(674, 293);
            this.tpEntityDeleteActions.TabIndex = 0;
            this.tpEntityDeleteActions.Text = "Entity Delete";
            this.tpEntityDeleteActions.UseVisualStyleBackColor = true;
            // 
            // tpAttributeDeleteAction
            // 
            this.tpAttributeDeleteAction.Location = new System.Drawing.Point(4, 25);
            this.tpAttributeDeleteAction.Name = "tpAttributeDeleteAction";
            this.tpAttributeDeleteAction.Padding = new System.Windows.Forms.Padding(3);
            this.tpAttributeDeleteAction.Size = new System.Drawing.Size(674, 293);
            this.tpAttributeDeleteAction.TabIndex = 1;
            this.tpAttributeDeleteAction.Text = "Attribute Delete";
            this.tpAttributeDeleteAction.UseVisualStyleBackColor = true;
            // 
            // tpDataAction
            // 
            this.tpDataAction.Location = new System.Drawing.Point(4, 25);
            this.tpDataAction.Name = "tpDataAction";
            this.tpDataAction.Padding = new System.Windows.Forms.Padding(3);
            this.tpDataAction.Size = new System.Drawing.Size(674, 293);
            this.tpDataAction.TabIndex = 2;
            this.tpDataAction.Text = "Data";
            this.tpDataAction.UseVisualStyleBackColor = true;
            // 
            // tpWorkflowAction
            // 
            this.tpWorkflowAction.Location = new System.Drawing.Point(4, 25);
            this.tpWorkflowAction.Name = "tpWorkflowAction";
            this.tpWorkflowAction.Padding = new System.Windows.Forms.Padding(3);
            this.tpWorkflowAction.Size = new System.Drawing.Size(674, 293);
            this.tpWorkflowAction.TabIndex = 3;
            this.tpWorkflowAction.Text = "Workflows";
            this.tpWorkflowAction.UseVisualStyleBackColor = true;
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
            // 
            // lbSolutions
            // 
            this.lbSolutions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lbSolutions.FormattingEnabled = true;
            this.lbSolutions.ItemHeight = 16;
            this.lbSolutions.Location = new System.Drawing.Point(6, 3);
            this.lbSolutions.Name = "lbSolutions";
            this.lbSolutions.Size = new System.Drawing.Size(243, 276);
            this.lbSolutions.TabIndex = 4;
            this.lbSolutions.SelectedIndexChanged += new System.EventHandler(this.lbSolutions_SelectedIndexChanged);
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbConnectionString;
        private System.Windows.Forms.TabPage tpLogo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabControl tcSolution;
        private System.Windows.Forms.TabPage tpEntityDeleteActions;
        private System.Windows.Forms.TabPage tpAttributeDeleteAction;
        private System.Windows.Forms.TabPage tpDataAction;
        private System.Windows.Forms.TabPage tpWorkflowAction;
        private System.Windows.Forms.Button btnDeleteSolution;
        private System.Windows.Forms.Button btnAddSolution;
        private System.Windows.Forms.ListBox lbSolutions;
    }
}

