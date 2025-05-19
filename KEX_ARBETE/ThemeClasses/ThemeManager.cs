using System.Collections.Generic;
using System.Drawing;

namespace KEX_ARBETE
{
    public static class ThemeManager
    {
        public static Dictionary<string, Theme> Themes { get; } = new Dictionary<string, Theme>
    {
        { "Dark", new Theme { BackgroundColor = Color.FromArgb(60, 60, 60), ForegroundColor = Color.FromArgb(240,240,240),
                              ButtonBackColor = Color.FromArgb(50,50,50), ButtonForeColor = Color.LightGray,
                              TextBoxBackColor = Color.DimGray, TextBoxForeColor = Color.White,
                              ToolStripBackColor = Color.FromArgb(45, 45, 45), ToolStripForeColor = Color.White,
                              MenuBackColor = Color.FromArgb(50, 50, 50), MenuForeColor = Color.White} },

        { "Light", new Theme { BackgroundColor = Color.FromArgb(245, 245, 245), ForegroundColor = Color.Black,
                               ButtonBackColor = Color.LightGray, ButtonForeColor = Color.Black,
                               TextBoxBackColor = Color.White, TextBoxForeColor = Color.Black,
                               ToolStripBackColor = Color.Gainsboro, ToolStripForeColor = Color.Black,
                               MenuBackColor = Color.White, MenuForeColor = Color.Black} },

        { "Retro", new Theme { BackgroundColor = Color.FromArgb(255, 250, 220), ForegroundColor = Color.Blue,
                               ButtonBackColor = Color.LightBlue, ButtonForeColor = Color.Black,
                               TextBoxBackColor = Color.FromArgb(240, 240, 240), TextBoxForeColor = Color.Black,
                               ToolStripBackColor = Color.FromArgb(15, 102, 163), ToolStripForeColor = Color.White,
                               MenuBackColor = Color.FromArgb(0, 100, 100), MenuForeColor = Color.Yellow} }
    };
    }
}
