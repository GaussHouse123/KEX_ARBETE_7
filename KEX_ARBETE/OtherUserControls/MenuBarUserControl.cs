using System;
using System.Windows.Forms;

namespace KEX_ARBETE
{
    public partial class MenuBarUserControl : UserControl
    {
        public MenuBarUserControl()
        {
            InitializeComponent();
            addButton.Enabled = false;
            logInAdminMenuItem.Enabled = true;
            logOutAdminMenuItem.Enabled = false;
            changePasswordAdminMenuItem.Enabled = false;
            excelButton.Enabled = false;
            selectMultipleButton.Enabled = false;
        }

        public event EventHandler ApplyDarkThemeEventHandler;
        public event EventHandler ApplyLightThemeEventHandler;
        public event EventHandler ApplyRetroThemeEventHandler;
        public event EventHandler LogInEventHandler;
        public event EventHandler LogOutEventHandler;
        public event EventHandler GoBackEventHandler;
        public event EventHandler AddItemEventHandler;
        public event EventHandler GoHomeEventHandler;
        public event EventHandler ViewProgramInfoEventHandler;
        public event EventHandler ChangePasswordEventHandler;
        public event EventHandler PageInfoEventHandler;
        public event EventHandler CancelActivityEventHandler;
        public event EventHandler ViewAttentionToolTipTextEventHandler;
        public event EventHandler LoadExcelDataEventHandler;
        public event EventHandler SetPicturesDirectoryEventHandler;
        public event EventHandler SaveDataEventHandler;
        public event EventHandler LoadDataEventHandler;
        public event EventHandler AssignMultipleEventHandler;
        public event EventHandler AddMultipleEventHandler;
        public event EventHandler ViewPictureHelpEventHandler;
        public event KeyEventHandler SearchEventHandler;


        /// <summary>
        /// Enables all controls that requires admin access to use.
        /// </summary>
        public void EnableAdminFeatures()
        {
            logInAdminMenuItem.Enabled = false;
            logOutAdminMenuItem.Enabled = true;
            changePasswordAdminMenuItem.Enabled = true;
            addButton.Enabled = true;
            excelButton.Enabled = true;
            selectMultipleButton.Enabled = true;
        }

        /// <summary>
        /// Disables all controls that requires admin access to use.
        /// </summary>
        public void DisableAdminFeatures()
        {
            logInAdminMenuItem.Enabled = true;
            logOutAdminMenuItem.Enabled = false;
            changePasswordAdminMenuItem.Enabled = false;
            addButton.Enabled = false;
            excelButton.Enabled = false;
            selectMultipleButton.Enabled = false;
        }  

        /// <summary>
        /// Sets the text of the tooltip that appears when the mouse is hovering over the attention sign.
        /// </summary>
        /// <param name="toolTipText">The text that should be displayed in the tooltip.</param>
        public void SetAttentionSignToolTipText(string toolTipText)
        {
            attentionPictureBoxToolTip.Show(toolTipText, attentionPictureBox);
        }

        /// <summary>
        /// Makes the add button visible or not.
        /// </summary>
        /// <param name="state">True means it should be visible, false means it should be hidden.</param>
        public void SetAddButtonVisibility(Boolean state)
        {
            addButton.Visible = state;
        }

        /// <summary>
        /// Makes the info button visible or not.
        /// </summary>
        /// <param name="state">True means it should be visible, false means it should be hidden.</param>
        public void SetInfoButtonVisibility(Boolean state)
        {
            pageInfoButton.Visible = state;
        }

        /// <summary>
        /// Makes the excel button visible or not.
        /// </summary>
        /// <param name="state">True means it should be visible, false means it should be hidden.</param>
        public void SetExcelButtonVisibility(Boolean state)
        {
            excelButton.Visible = state;
        }

        /// <summary>
        /// Makes the select multiple button visible or not.
        /// </summary>
        /// <param name="state">True means it should be visible, false means it should be hidden.</param>
        public void SetSelectMultipleButtonVisibility(Boolean state)
        {
            selectMultipleButton.Visible = state;
        }

