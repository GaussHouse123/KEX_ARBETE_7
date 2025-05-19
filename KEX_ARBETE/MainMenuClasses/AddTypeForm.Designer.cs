namespace KEX_ARBETE.MainMenuClasses
{
    partial class AddTypeForm
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
            this.titleLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.typeNameTextBox = new System.Windows.Forms.TextBox();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold);
            this.titleLabel.Location = new System.Drawing.Point(180, 38);
            this.titleLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(199, 25);
            this.titleLabel.TabIndex = 30;
            this.titleLabel.Text = "Lägg till ny kategori";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(185, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(182, 20);
            this.label1.TabIndex = 31;
            this.label1.Text = "Vad ska kategorin heta?";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // typeNameTextBox
            // 
            this.typeNameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.typeNameTextBox.Location = new System.Drawing.Point(185, 149);
            this.typeNameTextBox.Multiline = true;
            this.typeNameTextBox.Name = "typeNameTextBox";
            this.typeNameTextBox.Size = new System.Drawing.Size(182, 24);
            this.typeNameTextBox.TabIndex = 32;
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(292, 228);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 29);
            this.okButton.TabIndex = 33;
            this.okButton.Text = "Spara";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.OnSaveButtonClick);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(185, 228);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 29);
            this.cancelButton.TabIndex = 34;
            this.cancelButton.Text = "Avbryt";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.OnCancelButtonClick);
            // 
            // AddTypeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(571, 318);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.typeNameTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.titleLabel);
            this.MaximumSize = new System.Drawing.Size(587, 357);
            this.MinimumSize = new System.Drawing.Size(587, 357);
            this.Name = "AddTypeForm";
            this.Text = "AddTypeForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox typeNameTextBox;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
    }
}