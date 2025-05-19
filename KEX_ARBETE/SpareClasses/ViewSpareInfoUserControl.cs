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
    public partial class ViewSpareInfoUserControl : UserControl, IMenu
    {
        private string directory;

        private List<string> fileEntries = new List<string>();
        private List<PictureBox> images = new List<PictureBox>();
        private Spare spare;

        public Boolean IsShown { get; set; }
        public Boolean WasLastShown { get; set; }
        public Boolean HasAdminAccess { get; set; }

        public Theme CurrentTheme { get; set; }

        public event EventHandler UpdateSparesEventHandler;
        public event EventHandler DeleteSpareEventHandler;

        public ViewSpareInfoUserControl()
        {
            InitializeComponent();
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

        /// <summary>
        /// Shows how to navigate the current page.
        /// </summary>
        public void ShowPageInfo()
        {
            DialogResult result = MessageBox.Show("Detta är informationssidan för en reservdel. Här kan du se information kring den reservdel du valt." +
                "Du kan ändra reservdelens information eller ta bort reservdelen. Klicka spara för att spara eventuella ändringar." +
                "Bilder läggs till på samma sätt som för huvudhjälpmedel.", "Information om sidan",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void SetPicturesDirectory(string folderDirectory)
        {
            directory = folderDirectory;

        }

        public void ApplyThemeToUserControl()
        {
            foreach (Control control in this.Controls)
            {
                ApplyThemeClass.ApplyThemeToControl(control, CurrentTheme);
            }
        }

        /// <summary>
        /// Assigns correct values from the model to the controls on the screen.
        /// </summary>
        /// <param name="currentProduct"></param>
        public void SetSpare(Spare currentSpare)
        {
            ClearUserControl();

            this.spare = currentSpare;

            titleLabel.Text = spare.Artikelbenämning;
            huvudlagerTextBox.Text = spare.Huvudlager;
            leverantörTextBox.Text = spare.Leverantör;
            artikelbenämningTextBox.Text = spare.Artikelbenämning;
            leverantörArtNrTextBox.Text = spare.LeverantörArtikelNr;
            kommentarTextBox.Text = spare.Comment;

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
            this.titleLabel.Text = "Informationsmeny för " + spare.Artikelbenämning;

            SetFileDirectory();
            InitializeImages();
            ApplyThemeToUserControl();
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
        /// Cleares the user control from previous data.
        /// </summary>
        public void ClearUserControl()
        {
            while (tableLayoutPanel1.Controls.Count > 0)
                tableLayoutPanel1.Controls[0].Dispose();
            tableLayoutPanel1.RowCount = 1;

            tableLayoutPanel1.RowCount = 1;
            fileEntries.Clear();
            images.Clear();
        }

        /// <summary>
        /// Gets the directory of the folder that holds the images of the spare. If there is no folder it creates one.
        /// </summary>
        private void SetFileDirectory()
        {
            string spareName = spare.Artikelbenämning;
            string sparePictureDirectory = directory + "\\" + spareName;

            try
            {
                if (Directory.Exists(sparePictureDirectory))
                {
                    string[] tempArray = Directory.GetFiles(sparePictureDirectory);
                    fileEntries = tempArray.ToList<string>();
                }
            }
            catch (Exception) { }
        }

        /// <summary>
        /// Initializes the images of the spare, if there are any.
        /// </summary>
        private void InitializeImages()
        {
            int i = 0;
            int j = 0;

            string spareName = spare.Artikelbenämning;
            string sparePictureDirectory = directory + "\\" + spareName;

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
                    Console.WriteLine(imageLocation);

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

        // EventHandlers

        /// <summary>
        /// Saves the new information of the spare. If the spare changes Artikelbenämning, the folder containing the images will change name correspondingly.
        /// When done it returns to the previosuly shown UserControl.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnSaveSpareButtonClick(object sender, EventArgs e)
        {
            string oldSpareName = spare.Artikelbenämning;

            spare.Artikelbenämning = artikelbenämningTextBox.Text;
            spare.Leverantör = leverantörTextBox.Text;
            spare.LeverantörArtikelNr = leverantörArtNrTextBox.Text;
            spare.Huvudlager = huvudlagerTextBox.Text;
            spare.Comment = kommentarTextBox.Text;

            string newSpareName = spare.Artikelbenämning;
            string oldFolderDirectory = directory + "\\" + oldSpareName;
            string newFolderDirectory = directory + "\\" + newSpareName;

            if (Directory.Exists(oldFolderDirectory) && oldSpareName != newSpareName)
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
                        Console.WriteLine(oldFileName);
                        Console.WriteLine(newFileName);

                        File.Move(oldFileName, newFileName);
                        i++;
                    }
                }
                Directory.Delete(oldFolderDirectory);
            }
            ClearUserControl();
            UpdateSparesEventHandler?.Invoke(this, e);
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

        private void OnCancelButtonClick(object sender, EventArgs e)
        {
            UpdateSparesEventHandler?.Invoke(this, e);
        }

        private void OnDeleteButtonClick(object sender, EventArgs e)
        {
            string choosenSpareOldName = spare.Artikelbenämning;
            string oldFolderDirectory = directory + "\\" + choosenSpareOldName;

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
            DeleteSpareEventHandler?.Invoke(this, e);
        }
    }
}
