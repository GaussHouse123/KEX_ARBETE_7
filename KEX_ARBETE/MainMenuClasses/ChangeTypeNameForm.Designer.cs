namespace KEX_ARBETE.MainMenuClasses
{
    partial class ChangeTypeNameForm
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
            this.label = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.cancelButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label.Location = new System.Drawing.Point(66, 37);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(190, 20);
            this.label.TabIndex = 0;
            this.label.Text = "Välj kategorins nya namn:";
            this.label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nameTextBox
            // 
            this.nameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.nameTextBox.Location = new System.Drawing.Point(70, 93);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(186, 26);
            this.nameTextBox.TabIndex = 1;
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(70, 152);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(72, 36);
            this.cancelButton.TabIndex = 2;
            this.cancelButton.Text = "Avbryt";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.OnCancelButtonClick);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(184, 152);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(72, 36);
            this.saveButton.TabIndex = 3;
            this.saveButton.Text = "Spara";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.OnSaveButtonClick);
            // 
            // ChangeTypeNameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(313, 235);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.label);
            this.MaximumSize = new System.Drawing.Size(329, 274);
            this.MinimumSize = new System.Drawing.Size(329, 274);
            this.Name = "ChangeTypeNameForm";
            this.Text = "ChangeTypeNameForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button saveButton;
    }
}