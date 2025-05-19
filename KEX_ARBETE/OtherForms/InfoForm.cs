using KEX_ARBETE.ThemeClasses;
using System;
using System.Windows.Forms;

namespace KEX_ARBETE
{
    public partial class InfoForm : Form
    {
        private Theme theme;

        public InfoForm(Theme currentTheme)
        {
            InitializeComponent();
            this.theme = currentTheme;
            ApplyThemeToForm();
        }

        private void InfoForm_Load(object sender, EventArgs e)
        {

        }

        private void ApplyThemeToForm()
        {
            foreach (Control control in this.Controls)
            {
                ApplyThemeClass.ApplyThemeToForm(this, theme);
            }
        }



        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close(); // Closes the info window
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
