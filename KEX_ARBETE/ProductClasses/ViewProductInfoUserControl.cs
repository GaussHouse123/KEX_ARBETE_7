using KEX_ARBETE.OtherForms;
using KEX_ARBETE.ThemeClasses;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using WindowsFormsApp1.Model;
//using System.Windows.Controls;

namespace KEX_ARBETE
{
    public partial class ViewProductInfoUserControl : UserControl, IMenu
    {
        string directory;

        private List<string> fileEntries = new List<string>();
        private List<PictureBox> images = new List<PictureBox>();
        private Product product;

        private ChooseHowToAddForm chooseHowToAddForm;
        private ChooseHowToAddSpareForm chooseHowToAddSpareForm;
        private AddAccessoryForm addAccessoryForm;
        private AddSpareForm addSpareForm;


        public Boolean IsShown { get; set; }
        public Boolean WasLastShown { get; set; }
        public Boolean HasAdminAccess { get; set; }

        public Theme CurrentTheme { get; set; }


        

        public event EventHandler CancelProductInfoViewEventHandler;
        public event EventHandler UpdateProductsEventHandler;
        public event EventHandler DeleteProductEventHandler;
        public event EventHandler ShowAccessoriesViewEventHandler;
        public event EventHandler ShowSparesViewEventHandler;
        public event EventHandler ShowAccessoryInfoEventHandler;
        public event EventHandler ShowSpareInfoEventHandler;
        public event EventHandler AddExistingAccessoryEventHandler;
        public event EventHandler AddUnassignedAccessoryEventHandler;
        public event EventHandler AddExistingSpareEventHandler;
        public event EventHandler AddUnassigneSpareEventHandler;

