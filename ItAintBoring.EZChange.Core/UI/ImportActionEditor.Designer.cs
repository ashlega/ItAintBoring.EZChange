namespace ItAintBoring.EZChange.Core.UI
{
    partial class ImportActionEditor
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
            this.cbCreateOnly = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbFileName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // cbCreateOnly
            // 
            this.cbCreateOnly.AutoSize = true;
            this.cbCreateOnly.Location = new System.Drawing.Point(6, 60);
            this.cbCreateOnly.Name = "cbCreateOnly";
            this.cbCreateOnly.Size = new System.Drawing.Size(105, 21);
            this.cbCreateOnly.TabIndex = 1;
            this.cbCreateOnly.Text = "Create Only";
            this.cbCreateOnly.UseVisualStyleBackColor = true;
            this.cbCreateOnly.CheckedChanged += new System.EventHandler(this.cbCreateOnly_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Exported Data File Name";
            // 
            // tbFileName
            // 
            this.tbFileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbFileName.Location = new System.Drawing.Point(6, 30);
            this.tbFileName.Name = "tbFileName";
            this.tbFileName.Size = new System.Drawing.Size(566, 22);
            this.tbFileName.TabIndex = 3;
            this.tbFileName.TextChanged += new System.EventHandler(this.tbFileName_TextChanged);
            // 
            // ImportActionEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tbFileName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbCreateOnly);
            this.Name = "ImportActionEditor";
            this.Size = new System.Drawing.Size(580, 92);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cbCreateOnly;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbFileName;
    }
}
