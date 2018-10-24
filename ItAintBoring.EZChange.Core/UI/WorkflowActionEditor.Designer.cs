namespace ItAintBoring.EZChange.Core.UI
{
    partial class WorkflowActionEditor
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbWorkflowId = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbFetchXml = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Workflow Id";
            // 
            // tbWorkflowId
            // 
            this.tbWorkflowId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbWorkflowId.Location = new System.Drawing.Point(7, 25);
            this.tbWorkflowId.Name = "tbWorkflowId";
            this.tbWorkflowId.Size = new System.Drawing.Size(492, 22);
            this.tbWorkflowId.TabIndex = 1;
            this.tbWorkflowId.TextChanged += new System.EventHandler(this.tbWorkflowId_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Fetch XML";
            // 
            // tbFetchXml
            // 
            this.tbFetchXml.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbFetchXml.Location = new System.Drawing.Point(7, 78);
            this.tbFetchXml.Multiline = true;
            this.tbFetchXml.Name = "tbFetchXml";
            this.tbFetchXml.Size = new System.Drawing.Size(492, 80);
            this.tbFetchXml.TabIndex = 3;
            this.tbFetchXml.TextChanged += new System.EventHandler(this.tbFetchXml_TextChanged);
            // 
            // WorkflowActionEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tbFetchXml);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbWorkflowId);
            this.Controls.Add(this.label1);
            this.Name = "WorkflowActionEditor";
            this.Size = new System.Drawing.Size(508, 161);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbWorkflowId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbFetchXml;
    }
}
