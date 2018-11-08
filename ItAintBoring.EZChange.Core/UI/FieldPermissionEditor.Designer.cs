namespace ItAintBoring.EZChange.Core.UI
{
    partial class FieldPermissionEditor
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
            this.tbProfileName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbEntityName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbAttributeName = new System.Windows.Forms.TextBox();
            this.cbCanRead = new System.Windows.Forms.CheckBox();
            this.cbCanCreate = new System.Windows.Forms.CheckBox();
            this.cbCanUpdate = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Field Security Profile";
            // 
            // tbProfileName
            // 
            this.tbProfileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbProfileName.Location = new System.Drawing.Point(7, 25);
            this.tbProfileName.Name = "tbProfileName";
            this.tbProfileName.Size = new System.Drawing.Size(441, 22);
            this.tbProfileName.TabIndex = 1;
            this.tbProfileName.TextChanged += new System.EventHandler(this.tbProfileName_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Entity Name";
            // 
            // tbEntityName
            // 
            this.tbEntityName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbEntityName.Location = new System.Drawing.Point(7, 70);
            this.tbEntityName.Name = "tbEntityName";
            this.tbEntityName.Size = new System.Drawing.Size(441, 22);
            this.tbEntityName.TabIndex = 3;
            this.tbEntityName.TextChanged += new System.EventHandler(this.tbEntityName_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Attribute Name";
            // 
            // tbAttributeName
            // 
            this.tbAttributeName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbAttributeName.Location = new System.Drawing.Point(7, 115);
            this.tbAttributeName.Name = "tbAttributeName";
            this.tbAttributeName.Size = new System.Drawing.Size(441, 22);
            this.tbAttributeName.TabIndex = 5;
            this.tbAttributeName.TextChanged += new System.EventHandler(this.tbAttributeName_TextChanged);
            // 
            // cbCanRead
            // 
            this.cbCanRead.AutoSize = true;
            this.cbCanRead.Location = new System.Drawing.Point(7, 144);
            this.cbCanRead.Name = "cbCanRead";
            this.cbCanRead.Size = new System.Drawing.Size(93, 21);
            this.cbCanRead.TabIndex = 6;
            this.cbCanRead.Text = "Can Read";
            this.cbCanRead.UseVisualStyleBackColor = true;
            this.cbCanRead.CheckedChanged += new System.EventHandler(this.cbCanRead_CheckedChanged);
            // 
            // cbCanCreate
            // 
            this.cbCanCreate.AutoSize = true;
            this.cbCanCreate.Location = new System.Drawing.Point(115, 144);
            this.cbCanCreate.Name = "cbCanCreate";
            this.cbCanCreate.Size = new System.Drawing.Size(101, 21);
            this.cbCanCreate.TabIndex = 7;
            this.cbCanCreate.Text = "Can Create";
            this.cbCanCreate.UseVisualStyleBackColor = true;
            this.cbCanCreate.CheckedChanged += new System.EventHandler(this.cbCanCreate_CheckedChanged);
            // 
            // cbCanUpdate
            // 
            this.cbCanUpdate.AutoSize = true;
            this.cbCanUpdate.Location = new System.Drawing.Point(223, 144);
            this.cbCanUpdate.Name = "cbCanUpdate";
            this.cbCanUpdate.Size = new System.Drawing.Size(105, 21);
            this.cbCanUpdate.TabIndex = 8;
            this.cbCanUpdate.Text = "Can Update";
            this.cbCanUpdate.UseVisualStyleBackColor = true;
            this.cbCanUpdate.CheckedChanged += new System.EventHandler(this.cbCanUpdate_CheckedChanged);
            // 
            // FieldPermissionEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cbCanUpdate);
            this.Controls.Add(this.cbCanCreate);
            this.Controls.Add(this.cbCanRead);
            this.Controls.Add(this.tbAttributeName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbEntityName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbProfileName);
            this.Controls.Add(this.label1);
            this.Name = "FieldPermissionEditor";
            this.Size = new System.Drawing.Size(454, 173);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbProfileName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbEntityName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbAttributeName;
        private System.Windows.Forms.CheckBox cbCanRead;
        private System.Windows.Forms.CheckBox cbCanCreate;
        private System.Windows.Forms.CheckBox cbCanUpdate;
    }
}
