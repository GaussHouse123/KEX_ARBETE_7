using KEX_ARBETE.ThemeClasses;
using System;
using System.Windows.Forms;
using WindowsFormsApp1.Model;

namespace KEX_ARBETE.MainMenuClasses
{
    /// <summary>
    /// The form that opens when the user wants to change the name of a type.
    /// </summary>
    public partial class ChangeTypeNameForm : Form
    {
        private string buttonText;

        private MainProgram mainProgram;
        private Theme theme;

        // ------------------------- Constructor -------------------------

        /// <summary>
        /// Constructor of the ChangeTypeNameForm.
        /// </summary>
        /// <param name="mainProgram">The program in which the choosen type exists.</param>
        /// <param name="buttonText">The text of the button that the user wants the change name on.</param>
        /// <param name="currentTheme">The current theme of the program.</param>
        public ChangeTypeNameForm(MainProgram mainProgram, string buttonText, Theme currentTheme)
        {
            InitializeComponent();
            this.mainProgram = mainProgram;
            this.buttonText = buttonText;
            this.theme = currentTheme;
            ApplyThemeToForm();
        }

        // ------------------------- Methods -------------------------

        /// <summary>
        /// Gets the text in the nameTextBox.
        /// </summary>
        /// <returns>The text in the nameTextBox.</returns>
        public string GetTextBoxText()
        {
            return nameTextBox.Text;
        }

        /// <summary>
        /// Applies the current theme to the form.
        /// </summary>
        private void ApplyThemeToForm()
        {
            foreach (Control control in this.Controls)
            {
                ApplyThemeClass.ApplyThemeToForm(this, theme);
            }
        }

        /// <summary>
        /// Checks if the name the user wants the type to change to is valid. It way not contain only blankspaces, and may not be the name of a type that already exists.
        /// </summary>
        /// <returns>True if the choosen name is valid, otherwise false.</returns>
        private Boolean CheckIfValidName()
        {
            string nameToVerify = nameTextBox.Text;

            foreach (WindowsFormsApp1.Model.Type type in mainProgram.GetTypes())
            {
                if (nameToVerify == type.Name)
                {
                    MessageBox.Show("Det finns redan en kategori med detta namn. Vänligen välj ett annat namn.", "Ogiltigt namn på kategori.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }

            if (String.IsNullOrWhiteSpace(nameToVerify))
            {
                MessageBox.Show("Vänligen ange ett giltigt namn på kategorin (får ej vara tomt eller endast innehålla mellanrum).", "Ogiltigt namn på kategori.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        // ------------------------- EventHandlers -------------------------

        /// <summary>
        /// Saves the changes to the name of the choosen type.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnSaveButtonClick(object sender, EventArgs e)
        {
            foreach (WindowsFormsApp1.Model.Type type in mainProgram.GetTypes())
            {
                if (type.Name == buttonText)
                {
                    if(CheckIfValidName())
                    {
                        type.Name = nameTextBox.Text;
                        this.DialogResult = DialogResult.OK;
                    }                                         
                }
            }
        }
    
        /// <summary>
        /// Closes the form without saving.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnCancelButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
