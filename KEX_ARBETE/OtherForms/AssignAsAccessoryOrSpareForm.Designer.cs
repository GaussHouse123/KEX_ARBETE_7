namespace KEX_ARBETE.OtherForms
{
    partial class AssignAsAccessoryOrSpareForm
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
            this.accessoryCheckBox = new System.Windows.Forms.CheckBox();
            this.spareCheckBox = new System.Windows.Forms.CheckBox();
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(26, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(523, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Välj om du vill tilldela denna artikel som ett tillbehör eller som en reservdel:";
            // 
            // accessoryCheckBox
            // 
            this.accessoryCheckBox.AutoSize = true;
            this.accessoryCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.accessoryCheckBox.Location = new System.Drawing.Point(214, 166);
            this.accessoryCheckBox.Name = "accessoryCheckBox";
            this.accessoryCheckBox.Size = new System.Drawing.Size(83, 22);
            this.accessoryCheckBox.TabIndex = 3;
            this.accessoryCheckBox.Text = "Tillbehör";
            this.accessoryCheckBox.UseVisualStyleBackColor = true;
            this.accessoryCheckBox.CheckedChanged += new System.EventHandler(this.OnAccessoryCheckBoxStateChanged);
            // 
            // spareCheckBox
            // 
            this.spareCheckBox.AutoSize = true;
            this.spareCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.spareCheckBox.Location = new System.Drawing.Point(214, 212);
            this.spareCheckBox.Name = "spareCheckBox";
            this.spareCheckBox.Size = new System.Drawing.Size(93, 22);
            this.spareCheckBox.TabIndex = 4;
            this.spareCheckBox.Text = "Reservdel";
            this.spareCheckBox.UseVisualStyleBackColor = true;
            this.spareCheckBox.CheckedChanged += new System.EventHandler(this.OnSpareCheckBoxStateChanged);
            // 
            // cancelButton
            // 
            this.cancelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cancelButton.Location = new System.Drawing.Point(118, 268);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 29);
            this.cancelButton.TabIndex = 5;
            this.cancelButton.Text = "Avbryt";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.CancelButtonClick);
            // 
            // okButton
            // 
            this.okButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.okButton.Location = new System.Drawing.Point(298, 268);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 29);
            this.okButton.TabIndex = 6;
            this.okButton.Text = "Ok";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.OkButtonClick);
            // 
            // AssignAsAccessoryOrSpareForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(561, 360);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.spareCheckBox);
            this.Controls.Add(this.accessoryCheckBox);
            this.Controls.Add(this.label1);
            this.MaximumSize = new System.Drawing.Size(577, 399);
            this.MinimumSize = new System.Drawing.Size(577, 399);
            this.Name = "AssignAsAccessoryOrSpareForm";
            this.Text = "AssignAsAccessoryOrSpareForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox accessoryCheckBox;
        private System.Windows.Forms.CheckBox spareCheckBox;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
    }
}