        public ViewProductInfoUserControl()
        {
            InitializeComponent();
            this.directory = "";
            this.fileEntries = new List<string>();
            tillbehörComboBox.MouseWheel += new MouseEventHandler(OnAccessoryComboBoxMouseWheelScroll);
            reservComboBox.MouseWheel += new MouseEventHandler(OnSpareComboBoxMouseWheelScroll);

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
            DialogResult result = MessageBox.Show("Detta är informationsmenyn för ett huvudhjälpmedel. Här kan du se information kring det huvudhjälpmedel du klickat på." +
                "Du kan ändra artikelns information, lägga till tillbehör eller reservdelar och även ta bort artikeln." +
                "För att lägga till bilder lägger du in bilder i det folder med samma namn som huvudartikeln." +
                "Under fliken huvudhjälpmedlets tillbehör kan du klicka på ett tillbehör för att få se information om det tillbehöret." +
                "Om du klickar längst ned i fliken med tillbehör öppnas tillbehörmenyn. Samma sak gäller för reservdelar."
                , "Information om sidan", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void SetPicturesDirectory(string folderDirectory)
        {
            directory = folderDirectory;
        }

        /// <summary>
        /// Assigns correct values from the model to the controls on the screen.
        /// </summary>
        /// <param name="currentProduct"></param>
        /// 

        public void SetProduct(Product currentProduct)
        {
            ClearUserControl();

            this.product = currentProduct;

            titleLabel.Text = currentProduct.Artikelbenämning;
            huvudlagerTextBox.Text = currentProduct.Huvudlager;
            leverantörTextBox.Text = currentProduct.Leverantör;
            artikelbenämningTextBox.Text = currentProduct.Artikelbenämning;
            leverantörArtNrTextBox.Text = currentProduct.LeverantörArtikelNr;
            kommentarTextBox.Text = currentProduct.Comment;

            List<string> accessoryNames = new List<string>();

            for (int i = 0; i < currentProduct.GetAccessories().Count; i++)
            {
                string name = currentProduct.GetAccessoryByIndex(i).Artikelbenämning;
                if (name != "")
                    accessoryNames.Add(name);
            }

            string[] accessoryInput = accessoryNames.ToArray();

            tillbehörComboBox.Items.AddRange(accessoryInput);
            tillbehörComboBox.Items.Add("Klicka för att visa alla tillbehör");


            List<string> spareNames = new List<string>();

            for (int i = 0; i < currentProduct.GetSpares().Count; i++)
            {
                string name = currentProduct.GetSpareByIndex(i).Artikelbenämning;
                if (name != "")
                    spareNames.Add(name);
            }

            string[] spareInput = spareNames.ToArray();

            reservComboBox.Items.AddRange(spareInput);
            reservComboBox.Items.Add("Klicka för att visa alla reservdelar");


            if (!HasAdminAccess)
            {
                huvudlagerTextBox.ReadOnly = true;
                leverantörTextBox.ReadOnly = true;
                artikelbenämningTextBox.ReadOnly = true;
                leverantörArtNrTextBox.ReadOnly = true;
                kommentarTextBox.ReadOnly = true;
                tillbehörComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
                reservComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
                läggTillTillbehörButton.Enabled = false;
                läggTillReservdelButton.Enabled = false;
                deleteButton.Enabled = false;
                saveButton.Enabled = false;
            }

            this.titleLabel.Text = "Informationsmeny för " + product.Artikelbenämning;
            SetFileDirectory();
            InitializePictures();
        }

        public void ApplyThemeToUserControl()
        {
            foreach (Control control in this.Controls)
            {
                ApplyThemeClass.ApplyThemeToControl(control, CurrentTheme);
            }
        }

        /// <summary>
        /// Gets the directory of the folder that holds the images of the product. If there is no folder it creates one.
        /// </summary>
        private void SetFileDirectory()
        {
            string productName = product.Artikelbenämning;
            string productPictureDirectory = directory + "\\" + productName;

            try
            {
                if (Directory.Exists(productPictureDirectory))
                {
                    string[] tempArray = Directory.GetFiles(productPictureDirectory);
                    fileEntries = tempArray.ToList<string>();
                }              
            }
            catch (Exception) { }
        }

        /// <summary>
        /// Initializes the images of the product, if there are any.
        /// </summary>
        private void InitializePictures()
        {
            int i = 0;
            int j = 0;
            //!Directory.EnumerateFileSystemEntries(productPictureDirectory).Any()

            string productName = product.Artikelbenämning;
            string productPictureDirectory = directory + "\\" + productName;

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

        /// <summary>
        /// Updates which buttons that should be enabled and which that should not, depending on the state of the admin access.
        /// </summary>
        public void UpdateAdminFeatures()
        {
            ApplyThemeToUserControl();

            if (HasAdminAccess)
            {
                huvudlagerTextBox.ReadOnly = false;
                leverantörTextBox.ReadOnly = false;
                artikelbenämningTextBox.ReadOnly = false;
                leverantörArtNrTextBox.ReadOnly = false;
                kommentarTextBox.ReadOnly = false;
                tillbehörComboBox.DropDownStyle = ComboBoxStyle.DropDown;
                reservComboBox.DropDownStyle = ComboBoxStyle.DropDown;
                läggTillTillbehörButton.Enabled = true;
                läggTillReservdelButton.Enabled = true;
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
                tillbehörComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
                reservComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
                läggTillTillbehörButton.Enabled = false;
                läggTillReservdelButton.Enabled = false;
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
            {
                tableLayoutPanel1.Controls[0].Dispose();
            }

            tableLayoutPanel1.RowCount = 1;
            fileEntries.Clear();
            images.Clear();

            tillbehörComboBox.Items.Clear();
            tillbehörComboBox.Text = "";
            reservComboBox.Items.Clear();
            reservComboBox.Text = "";
        }

        private void UpdateAccessoryAndSpareList()
        {
            tillbehörComboBox.Items.Clear();
            tillbehörComboBox.Text = "";
            reservComboBox.Items.Clear();
            reservComboBox.Text = "";

            List<string> accessoryNames = new List<string>();

            for (int i = 0; i < product.GetAccessories().Count; i++)
            {
                string name = product.GetAccessoryByIndex(i).Artikelbenämning;
                if (name != "")
                    accessoryNames.Add(name);
            }

            string[] accessoryInput = accessoryNames.ToArray();

            tillbehörComboBox.Items.AddRange(accessoryInput);
            tillbehörComboBox.Items.Add("Klicka för att visa alla tillbehör");


            List<string> spareNames = new List<string>();

            for (int i = 0; i < product.GetSpares().Count; i++)
            {
                string name = product.GetSpareByIndex(i).Artikelbenämning;
                if (name != "")
                    spareNames.Add(name);
            }

            string[] spareInput = spareNames.ToArray();

            reservComboBox.Items.AddRange(spareInput);
            reservComboBox.Items.Add("Klicka för att visa alla reservdelar");
        }

        // ------------------- EventHandlers -------------------

        /// <summary>
        /// Reshapes some of the buttons when the form is resized so they don't look weird.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnFormResize(object sender, EventArgs e)
        {
            int panelWidth1 = removeProductPanel.Width;
            int buttonWidth1 = deleteButton.Width;

            int xPos1 = (panelWidth1 - buttonWidth1) / 2;
            int yPos1 = deleteButton.Location.Y;

            deleteButton.Location = new Point(xPos1, yPos1);

            int panelWidth2 = addAccessoriesPanel.Width;
            int buttonWidth2 = läggTillTillbehörButton.Width;

            int xPos2 = (panelWidth2 - buttonWidth2) / 2;
            int yPos2 = läggTillTillbehörButton.Location.Y;

            läggTillTillbehörButton.Location = new Point(xPos2, yPos2);
            läggTillReservdelButton.Location = new Point(xPos2, yPos2);

            int panelWidth3 = splitContainer1.Panel1.Width;
            int buttonWidth3 = cancelButton.Width;

            int xPos3 = (panelWidth3 - buttonWidth3) / 2;
            int yPos3 = cancelButton.Location.Y;

            cancelButton.Location = new Point(xPos3, yPos3);
            saveButton.Location = new Point(xPos3, yPos3);
        }

        private void LäggTillTillbehörButtonClick(object sender, EventArgs e)
        {
            this.chooseHowToAddForm = new ChooseHowToAddForm(CurrentTheme);

            chooseHowToAddForm.AddNewAccessoryEventHandler += new EventHandler(OnAddNewAccessoryOkButtonClick);
            chooseHowToAddForm.AddUnassignedAccessoryEventHandler += new EventHandler(OnAddUnassignedAccessoryOkButtonClick);
            chooseHowToAddForm.AddExistingAccessoryEventHandler += new EventHandler(OnAddExistingAccessoryOkButtonClick);

            chooseHowToAddForm.ShowDialog();
        }

        private void OnAddNewAccessoryOkButtonClick(object sender, EventArgs e)
        {
            this.addAccessoryForm = new AddAccessoryForm(product, CurrentTheme);
            addAccessoryForm.ShowDialog();
            UpdateAccessoryAndSpareList();
        }

        private void OnAddUnassignedAccessoryOkButtonClick(object sender, EventArgs e)
        {
            AddUnassignedAccessoryEventHandler?.Invoke(sender, e);
        }

        private void OnAddExistingAccessoryOkButtonClick(object sender, EventArgs e)
        {
            AddExistingAccessoryEventHandler?.Invoke(sender, e);
        }

        private void AddSpareButtonClick(object sender, EventArgs e)
        {
            this.chooseHowToAddSpareForm = new ChooseHowToAddSpareForm(CurrentTheme);

            chooseHowToAddSpareForm.AddNewSpareEventHandler += new EventHandler(OnAddNewSpareOkButtonClick);
            chooseHowToAddSpareForm.AddUnassignedSpareEventHandler += new EventHandler(OnAddUnassignedSpareOkButtonClick);
            chooseHowToAddSpareForm.AddExistingSpareEventHandler += new EventHandler(OnAddExistingSpareOkButtonClick);

            chooseHowToAddSpareForm.ShowDialog();
        }

        private void OnAddNewSpareOkButtonClick(object sender, EventArgs e)
        {
            this.addSpareForm = new AddSpareForm(product, CurrentTheme);
            addSpareForm.ShowDialog();
            UpdateAccessoryAndSpareList();
        }

        private void OnAddUnassignedSpareOkButtonClick(object sender, EventArgs e)
        {
            AddUnassigneSpareEventHandler?.Invoke(sender, e);
        }

        private void OnAddExistingSpareOkButtonClick(object sender, EventArgs e)
        {
            AddExistingSpareEventHandler?.Invoke(sender, e);
        }

        /// <summary>
        /// Sets the products values to those currently shown in the textboxes, and then invokes an event to MainForm to update the view.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnSaveProductButtonClick(object sender, EventArgs e)
        {
            //Saker som måste fixas senare:
            //Om man avslutar produktnamnet med ett mellanslag ska man få ett error.
            //Om man ändrar namnet på en produkt till samma namn som en existerande produkt ska man få ett error.
            //Om man skriver in olagliga symboler i produktnamnet ska man få ett error.

            string oldProductName = product.Artikelbenämning;

            product.Artikelbenämning = artikelbenämningTextBox.Text;
            product.Leverantör = leverantörTextBox.Text;
            product.LeverantörArtikelNr = leverantörArtNrTextBox.Text;
            product.Huvudlager = huvudlagerTextBox.Text;
            product.Comment = kommentarTextBox.Text;

            string newProductName = product.Artikelbenämning;
            string oldFolderDirectory = directory + "\\" + oldProductName;
            string newFolderDirectory = directory + "\\" + newProductName;

            if (Directory.Exists(oldFolderDirectory) && oldProductName != newProductName)
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
            UpdateProductsEventHandler?.Invoke(this, e);
        }

        private void OnCancelButtonClick(object sender, EventArgs e)
        {
            UpdateProductsEventHandler?.Invoke(this, e);
        }

        private void OnDeleteButtonClick(object sender, EventArgs e)
        {
            string choosenTypeOldName = product.Artikelbenämning;
            string oldFolderDirectory = directory + "\\" + choosenTypeOldName;

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
            DeleteProductEventHandler?.Invoke(this, e);
        }

        /// <summary>
        /// Invokes an event to MainForm that handles the event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnViewAccessoriesComboBoxClick(object sender, EventArgs e)
        {
            if (tillbehörComboBox.SelectedIndex == product.GetAccessories().Count)
                ShowAccessoriesViewEventHandler?.Invoke(this, e);
            else
                ShowAccessoryInfoEventHandler?.Invoke(sender, e);
        }

        /// <summary>
        /// Invokes an event to MainForm that handles the event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnViewSparesComboBoxClick(object sender, EventArgs e)
        {
            if (reservComboBox.SelectedIndex == product.GetSpares().Count)
                ShowSparesViewEventHandler?.Invoke(this, e);
            else
                ShowSpareInfoEventHandler?.Invoke(sender, e);
        }

        /// <summary>
        /// Stops the scrolling of the combo box.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnAccessoryComboBoxMouseWheelScroll(object sender, EventArgs e)            ///OBS! Piltangenter.
        {
            ((HandledMouseEventArgs)e).Handled = true;
        }

        /// <summary>
        /// Stops the scrolling of the combo box.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnSpareComboBoxMouseWheelScroll(object sender, EventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;
        }

        /// <summary>
        /// Invokes an event to MainForm so that the info view can be canceled.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnCancelProductClick(object sender, EventArgs e)
        {
            UpdateProductsEventHandler?.Invoke(this, e);
        }
    }
}