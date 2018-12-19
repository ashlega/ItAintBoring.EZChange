namespace ItAintBoring.EZChange.Core.UI
{
    partial class StepSelectorEditor
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
            this.cbActivate = new System.Windows.Forms.CheckBox();
            this.tbStepName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Step";
            // 
            // cbActivate
            // 
            this.cbActivate.AutoSize = true;
            this.cbActivate.Location = new System.Drawing.Point(6, 62);
            this.cbActivate.Name = "cbActivate";
            this.cbActivate.Size = new System.Drawing.Size(80, 21);
            this.cbActivate.TabIndex = 3;
            this.cbActivate.Text = "Activate";
            this.cbActivate.UseVisualStyleBackColor = true;
            this.cbActivate.CheckedChanged += new System.EventHandler(this.cbActivate_CheckedChanged);
            // 
            // tbStepName
            // 
            this.tbStepName.Location = new System.Drawing.Point(6, 28);
            this.tbStepName.Name = "tbStepName";
            this.tbStepName.Size = new System.Drawing.Size(574, 22);
            this.tbStepName.TabIndex = 4;
            this.tbStepName.TextChanged += new System.EventHandler(this.tbStepName_TextChanged);
            // 
            // StepSelectorEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tbStepName);
            this.Controls.Add(this.cbActivate);
            this.Controls.Add(this.label1);
            this.Name = "StepSelectorEditor";
            this.Size = new System.Drawing.Size(587, 93);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cbActivate;
        private System.Windows.Forms.TextBox tbStepName;
    }
}
