namespace KEX_ARBETE
{
    partial class ChangePasswordForm
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
            this.SavePassButton = new System.Windows.Forms.Button();
            this.CancelPassButton = new System.Windows.Forms.Button();
            this.newPassLabel = new System.Windows.Forms.Label();
            this.passtextBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.passtextBox2 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // SavePassButton
            // 
            this.SavePassButton.Location = new System.Drawing.Point(314, 275);
            this.SavePassButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.SavePassButton.Name = "SavePassButton";
            this.SavePassButton.Size = new System.Drawing.Size(76, 32);
            this.SavePassButton.TabIndex = 0;
            this.SavePassButton.Text = "Spara";
            this.SavePassButton.UseVisualStyleBackColor = true;
            this.SavePassButton.Click += new System.EventHandler(this.SavePassButton_Click);
            // 
            // CancelPassButton
            // 
            this.CancelPassButton.Location = new System.Drawing.Point(214, 275);
            this.CancelPassButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.CancelPassButton.Name = "CancelPassButton";
            this.CancelPassButton.Size = new System.Drawing.Size(76, 32);
            this.CancelPassButton.TabIndex = 1;
            this.CancelPassButton.Text = "Avbryt";
            this.CancelPassButton.UseVisualStyleBackColor = true;
            this.CancelPassButton.Click += new System.EventHandler(this.CancelPassButton_Click);
            // 
            // newPassLabel
            // 
            this.newPassLabel.AutoSize = true;
            this.newPassLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newPassLabel.Location = new System.Drawing.Point(170, 120);
            this.newPassLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.newPassLabel.Name = "newPassLabel";
            this.newPassLabel.Size = new System.Drawing.Size(130, 18);
            this.newPassLabel.TabIndex = 2;
            this.newPassLabel.Text = "Ange nytt lösenord";
            // 
            // passtextBox1
            // 
            this.passtextBox1.Location = new System.Drawing.Point(314, 120);
            this.passtextBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.passtextBox1.Name = "passtextBox1";
            this.passtextBox1.Size = new System.Drawing.Size(76, 20);
            this.passtextBox1.TabIndex = 3;
            this.passtextBox1.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(166, 174);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 18);
            this.label1.TabIndex = 4;
            this.label1.Text = "Ange lösenord igen";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // passtextBox2
            // 
            this.passtextBox2.Location = new System.Drawing.Point(314, 174);
            this.passtextBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.passtextBox2.Name = "passtextBox2";
            this.passtextBox2.Size = new System.Drawing.Size(76, 20);
            this.passtextBox2.TabIndex = 5;
            this.passtextBox2.UseSystemPasswordChar = true;
            // 
            // ChangePasswordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.passtextBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.passtextBox1);
            this.Controls.Add(this.newPassLabel);
            this.Controls.Add(this.CancelPassButton);
            this.Controls.Add(this.SavePassButton);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "ChangePasswordForm";
            this.Text = "ChangePasswordForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SavePassButton;
        private System.Windows.Forms.Button CancelPassButton;
        private System.Windows.Forms.Label newPassLabel;
        private System.Windows.Forms.TextBox passtextBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox passtextBox2;
    }
}