namespace ItAintBoring.EZChange
{
    partial class VariableSetSelector
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
            this.btnRemoveVar = new System.Windows.Forms.Button();
            this.btnAddVar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cbVariableSet = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnRemoveVar
            // 
            this.btnRemoveVar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveVar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnRemoveVar.Location = new System.Drawing.Point(402, 60);
            this.btnRemoveVar.Name = "btnRemoveVar";
            this.btnRemoveVar.Size = new System.Drawing.Size(75, 30);
            this.btnRemoveVar.TabIndex = 12;
            this.btnRemoveVar.Text = "Cancel";
            this.btnRemoveVar.UseVisualStyleBackColor = true;
            // 
            // btnAddVar
            // 
            this.btnAddVar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddVar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAddVar.Location = new System.Drawing.Point(321, 60);
            this.btnAddVar.Name = "btnAddVar";
            this.btnAddVar.Size = new System.Drawing.Size(75, 30);
            this.btnAddVar.TabIndex = 11;
            this.btnAddVar.Text = "OK";
            this.btnAddVar.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 17);
            this.label1.TabIndex = 13;
            this.label1.Text = "Variable Set";
            // 
            // cbVariableSet
            // 
            this.cbVariableSet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbVariableSet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVariableSet.FormattingEnabled = true;
            this.cbVariableSet.Location = new System.Drawing.Point(103, 15);
            this.cbVariableSet.Name = "cbVariableSet";
            this.cbVariableSet.Size = new System.Drawing.Size(374, 24);
            this.cbVariableSet.TabIndex = 14;
            // 
            // VariableSetSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(489, 102);
            this.Controls.Add(this.cbVariableSet);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnRemoveVar);
            this.Controls.Add(this.btnAddVar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "VariableSetSelector";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Variable Set Selector";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRemoveVar;
        private System.Windows.Forms.Button btnAddVar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbVariableSet;
    }
}