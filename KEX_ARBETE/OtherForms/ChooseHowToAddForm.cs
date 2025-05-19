using KEX_ARBETE.ThemeClasses;
using System;
using System.Windows.Forms;

namespace KEX_ARBETE.OtherForms
{
    public partial class ChooseHowToAddForm : Form
    {
        private Theme theme;

        public event EventHandler AddNewAccessoryEventHandler;
        public event EventHandler AddUnassignedAccessoryEventHandler;
        public event EventHandler AddExistingAccessoryEventHandler;


        public ChooseHowToAddForm(Theme currentTheme)
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
            AddNewAccessoryEventHandler?.Invoke(this, e);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void OkUnassignedButtonClick(object sender, EventArgs e)
        {
            AddUnassignedAccessoryEventHandler?.Invoke(this, e);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void OkExistingButtonClick(object sender, EventArgs e)
        {
            AddExistingAccessoryEventHandler?.Invoke(this, e);
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
