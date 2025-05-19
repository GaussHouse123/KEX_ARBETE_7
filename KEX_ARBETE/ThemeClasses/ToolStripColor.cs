using System.Drawing;
using System.Windows.Forms;

namespace KEX_ARBETE
{
    public class ToolStripColor : ToolStripProfessionalRenderer
    {
        private readonly Color menuBackColor;
        private readonly Color menuForeColor;

        public ToolStripColor(Color backColor, Color foreColor) : base(new ProfessionalColorTable())
        {
            menuBackColor = backColor;
            menuForeColor = foreColor;
        }

        protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
        {
            if (e.Item.Selected)
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.Gray), e.Item.ContentRectangle); // Hover color
            }
            else
            {
                e.Graphics.FillRectangle(new SolidBrush(menuBackColor), e.Item.ContentRectangle);
            }
        }
        protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
        {
            e.TextColor = menuForeColor;
            base.OnRenderItemText(e);
        }
    }
}
