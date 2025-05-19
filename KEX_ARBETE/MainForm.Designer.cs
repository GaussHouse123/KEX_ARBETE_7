using System.Reflection.Emit;
using System.Windows.Forms;

namespace KEX_ARBETE
{
    partial class MainForm
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
            KEX_ARBETE.Theme theme1 = new KEX_ARBETE.Theme();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.menuBarUserControl = new KEX_ARBETE.MenuBarUserControl();
            this.viewUnassignedItemInfoUserControl = new KEX_ARBETE.ViewUnassignedItemInfoUserControl();
            this.viewUnassignedItemsUserControl = new KEX_ARBETE.ViewUnassignedItemsUserControl();
            this.viewProductInfoUserControl = new KEX_ARBETE.ViewProductInfoUserControl();
            this.viewSpareInfoUserControl = new KEX_ARBETE.ViewSpareInfoUserControl();
            this.viewSparesUserControl = new KEX_ARBETE.ViewSparesUserControl();
            this.viewAccessoryInfoUserControl = new KEX_ARBETE.ViewAccessoryInfoUserControl();
            this.viewAccessoriesUserControl = new KEX_ARBETE.ViewAccessoriesUserControl();
            this.viewProductsUserControl = new KEX_ARBETE.ViewProductUserControl();
            this.mainMenuUserControl = new KEX_ARBETE.MainMenuUserControl();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.menuBarUserControl);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.viewUnassignedItemInfoUserControl);
            this.splitContainer1.Panel2.Controls.Add(this.viewUnassignedItemsUserControl);
            this.splitContainer1.Panel2.Controls.Add(this.viewProductInfoUserControl);
            this.splitContainer1.Panel2.Controls.Add(this.viewSpareInfoUserControl);
            this.splitContainer1.Panel2.Controls.Add(this.viewSparesUserControl);
            this.splitContainer1.Panel2.Controls.Add(this.viewAccessoryInfoUserControl);
            this.splitContainer1.Panel2.Controls.Add(this.viewAccessoriesUserControl);
            this.splitContainer1.Panel2.Controls.Add(this.viewProductsUserControl);
            this.splitContainer1.Panel2.Controls.Add(this.mainMenuUserControl);
            this.splitContainer1.Size = new System.Drawing.Size(1034, 654);
            this.splitContainer1.SplitterDistance = 36;
            this.splitContainer1.TabIndex = 1;
            // 
            // menuBarUserControl
            // 
            this.menuBarUserControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menuBarUserControl.Location = new System.Drawing.Point(0, 0);
            this.menuBarUserControl.Name = "menuBarUserControl";
            this.menuBarUserControl.Size = new System.Drawing.Size(1034, 36);
            this.menuBarUserControl.TabIndex = 1;
            // 
            // viewUnassignedItemInfoUserControl
            // 
            this.viewUnassignedItemInfoUserControl.CurrentTheme = null;
            this.viewUnassignedItemInfoUserControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewUnassignedItemInfoUserControl.HasAdminAccess = false;
            this.viewUnassignedItemInfoUserControl.IsShown = false;
            this.viewUnassignedItemInfoUserControl.Location = new System.Drawing.Point(0, 0);
            this.viewUnassignedItemInfoUserControl.Name = "viewUnassignedItemInfoUserControl";
            this.viewUnassignedItemInfoUserControl.Size = new System.Drawing.Size(1034, 614);
            this.viewUnassignedItemInfoUserControl.TabIndex = 2;
            this.viewUnassignedItemInfoUserControl.WasLastShown = false;
            // 
            // viewUnassignedItemsUserControl
            // 
            this.viewUnassignedItemsUserControl.CurrentTheme = null;
            this.viewUnassignedItemsUserControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewUnassignedItemsUserControl.HasAdminAccess = false;
            this.viewUnassignedItemsUserControl.IsShown = false;
            this.viewUnassignedItemsUserControl.Location = new System.Drawing.Point(0, 0);
            this.viewUnassignedItemsUserControl.Name = "viewUnassignedItemsUserControl";
            this.viewUnassignedItemsUserControl.Size = new System.Drawing.Size(1034, 614);
            this.viewUnassignedItemsUserControl.TabIndex = 2;
            this.viewUnassignedItemsUserControl.WasLastShown = false;
            // 
            // viewProductInfoUserControl
            // 
            this.viewProductInfoUserControl.CurrentTheme = null;
            this.viewProductInfoUserControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewProductInfoUserControl.HasAdminAccess = false;
            this.viewProductInfoUserControl.IsShown = false;
            this.viewProductInfoUserControl.Location = new System.Drawing.Point(0, 0);
            this.viewProductInfoUserControl.Name = "viewProductInfoUserControl";
            this.viewProductInfoUserControl.Size = new System.Drawing.Size(1034, 614);
            this.viewProductInfoUserControl.TabIndex = 5;
            this.viewProductInfoUserControl.WasLastShown = false;
            // 
            // viewSpareInfoUserControl
            // 
            this.viewSpareInfoUserControl.CurrentTheme = null;
            this.viewSpareInfoUserControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewSpareInfoUserControl.HasAdminAccess = false;
            this.viewSpareInfoUserControl.IsShown = false;
            this.viewSpareInfoUserControl.Location = new System.Drawing.Point(0, 0);
            this.viewSpareInfoUserControl.Margin = new System.Windows.Forms.Padding(2);
            this.viewSpareInfoUserControl.Name = "viewSpareInfoUserControl";
            this.viewSpareInfoUserControl.Size = new System.Drawing.Size(1034, 614);
            this.viewSpareInfoUserControl.TabIndex = 2;
            this.viewSpareInfoUserControl.WasLastShown = false;
            // 
            // viewSparesUserControl
            // 
            this.viewSparesUserControl.CurrentTheme = null;
            this.viewSparesUserControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewSparesUserControl.HasAdminAccess = false;
            this.viewSparesUserControl.IsShown = false;
            this.viewSparesUserControl.Location = new System.Drawing.Point(0, 0);
            this.viewSparesUserControl.Name = "viewSparesUserControl";
            this.viewSparesUserControl.Size = new System.Drawing.Size(1034, 614);
            this.viewSparesUserControl.TabIndex = 2;
            this.viewSparesUserControl.WasLastShown = false;
            // 
            // viewAccessoryInfoUserControl
            // 
            this.viewAccessoryInfoUserControl.CurrentTheme = null;
            this.viewAccessoryInfoUserControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewAccessoryInfoUserControl.HasAdminAccess = false;
            this.viewAccessoryInfoUserControl.IsShown = false;
            this.viewAccessoryInfoUserControl.Location = new System.Drawing.Point(0, 0);
            this.viewAccessoryInfoUserControl.Margin = new System.Windows.Forms.Padding(2);
            this.viewAccessoryInfoUserControl.Name = "viewAccessoryInfoUserControl";
            this.viewAccessoryInfoUserControl.Size = new System.Drawing.Size(1034, 614);
            this.viewAccessoryInfoUserControl.TabIndex = 4;
            this.viewAccessoryInfoUserControl.WasLastShown = false;
            // 
            // viewAccessoriesUserControl
            // 
            this.viewAccessoriesUserControl.CurrentTheme = null;
            this.viewAccessoriesUserControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewAccessoriesUserControl.HasAdminAccess = false;
            this.viewAccessoriesUserControl.IsShown = false;
            this.viewAccessoriesUserControl.Location = new System.Drawing.Point(0, 0);
            this.viewAccessoriesUserControl.Name = "viewAccessoriesUserControl";
            this.viewAccessoriesUserControl.Size = new System.Drawing.Size(1034, 614);
            this.viewAccessoriesUserControl.TabIndex = 2;
            this.viewAccessoriesUserControl.WasLastShown = false;
            // 
            // viewProductsUserControl
            // 
            this.viewProductsUserControl.CurrentTheme = null;
            this.viewProductsUserControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewProductsUserControl.HasAdminAccess = false;
            this.viewProductsUserControl.IsShown = false;
            this.viewProductsUserControl.Location = new System.Drawing.Point(0, 0);
            this.viewProductsUserControl.Name = "viewProductsUserControl";
            this.viewProductsUserControl.Size = new System.Drawing.Size(1034, 614);
            this.viewProductsUserControl.TabIndex = 2;
            this.viewProductsUserControl.WasLastShown = false;
            // 
            // mainMenuUserControl
            // 
            this.mainMenuUserControl.BackColor = System.Drawing.SystemColors.ControlDark;
            theme1.BackgroundColor = System.Drawing.Color.Empty;
            theme1.ButtonBackColor = System.Drawing.Color.Empty;
            theme1.ButtonForeColor = System.Drawing.Color.Empty;
            theme1.ForegroundColor = System.Drawing.Color.Empty;
            theme1.MenuBackColor = System.Drawing.Color.Empty;
            theme1.MenuForeColor = System.Drawing.Color.Empty;
            theme1.TextBoxBackColor = System.Drawing.Color.Empty;
            theme1.TextBoxForeColor = System.Drawing.Color.Empty;
            theme1.ToolStripBackColor = System.Drawing.Color.Empty;
            theme1.ToolStripForeColor = System.Drawing.Color.Empty;
            this.mainMenuUserControl.CurrentTheme = theme1;
            this.mainMenuUserControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainMenuUserControl.HasAdminAccess = false;
            this.mainMenuUserControl.IsShown = false;
            this.mainMenuUserControl.Location = new System.Drawing.Point(0, 0);
            this.mainMenuUserControl.Margin = new System.Windows.Forms.Padding(2);
            this.mainMenuUserControl.Name = "mainMenuUserControl";
            this.mainMenuUserControl.Size = new System.Drawing.Size(1034, 614);
            this.mainMenuUserControl.TabIndex = 0;
            this.mainMenuUserControl.WasLastShown = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1034, 654);
            this.Controls.Add(this.splitContainer1);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnFormClosing);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private MainMenuUserControl mainMenuUserControl;
        private SplitContainer splitContainer1;
        private MenuBarUserControl menuBarUserControl;
        private ViewProductUserControl viewProductsUserControl;
        private ViewAccessoriesUserControl viewAccessoriesUserControl;
        private ViewAccessoryInfoUserControl viewAccessoryInfoUserControl;
        private ViewSparesUserControl viewSparesUserControl;
        private ViewSpareInfoUserControl viewSpareInfoUserControl;
        private ViewProductInfoUserControl viewProductInfoUserControl;
        private ViewUnassignedItemsUserControl viewUnassignedItemsUserControl;
        private ViewUnassignedItemInfoUserControl viewUnassignedItemInfoUserControl;
    }
}

