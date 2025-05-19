using System.Windows.Forms;

namespace KEX_ARBETE
{
    partial class ViewAccessoriesUserControl
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
            this.notPanel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.titlePanel = new System.Windows.Forms.Panel();
            this.titleLabel = new System.Windows.Forms.Label();
            this.notPanel1.SuspendLayout();
            this.titlePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // notPanel1
            // 
            this.notPanel1.AutoScroll = true;
            this.notPanel1.Controls.Add(this.tableLayoutPanel1);
            this.notPanel1.Controls.Add(this.titlePanel);
            this.notPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.notPanel1.Location = new System.Drawing.Point(0, 0);
            this.notPanel1.Name = "notPanel1";
            this.notPanel1.Size = new System.Drawing.Size(936, 548);
            this.notPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 83);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(0, 30, 0, 0);
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 210F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(936, 240);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // titlePanel
            // 
            this.titlePanel.BackColor = System.Drawing.SystemColors.Control;
            this.titlePanel.Controls.Add(this.titleLabel);
            this.titlePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.titlePanel.Location = new System.Drawing.Point(0, 0);
            this.titlePanel.Name = "titlePanel";
            this.titlePanel.Size = new System.Drawing.Size(936, 83);
            this.titlePanel.TabIndex = 0;
            // 
            // titleLabel
            // 
            this.titleLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.titleLabel.Location = new System.Drawing.Point(0, 0);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(936, 83);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "Title";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainMenuUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.notPanel1);
            this.Name = "MainMenuUserControl";
            this.Size = new System.Drawing.Size(936, 548);
            this.notPanel1.ResumeLayout(false);
            this.notPanel1.PerformLayout();
            this.titlePanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel notPanel1;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel titlePanel;
        private Label titleLabel;
    }
}
