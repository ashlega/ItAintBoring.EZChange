namespace ItAintBoring.EZChange.Core.UI
{
    partial class DynamicsSolutionEditor
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbText = new System.Windows.Forms.TextBox();
            this.lbName = new System.Windows.Forms.Label();
            this.fsEditor = new ItAintBoring.EZChange.Core.UI.FileSelectorEditor();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbGuidShift = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // tbText
            // 
            this.tbText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbText.Location = new System.Drawing.Point(6, 71);
            this.tbText.Name = "tbText";
            this.tbText.Size = new System.Drawing.Size(517, 22);
            this.tbText.TabIndex = 1;
            this.tbText.TextChanged += new System.EventHandler(this.tbText_TextChanged);
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Location = new System.Drawing.Point(3, 51);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(100, 17);
            this.lbName.TabIndex = 2;
            this.lbName.Text = "Solution Name";
            // 
            // fsEditor
            // 
            this.fsEditor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fsEditor.FileName = "";
            this.fsEditor.Location = new System.Drawing.Point(5, 99);
            this.fsEditor.Name = "fsEditor";
            this.fsEditor.Size = new System.Drawing.Size(517, 51);
            this.fsEditor.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 17);
            this.label1.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 157);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Guid Shift";
            // 
            // tbGuidShift
            // 
            this.tbGuidShift.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbGuidShift.Location = new System.Drawing.Point(5, 177);
            this.tbGuidShift.Name = "tbGuidShift";
            this.tbGuidShift.Size = new System.Drawing.Size(82, 22);
            this.tbGuidShift.TabIndex = 6;
            // 
            // DynamicsSolutionEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tbGuidShift);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.fsEditor);
            this.Controls.Add(this.lbName);
            this.Controls.Add(this.tbText);
            this.Name = "DynamicsSolutionEditor";
            this.Size = new System.Drawing.Size(529, 211);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbText;
        private System.Windows.Forms.Label lbName;
        private FileSelectorEditor fsEditor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbGuidShift;
    }
}
