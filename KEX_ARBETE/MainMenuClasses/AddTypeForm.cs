using KEX_ARBETE.ThemeClasses;
using System;
using System.Windows.Forms;
using WindowsFormsApp1.Model;

namespace KEX_ARBETE.MainMenuClasses
{
    /// <summary>
    /// The form that opens when the user wants to add a new type to the program.
    /// </summary>
    public partial class AddTypeForm : Form
    {
        private MainProgram mainProgram;
        private Theme theme;

        // ------------------------- Constructor -------------------------

        /// <summary>
        /// Constructor of the AddTypeForm.
        /// </summary>
        /// <param name="currentMainProgram">The program in which the type will be added.</param>
        /// <param name="currentTheme">The current theme of the program.</param>
        public AddTypeForm(MainProgram currentMainProgram, Theme currentTheme)
        {
            InitializeComponent();
            this.mainProgram = currentMainProgram;
            this.theme = currentTheme;
            ApplyThemeToForm();
        }

        // ------------------------- Methods -------------------------

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
        /// Checks if the newly added type has a valid name. It way not contain only blankspaces, and may not be the name of a type that already exists.
        /// </summary>
        /// <returns>True if the choosen name is valid, otherwise false.</returns>
        private Boolean CheckIfValidName()
        {
            string nameToVerify = typeNameTextBox.Text;

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
        /// Adds the newly added type to the program.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnSaveButtonClick(object sender, EventArgs e)
        {
            string name = typeNameTextBox.Text;
            WindowsFormsApp1.Model.Type newType = new WindowsFormsApp1.Model.Type(name);
                      
            if(CheckIfValidName())
            {
                mainProgram.AddType(newType);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        /// <summary>
        /// Closes the form without saving.
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