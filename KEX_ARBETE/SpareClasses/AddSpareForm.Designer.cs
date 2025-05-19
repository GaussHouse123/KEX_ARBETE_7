namespace KEX_ARBETE
{
    partial class AddSpareForm
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
            this.label3 = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.huvudlagerLabel = new System.Windows.Forms.Label();
            this.huvudlagerComboBox = new System.Windows.Forms.ComboBox();
            this.leverantörLabel = new System.Windows.Forms.Label();
            this.leverantörTextBox = new System.Windows.Forms.TextBox();
            this.artikelbenämningLabel = new System.Windows.Forms.Label();
            this.artikelbenämningTextBox = new System.Windows.Forms.TextBox();
            this.leverantörensArtNrLabel = new System.Windows.Forms.Label();
            this.leverantörensArtNrTextBox = new System.Windows.Forms.TextBox();
            this.kommentarLabel = new System.Windows.Forms.Label();
            this.kommentarTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(322, 26);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(211, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Lägg till ny reservdel";
            // 
            // saveButton
            // 
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveButton.Location = new System.Drawing.Point(503, 431);
            this.saveButton.Margin = new System.Windows.Forms.Padding(2);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(56, 28);
            this.saveButton.TabIndex = 18;
            this.saveButton.Text = "Spara";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.OnSaveButtonClick);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelButton.Location = new System.Drawing.Point(265, 431);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(2);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(56, 28);
            this.cancelButton.TabIndex = 19;
            this.cancelButton.Text = "Avbryt";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.OnCancelButtonClick);
            // 
            // huvudlagerLabel
            // 
            this.huvudlagerLabel.AutoSize = true;
            this.huvudlagerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.huvudlagerLabel.Location = new System.Drawing.Point(126, 98);
            this.huvudlagerLabel.Name = "huvudlagerLabel";
            this.huvudlagerLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.huvudlagerLabel.Size = new System.Drawing.Size(107, 22);
            this.huvudlagerLabel.TabIndex = 20;
            this.huvudlagerLabel.Text = "Huvudlager:";
            this.huvudlagerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // huvudlagerComboBox
            // 
            this.huvudlagerComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.huvudlagerComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.huvudlagerComboBox.FormattingEnabled = true;
            this.huvudlagerComboBox.Location = new System.Drawing.Point(265, 97);
            this.huvudlagerComboBox.Name = "huvudlagerComboBox";
            this.huvudlagerComboBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.huvudlagerComboBox.Size = new System.Drawing.Size(427, 26);
            this.huvudlagerComboBox.TabIndex = 21;
            // 
            // leverantörLabel
            // 
            this.leverantörLabel.AutoSize = true;
            this.leverantörLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.leverantörLabel.Location = new System.Drawing.Point(132, 139);
            this.leverantörLabel.Name = "leverantörLabel";
            this.leverantörLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.leverantörLabel.Size = new System.Drawing.Size(101, 22);
            this.leverantörLabel.TabIndex = 22;
            this.leverantörLabel.Text = "Leverantör:";
            this.leverantörLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // leverantörTextBox
            // 
            this.leverantörTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.leverantörTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.leverantörTextBox.Location = new System.Drawing.Point(265, 139);
            this.leverantörTextBox.Name = "leverantörTextBox";
            this.leverantörTextBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.leverantörTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.leverantörTextBox.Size = new System.Drawing.Size(427, 24);
            this.leverantörTextBox.TabIndex = 23;
            // 
            // artikelbenämningLabel
            // 
            this.artikelbenämningLabel.AutoSize = true;
            this.artikelbenämningLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.artikelbenämningLabel.Location = new System.Drawing.Point(80, 180);
            this.artikelbenämningLabel.Name = "artikelbenämningLabel";
            this.artikelbenämningLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.artikelbenämningLabel.Size = new System.Drawing.Size(153, 22);
            this.artikelbenämningLabel.TabIndex = 24;
            this.artikelbenämningLabel.Text = "Artikelbenämning:";
            this.artikelbenämningLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // artikelbenämningTextBox
            // 
            this.artikelbenämningTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.artikelbenämningTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.artikelbenämningTextBox.Location = new System.Drawing.Point(265, 180);
            this.artikelbenämningTextBox.Name = "artikelbenämningTextBox";
            this.artikelbenämningTextBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.artikelbenämningTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.artikelbenämningTextBox.Size = new System.Drawing.Size(427, 24);
            this.artikelbenämningTextBox.TabIndex = 25;
            // 
            // leverantörensArtNrLabel
            // 
            this.leverantörensArtNrLabel.AutoSize = true;
            this.leverantörensArtNrLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.leverantörensArtNrLabel.Location = new System.Drawing.Point(46, 222);
            this.leverantörensArtNrLabel.Name = "leverantörensArtNrLabel";
            this.leverantörensArtNrLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.leverantörensArtNrLabel.Size = new System.Drawing.Size(187, 22);
            this.leverantörensArtNrLabel.TabIndex = 26;
            this.leverantörensArtNrLabel.Text = "Leverantörens Art. Nr:";
            this.leverantörensArtNrLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // leverantörensArtNrTextBox
            // 
            this.leverantörensArtNrTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.leverantörensArtNrTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.leverantörensArtNrTextBox.Location = new System.Drawing.Point(265, 221);
            this.leverantörensArtNrTextBox.Name = "leverantörensArtNrTextBox";
            this.leverantörensArtNrTextBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.leverantörensArtNrTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.leverantörensArtNrTextBox.Size = new System.Drawing.Size(427, 24);
            this.leverantörensArtNrTextBox.TabIndex = 27;
            // 
            // kommentarLabel
            // 
            this.kommentarLabel.AutoSize = true;
            this.kommentarLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.kommentarLabel.Location = new System.Drawing.Point(127, 314);
            this.kommentarLabel.Name = "kommentarLabel";
            this.kommentarLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.kommentarLabel.Size = new System.Drawing.Size(106, 22);
            this.kommentarLabel.TabIndex = 28;
            this.kommentarLabel.Text = "Kommentar:";
            this.kommentarLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // kommentarTextBox
            // 
            this.kommentarTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.kommentarTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.kommentarTextBox.Location = new System.Drawing.Point(265, 295);
            this.kommentarTextBox.Multiline = true;
            this.kommentarTextBox.Name = "kommentarTextBox";
            this.kommentarTextBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.kommentarTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.kommentarTextBox.Size = new System.Drawing.Size(427, 63);
            this.kommentarTextBox.TabIndex = 29;
            // 
            // AddSpareForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 500);
            this.Controls.Add(this.kommentarTextBox);
            this.Controls.Add(this.kommentarLabel);
            this.Controls.Add(this.leverantörensArtNrTextBox);
            this.Controls.Add(this.leverantörensArtNrLabel);
            this.Controls.Add(this.artikelbenämningTextBox);
            this.Controls.Add(this.artikelbenämningLabel);
            this.Controls.Add(this.leverantörTextBox);
            this.Controls.Add(this.leverantörLabel);
            this.Controls.Add(this.huvudlagerComboBox);
            this.Controls.Add(this.huvudlagerLabel);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.label3);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximumSize = new System.Drawing.Size(815, 539);
            this.MinimumSize = new System.Drawing.Size(815, 539);
            this.Name = "AddSpareForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label huvudlagerLabel;
        private System.Windows.Forms.ComboBox huvudlagerComboBox;
        private System.Windows.Forms.Label leverantörLabel;
        private System.Windows.Forms.TextBox leverantörTextBox;
        private System.Windows.Forms.Label artikelbenämningLabel;
        private System.Windows.Forms.TextBox artikelbenämningTextBox;
        private System.Windows.Forms.Label leverantörensArtNrLabel;
        private System.Windows.Forms.TextBox leverantörensArtNrTextBox;
        private System.Windows.Forms.Label kommentarLabel;
        private System.Windows.Forms.TextBox kommentarTextBox;
    }
}