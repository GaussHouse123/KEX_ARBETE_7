namespace KEX_ARBETE
{
    partial class AdminForm
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
            this.enterPassLabel = new System.Windows.Forms.Label();
            this.enterPassTextBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.avbrytButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // enterPassLabel
            // 
            this.enterPassLabel.AutoSize = true;
            this.enterPassLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.enterPassLabel.Location = new System.Drawing.Point(194, 126);
            this.enterPassLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.enterPassLabel.Name = "enterPassLabel";
            this.enterPassLabel.Size = new System.Drawing.Size(121, 18);
            this.enterPassLabel.TabIndex = 0;
            this.enterPassLabel.Text = "Ange lösenord:";
            // 
            // txtPassword
            // 
            this.enterPassTextBox.Location = new System.Drawing.Point(316, 126);
            this.enterPassTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.enterPassTextBox.Name = "txtPassword";
            this.enterPassTextBox.Size = new System.Drawing.Size(98, 20);
            this.enterPassTextBox.TabIndex = 1;
            this.enterPassTextBox.UseSystemPasswordChar = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(316, 274);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 37);
            this.button1.TabIndex = 2;
            this.button1.Text = "Logga in";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.OnLogInButtonClick);
            // 
            // button2
            // 
            this.avbrytButton.Location = new System.Drawing.Point(208, 274);
            this.avbrytButton.Margin = new System.Windows.Forms.Padding(2);
            this.avbrytButton.Name = "button2";
            this.avbrytButton.Size = new System.Drawing.Size(75, 37);
            this.avbrytButton.TabIndex = 3;
            this.avbrytButton.Text = "Avbryt";
            this.avbrytButton.UseVisualStyleBackColor = true;
            this.avbrytButton.Click += new System.EventHandler(this.OnCancelButtonClick);
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(617, 356);
            this.Controls.Add(this.avbrytButton);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.enterPassTextBox);
            this.Controls.Add(this.enterPassLabel);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "AdminForm";
            this.Text = "LogInForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label enterPassLabel;
        private System.Windows.Forms.TextBox enterPassTextBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button avbrytButton;
    }
}