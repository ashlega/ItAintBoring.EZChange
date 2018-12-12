namespace ItAintBoring.EZChange.Dialogs
{
    partial class VariableEditor
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbDefaultValue = new System.Windows.Forms.TextBox();
            this.btnRemoveVar = new System.Windows.Forms.Button();
            this.btnAddVar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // tbName
            // 
            this.tbName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbName.Location = new System.Drawing.Point(7, 30);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(500, 22);
            this.tbName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Value";
            // 
            // tbDefaultValue
            // 
            this.tbDefaultValue.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbDefaultValue.Location = new System.Drawing.Point(7, 80);
            this.tbDefaultValue.Multiline = true;
            this.tbDefaultValue.Name = "tbDefaultValue";
            this.tbDefaultValue.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.tbDefaultValue.Size = new System.Drawing.Size(500, 90);
            this.tbDefaultValue.TabIndex = 3;
            // 
            // btnRemoveVar
            // 
            this.btnRemoveVar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveVar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnRemoveVar.Location = new System.Drawing.Point(433, 176);
            this.btnRemoveVar.Name = "btnRemoveVar";
            this.btnRemoveVar.Size = new System.Drawing.Size(75, 30);
            this.btnRemoveVar.TabIndex = 10;
            this.btnRemoveVar.Text = "Cancel";
            this.btnRemoveVar.UseVisualStyleBackColor = true;
            // 
            // btnAddVar
            // 
            this.btnAddVar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddVar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAddVar.Location = new System.Drawing.Point(352, 176);
            this.btnAddVar.Name = "btnAddVar";
            this.btnAddVar.Size = new System.Drawing.Size(75, 30);
            this.btnAddVar.TabIndex = 9;
            this.btnAddVar.Text = "OK";
            this.btnAddVar.UseVisualStyleBackColor = true;
            // 
            // VariableEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 218);
            this.Controls.Add(this.btnRemoveVar);
            this.Controls.Add(this.btnAddVar);
            this.Controls.Add(this.tbDefaultValue);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "VariableEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Variable Editor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbDefaultValue;
        private System.Windows.Forms.Button btnRemoveVar;
        private System.Windows.Forms.Button btnAddVar;
    }
}