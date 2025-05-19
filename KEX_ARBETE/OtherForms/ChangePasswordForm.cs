using KEX_ARBETE.ThemeClasses;
using System;
using System.Windows.Forms;

namespace KEX_ARBETE
{
    public partial class ChangePasswordForm : Form
    {
        private Theme theme;
        private string password;
        public ChangePasswordForm(Theme currentTheme, string currentPassword)
        {
            InitializeComponent();
            this.theme = currentTheme;
            this.password = currentPassword;
            ApplyThemeToForm();
        }

        private void ApplyThemeToForm()
        {
            foreach (Control control in this.Controls)
            {
                ApplyThemeClass.ApplyThemeToForm(this, theme);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void SavePassButton_Click(object sender, EventArgs e)
        {
            if (passtextBox1.Text.Trim() == passtextBox2.Text.Trim())
            {
                //password = passtextBox1.Text.Trim();
                MessageBox.Show("Nytt lösenord sparat", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;

                //string newPassword = passtextBox1.Text.Trim();
                //PasswordManager.SavePassword(newPassword); // Save to Registry
                // MessageBox.Show("Nytt lösenord sparat permanent!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Lösenorden matchar ej", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                passtextBox1.Clear(); // Clear input
                passtextBox1.Focus();
                passtextBox2.Clear();
                passtextBox2.Focus();
            }
        }

        public string GetPassword()
        {
            return passtextBox1.Text.Trim();
        }

        private void CancelPassButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Console.WriteLine("DBG!");

            this.Close();
        }
    }
}
