using System;

namespace KEX_ARBETE
{
    /// <summary>
    /// An interface representing all UserControls that represents a menu.
    /// </summary>
    public interface IMenu
    {
        /// <summary>
        /// Indicates if a UserControl is currently shown or not.
        /// </summary>
        Boolean IsShown { get; set; }

        /// <summary>
        /// Indicated if a UserControl is the next one to be shown if the user goes back one step in the hierarchy of menues.
        /// </summary>
        Boolean WasLastShown { get; set; }

        /// <summary>
        /// Indicates if the user had admin access or not.
        /// </summary>
        Boolean HasAdminAccess { get; set; }

        /// <summary>
        /// The choosen theme for the program.
        /// </summary>
        Theme CurrentTheme { get; set; }

        /// <summary>
        /// Shows the UserControl.
        /// </summary>
        void ShowUserControl();

        /// <summary>
        /// Hides the UserControl.
        /// </summary>
        void HideUserControl();

        /// <summary>
        /// Sets what text should be displayed when the user presses the Page info button.
        /// </summary>
        void ShowPageInfo();

        /// <summary>
        /// Applies the choosen theme to the current UserControl.
        /// </summary>
        void ApplyThemeToUserControl();
    }
}
