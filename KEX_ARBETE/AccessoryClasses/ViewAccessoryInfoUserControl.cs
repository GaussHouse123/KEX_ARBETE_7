using KEX_ARBETE.ThemeClasses;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using WindowsFormsApp1.Model;

namespace KEX_ARBETE
{
    /// <summary>
    /// The UserControl that shows the information of a specific accessory.
    /// </summary>
    public partial class ViewAccessoryInfoUserControl : UserControl, IMenu
    {
        private string directory;

        private Accessory accessory;

        private List<string> fileEntries = new List<string>();
        private List<PictureBox> images = new List<PictureBox>();

        public event EventHandler UpdateAccessoriesEventHandler;
        public event EventHandler DeleteAccessoryEventHandler;

        // ------------------------- Constructor -------------------------

        /// <summary>
        /// Constructor for the ViewAccessoryInfoUserControl
        /// </summary>
        public ViewAccessoryInfoUserControl()
        {
            InitializeComponent();
            this.directory = "";
        }

        // ------------------------- Implemented from IMenu -------------------------

        public Boolean IsShown { get; set; }

        public Boolean WasLastShown { get; set; }

        public Boolean HasAdminAccess { get; set; }

        public Theme CurrentTheme { get; set; }

        public void ShowUserControl()
        {
            this.Show();
        }

        public void HideUserControl()
        {
            this.Hide();
        }

        public void ShowPageInfo()
        {
            DialogResult result = MessageBox.Show("Detta är informationssidan för ett tillbehör. Här kan du se information kring det tillbehör du valt." +
                "Du kan ändra tillbehörets information eller ta bort tillbehöret. Klicka spara för att spara eventuella ändringar." +
                "Bilder läggs till på samma sätt som för huvudhjälpmedel.", "Information om sidan",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        public void ApplyThemeToUserControl()
        {
            foreach (Control control in this.Controls)
            {
                ApplyThemeClass.ApplyThemeToControl(control, CurrentTheme);
            }
        }

        // ------------------------- Methods -------------------------

        /// <summary>
        /// Assigns correct information from the model to the controls.
        /// </summary>
        /// <param name="currentProduct">The accessory that the user wants to see information about.</param>
        public void SetAccessory(Accessory currentAccessory)
        {
            ClearUserControl();

            this.accessory = currentAccessory;

            titleLabel.Text = accessory.Artikelbenämning;
            huvudlagerTextBox.Text = accessory.Huvudlager;
            leverantörTextBox.Text = accessory.Leverantör;
            artikelbenämningTextBox.Text = accessory.Artikelbenämning;
            leverantörArtNrTextBox.Text = accessory.LeverantörArtikelNr;
            kommentarTextBox.Text = accessory.Comment;

            if (!HasAdminAccess)
            {
                huvudlagerTextBox.ReadOnly = true;
                leverantörTextBox.ReadOnly = true;
                artikelbenämningTextBox.ReadOnly = true;
                leverantörArtNrTextBox.ReadOnly = true;
                kommentarTextBox.ReadOnly = true;
                deleteButton.Enabled = false;
                saveButton.Enabled = false;
            }
            this.titleLabel.Text = "Informationsmeny för " + accessory.Artikelbenämning;
            SetFileDirectory();
            InitializeImages();
            ApplyThemeToUserControl();
        }

        /// <summary>
        /// Sets the path to the directory that contains the images.
        /// </summary>
        /// <param name="folderDirectory">The directory to the images.</param>
        public void SetPicturesDirectory(string folderDirectory)
        {
            directory = folderDirectory;
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
                deleteButton.Enabled = true;
                saveButton.Enabled = true;
            }
            else
            {
                huvudlagerTextBox.ReadOnly = true;
                leverantörTextBox.ReadOnly = true;
                artikelbenämningTextBox.ReadOnly = true;
                leverantörArtNrTextBox.ReadOnly = true;
                kommentarTextBox.ReadOnly = true;
                deleteButton.Enabled = false;
                saveButton.Enabled = false;
            }
        }

        /// <summary>
        /// Clears the controls and dispose of all images.
        /// </summary>
        public void ClearUserControl()
        {
            while (tableLayoutPanel1.Controls.Count > 0)
            {
                tableLayoutPanel1.Controls[0].Dispose();
            }

            tableLayoutPanel1.RowCount = 1;

            for (int i = 0; i < images.Count; i++)
            {
                images[i].Dispose();
            }

            tableLayoutPanel1.RowCount = 1;
            fileEntries.Clear();
            images.Clear();
        }

        /// <summary>
        /// Gets the directory of the folder that holds the images of the accessory. If there is no folder it creates one.
        /// </summary>
        private void SetFileDirectory()
        {
            string accessoryName = accessory.Artikelbenämning;
            string accessoryPictureDirectory = directory + "\\" + accessoryName;

            try
            {
                if (Directory.Exists(accessoryPictureDirectory))
                {
                    string[] tempArray = Directory.GetFiles(accessoryPictureDirectory);
                    fileEntries = tempArray.ToList<string>();
                }
            }
            catch (Exception) { }
        }

        /// <summary>
        /// Initializes the images of the accessory, if there are any.
        /// </summary>
        private void InitializeImages()
        {
            int i = 0;
            int j = 0;

            string accessoryName = accessory.Artikelbenämning;
            string accessoryPictureDirectory = directory + "\\" + accessoryName;

            if (fileEntries.Count == 0)
                bilderLabel.Text = "Inga tillagda bilder";
            else
            {
                bilderLabel.Text = "Bilder:";

                while (i < fileEntries.Count)
                {
                    PictureBox newPictureBox = new PictureBox();
                    newPictureBox.SizeMode = PictureBoxSizeMode.Zoom;

                    string imageLocation = fileEntries[i];

                    if (newPictureBox.Image != null)
                        newPictureBox.Image.Dispose();
                    else
                        newPictureBox.Image = null;

                    Image img;

                    using (var bmpTemp = new Bitmap(imageLocation))
                    {
                        img = new Bitmap(bmpTemp);
                    }

                    newPictureBox.Image = img;

                    if (((i % 2) == 0) && i != 0)
                    {
                        tableLayoutPanel1.RowCount = tableLayoutPanel1.RowCount + 1;
                        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 300F));
                        tableLayoutPanel1.Controls.Add(newPictureBox, 0, tableLayoutPanel1.RowCount - 1);
                        newPictureBox.Dock = DockStyle.Fill;
                        j = 1;
                    }
                    else
                    {
                        tableLayoutPanel1.Controls.Add(newPictureBox, j, tableLayoutPanel1.RowCount - 1);
                        newPictureBox.Dock = DockStyle.Fill;
                        j++;
                    }

                    images.Add(newPictureBox);
                    i++;
                }
            }
        }

