using KEX_ARBETE.ThemeClasses;
using System;
using System.Windows.Forms;
using WindowsFormsApp1.Model;

namespace KEX_ARBETE
{
    public partial class AddSpareForm : Form
    {
        private Product product;
        private Theme theme;

        String[] input = {
                "10 MAH", "20 HMS", "30 HMS Reservdelslager", "60 KOM", "61 KOM", "80 HMS Återtaget",
                "EX19 Vision Service AB", "EX40 Roux Healthcare", "EX70 Arjo", "EX120 Haco Rehabservice",
                "EX130 Abilia"
        };

        public AddSpareForm(Product currentProduct, Theme currentTheme)
        {
            InitializeComponent();
            this.product = currentProduct;
            this.theme = currentTheme;
            huvudlagerComboBox.Items.AddRange(input);
            ApplyThemeToForm();
        }

        private void ApplyThemeToForm()
        {
            foreach (Control control in this.Controls)
            {
                ApplyThemeClass.ApplyThemeToForm(this, theme);
            }
        }

        // EventHandlers

        /// <summary>
        /// Saves the newly added spare and closes the AddAccessoryForm.
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

            Spare newSpare = new Spare(huvudlager, leverantör, artikelbenämning, leverantörArtikelNr, kommentar, true);

            product.AddSpare(newSpare);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        /// <summary>
        /// Closes the AddSpareForm.
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
