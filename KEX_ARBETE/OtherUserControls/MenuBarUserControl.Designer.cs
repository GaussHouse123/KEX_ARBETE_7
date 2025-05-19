namespace KEX_ARBETE
{
    partial class MenuBarUserControl
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuBarUserControl));
            this.searchBox = new System.Windows.Forms.TextBox();
            this.addButton = new System.Windows.Forms.Button();
            this.pageInfoButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.attentionPictureBox = new System.Windows.Forms.PictureBox();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.homeButton = new System.Windows.Forms.ToolStripButton();
            this.settingsButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.adminSettingsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logInAdminMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logOutAdminMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changePasswordAdminMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.themeSettingsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lightModeThemeMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.darkModeThemeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.retroModeThemeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bilderSettingsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setAddressPicturesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpPicturesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadSettingsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveSettingsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.programInformationSettingsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backButton = new System.Windows.Forms.ToolStripButton();
            this.mainToolStrip = new System.Windows.Forms.ToolStrip();
            this.attentionPictureBoxToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.excelButton = new System.Windows.Forms.Button();
            this.selectMultipleButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.attentionPictureBox)).BeginInit();
            this.mainToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // searchBox
            // 
            this.searchBox.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.searchBox.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.searchBox.Location = new System.Drawing.Point(897, 2);
            this.searchBox.Margin = new System.Windows.Forms.Padding(2);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(171, 20);
            this.searchBox.TabIndex = 4;
            this.searchBox.Text = "Sök här";
            this.searchBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnSearchEnterKeyPress);
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(195, 1);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(71, 23);
            this.addButton.TabIndex = 5;
            this.addButton.Text = "Lägg till";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.OnAddItemButtonClick);
            // 
            // pageInfoButton
            // 
            this.pageInfoButton.Location = new System.Drawing.Point(283, 1);
            this.pageInfoButton.Name = "pageInfoButton";
            this.pageInfoButton.Size = new System.Drawing.Size(73, 23);
            this.pageInfoButton.TabIndex = 6;
            this.pageInfoButton.Text = "Page info";
            this.pageInfoButton.UseVisualStyleBackColor = true;
            this.pageInfoButton.Click += new System.EventHandler(this.OnPageInfoButtonClick);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(373, 1);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(73, 23);
            this.cancelButton.TabIndex = 7;
            this.cancelButton.Text = "Avbryt ";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.OnCancelButtonClick);
            // 
            // attentionPictureBox
            // 
            this.attentionPictureBox.BackColor = System.Drawing.SystemColors.Control;
            this.attentionPictureBox.Location = new System.Drawing.Point(463, 1);
            this.attentionPictureBox.Name = "attentionPictureBox";
            this.attentionPictureBox.Size = new System.Drawing.Size(31, 23);
            this.attentionPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.attentionPictureBox.TabIndex = 8;
            this.attentionPictureBox.TabStop = false;
            this.attentionPictureBox.MouseHover += new System.EventHandler(this.OntAttentionPictureBoxMouseHover);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(24, 24);
            this.toolStripButton2.Text = "toolStripButton2";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // homeButton
            // 
            this.homeButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.homeButton.Name = "homeButton";
            this.homeButton.Size = new System.Drawing.Size(37, 22);
            this.homeButton.Text = "Hem";
            this.homeButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.homeButton.Click += new System.EventHandler(this.OnHomeButtonClick);
            // 
            // settingsButton
            // 
            this.settingsButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adminSettingsMenuItem,
            this.themeSettingsMenuItem,
            this.bilderSettingsMenuItem,
            this.loadSettingsMenuItem,
            this.saveSettingsMenuItem,
            this.programInformationSettingsMenuItem});
            this.settingsButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.settingsButton.Name = "settingsButton";
            this.settingsButton.Size = new System.Drawing.Size(85, 22);
            this.settingsButton.Text = "Inställningar";
            // 
            // adminSettingsMenuItem
            // 
            this.adminSettingsMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logInAdminMenuItem,
            this.logOutAdminMenuItem,
            this.changePasswordAdminMenuItem});
            this.adminSettingsMenuItem.Name = "adminSettingsMenuItem";
            this.adminSettingsMenuItem.Size = new System.Drawing.Size(186, 22);
            this.adminSettingsMenuItem.Text = "Admin";
            // 
            // logInAdminMenuItem
            // 
            this.logInAdminMenuItem.Name = "logInAdminMenuItem";
            this.logInAdminMenuItem.Size = new System.Drawing.Size(140, 22);
            this.logInAdminMenuItem.Text = "Logga in";
            this.logInAdminMenuItem.Click += new System.EventHandler(this.OnLogInMenuItemClick);
            // 
            // logOutAdminMenuItem
            // 
            this.logOutAdminMenuItem.Name = "logOutAdminMenuItem";
            this.logOutAdminMenuItem.Size = new System.Drawing.Size(140, 22);
            this.logOutAdminMenuItem.Text = "Logga ut";
            this.logOutAdminMenuItem.Click += new System.EventHandler(this.OnLogOutMenuItemClick);
            // 
            // changePasswordAdminMenuItem
            // 
            this.changePasswordAdminMenuItem.Name = "changePasswordAdminMenuItem";
            this.changePasswordAdminMenuItem.Size = new System.Drawing.Size(140, 22);
            this.changePasswordAdminMenuItem.Text = "Byt lösenord";
            this.changePasswordAdminMenuItem.Click += new System.EventHandler(this.OnChangePasswordMenuItemClick);
            // 
            // themeSettingsMenuItem
            // 
            this.themeSettingsMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lightModeThemeMenuItem1,
            this.darkModeThemeMenuItem,
            this.retroModeThemeMenuItem});
            this.themeSettingsMenuItem.Name = "themeSettingsMenuItem";
            this.themeSettingsMenuItem.Size = new System.Drawing.Size(186, 22);
            this.themeSettingsMenuItem.Text = "Färgtema";
            // 
            // lightModeThemeMenuItem1
            // 
            this.lightModeThemeMenuItem1.Name = "lightModeThemeMenuItem1";
            this.lightModeThemeMenuItem1.Size = new System.Drawing.Size(135, 22);
            this.lightModeThemeMenuItem1.Text = "Light Mode";
            this.lightModeThemeMenuItem1.Click += new System.EventHandler(this.OnLightModeMenuItemClick);
            // 
            // darkModeThemeMenuItem
            // 
            this.darkModeThemeMenuItem.Name = "darkModeThemeMenuItem";
            this.darkModeThemeMenuItem.Size = new System.Drawing.Size(135, 22);
            this.darkModeThemeMenuItem.Text = "Dark Mode";
            this.darkModeThemeMenuItem.Click += new System.EventHandler(this.OnDarkModeMenuItemClick);
            // 
            // retroModeThemeMenuItem
            // 
            this.retroModeThemeMenuItem.Name = "retroModeThemeMenuItem";
            this.retroModeThemeMenuItem.Size = new System.Drawing.Size(135, 22);
            this.retroModeThemeMenuItem.Text = "Retro";
            this.retroModeThemeMenuItem.Click += new System.EventHandler(this.OnRetroModeMenuItemClick);
            // 
            // bilderSettingsMenuItem
            // 
            this.bilderSettingsMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setAddressPicturesMenuItem,
            this.helpPicturesMenuItem});
            this.bilderSettingsMenuItem.Name = "bilderSettingsMenuItem";
            this.bilderSettingsMenuItem.Size = new System.Drawing.Size(186, 22);
            this.bilderSettingsMenuItem.Text = "Bilder";
            // 
            // setAddressPicturesMenuItem
            // 
            this.setAddressPicturesMenuItem.Name = "setAddressPicturesMenuItem";
            this.setAddressPicturesMenuItem.Size = new System.Drawing.Size(181, 22);
            this.setAddressPicturesMenuItem.Text = "Sätt adress för bilder";
            this.setAddressPicturesMenuItem.Click += new System.EventHandler(this.OnSetAddressForPicturesMenuItemClick);
            // 
            // helpPicturesMenuItem
            // 
            this.helpPicturesMenuItem.Name = "helpPicturesMenuItem";
            this.helpPicturesMenuItem.Size = new System.Drawing.Size(181, 22);
            this.helpPicturesMenuItem.Text = "Hjälp";
            this.helpPicturesMenuItem.Click += new System.EventHandler(this.OnHelpPicturesMenuItemClick);
            // 
            // loadSettingsMenuItem
            // 
            this.loadSettingsMenuItem.Name = "loadSettingsMenuItem";
            this.loadSettingsMenuItem.Size = new System.Drawing.Size(186, 22);
            this.loadSettingsMenuItem.Text = "Ladda";
            this.loadSettingsMenuItem.Click += new System.EventHandler(this.OnLoadMenuItemClick);
            // 
            // saveSettingsMenuItem
            // 
            this.saveSettingsMenuItem.Name = "saveSettingsMenuItem";
            this.saveSettingsMenuItem.Size = new System.Drawing.Size(186, 22);
            this.saveSettingsMenuItem.Text = "Spara";
            this.saveSettingsMenuItem.Click += new System.EventHandler(this.OnSaveMenuItemClick);
            // 
            // programInformationSettingsMenuItem
            // 
            this.programInformationSettingsMenuItem.Name = "programInformationSettingsMenuItem";
            this.programInformationSettingsMenuItem.Size = new System.Drawing.Size(186, 22);
            this.programInformationSettingsMenuItem.Text = "Program Information";
            this.programInformationSettingsMenuItem.Click += new System.EventHandler(this.OnProgramInformationMenuItemClick);
            // 
            // backButton
            // 
            this.backButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(36, 22);
            this.backButton.Text = "Back";
            this.backButton.Click += new System.EventHandler(this.OnBackButtonClick);
            // 
            // mainToolStrip
            // 
            this.mainToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.mainToolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mainToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.homeButton,
            this.settingsButton,
            this.backButton});
            this.mainToolStrip.Location = new System.Drawing.Point(0, 0);
            this.mainToolStrip.Name = "mainToolStrip";
            this.mainToolStrip.Size = new System.Drawing.Size(1068, 25);
            this.mainToolStrip.TabIndex = 3;
            this.mainToolStrip.Text = "toolStrip1";
            // 
            // excelButton
            // 
            this.excelButton.Location = new System.Drawing.Point(515, 1);
            this.excelButton.Name = "excelButton";
            this.excelButton.Size = new System.Drawing.Size(72, 23);
            this.excelButton.TabIndex = 9;
            this.excelButton.Text = "Excel";
            this.excelButton.UseVisualStyleBackColor = true;
            this.excelButton.Click += new System.EventHandler(this.OnExcelButtonClick);
            // 
            // selectMultipleButton
            // 
            this.selectMultipleButton.Location = new System.Drawing.Point(593, 1);
            this.selectMultipleButton.Name = "selectMultipleButton";
            this.selectMultipleButton.Size = new System.Drawing.Size(72, 23);
            this.selectMultipleButton.TabIndex = 10;
            this.selectMultipleButton.Text = "Tilldela flera";
            this.selectMultipleButton.UseVisualStyleBackColor = true;
            this.selectMultipleButton.Click += new System.EventHandler(this.OnSelectMultipleButtonClick);
            // 
            // MenuBarUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.selectMultipleButton);
            this.Controls.Add(this.excelButton);
            this.Controls.Add(this.attentionPictureBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.pageInfoButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.searchBox);
            this.Controls.Add(this.mainToolStrip);
            this.Name = "MenuBarUserControl";
            this.Size = new System.Drawing.Size(1068, 24);
            ((System.ComponentModel.ISupportInitialize)(this.attentionPictureBox)).EndInit();
            this.mainToolStrip.ResumeLayout(false);
            this.mainToolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox searchBox;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button pageInfoButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.PictureBox attentionPictureBox;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton homeButton;
        private System.Windows.Forms.ToolStripDropDownButton settingsButton;
        private System.Windows.Forms.ToolStripMenuItem themeSettingsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem darkModeThemeMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lightModeThemeMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem retroModeThemeMenuItem;
        private System.Windows.Forms.ToolStripMenuItem adminSettingsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logInAdminMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logOutAdminMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changePasswordAdminMenuItem;
        private System.Windows.Forms.ToolStripMenuItem programInformationSettingsMenuItem;
        private System.Windows.Forms.ToolStripButton backButton;
        private System.Windows.Forms.ToolStrip mainToolStrip;
        private System.Windows.Forms.ToolTip attentionPictureBoxToolTip;
        private System.Windows.Forms.Button excelButton;
        private System.Windows.Forms.ToolStripMenuItem bilderSettingsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setAddressPicturesMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpPicturesMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveSettingsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadSettingsMenuItem;
        private System.Windows.Forms.Button selectMultipleButton;
    }
}
//            