        // ------------------------- EventHandlers -------------------------

        /// <summary>
        /// Saves the new information of the accessory. If the accessory changes Artikelbenämning, the folder containing the images will change name correspondingly.
        /// When done it returns to the previosuly shown UserControl.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnSaveAccessoryButtonClick(object sender, EventArgs e)
        {
            string oldAccessoryName = accessory.Artikelbenämning;

            accessory.Artikelbenämning = artikelbenämningTextBox.Text;
            accessory.Leverantör = leverantörTextBox.Text;
            accessory.LeverantörArtikelNr = leverantörArtNrTextBox.Text;
            accessory.Huvudlager = huvudlagerTextBox.Text;
            accessory.Comment = kommentarTextBox.Text;

            string newAccessoryName = accessory.Artikelbenämning;
            string oldFolderDirectory = directory + "\\" + oldAccessoryName;
            string newFolderDirectory = directory + "\\" + newAccessoryName;

            if (Directory.Exists(oldFolderDirectory) && oldAccessoryName != newAccessoryName)
            {
                string[] tempArray = Directory.GetFiles(oldFolderDirectory);
                fileEntries = tempArray.ToList<string>();

                try
                {
                    if (!Directory.Exists(newFolderDirectory))
                        Directory.CreateDirectory(newFolderDirectory);
                }
                catch (Exception) { }

                int i = 1;

                if (fileEntries.Count != 0)
                {
                    foreach (string fileName in fileEntries)
                    {
                        string oldFileName = fileName;
                        string newFileName = newFolderDirectory + "\\image" + i + ".jpg";

                        File.Move(oldFileName, newFileName);
                        i++;
                    }
                }
                Directory.Delete(oldFolderDirectory);
            }
            ClearUserControl();
            UpdateAccessoriesEventHandler?.Invoke(this, e);
        }

        /// <summary>
        /// Changes the position of the deleteButton, cancelButton and saveButton to better fit the newly resized form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnFormResize(object sender, EventArgs e)
        {
            int distanceBetweenDeleteButtonAndSaveButton = 50;

            int deletePanelWidth = removeProductPanel.Width;
            int deleteButtonWidth = deleteButton.Width;

            int xPosDeleteButton = (deletePanelWidth - deleteButtonWidth) / 2;
            int yPosDeleteButton = deleteButton.Location.Y;

            deleteButton.Location = new Point(xPosDeleteButton, yPosDeleteButton);

            int cancelButtonWidth = cancelButton.Width;

            int xPosCancelButton = xPosDeleteButton - cancelButtonWidth;
            int yPosCancelButton = cancelButton.Location.Y;

            cancelButton.Location = new Point(xPosCancelButton - distanceBetweenDeleteButtonAndSaveButton, yPosCancelButton);

            int saveButtonWidth = cancelButtonWidth;

            int xPosSaveButton = deleteButtonWidth / 2;
            int yPosSaveButton = yPosCancelButton;

            saveButton.Location = new Point(xPosSaveButton + distanceBetweenDeleteButtonAndSaveButton, yPosSaveButton);
        }

        /// <summary>
        /// Deletes the current accessory. If it has images, every image is removed and the folder deleted.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnDeleteButtonClick(object sender, EventArgs e)
        {
            string choosenAccessoryOldName = accessory.Artikelbenämning;
            string oldFolderDirectory = directory + "\\" + choosenAccessoryOldName;

            if (Directory.Exists(oldFolderDirectory))
            {
                string[] tempArray = Directory.GetFiles(oldFolderDirectory);
                fileEntries = tempArray.ToList<string>();

                if (fileEntries.Count != 0)
                {
                    foreach (string fileName in fileEntries)
                    {
                        File.Delete(fileName);
                    }
                }
                Directory.Delete(oldFolderDirectory);
            }
            DeleteAccessoryEventHandler?.Invoke(this, e);
        }

        private void OnCancelButtonClick(object sender, EventArgs e)
        {
            UpdateAccessoriesEventHandler?.Invoke(this, e);
        }
    }
}
