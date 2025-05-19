namespace KEX_ARBETE.OtherForms
{
    partial class ChooseWhichUnassignedToViewForm
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
            this.productsCheckBox = new System.Windows.Forms.CheckBox();
            this.accessoriesAndSparesCheckBox = new System.Windows.Forms.CheckBox();
            this.allCheckBox = new System.Windows.Forms.CheckBox();
            this.confirmButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(129, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(221, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Välj vilka typer av unassigned items du vill se:";
            // 
            // productsCheckBox
            // 
            this.productsCheckBox.AutoSize = true;
            this.productsCheckBox.Location = new System.Drawing.Point(201, 100);
            this.productsCheckBox.Name = "productsCheckBox";
            this.productsCheckBox.Size = new System.Drawing.Size(72, 17);
            this.productsCheckBox.TabIndex = 1;
            this.productsCheckBox.Text = "Produkter";
            this.productsCheckBox.UseVisualStyleBackColor = true;
            // 
            // accessoriesAndSparesCheckBox
            // 
            this.accessoriesAndSparesCheckBox.AutoSize = true;
            this.accessoriesAndSparesCheckBox.Location = new System.Drawing.Point(201, 137);
            this.accessoriesAndSparesCheckBox.Name = "accessoriesAndSparesCheckBox";
            this.accessoriesAndSparesCheckBox.Size = new System.Drawing.Size(142, 17);
            this.accessoriesAndSparesCheckBox.TabIndex = 2;
            this.accessoriesAndSparesCheckBox.Text = "Tillbehör och reservdelar";
            this.accessoriesAndSparesCheckBox.UseVisualStyleBackColor = true;
            // 
            // allCheckBox
            // 
            this.allCheckBox.AutoSize = true;
            this.allCheckBox.Location = new System.Drawing.Point(201, 172);
            this.allCheckBox.Name = "allCheckBox";
            this.allCheckBox.Size = new System.Drawing.Size(40, 17);
            this.allCheckBox.TabIndex = 4;
            this.allCheckBox.Text = "Allt";
            this.allCheckBox.UseVisualStyleBackColor = true;
            // 
            // confirmButton
            // 
            this.confirmButton.Location = new System.Drawing.Point(254, 210);
            this.confirmButton.Name = "confirmButton";
            this.confirmButton.Size = new System.Drawing.Size(75, 23);
            this.confirmButton.TabIndex = 5;
            this.confirmButton.Text = "Ok";
            this.confirmButton.UseVisualStyleBackColor = true;
            this.confirmButton.Click += new System.EventHandler(this.OkButtonClick);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(146, 210);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 6;
            this.cancelButton.Text = "Avbryt";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.CancelButtonClick);
            // 
            // ChooseWhichUnassignedToViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(545, 292);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.confirmButton);
            this.Controls.Add(this.allCheckBox);
            this.Controls.Add(this.accessoriesAndSparesCheckBox);
            this.Controls.Add(this.productsCheckBox);
            this.Controls.Add(this.label1);
            this.MaximumSize = new System.Drawing.Size(561, 331);
            this.MinimumSize = new System.Drawing.Size(561, 331);
            this.Name = "ChooseWhichUnassignedToViewForm";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox productsCheckBox;
        private System.Windows.Forms.CheckBox accessoriesAndSparesCheckBox;
        private System.Windows.Forms.CheckBox allCheckBox;
        private System.Windows.Forms.Button confirmButton;
        private System.Windows.Forms.Button cancelButton;
    }
}