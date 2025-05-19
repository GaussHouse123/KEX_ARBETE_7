using KEX_ARBETE.ThemeClasses;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using WindowsFormsApp1.Model;

namespace KEX_ARBETE
{
    public partial class AddProductForm : Form
    {
        private WindowsFormsApp1.Model.Type type;
        private Theme theme;

        String[] input = {
                "10 MAH", "20 HMS", "30 HMS Reservdelslager", "60 KOM", "61 KOM", "80 HMS Återtaget",
                "EX19 Vision Service AB", "EX40 Roux Healthcare", "EX70 Arjo", "EX120 Haco Rehabservice",
                "EX130 Abilia"
        };


        public AddProductForm(WindowsFormsApp1.Model.Type currentType, Theme currentTheme)
        {
            InitializeComponent();
            huvudlagerComboBox.Items.AddRange(input);
            this.type = currentType;
            this.theme = currentTheme;
            ApplyThemeToForm();
        }

        private void ApplyThemeToForm()
        {
            foreach (Control control in this.Controls)
            {
                ApplyThemeClass.ApplyThemeToForm(this, theme);
            }
        }

        private Boolean CheckIfValidName()
        {
            string nameToVerify = artikelbenämningTextBox.Text;

            foreach (Product product in type.GetProducts())
            {
                if (nameToVerify == product.Artikelbenämning)
                {
                    MessageBox.Show("Det finns redan ett huvudhjälpmedel i denna kategori med detta namn. Vänligen välj ett annat namn.", "Ogiltigt namn på huvudhjälpmedel.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }

            if (String.IsNullOrWhiteSpace(nameToVerify))
            {
                MessageBox.Show("Vänligen ange ett giltigt namn på huvudhjälpmedlet (får ej vara tomt eller endast innehålla mellanrum).", "Ogiltigt namn på huvudhjälpmedel.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        // EventHandlers
        private void OnSaveButtonClick(object sender, EventArgs e)
        {
            string huvudlager = huvudlagerComboBox.Text;
            string leverantör = leverantörTextBox.Text;
            string artikelbenämning = artikelbenämningTextBox.Text;
            string leverantörArtikelNr = leverantörensArtNrTextBox.Text;
            string kommentar = kommentarTextBox.Text;

            huvudlagerComboBox.Items.AddRange(input);

            Product newProduct = new Product(huvudlager, leverantör, artikelbenämning, leverantörArtikelNr, kommentar, true);

            if(CheckIfValidName())
            {
                type.AddProduct(newProduct);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            
        }

        private void OnCancelButtonClick(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

    }
}
