namespace KEX_ARBETE.OtherForms
{
    partial class ChooseHowToAddSpareForm
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
            this.cancelButton = new System.Windows.Forms.Button();
            this.okNewButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.okUnassignedButton = new System.Windows.Forms.Button();
            this.okExistingButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(234, 294);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(112, 35);
            this.cancelButton.TabIndex = 13;
            this.cancelButton.Text = "Avbryt";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.CancelButtonClick);
            // 
            // okNewButton
            // 
            this.okNewButton.Location = new System.Drawing.Point(333, 119);
            this.okNewButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.okNewButton.Name = "okNewButton";
            this.okNewButton.Size = new System.Drawing.Size(112, 35);
            this.okNewButton.TabIndex = 12;
            this.okNewButton.Text = "Ok";
            this.okNewButton.UseVisualStyleBackColor = true;
            this.okNewButton.Click += new System.EventHandler(this.OkNewButtonClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(189, 60);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(192, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "Vill du lägga till genom att:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label2.Location = new System.Drawing.Point(135, 126);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(156, 20);
            this.label2.TabIndex = 16;
            this.label2.Text = "Lägg till nytt tillbehör:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label3.Location = new System.Drawing.Point(25, 175);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(266, 20);
            this.label3.TabIndex = 17;
            this.label3.Text = "Lägg till från icke-tilldelade produkter";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(85, 231);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(206, 20);
            this.label4.TabIndex = 18;
            this.label4.Text = "Lägg till från annan produkt:";
            // 
            // okUnassignedButton
            // 
            this.okUnassignedButton.Location = new System.Drawing.Point(333, 168);
            this.okUnassignedButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.okUnassignedButton.Name = "okUnassignedButton";
            this.okUnassignedButton.Size = new System.Drawing.Size(112, 35);
            this.okUnassignedButton.TabIndex = 19;
            this.okUnassignedButton.Text = "Ok";
            this.okUnassignedButton.UseVisualStyleBackColor = true;
            this.okUnassignedButton.Click += new System.EventHandler(this.OkUnassignedButtonClick);
            // 
            // okExistingButton
            // 
            this.okExistingButton.Location = new System.Drawing.Point(333, 224);
            this.okExistingButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.okExistingButton.Name = "okExistingButton";
            this.okExistingButton.Size = new System.Drawing.Size(112, 35);
            this.okExistingButton.TabIndex = 20;
            this.okExistingButton.Text = "Ok";
            this.okExistingButton.UseVisualStyleBackColor = true;
            this.okExistingButton.Click += new System.EventHandler(this.OkExistingButtonClick);
            // 
            // ChooseHowToAddSpareForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 407);
            this.Controls.Add(this.okExistingButton);
            this.Controls.Add(this.okUnassignedButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okNewButton);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ChooseHowToAddSpareForm";
            this.Text = "ChooseHowToAddAccessoryOrSpareForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okNewButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button okUnassignedButton;
        private System.Windows.Forms.Button okExistingButton;
    }
}