using KEX_ARBETE.ThemeClasses;
using System;
using System.Windows.Forms;

namespace KEX_ARBETE
{
    public partial class AdminForm : Form
    {
        private Theme theme;

        private string password = "";

        private Boolean hasAdminAccess;
        //public static string password { get; private set; } = "1234";


        public AdminForm(Theme currentTheme, string currentPassword)
        {
            InitializeComponent();
            this.theme = currentTheme;
            this.password = currentPassword;
            ApplyThemeToForm();
        }

        private void ApplyThemeToForm()
        {
            foreach (Control control in this.Controls)
            {
                ApplyThemeClass.ApplyThemeToForm(this, theme);
            }
        }

        /// <summary>
        /// Gets the current state of the admin access.
        /// </summary>
        /// <returns>Returns true if the user has admin access, otherwise false.</returns>
        public Boolean GetAdminAccess()
        {
            return this.hasAdminAccess;
        }

        /// <summary>
        /// Sets the admin access.
        /// </summary>
        /// <param name="access">The state that the admin access should be set to.</param>
        public void setAdminAccess(Boolean access)
        {
            this.hasAdminAccess = access;
        }       

        // EventHandlers

        /// <summary>
        /// Handles what happens when the user press on the log in button. The result will be communicated to the main form through DialogResult.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnLogInButtonClick(object sender, EventArgs e)
        {
            //(enterPassTextBox.Text.Trim() == "1234")
            if ((enterPassTextBox.Text.Trim() == password) && !(hasAdminAccess))
            {
                this.DialogResult = DialogResult.OK;
                this.Close(); // Close the form on successful login
            }
            else
            {
                MessageBox.Show("Fel lösenord, försök igen.", "Inloggning misslyckades", MessageBoxButtons.OK, MessageBoxIcon.Error);
                enterPassTextBox.Clear(); // Clear input
                enterPassTextBox.Focus(); // Focus back on the textbox
            }
        }

        /// <summary>
        /// Handles what happens when the user press the cancel button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnCancelButtonClick(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
