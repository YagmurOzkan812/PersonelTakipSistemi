using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace personelTakip.UI
{
    public static class ThemeHelper
    {
        // Pastel Palette
        public static readonly Color BackgroundColor = Color.FromArgb(253, 245, 230); // Old Lace (Warm White)
        public static readonly Color ButtonColor = Color.FromArgb(174, 198, 207); // Pastel Blue
        public static readonly Color ButtonTextColor = Color.FromArgb(60, 60, 60); // Dark Gray
        public static readonly Color LabelTextColor = Color.FromArgb(80, 80, 80); // Soft Charcoal
        public static readonly Color TextBoxBackgroundColor = Color.White;
        public static readonly Color TextBoxTextColor = Color.Black;
        
        // Fonts
        public static readonly Font MainFont = new Font("Segoe UI", 10F, FontStyle.Regular);
        public static readonly Font HeaderFont = new Font("Segoe UI", 12F, FontStyle.Bold);

        public static void ApplyTheme(Form form)
        {
            form.BackColor = BackgroundColor;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.Size = new Size(820, 525);
            // form.FormBorderStyle = FormBorderStyle.FixedSingle; // Optional: to prevent resizing if desired
            
            // Loop through all controls in the form
            ApplyToControls(form.Controls);
        }

        private static void ApplyToControls(Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                if (control is Button)
                {
                    Button btn = (Button)control;
                    btn.BackColor = ButtonColor;
                    btn.ForeColor = ButtonTextColor;
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 0;
                    btn.Font = MainFont;
                }
                else if (control is Label)
                {
                    control.ForeColor = LabelTextColor;
                    // control.Font = MainFont; // Keep original font size usually, or standardized
                }
                else if (control is TextBox)
                {
                    control.BackColor = TextBoxBackgroundColor;
                    control.ForeColor = TextBoxTextColor;
                    control.Font = MainFont;
                }
                else if (control is ComboBox)
                {
                    control.BackColor = TextBoxBackgroundColor;
                    control.ForeColor = TextBoxTextColor;
                    control.Font = MainFont;
                }
                else if (control is DataGridView)
                {
                    DataGridView dgv = (DataGridView)control;
                    dgv.BackgroundColor = BackgroundColor;
                    dgv.DefaultCellStyle.BackColor = Color.White;
                    dgv.DefaultCellStyle.ForeColor = Color.Black;
                    dgv.DefaultCellStyle.SelectionBackColor = ButtonColor;
                    dgv.DefaultCellStyle.SelectionForeColor = Color.White;
                    dgv.ColumnHeadersDefaultCellStyle.BackColor = ButtonColor;
                    dgv.ColumnHeadersDefaultCellStyle.ForeColor = ButtonTextColor;
                    dgv.EnableHeadersVisualStyles = false;
                }
                else if (control is Panel || control is GroupBox)
                {
                    control.BackColor = Color.Transparent; // Or BackgroundColor
                    ApplyToControls(control.Controls); // Recursively apply to children
                }
            }
        }
    }
}
