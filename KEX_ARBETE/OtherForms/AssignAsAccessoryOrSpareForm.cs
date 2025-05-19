using KEX_ARBETE.ThemeClasses;
using System;
using System.Windows.Forms;

namespace KEX_ARBETE.OtherForms
{
    public partial class AssignAsAccessoryOrSpareForm : Form
    {
        private Theme theme;
        public AssignAsAccessoryOrSpareForm(Theme currentTheme)
        {
            InitializeComponent();
            this.theme = currentTheme;
            ApplyThemeToForm();
        }

        public CheckBox GetAccessoryCheckBox()
        {
            return this.accessoryCheckBox;
        }

        public CheckBox GetSpareCheckBox()
        {
            return this.spareCheckBox;
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

        private void OnAccessoryCheckBoxStateChanged(object sender, EventArgs e)
        {
            if (accessoryCheckBox.Checked)
            {
                accessoryCheckBox.Enabled = true;
                spareCheckBox.Enabled = false;
            }
            else
            {
                accessoryCheckBox.Enabled = true;
                spareCheckBox.Enabled = true;
            }
        }

        private void ApplyThemeToForm()
        {
            foreach (Control control in this.Controls)
            {
                ApplyThemeClass.ApplyThemeToForm(this, theme);
            }
        }


        private void OnSpareCheckBoxStateChanged(object sender, EventArgs e)
        {
            if (spareCheckBox.Checked)
            {
                accessoryCheckBox.Enabled = false;
                spareCheckBox.Enabled = true;
            }
            else
            {
                accessoryCheckBox.Enabled = true;
                spareCheckBox.Enabled = true;
            }
        }
    }
}