        /// <summary>
        /// Makes the cancel button and the attention picture visible or not.
        /// </summary>
        /// <param name="state">True means they should be visible, false means they should be hidden.</param>
        public void SetAttentionVisibility(Boolean state) 
        {
            cancelButton.Visible = state;
            attentionPictureBox.Visible = state;     
        }

        /// <summary>
        /// Gets the toolstrip of the menu bar.
        /// </summary>
        /// <returns>The toolstrip.</returns>
        public ToolStrip GetToolStrip()
        {
            return this.mainToolStrip;
        }

        /// <summary>
        /// Retrieves the text box that is the search box.
        /// </summary>
        /// <returns>The text box.</returns>
        public TextBox GetSearchBarTextBox()
        {
            return this.searchBox;
        }

        // EventHandlers

        private void OnHomeButtonClick(object sender, EventArgs e)
        {
            GoHomeEventHandler?.Invoke(this, e);
        }

        private void OnLogInMenuItemClick(object sender, EventArgs e)
        {
            LogInEventHandler?.Invoke(this, e);
        }

        private void OnLogOutMenuItemClick(object sender, EventArgs e)
        {
            LogOutEventHandler?.Invoke(this, e);
        }

        private void OnChangePasswordMenuItemClick(object sender, EventArgs e)
        {
            ChangePasswordEventHandler?.Invoke(this, e);
        }

        private void OnLightModeMenuItemClick(object sender, EventArgs e)
        {
            ApplyLightThemeEventHandler?.Invoke(this, e);
        }

        private void OnDarkModeMenuItemClick(object sender, EventArgs e)
        {
            ApplyDarkThemeEventHandler?.Invoke(this, e);
        }

        private void OnRetroModeMenuItemClick(object sender, EventArgs e)
        {
            ApplyRetroThemeEventHandler?.Invoke(this, e);
        }

        private void OnSetAddressForPicturesMenuItemClick(object sender, EventArgs e)
        {
            SetPicturesDirectoryEventHandler?.Invoke(this, e);
        }

        private void OnHelpPicturesMenuItemClick(object sender, EventArgs e)
        {
            ViewPictureHelpEventHandler?.Invoke(this, e);
        }

        private void OnLoadMenuItemClick(object sender, EventArgs e)
        {
            LoadDataEventHandler?.Invoke(this, e);
        }

        private void OnSaveMenuItemClick(object sender, EventArgs e)
        {
            SaveDataEventHandler?.Invoke(this, e);
        }

        private void OnProgramInformationMenuItemClick(object sender, EventArgs e)
        {
            ViewProgramInfoEventHandler?.Invoke(this, e);
        }

        private void OnBackButtonClick(object sender, EventArgs e)
        {
            GoBackEventHandler?.Invoke(this, e);
        }

        private void OnAddItemButtonClick(object sender, EventArgs e)
        {
            AddItemEventHandler?.Invoke(this, e);
        }

        private void OnPageInfoButtonClick(object sender, EventArgs e)
        {
            PageInfoEventHandler?.Invoke(this, e);
        }

        private void OnCancelButtonClick(object sender, EventArgs e)
        {
            CancelActivityEventHandler?.Invoke(this, e);
        }

        private void OntAttentionPictureBoxMouseHover(object sender, EventArgs e)
        {
            ViewAttentionToolTipTextEventHandler?.Invoke(this, e);
        }

        private void OnExcelButtonClick(object sender, EventArgs e)
        {
            LoadExcelDataEventHandler?.Invoke(this, e);
        }

        private void OnSelectMultipleButtonClick(object sender, EventArgs e)
        {
            AssignMultipleEventHandler?.Invoke(this, e);
        }

        private void OnSearchEnterKeyPress(object sender, KeyEventArgs e)
        {
            SearchEventHandler?.Invoke(sender, e);
        }      
    }
}
