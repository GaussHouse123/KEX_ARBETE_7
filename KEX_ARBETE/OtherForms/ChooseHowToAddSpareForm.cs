using KEX_ARBETE.ThemeClasses;
using System;
using System.Windows.Forms;

namespace KEX_ARBETE.OtherForms
{
    public partial class ChooseHowToAddSpareForm : Form
    {
        private Theme theme;

        public event EventHandler AddNewSpareEventHandler;
        public event EventHandler AddUnassignedSpareEventHandler;
        public event EventHandler AddExistingSpareEventHandler;


        public ChooseHowToAddSpareForm(Theme currentTheme)
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

        private void OkNewButtonClick(object sender, EventArgs e)
        {
            AddNewSpareEventHandler?.Invoke(this, e);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void OkUnassignedButtonClick(object sender, EventArgs e)
        {
            AddUnassignedSpareEventHandler?.Invoke(this, e);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void OkExistingButtonClick(object sender, EventArgs e)
        {
            AddExistingSpareEventHandler?.Invoke(this, e);
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
