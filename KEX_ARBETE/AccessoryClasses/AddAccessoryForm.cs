using KEX_ARBETE.ThemeClasses;
using System;
using System.Windows.Forms;
using WindowsFormsApp1.Model;

namespace KEX_ARBETE
{
    /// <summary>
    /// The form that the user sees when it has choosen to add an accessory.
    /// </summary>
    public partial class AddAccessoryForm : Form
    {
        private Product product;
        private Theme theme;

        String[] input = {
                "10 MAH", "20 HMS", "30 HMS Reservdelslager", "60 KOM", "61 KOM", "80 HMS Återtaget",
                "EX19 Vision Service AB", "EX40 Roux Healthcare", "EX70 Arjo", "EX120 Haco Rehabservice",
                "EX130 Abilia"
        };

        // ------------------------- Constructor -------------------------

        /// <summary>
        /// Constructor of the AddAccessoryForm.
        /// </summary>
        /// <param name="currentProduct">The product in which the accessory will be added.</param>
        /// <param name="currentTheme">The current theme of the program.</param>
        public AddAccessoryForm(Product currentProduct, Theme currentTheme)
        {
            InitializeComponent();
            this.product = currentProduct;
            this.theme = currentTheme;
            huvudlagerComboBox.Items.AddRange(input);
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

        // ------------------------- EventHandlers -------------------------

        /// <summary>
        /// Saves the newly added accessory and closes the AddAccessoryForm.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnSaveButtonClick(object sender, EventArgs e)
        {
            string huvudlager = huvudlagerComboBox.Text;
            string leverantör = leverantörTextBox.Text;
            string artikelbenämning = artikelbenämningTextBox.Text;
            string leverantörArtikelNr = leverantörensArtNrTextBox.Text;
            string kommentar = kommentarTextBox.Text;

            Accessory newAccessory = new Accessory(huvudlager, leverantör, artikelbenämning, leverantörArtikelNr, kommentar, true);
            product.AddAccessory(newAccessory);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        /// <summary>
        /// Closes the AddAccessoryForm.
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
