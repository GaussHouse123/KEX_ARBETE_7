using KEX_ARBETE.ThemeClasses;
using System;
using System.Windows.Forms;

namespace KEX_ARBETE.OtherForms
{
    public partial class ChooseWhichUnassignedToViewForm : Form
    {
        private Theme theme;
        public ChooseWhichUnassignedToViewForm(Theme currentTheme)
        {
            InitializeComponent();
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


        public CheckBox GetProductCheckBox()
        {
            return this.productsCheckBox;
        }

        public CheckBox GetAccessoryAndSpareCheckBox()
        {
            return this.accessoriesAndSparesCheckBox;
        }

        public CheckBox GetAllCheckBox()
        {
            return this.allCheckBox;
        }



        private void OkButtonClick(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void CancelButtonClick(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
