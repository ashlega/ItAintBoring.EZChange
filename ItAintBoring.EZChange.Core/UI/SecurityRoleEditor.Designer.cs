namespace ItAintBoring.EZChange.Core.UI
{
    partial class SecurityRoleEditor
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
            this.tbProfileName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbCreate = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbRead = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbWrite = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbDelete = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbAssign = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbShare = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cbAppend = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cbAppendTo = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // tbProfileName
            // 
            this.tbProfileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbProfileName.Location = new System.Drawing.Point(6, 25);
            this.tbProfileName.Name = "tbProfileName";
            this.tbProfileName.Size = new System.Drawing.Size(530, 22);
            this.tbProfileName.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Security Role";
            // 
            // cbCreate
            // 
            this.cbCreate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbCreate.FormattingEnabled = true;
            this.cbCreate.Items.AddRange(new object[] {
            "None",
            "Owner",
            "Business Unit",
            "Parent-Child BU",
            "Organization"});
            this.cbCreate.Location = new System.Drawing.Point(133, 53);
            this.cbCreate.Name = "cbCreate";
            this.cbCreate.Size = new System.Drawing.Size(403, 24);
            this.cbCreate.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Create";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "Read";
            // 
            // cbRead
            // 
            this.cbRead.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbRead.FormattingEnabled = true;
            this.cbRead.Items.AddRange(new object[] {
            "None",
            "Owner",
            "Business Unit",
            "Parent-Child BU",
            "Organization"});
            this.cbRead.Location = new System.Drawing.Point(133, 82);
            this.cbRead.Name = "cbRead";
            this.cbRead.Size = new System.Drawing.Size(403, 24);
            this.cbRead.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 117);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 17);
            this.label4.TabIndex = 9;
            this.label4.Text = "Write";
            // 
            // cbWrite
            // 
            this.cbWrite.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbWrite.FormattingEnabled = true;
            this.cbWrite.Items.AddRange(new object[] {
            "None",
            "Owner",
            "Business Unit",
            "Parent-Child BU",
            "Organization"});
            this.cbWrite.Location = new System.Drawing.Point(133, 111);
            this.cbWrite.Name = "cbWrite";
            this.cbWrite.Size = new System.Drawing.Size(403, 24);
            this.cbWrite.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 145);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 17);
            this.label5.TabIndex = 11;
            this.label5.Text = "Delete";
            // 
            // cbDelete
            // 
            this.cbDelete.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbDelete.FormattingEnabled = true;
            this.cbDelete.Items.AddRange(new object[] {
            "None",
            "Owner",
            "Business Unit",
            "Parent-Child BU",
            "Organization"});
            this.cbDelete.Location = new System.Drawing.Point(133, 139);
            this.cbDelete.Name = "cbDelete";
            this.cbDelete.Size = new System.Drawing.Size(403, 24);
            this.cbDelete.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 175);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 17);
            this.label6.TabIndex = 13;
            this.label6.Text = "Assign";
            // 
            // cbAssign
            // 
            this.cbAssign.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbAssign.FormattingEnabled = true;
            this.cbAssign.Items.AddRange(new object[] {
            "None",
            "Owner",
            "Business Unit",
            "Parent-Child BU",
            "Organization"});
            this.cbAssign.Location = new System.Drawing.Point(133, 169);
            this.cbAssign.Name = "cbAssign";
            this.cbAssign.Size = new System.Drawing.Size(403, 24);
            this.cbAssign.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 205);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 17);
            this.label7.TabIndex = 15;
            this.label7.Text = "Share";
            // 
            // cbShare
            // 
            this.cbShare.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbShare.FormattingEnabled = true;
            this.cbShare.Items.AddRange(new object[] {
            "None",
            "Owner",
            "Business Unit",
            "Parent-Child BU",
            "Organization"});
            this.cbShare.Location = new System.Drawing.Point(133, 199);
            this.cbShare.Name = "cbShare";
            this.cbShare.Size = new System.Drawing.Size(403, 24);
            this.cbShare.TabIndex = 14;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 235);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 17);
            this.label8.TabIndex = 17;
            this.label8.Text = "Append";
            // 
            // cbAppend
            // 
            this.cbAppend.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbAppend.FormattingEnabled = true;
            this.cbAppend.Items.AddRange(new object[] {
            "None",
            "Owner",
            "Business Unit",
            "Parent-Child BU",
            "Organization"});
            this.cbAppend.Location = new System.Drawing.Point(133, 229);
            this.cbAppend.Name = "cbAppend";
            this.cbAppend.Size = new System.Drawing.Size(403, 24);
            this.cbAppend.TabIndex = 16;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 265);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(78, 17);
            this.label9.TabIndex = 19;
            this.label9.Text = "Append To";
            // 
            // cbAppendTo
            // 
            this.cbAppendTo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbAppendTo.FormattingEnabled = true;
            this.cbAppendTo.Items.AddRange(new object[] {
            "None",
            "Owner",
            "Business Unit",
            "Parent-Child BU",
            "Organization"});
            this.cbAppendTo.Location = new System.Drawing.Point(133, 259);
            this.cbAppendTo.Name = "cbAppendTo";
            this.cbAppendTo.Size = new System.Drawing.Size(403, 24);
            this.cbAppendTo.TabIndex = 18;
            // 
            // SecurityRoleEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cbAppendTo);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cbAppend);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cbShare);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cbAssign);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbDelete);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbWrite);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbRead);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbCreate);
            this.Controls.Add(this.tbProfileName);
            this.Controls.Add(this.label1);
            this.Name = "SecurityRoleEditor";
            this.Size = new System.Drawing.Size(542, 301);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbProfileName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbCreate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbRead;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbWrite;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbDelete;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbAssign;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbShare;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbAppend;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbAppendTo;
    }
}
