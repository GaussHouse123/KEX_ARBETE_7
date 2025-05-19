using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KEX_ARBETE.ThemeClasses
{
    public static class ApplyThemeClass
    {
        public static void ApplyThemeToControl(Control control, Theme theme)
        {
            if (control is Button btn)
            {
                if(!(btn.BackColor == Color.FromArgb(211, 45, 44)))
                {
                    btn.BackColor = theme.ButtonBackColor;
                    btn.ForeColor = theme.ButtonForeColor;
                }                
            }
            else if (control is TextBox txt)
            {
                txt.BackColor = theme.TextBoxBackColor;
                txt.ForeColor = theme.TextBoxForeColor;
            }
            else if(control is ComboBox comboBox)
            {
                comboBox.BackColor = theme.TextBoxBackColor;
                comboBox.ForeColor = theme.TextBoxForeColor;

            }
            else 
            {
                control.BackColor = theme.BackgroundColor;
                control.ForeColor = theme.ForegroundColor;
            }

            foreach (Control child in control.Controls)
            {
                ApplyThemeToControl(child, theme);
            }
        }



        public static void ApplyThemeToForm(Form form, Theme theme)
        {
            form.BackColor = theme.BackgroundColor;
            form.ForeColor = theme.ForegroundColor;

            foreach (Control control in form.Controls)
            {
                ApplyThemeToControl(control, theme);
            }
        }

        public static void ApplyThemeToPaginationBar(Control control, Theme theme)
        {
            if (control is Button btn)
            {  
                btn.BackColor = theme.ButtonBackColor;
                btn.ForeColor = theme.ButtonForeColor;
            }
            else if (control is Label label)
            {
                label.BackColor = theme.ButtonBackColor;
                label.ForeColor = theme.ButtonForeColor;
            }            
            
            foreach (Control child in control.Controls)
            {
                ApplyThemeToControl(child, theme);
            }
        }
    }
}
