using KEX_ARBETE.ThemeClasses;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace KEX_ARBETE
{
    public partial class ViewUnassignedItemInfoUserControl : UserControl, IMenu
    {
        public event EventHandler OnAssignToItemButtonClickEventHandler;
        private string album = "";
        string directory = "C:\\Users\\Alexander\\Pictures\\MAH Main\\";

        private List<string> fileEntries = new List<string>();
        private List<PictureBox> images = new List<PictureBox>();
        private IAssignable unassignable;

        public event EventHandler UpdateItemEventHandler;
        public event EventHandler DeleteItemEventHandler;
        public event EventHandler AssignItemEventHandler;



        public ViewUnassignedItemInfoUserControl()
        {

            InitializeComponent();

        }


        private void OnAssignToItemButtonClick(object sender, EventArgs e)
        {
            OnAssignToItemButtonClickEventHandler?.Invoke(sender, e);
        }

        public Boolean IsShown { get; set; }
        public Boolean WasLastShown { get; set; }
        public Boolean HasAdminAccess { get; set; }

        public Theme CurrentTheme { get; set; }


        public void ApplyThemeToUserControl()
        {
            foreach (Control control in this.Controls)
            {
                ApplyThemeClass.ApplyThemeToControl(control, CurrentTheme);
            }
        }

        /// <summary>
        /// Hides the current user control.
        /// </summary>
        public void HideUserControl()
        {
            this.Hide();
        }

        /// <summary>
        /// Shows the current user control.
        /// </summary>
        public void ShowUserControl()
        {
            this.Show();
        }



        public void ShowPageInfo()
        {
            DialogResult result = MessageBox.Show("Detta är informationsmenyn för den icke-tilldelade produkt du valt." +
               " Du kan redigera informationen, radera produkten eller tilldela produkten. Observera att inga bilder tillåts för icke-tilldelade produkter.",
               "Information om sidan", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public void SetProduct(IAssignable currentUnassignable)
        {
            this.unassignable = currentUnassignable;

            titleLabel.Text = unassignable.Artikelbenämning;
            huvudlagerTextBox.Text = unassignable.Huvudlager;
            leverantörTextBox.Text = unassignable.Leverantör;
            artikelbenämningTextBox.Text = unassignable.Artikelbenämning;
            leverantörArtNrTextBox.Text = unassignable.LeverantörArtikelNr;
            kommentarTextBox.Text = unassignable.Comment;

            if (!HasAdminAccess)
            {
                huvudlagerTextBox.ReadOnly = true;
                leverantörTextBox.ReadOnly = true;
                artikelbenämningTextBox.ReadOnly = true;
                leverantörArtNrTextBox.ReadOnly = true;
                kommentarTextBox.ReadOnly = true;
                assignButton.Enabled = false;
                saveButton.Enabled = false;
                deleteButton.Enabled = false;
            }
            this.titleLabel.Text = "Informationsmeny för " + currentUnassignable.Artikelbenämning;
            SetFileDirectory();
            InitializeImages();
            ApplyThemeToUserControl();
        }

        private void SetFileDirectory()
        {
            string itemName = unassignable.Artikelbenämning;
            album = directory + itemName;

            try
            {
                if (!Directory.Exists(album))
                {
                    Directory.CreateDirectory(album);
                    fileEntries = new List<string>();
                }

                else
                {
                    string[] tempArray = Directory.GetFiles(album);
                    fileEntries = tempArray.ToList<string>();
                }
            }
            catch (Exception) { }
        }


        /// <summary>
        /// Initializes the images of the product, if there are any.
        /// </summary>
        private void InitializeImages()
        {

        }

        private void OnFormResize(object sender, EventArgs e)
        {
            int triplePanelWidth = triplePanel.Width;
            int assignButtonWidth = assignButton.Width;
            int cancelButtonWidth = cancelButton.Width;
            int deleteButtonWidth = deleteButton.Width;

            int xPosAssignButton = (triplePanelWidth - assignButtonWidth) / 2;
            int yPosAssignButton = assignButton.Location.Y;
            int yPosDeleteButton = deleteButton.Location.Y;

            assignButton.Location = new Point(xPosAssignButton, yPosAssignButton);
            cancelButton.Location = new Point(xPosAssignButton - cancelButtonWidth - 50, yPosAssignButton);
            saveButton.Location = new Point(xPosAssignButton + assignButtonWidth + 50, yPosAssignButton);
            deleteButton.Location = new Point(xPosAssignButton, yPosDeleteButton);
        }




        /// <summary>
        /// Updates which buttons that should be enabled and which that should not, depending on the state of the admin access.
        /// </summary>
        public void UpdateAdminFeatures()
        {
            if (HasAdminAccess)
            {
                huvudlagerTextBox.ReadOnly = false;
                leverantörTextBox.ReadOnly = false;
                artikelbenämningTextBox.ReadOnly = false;
                leverantörArtNrTextBox.ReadOnly = false;
                kommentarTextBox.ReadOnly = false;
                assignButton.Enabled = true;
                saveButton.Enabled = true;
                deleteButton.Enabled = true;
            }
            else
            {
                huvudlagerTextBox.ReadOnly = true;
                leverantörTextBox.ReadOnly = true;
                artikelbenämningTextBox.ReadOnly = true;
                leverantörArtNrTextBox.ReadOnly = true;
                kommentarTextBox.ReadOnly = true;
                assignButton.Enabled = false;
                saveButton.Enabled = false;
                deleteButton.Enabled = false;
            }
        }

        private void OnSaveButtonClick(object sender, EventArgs e)
        {
            unassignable.Huvudlager = huvudlagerTextBox.Text;
            unassignable.Leverantör = leverantörTextBox.Text;
            unassignable.Artikelbenämning = artikelbenämningTextBox.Text;
            unassignable.LeverantörArtikelNr = leverantörArtNrTextBox.Text;
            unassignable.Comment = kommentarTextBox.Text;

            UpdateItemEventHandler?.Invoke(this, e);
        }

        private void OnCancelButtonClick(object sender, EventArgs e)
        {
            UpdateItemEventHandler?.Invoke(this, e);
        }

        private void OnDeleteButtonClick(object sender, EventArgs e)
        {
            DeleteItemEventHandler?.Invoke(this, e);
        }

        private void OnAssignButtonClick(object sender, EventArgs e)
        {
            AssignItemEventHandler?.Invoke(this, e);
        }
    }
}

