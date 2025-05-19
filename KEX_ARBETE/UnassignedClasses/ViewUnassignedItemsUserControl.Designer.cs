using System.Windows.Forms;

namespace KEX_ARBETE
{
    partial class ViewUnassignedItemsUserControl
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
        /// 

        private void InitializeComponent()
        {
            this.notPanel1 = new System.Windows.Forms.Panel();
            this.bottomPanel = new System.Windows.Forms.Panel();
            this.pageNavigatorUserControl1 = new KEX_ARBETE.PageNavigatorUserControl();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.titlePanel = new System.Windows.Forms.Panel();
            this.titleLabel = new System.Windows.Forms.Label();
            this.notPanel1.SuspendLayout();
            this.bottomPanel.SuspendLayout();
            this.titlePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // notPanel1
            // 
            this.notPanel1.AutoScroll = true;
            this.notPanel1.Controls.Add(this.bottomPanel);
            this.notPanel1.Controls.Add(this.tableLayoutPanel1);
            this.notPanel1.Controls.Add(this.titlePanel);
            this.notPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.notPanel1.Location = new System.Drawing.Point(0, 0);
            this.notPanel1.Name = "notPanel1";
            this.notPanel1.Size = new System.Drawing.Size(936, 620);
            this.notPanel1.TabIndex = 0;
            // 
            // bottomPanel
            // 
            this.bottomPanel.Controls.Add(this.pageNavigatorUserControl1);
            this.bottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomPanel.Location = new System.Drawing.Point(0, 410);
            this.bottomPanel.Name = "bottomPanel";
            this.bottomPanel.Padding = new System.Windows.Forms.Padding(100, 30, 100, 30);
            this.bottomPanel.Size = new System.Drawing.Size(936, 210);
            this.bottomPanel.TabIndex = 2;
            // 
            // pageNavigatorUserControl1
            // 
            this.pageNavigatorUserControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pageNavigatorUserControl1.Location = new System.Drawing.Point(100, 30);
            this.pageNavigatorUserControl1.MaximumSize = new System.Drawing.Size(559, 203);
            this.pageNavigatorUserControl1.MinimumSize = new System.Drawing.Size(559, 203);
            this.pageNavigatorUserControl1.Name = "pageNavigatorUserControl1";
            this.pageNavigatorUserControl1.Size = new System.Drawing.Size(559, 203);
            this.pageNavigatorUserControl1.TabIndex = 0;
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
            this.titleLabel.Text = "Meny för icke-tilldelade produkter";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ViewUnassignedItemsUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.notPanel1);
            this.Name = "ViewUnassignedItemsUserControl";
            this.Size = new System.Drawing.Size(936, 620);
            this.notPanel1.ResumeLayout(false);
            this.notPanel1.PerformLayout();
            this.bottomPanel.ResumeLayout(false);
            this.titlePanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel notPanel1;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel titlePanel;
        private Label titleLabel;
        private Panel bottomPanel;
        private PageNavigatorUserControl pageNavigatorUserControl1;

        /*
                private void InitializeComponent()
                {
                    this.notPanel1 = new System.Windows.Forms.Panel();
                    this.bottomPanel = new System.Windows.Forms.Panel();
                    this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
                    this.titlePanel = new System.Windows.Forms.Panel();
                    this.titleLabel = new System.Windows.Forms.Label();
                    this.pageNavigatorUserControl1 = new KEX_Arbete.PageNavigatorUserControl();
                    this.notPanel1.SuspendLayout();
                    this.bottomPanel.SuspendLayout();
                    this.titlePanel.SuspendLayout();
                    this.SuspendLayout();
                    // 
                    // notPanel1
                    // 
                    this.notPanel1.AutoScroll = true;
                    this.notPanel1.Controls.Add(this.bottomPanel);
                    this.notPanel1.Controls.Add(this.tableLayoutPanel1);
                    this.notPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
                    this.notPanel1.Location = new System.Drawing.Point(0, 0);
                    this.notPanel1.Name = "notPanel1";
                    this.notPanel1.Size = new System.Drawing.Size(936, 548);
                    this.notPanel1.TabIndex = 0;
                    // 
                    // bottomPanel
                    // 
                    this.bottomPanel.Controls.Add(this.pageNavigatorUserControl1);
                    this.bottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
                    this.bottomPanel.Location = new System.Drawing.Point(0, 316);
                    this.bottomPanel.Name = "bottomPanel";
                    this.bottomPanel.Padding = new System.Windows.Forms.Padding(100, 30, 100, 0);
                    this.bottomPanel.Size = new System.Drawing.Size(936, 232);
                    this.bottomPanel.TabIndex = 1;
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
                    this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
                    this.tableLayoutPanel1.Name = "tableLayoutPanel1";
                    this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(0, 30, 0, 0);
                    this.tableLayoutPanel1.RowCount = 1;
                    this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 210F));
                    this.tableLayoutPanel1.Size = new System.Drawing.Size(936, 240);
                    this.tableLayoutPanel1.TabIndex = 0;
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
                    // pageNavigatorUserControl1
                    // 
                    this.pageNavigatorUserControl1.Dock = System.Windows.Forms.DockStyle.Fill;
                    this.pageNavigatorUserControl1.Location = new System.Drawing.Point(100, 30);
                    this.pageNavigatorUserControl1.MaximumSize = new System.Drawing.Size(559, 203);
                    this.pageNavigatorUserControl1.MinimumSize = new System.Drawing.Size(559, 203);
                    this.pageNavigatorUserControl1.Name = "pageNavigatorUserControl1";
                    this.pageNavigatorUserControl1.Size = new System.Drawing.Size(559, 203);
                    this.pageNavigatorUserControl1.TabIndex = 0;
                    // 
                    // UnassignedItemsUserControl
                    // 
                    this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
                    this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                    this.Controls.Add(this.notPanel1);
                    this.Name = "UnassignedItemsUserControl";
                    this.Size = new System.Drawing.Size(936, 548);
                    this.notPanel1.ResumeLayout(false);
                    this.notPanel1.PerformLayout();
                    this.bottomPanel.ResumeLayout(false);
                    this.titlePanel.ResumeLayout(false);
                    this.ResumeLayout(false);

                }

                #endregion

                private System.Windows.Forms.Panel notPanel1;
                //private System.Windows.Forms.Panel notPanel2;
                private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
                private System.Windows.Forms.Panel bottomPanel;
                private Panel titlePanel;
                private Label titleLabel;
                private PageNavigatorUserControl pageNavigatorUserControl1;
        */
    }
}
